using System;
using System.Collections.Generic;
using System.Linq;

using Sharpening2020.Cards;
using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Activatables;
using Sharpening2020.Commands;
using Sharpening2020.Mana;

namespace Sharpening2020.Input
{
    class PayManaCost : InputStateBase
    {
        public readonly Dictionary<Int32, CommandBase> ActionCommandPairs = new Dictionary<Int32, CommandBase>();
       
        public Activatable MyActivatable;
        public AbilityType Mode;

        private Int32 activatableIndex;

        public PayManaCost(Activatable act, AbilityType m)
        {
            MyActivatable = act;
            Mode = m;
        }

        public void PromptAndRequestAction()
        {
            MyBridge.Prompt("Pay \"" + Utilities.ColorListToShortenedString(MyActivatable.MyCost.GetUnpaidMana().Select(x => { return x.Color; })) + "\"?");
            SelectAction(MyBridge.SelectActionFromList(GetActions()));
        }

        public override void Enter()
        {
            activatableIndex = MyActivatable.Host.Value(MyGame).CurrentCharacteristics.IndexOfAbility(MyActivatable, Mode);
            if (MyActivatable.MyCost.IsManaPaid())
            {
                MyGame.PlayActivatable(MyActivatable, MyPlayer.Value(MyGame), Mode);
                MyGame.MyExecutor.Do(new CommandGroup(
                    new CommandSetIsActivating(MyActivatable.Host.ID, activatableIndex, false, Mode), 
                    new CommandRemoveTopInputStates(MyPlayer.ID,3),
                    new CommandEnterInputState()));
            }

            PromptAndRequestAction();
        }

        public override void Leave()
        {
            MyGame.MyExecutor.Do(new CommandResetManaCost(MyPlayer.ID));
        }

        public override List<GameAction> GetActions()
        {
            List<GameAction> res = new List<GameAction>();
            ActionCommandPairs.Clear();

            GameAction cancel = new GameAction(-2, -2, "Cancel");
            res.Add(cancel);
            ActionCommandPairs.Add(-2, null);

            int i = 0;

            foreach(LazyGameObject<ManaPoint> lmp in MyPlayer.Value(MyGame).ManaPool)
            {
                ManaPoint mp = lmp.Value(MyGame);
                foreach(ManaCostPart mcp in MyActivatable.MyCost.ManaParts.Where(x => { return !MyActivatable.MyCost.PaidMana.Contains(x); }))
                {
                    if(mp.MyColor == mcp.Color || mcp.Color == ManaColor.Colorless)
                    {
                        GameAction ga = new GameAction(i++, mp.ID, "Pay " + mp.MyColor + " mana for " + mcp.ToString());
                        res.Add(ga);

                        ActionCommandPairs.Add(ga.ID, new CommandPayMana(MyPlayer.ID,mp.ID, MyActivatable.MyCost.ManaParts.IndexOf(mcp)));
                    }
                }
            }

            return res;
        }

        public override void SelectAction(GameAction a)
        {
            if(a.ID == -2)
            {
                MyGame.MyExecutor.UndoUntilMarker(CommandMarkerType.StartActivating);
                MyGame.EnterAllInputStates();
                return;
            }
            MyGame.MyExecutor.Do(ActionCommandPairs[a.ID]);

            if(MyActivatable.MyCost.IsManaPaid())
            {
                MyGame.PlayActivatable(MyActivatable, MyPlayer.Value(MyGame), Mode);
                MyGame.MyExecutor.Do(new CommandGroup(
                    new CommandSetIsActivating(MyActivatable.Host.ID, activatableIndex, false, Mode),
                    new CommandRemoveTopInputStates(MyPlayer.ID, 3),
                    new CommandEnterInputState()));                
            }
            else
            {
                PromptAndRequestAction();
            }
        }

        public override object Clone()
        {
            return new PayManaCost(MyActivatable, Mode);
        }

        public override string ToString()
        {
            return "PayManaCost for " + MyActivatable.ToString();
        }
    }
}
