using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Sharpening2020.Input;
using Sharpening2020.Phases;
using Sharpening2020.Views;
using Sharpening2020.Zones;

namespace DbgUI
{
    public partial class MatchForm : Form
    {
        public GameAction SelectedAction;
        private List<GameAction> AvailableActions;

        private Dictionary<Int32, ViewObject> ViewMap = new Dictionary<int, ViewObject>();
        private Dictionary<ListViewItem, Int32> CardMap = new Dictionary<ListViewItem, int>();
        private Dictionary<Int32, ContextMenuStrip> ContextMap = new Dictionary<int, ContextMenuStrip>();

        private StreamWriter fsLog;
        private Int32 MainPlayer;

        public MatchForm(StreamWriter fs, Int32 mainPlayer)
        {
            InitializeComponent();

            MainPlayer = mainPlayer;
            fsLog = fs;
        }      

        public void SetupActions(List<GameAction> actions)
        {
            //Setup 
            SelectedAction = null;
            AvailableActions = actions;
            bOK.Enabled = false;
            bCancel.Enabled = false;

            foreach(GameAction ga in AvailableActions)
            {                
                if(ga.AssociatedGameObjectID == -1)
                {
                    bOK.Enabled = true;
                    continue;
                 }
                if (ga.AssociatedGameObjectID == -2)
                {
                    bCancel.Enabled = true;
                    continue;
                }

                ViewObject vo = ViewMap[ga.AssociatedGameObjectID];
                if (vo is CardView)
                {
                    ContextMenuStrip cont;
                    if (ContextMap.ContainsKey(vo.ID))
                    {
                        cont = ContextMap[vo.ID];
                    }
                    else {
                        cont = new ContextMenuStrip();
                    }
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(ga.Description);
                    tsmi.Click += (o, e) => { SelectedAction = ga; };
                    cont.Items.Add(tsmi);
                    ContextMap.Add(vo.ID, cont);
                }
                else if(vo is PlayerView)
                {
                    ContextMenuStrip cont;
                    if (ContextMap.ContainsKey(vo.ID))
                    {
                        cont = ContextMap[vo.ID];
                    }
                    else
                    {
                        cont = new ContextMenuStrip();
                    }
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(ga.Description);
                    tsmi.Click += (o, e) => { SelectedAction = ga; };
                    cont.Items.Add(tsmi);
                    if(vo.ID == MainPlayer)
                    {
                        grpPlayer1.ContextMenuStrip = cont;
                    }
                    else
                    {
                        grpPlayer2.ContextMenuStrip = cont;
                    }
                }
            }            
        }

        public void UpdateCardView(CardView view)
        {
            foreach(ListViewItem lvi in CardMap.Keys)
            {
                if(CardMap[lvi] == view.ID)
                {
                    if (view.IsTapped)
                    {
                        lvi.Text = "(" + view.Name + ")";
                    }
                    else
                    {
                        lvi.Text = view.Name;
                    }
                    break;
                }
            }
            AddViewToMap(view);
        }

        public void UpdatePlayerView(PlayerView view)
        {
            AddViewToMap(view);
            Label life;
            ComboBox counters, manapool;

            if(view.ID == MainPlayer)
            {
                life = lblLife1;
                counters = cbCounters1;
                manapool = cbManaPool1;
            }
            else
            {
                life = lblLife2;
                counters = cbCounters2;
                manapool = cbManaPool2;
            }

            life.Text = view.Life.ToString();
            counters.Items.Clear();
            manapool.Items.Clear();

            foreach (ManaPointView mpv in view.ManaPool)
            {
                manapool.Items.Add(mpv);
            }
            foreach (CounterView cv in view.Counters)
            {
                counters.Items.Add(cv);
            }
        }

        public void UpdateStackView(List<StackInstanceView> views)
        {
            foreach(StackInstanceView siv in views)
            {
                AddViewToMap(siv);
            }
            lbStack.Items.Clear();
            lbStack.Items.AddRange(views.ToArray());
        }

        public void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            foreach(CardView cv in views)
            {
                AddViewToMap(cv);
            }
            ListView Zone = GetZoneControl(zt, PlayerID);

            foreach(ListViewItem lvi in Zone.Items)
            {
                CardMap.Remove(lvi);
            }

            Zone.Items.Clear();

            foreach (CardView cv in views)
            {
                ListViewItem lvi = new ListViewItem();
                if(cv.IsTapped)
                {
                    lvi.Text = "(" + cv.Name + ")";
                }
                else
                {
                    lvi.Text = cv.Name;
                }
                

                Zone.Items.Add(lvi);
                CardMap.Add(lvi, cv.ID);
            }
        }

