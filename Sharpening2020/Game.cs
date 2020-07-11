using System;
using System.Linq;
using System.Collections.Generic;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Cards.ContinuousEffects;
using Sharpening2020.Cards.Triggers;
using Sharpening2020.Combat;
using Sharpening2020.Commands;
using Sharpening2020.Input;
using Sharpening2020.InputBridges;
using Sharpening2020.Phases;
using Sharpening2020.Players;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace Sharpening2020
{
    public enum DebugMode { CardViews, Commands, ContinuousEffects, InputStates, Mana, Phases, Triggers  }
    public class Game : ICloneable
    {
        public Game() { }

        public static Game Construct()
        {
            Game ret = new Game();
            ret.MyExecutor.MyGame = ret;
            ret.MyContinuousEffects.MyGame = ret;
            ret.MyPhaseHandler.MyGame = ret;
            ret.MyTriggerHandler.MyGame = ret;
            ret.MyCombatHandler.MyGame = ret;

            return ret;
        }

        public Executor MyExecutor = new Executor();
  
        public Int32 NextGameObjectID = 0;

        public Int32 NextTimeStamp = 0;

        public List<GameObject> GameObjects = new List<GameObject>();

        public readonly Dictionary<Int32, InputHandler> InputHandlers = new Dictionary<Int32, InputHandler>();

        private Int32 activePlayerIndex = 0;

        public List<DebugMode> DebugFlag = new List<DebugMode>();

        public Int32 PlayerCount = 0;

        public Int32 PlayersPassedInSuccession = 0;

        public Int32 ActivePlayerIndex
        {
            get
            {
                return activePlayerIndex;
            }

            set
            {
                activePlayerIndex = value;
                Int32 PlayerCount = GetPlayers().Count();
                while(activePlayerIndex >= PlayerCount)
                {
                    activePlayerIndex -= PlayerCount;
                }

                while(activePlayerIndex < 0)
                {
                    activePlayerIndex += PlayerCount;
                }               
            }

        }

        public Player ActivePlayer
        {
            get { return GetPlayers().ElementAt(activePlayerIndex); }
        }

        private Int32 playerWithPriorityIndex = 0;

        public Int32 PlayerWithPriorityIndex
        {
            get
            {
                return playerWithPriorityIndex;
            }

            set
            {
                Boolean indexGrew = playerWithPriorityIndex < value;

                playerWithPriorityIndex = value;

                while (playerWithPriorityIndex >= PlayerCount)
                {
                    playerWithPriorityIndex -= PlayerCount;
                }

                while (playerWithPriorityIndex < 0)
                {
                    playerWithPriorityIndex += PlayerCount;
                }

                if(indexGrew)
                {
                    RunStateBasedActions();
                    MyContinuousEffects.RunContinuousEffects();
                }

                if (PlayersPassedInSuccession == PlayerCount)
                {
                    PlayersPassedInSuccession = 0;
                    if (SpellStack.Count == 0)
                    {
                        MyExecutor.Do(new CommandAdvancePhase());
                    }
                    else
                    {
                        MyExecutor.Do(new CommandResolveTopOfStack());
                    }
                }

                if(MyTriggerHandler.WaitingTriggers.Count > 0)
                {
                    MyTriggerHandler.RunTriggers();
                }
                else
                {
                    foreach (Player p in GetPlayers())
                    {
                        if (p.ID != PlayerWithPriority.ID)
                        {
                            MyExecutor.Do(new CommandClearInputList(p.ID));
                        }
                    }
                    MyExecutor.Do(new CommandGroup(new CommandSetHavePriorityState(PlayerWithPriority.ID),
                        new CommandEnterInputState()));
                }
            }
        }

        public Player PlayerWithPriority
        {
            get { return GetPlayers().ElementAt(playerWithPriorityIndex); }
        }

        public ContinuousEffectHandler MyContinuousEffects = new ContinuousEffectHandler();

        public PhaseHandler MyPhaseHandler = new PhaseHandler();

        public TriggerHandler MyTriggerHandler = new TriggerHandler();

        public CombatHandler MyCombatHandler = new CombatHandler();

        public Stack<LazyGameObject<StackInstance>> SpellStack = new Stack<LazyGameObject<StackInstance>>();

        public Zone StackZone = new Zone(ZoneType.Stack);

        public void RegisterGameObject(GameObject go)
        {
            go.ID = NextGameObjectID++;
            GameObjects.Add(go);
        }

        public ZoneType GetZoneTypeOf(Card c)
        {
            return GetZoneOf(c.ID).MyType;
        }

        public ZoneType GetZoneTypeOf(LazyGameObject<Card> c)
        {
            return GetZoneOf(c.ID).MyType;
        }

        public ZoneType GetZoneTypeOf(Int32 ID)
        {
            return GetZoneOf(ID).MyType;
        }

        public Zone GetZoneOf(Card c)
        {
            return GetZoneOf(c.ID);
        }

        public Zone GetZoneOf(LazyGameObject<Card> c)
        {
            return GetZoneOf(c.ID);
        }

        public Zone GetZoneOf(Int32 ID)
        {
            if (StackZone.Contents.Count(x => { return x.ID == ID; }) > 0)
                return StackZone;

            foreach (Player p in GetPlayers())
            {
                foreach (Zone z in p.MyZones.Values)
                {
                    if (z.Contents.Count(x => { return x.ID == ID; }) > 0)
                    {
                        return z;
                    }
                }
            }

            throw new Exception("Card " + ((Card)GetGameObjectByID(ID)).ToString() + " outside all zones!");
        }

        public IEnumerable<Player> GetPlayers()
        {
            return GameObjects.Where(x => { return x is Player; }).Cast<Player>();
        }
        
        public IEnumerable<Card> GetCards()
        {
            return GameObjects.Where(x => { return x is Card; }).Cast<Card>();
        }

        public IEnumerable<Card> GetCards(ZoneType zt)
        {
            return GameObjects.Where(x => { if (x is Card) { return GetZoneTypeOf((Card)x) == zt; } return false; }).Cast<Card>();
        }

        public IEnumerable<Card> GetCards(ZoneType zt, Player controller)
        {
            return GameObjects.Where(x => { if (x is Card) { return GetZoneTypeOf((Card)x) == zt && ((Card)x).Controller.Value(this).Equals(controller); } return false; }).Cast<Card>();
        }

        public IEnumerable<Activatable> GetActivatables()
        {
            IEnumerable<Activatable> res = new List<Activatable>();
            foreach(Card c in GetCards())
            {
                res = res.Concat(c.CurrentCharacteristics.Activatables);
            }

            return res;
        }

        public IEnumerable<Ability> GetAbilities()
        {
            IEnumerable<Ability> res = new List<Ability>();
            foreach(Card c in GetCards())
            {
                res.Concat(c.CurrentCharacteristics.Activatables.Where(x => { return x is Ability; }));
            }

            return res;
        }

        public IEnumerable<Spell> GetSpells()
        {
            IEnumerable<Spell> res = new List<Spell>();
            foreach (Card c in GetCards())
            {
                res.Concat(c.CurrentCharacteristics.Activatables.Where(x => { return x is Spell; }));
            }

            return res;
        }

        public GameObject GetGameObjectByID(Int32 GOID)
        {
            IEnumerable<GameObject> res = GameObjects.Where(x => { return x.ID == GOID; });
            if(res.Count() > 0)
            {
                return res.First();
            }
            else
            {
                return null;
            }
        }

        public void RunStateBasedActions()
        {
            IEnumerable<Card> crds;
            //704.5a.If a player has 0 or less life, that player loses the game.
            //704.5b.If a player attempted to draw a card from a library with no cards in it since the last time state-based actions were checked, that player loses the game.
            //704.5c.If a player has ten or more poison counters, that player loses the game.Ignore this rule in Two - Headed Giant games; see rule 704.5u instead.
            //704.5d.If a token is in a zone other than the battlefield, it ceases to exist.
            crds = GetCards().Where(x => { return x.IsToken && GetZoneTypeOf((Card)x) != ZoneType.Battlefield; });
            foreach(Card c in crds)
            {
                MyExecutor.Do(new CommandRemoveGameObjectFromGame(c.ID));
            }

            //704.5e.If a copy of a spell is in a zone other than the stack, it ceases to exist.If a copy of a card is in any zone other than the stack or the battlefield, it ceases to exist.
            //704.5f.If a creature has toughness 0 or less, it's put into its owner's graveyard. Regeneration can't replace this event.
            crds = GetCards(ZoneType.Battlefield).Where(x => { return x.CurrentCharacteristics.CardTypes.Contains("Creature") && x.CurrentCharacteristics.Toughness <= 0; });
            foreach(Card c in crds)
            {
                MyExecutor.Do(new CommandMoveCard(c.ID, ZoneType.Graveyard));
            }

            //704.5g.If a creature has toughness greater than 0, it has damage marked on it, and the total damage marked on it is greater than or equal to its toughness, that creature has been dealt lethal damage and is destroyed.Regeneration can replace this event.
            crds = GetCards(ZoneType.Battlefield).Where(x => { return x.CurrentCharacteristics.CardTypes.Contains("Creature") && x.AssignedDamage >= x.CurrentCharacteristics.Toughness; });
            foreach (Card c in crds)
            {
                MyExecutor.Do(new CommandDestroy(c.ID));
            }

            //704.5h.If a creature has toughness greater than 0, and it's been dealt damage by a source with deathtouch since the last time state-based actions were checked, that creature is destroyed. Regeneration can replace this event.
            //704.5i.If a planeswalker has loyalty 0, it's put into its owner's graveyard.
            crds = GetCards(ZoneType.Battlefield).Where(x => { return x.CurrentCharacteristics.CardTypes.Contains("Planeswalker") && x.GetCounterAmount(this, CounterType.Loyalty) == 0; });
            foreach (Card c in crds)
            {
                MyExecutor.Do(new CommandMoveCard(c.ID, ZoneType.Graveyard));
            }
            //704.5j.If a player controls two or more legendary permanents with the same name, that player chooses one of them, and the rest are put into their owners' graveyards. This is called the "legend rule."
            //704.5k.If two or more permanents have the supertype world, all except the one that has had the world supertype for the shortest amount of time are put into their owners' graveyards. In the event of a tie for the shortest amount of time, all are put into their owners' graveyards. This is called the "world rule."
            //704.5m.If an Aura is attached to an illegal object or player, or is not attached to an object or player, that Aura is put into its owner's graveyard.
            //704.5n.If an Equipment or Fortification is attached to an illegal permanent or to a player, it becomes unattached from that permanent or player.It remains on the battlefield.
            //704.5p.If a creature is attached to an object or player, it becomes unattached and remains on the battlefield. Similarly, if a permanent that's neither an Aura, an Equipment, nor a Fortification is attached to an object or player, it becomes unattached and remains on the battlefield.
            //704.5q.If a permanent has both a +1/+1 counter and a -1/-1 counter on it, N +1/+1 and N -1/-1 counters are removed from it, where N is the smaller of the number of +1/+1 and -1/-1 counters on it.
            crds = GetCards(ZoneType.Battlefield).Where(x => { return x.GetCounterAmount(this, CounterType.P1P1) > 0 && x.GetCounterAmount(this, CounterType.M1M1) > 0; });
            foreach(Card c in crds)
            {
                Int32 ToRemove = Math.Min(c.GetCounterAmount(this, CounterType.P1P1), c.GetCounterAmount(this, CounterType.M1M1));

                MyExecutor.Do(new CommandRemoveCounter(c.ID, CounterType.P1P1, ToRemove));
                MyExecutor.Do(new CommandRemoveCounter(c.ID, CounterType.M1M1, ToRemove));
            }
            //704.5r.If a permanent with an ability that says it can't have more than N counters of a certain kind on it has more than N counters of that kind on it, all but N of those counters are removed from it.
            //704.5s.If the number of lore counters on a Saga permanent is greater than or equal to its final chapter number and it isn't the source of a chapter ability that has triggered but not yet left the stack, that Saga's controller sacrifices it. See rule 714, "Saga Cards."
            //704.5t.In a Two-Headed Giant game, if a team has 0 or less life, that team loses the game.See rule 810, "Two-Headed Giant Variant."
            //704.5u.In a Two-Headed Giant game, if a team has fifteen or more poison counters, that team loses the game.See rule 810, "Two-Headed Giant Variant."
            //704.5v.In a Commander game, a player that's been dealt 21 or more combat damage by the same commander over the course of the game loses the game. See rule 903, "Commander."
            //704.5w.In an Archenemy game, if a non-ongoing scheme card is face up in the command zone, and no triggered abilities of any scheme are on the stack or waiting to be put on the stack, that scheme card is turned face down and put on the bottom of its owner's scheme deck. See rule 904, "Archenemy."
            //704.5x.In a Planechase game, if a phenomenon card is face up in the command zone, and it isn't the source of a triggered ability that has triggered but not yet left the stack, the planar controller planeswalks. See rule 901, "Planechase."
        }

        public object Clone()
        {
            Game ret = new Game();
            ret.MyContinuousEffects = (ContinuousEffectHandler)this.MyContinuousEffects.Clone();
            ret.MyPhaseHandler = (PhaseHandler)this.MyPhaseHandler.Clone();
            ret.NextGameObjectID = this.NextGameObjectID;
            ret.StackZone = (Zone)this.StackZone.Clone();
            
            foreach(GameObject go in GameObjects)
            {
                GameObject goClone = (GameObject)go.Clone();
                goClone.MyGame = ret;
                ret.GameObjects.Add(goClone);
            }

            ret.MyContinuousEffects.MyGame = ret;
            ret.MyPhaseHandler.MyGame = ret;
            ret.MyExecutor.MyGame = ret;

            foreach (InputHandler ih in ret.InputHandlers.Values)
            {
                ih.MyGame = ret;
                ih.UpdateGameReferences(ret);
            }

            return ret;
        }

        public void AssociateInputBridge(InputBridge ib, Int32 PlayerID)
        {
            if(InputHandlers.ContainsKey(PlayerID))
            {
                InputHandlers[PlayerID].Bridge = ib;
            }
            else
            {
                InputHandlers.Add(PlayerID, new InputHandler(this, new LazyGameObject<Player>(PlayerID), ib));
            }
        }

        public void InitGame(params KeyValuePair<InputBridge,List<String>>[] test)
        {
            MyTriggerHandler.SuspendTriggers = true;
            MyExecutor.SuspendViewUpdates = true;
            foreach(KeyValuePair<InputBridge,List<String>> kvp in test)
            {
                CommandCreatePlayer ccp = new CommandCreatePlayer();
                MyExecutor.Do(ccp);
                Player newPlayer = ccp.CreatedPlayer;

                InputHandlers.Add(newPlayer.ID, new InputHandler(this, new LazyGameObject<Player>(newPlayer), kvp.Key));
            }

            PlayerCount = GetPlayers().Count();

            Int32 i = 0;

            foreach (KeyValuePair<InputBridge, List<String>> kvp in test)
            {
                foreach (String s in kvp.Value)
                {
                    MyExecutor.Do(new CommandCreateCard(s, i));
                }

                i++;
                //MyExecutor.Do(new CommandShuffleLibrary(i++, (Int32)DateTime.Now.Ticks));
            }

            foreach (Player p in GetPlayers())
            {
                for (int j = 0; j < 7; j++)
                {
                    MyExecutor.Do(new CommandDrawCard(p.ID));
                }
            }

            MyTriggerHandler.SuspendTriggers = false;
            MyExecutor.SuspendViewUpdates = false;

            UpdateAllViews();
            
            MyExecutor.Do(new CommandGroup(new CommandSetHavePriorityState(ActivePlayer.ID),
                new CommandEnterInputState()));
        }

        public void UpdateAllViews()
        {
            foreach (Player p in GetPlayers())
            {
                foreach (InputHandler ih in InputHandlers.Values)
                {
                    ih.Bridge.UpdatePlayerView((PlayerView)p.GetView(this, p));
                }
                foreach (Zone z in p.MyZones.Values)
                {
                    foreach (InputHandler ih in InputHandlers.Values)
                    {
                        List<CardView> viewList = new List<CardView>();
                        foreach (LazyGameObject<Card> lc in z.Contents)
                        {
                            Card c = lc.Value(this);
                            CardView cv = c.GetView(this, ih.AssociatedPlayer.Value(this)) as CardView;

                            viewList.Add(cv);
                        }
                        ih.Bridge.UpdateZoneView(z.MyType, p.ID, viewList);
                    }
                }
            }

            UpdatePhase();
        }

        public void UpdateView(ViewObject view)
        {
            foreach (InputHandler ih in InputHandlers.Values)
            {
                if (view is CardView)
                    ih.Bridge.UpdateCardView((CardView)view);
                else if (view is PlayerView)
                    ih.Bridge.UpdatePlayerView((PlayerView)view);
            }
        }

        public void UpdateZoneView(ZoneType zt, Int32 PlayerID)
        {
            Player p = (Player)GetGameObjectByID(PlayerID);
            List<CardView> list = GetCards(zt, (Player)GetGameObjectByID(PlayerID)).Select<Card,CardView>(x => { return (CardView)x.GetView(this, p); }).ToList();
            foreach(InputHandler ih in InputHandlers.Values)
            {
                ih.Bridge.UpdateZoneView(zt, PlayerID, list);
            }
        }

        public void PlayActivatable(Activatable act, Player Activator, AbilityType Mode, StackInstance si = null)
        {
            PlayersPassedInSuccession = 0;
            act.Activator = Activator;
            if(act is SpecialAction)
            {
                act.Resolve(this, si);
                return;
            }
            if(act is Ability)
            {
                if(((Ability)act).IsManaAbility)
                {
                    act.Resolve(this, si);
                    return;
                }
            }

            MyExecutor.Do(new CommandPutOnStack(act.Host.ID, act.Host.Value(this).CurrentCharacteristics.IndexOfAbility(act, Mode),Mode));
        }

        public List<StackInstanceView> GetStackView()
        {
            return SpellStack.Select(x => { return (StackInstanceView)x.Value(this).GetView(this,null); }).ToList();
        }

        public void DebugAlert(DebugMode flag, String msg)
        {
            if(!DebugFlag.Contains(flag))
            {
                return;
            }
            foreach(InputHandler ih in InputHandlers.Values)
            {
                ih.Bridge.DebugAlert(flag.ToString() + ": " + msg);
            }
        }

        public void UpdatePhase()
        {
            foreach (InputHandler ih in InputHandlers.Values)
            {
                ih.Bridge.UpdatePhase(MyPhaseHandler.CurrentPhase.MyType);
            }
        }

        public void UpdateStack()
        {
            foreach (InputHandler ih in InputHandlers.Values)
            {
                ih.Bridge.UpdateStackView(GetStackView());
            }
        }

        public void EnterAllInputStates()
        {
            if(MyExecutor.IsLoading)
            {
                return;
            }

            foreach(InputHandler ih in InputHandlers.Values)
            {
                if(ih.CurrentInputState is WaitingForOpponent)
                {
                    ih.CurrentInputState.Enter();
                }
            }
            foreach (InputHandler ih in InputHandlers.Values)
            {
                if (!(ih.CurrentInputState is WaitingForOpponent))
                {
                    ih.CurrentInputState.Enter();
                }
            }
        }
    }
}