        public void UpdatePhase(PhaseType pt)
        {
            this.Text = "Sharpening horrible very bad no good \"UI\" :" + pt.ToString();
        }

        public void AddViewToMap(ViewObject vo)
        {
            if(ViewMap.ContainsKey(vo.ID))
            {
                ViewMap[vo.ID] = vo;
            }
            else
            {
                ViewMap.Add(vo.ID, vo);
            }
        }

        public ListView GetZoneControl(ZoneType z, Int32 Player)
        {
            ListView res = null;
            if(Player == MainPlayer)
            {
                switch(z)
                {
                    case (ZoneType.Library): res = lvLibrary1; break;
                    case (ZoneType.Hand): res = lvHand1; break;
                    case (ZoneType.Battlefield): res = lvBattlefield1; break;
                    case (ZoneType.Graveyard): res = lvGraveyard1; break;
                    case (ZoneType.Exile): res = lvExile1; break;
                    case (ZoneType.Command): res = lvCommand1; break;
                }
            }
            else
            {
                switch (z)
                {
                    case (ZoneType.Library): res = lvLibrary2; break;
                    case (ZoneType.Hand): res = lvHand2; break;
                    case (ZoneType.Battlefield): res = lvBattlefield2; break;
                    case (ZoneType.Graveyard): res = lvGraveyard2; break;
                    case (ZoneType.Exile): res = lvExile2; break;
                    case (ZoneType.Command): res = lvCommand2; break;
                }
            }
            
            return res;
        }

        public void DebugAlert(string msg)
        {
            fsLog?.Write(msg);
            fsLog?.WriteLine("");
            fsLog?.Flush();
        }

        public void Prompt(String s)
        {
            lblPrompt.Text = s;
        }

        private void bSelectPlayerCounter2_Click(object sender, EventArgs e)
        {
            if (cbCounters2.Items.Count == 0)
                return;

            CounterView cv = (CounterView)cbCounters2.SelectedItem;
            if(AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).Count() > 0)
            {
                SelectedAction = AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).First();
            }
        }

        private void bSelectManaPoint2_Click(object sender, EventArgs e)
        {
            if (cbCounters2.Items.Count == 0)
                return;

            ManaPointView cv = (ManaPointView)cbManaPool2.SelectedItem;
            if (AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).Count() > 0)
            {
                SelectedAction = AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).First();
            }
        }

        private void bSelectPlayerCounter1_Click(object sender, EventArgs e)
        {
            if (cbCounters1.Items.Count == 0)
                return;

            CounterView cv = (CounterView)cbCounters1.SelectedItem;
            if (AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).Count() > 0)
            {
                SelectedAction = AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).First();
            }
        }

        private void bSelectManaPoint1_Click(object sender, EventArgs e)
        {
            if (cbCounters1.Items.Count == 0)
                return;

            ManaPointView cv = (ManaPointView)cbManaPool1.SelectedItem;
            if (AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).Count() > 0)
            {
                SelectedAction = AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).First();
            }
        }

        private void bSelectCardCounter_Click(object sender, EventArgs e)
        {
            if (cbCardDetailCounters.Items.Count == 0)
                return;

            CounterView cv = (CounterView)cbCardDetailCounters.SelectedItem;
            if (AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).Count() > 0)
            {
                SelectedAction = AvailableActions.Where(x => { return x.AssociatedGameObjectID == cv.ID; }).First();
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            SelectedAction = AvailableActions.Where(x => { return x.ID == -1; }).First();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            SelectedAction = AvailableActions.Where(x => { return x.ID == -2; }).First();
        }

        private void lvZone_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = ((ListView)sender).FocusedItem;

                if (lvi == null)
                    return;

                if (lvi.Bounds.Contains(e.Location))
                {                    
                    if (!CardMap.ContainsKey(lvi))
                        return;

                    Int32 ID = CardMap[lvi];

                    if (!ContextMap.ContainsKey(ID))
                        return;

                    ContextMap[ID].Show(Cursor.Position);
                }
            }
        }

        public void Reset()
        {
            SelectedAction = null;
            ContextMap.Clear();
            AvailableActions.Clear();
            bOK.Enabled = false;
            bCancel.Enabled = false;
        }

        private void lvZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lvi = ((ListView)sender).FocusedItem;

            CardView cv = (CardView)ViewMap[CardMap[lvi]];

            lblCardDetailID.Text = cv.ID.ToString();
            lblCardDetailName.Text = cv.Name.ToString();
            cbCardDetailCounters.Items.Clear();
            cbCardDetailCounters.Items.AddRange(cv.Counters.ToArray());
            tbCardDetailText.Text = cv.Text;
        }
    }
}
