using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;
using Sharpening2020.Cards;
using Sharpening2020.Input;
using Sharpening2020.InputBridges;
using Sharpening2020.Views;

namespace DbgUI
{
    class UIBridge : InputBridge
    {
        public GameAction SelectedAction = null;

        private readonly Label MyPrompt;
        private readonly ListBox MyStack;
        private readonly Label DetailID;
        private readonly Label DetailName;
        private readonly ComboBox DetailCounters;
        private readonly TextBox DetailText;

        private readonly Dictionary<Int32, Control> AssociatedControls = new Dictionary<Int32, Control>();

        private readonly List<Dictionary<String, Control>> Controls = new List<Dictionary<string, Control>>();

        public UIBridge(Form1 fr)
        {
            MyPrompt = (Label)fr.Controls["lblPrompt"];
            MyStack = (ListBox)fr.Controls["lbStack"];
            DetailID = (Label)fr.Controls["lblCardDetailID"];
            DetailName = (Label)fr.Controls["lblCardDetailName"];
            DetailCounters = (ComboBox)fr.Controls["cbCardDetailCounters"];
            DetailText = (TextBox)fr.Controls["tbCarddetailText"];

            Controls.Add(new Dictionary<string, Control>());
            Controls.Add(new Dictionary<string, Control>());

            Controls[0].Add("Player", fr.Controls["grpPlayer1"]);
            Controls[0].Add("PlayerLife", fr.Controls["lblLife1"]);
            Controls[0].Add("PlayerCounters", fr.Controls["cbCounters1"]);
            Controls[0].Add("PlayerManapool", fr.Controls["cbManapool1"]);
            Controls[0].Add("Library", fr.Controls["lvLibrary1"]);
            Controls[0].Add("Hand", fr.Controls["lvHand1"]);
            Controls[0].Add("Battlefield", fr.Controls["lvBattlefield1"]);
            Controls[0].Add("Graveyard", fr.Controls["lvGraveyard1"]);
            Controls[0].Add("Exile", fr.Controls["lvExile1"]);
            Controls[0].Add("Command", fr.Controls["lvCommand1"]);

            Controls[1].Add("Player", fr.Controls["grpPlayer2"]);
            Controls[1].Add("PlayerLife", fr.Controls["lblLife2"]);
            Controls[1].Add("PlayerCounters", fr.Controls["cbCounters2"]);
            Controls[1].Add("PlayerManapool", fr.Controls["cbManapool2"]);
            Controls[1].Add("Library", fr.Controls["lvLibrary2"]);
            Controls[1].Add("Hand", fr.Controls["lvHand2"]);
            Controls[1].Add("Battlefield", fr.Controls["lvBattlefield2"]);
            Controls[1].Add("Graveyard", fr.Controls["lvGraveyard2"]);
            Controls[1].Add("Exile", fr.Controls["lvExile2"]);
            Controls[1].Add("Command", fr.Controls["lvCommand2"]);
        }

        public override void Prompt(String s)
        {
            MyPrompt.Text = s;
        }
        

        public override GameAction SelectActionFromList(List<GameAction> actions)
        {
            //Setup 
            SelectedAction = null;


            while(SelectedAction == null)
            {
                Thread.Sleep(100);
            }

            return SelectedAction;
        }

        public override void UpdateCardView(CardView view)
        {
            MessageBox.Show("Bleh");

        }

        public override void UpdatePlayerView(PlayerView view)
        {
            Dictionary<String, Control> ctrls = Controls[view.ID];

            ((Label)ctrls["PlayerLife"]).Text = view.Life.ToString();

            ComboBox counters = (ComboBox)ctrls["PlayerCounters"];
            ComboBox mana = (ComboBox)ctrls["PlayerManapool"];

            counters.Items.Clear();
            mana.Items.Clear();

            foreach(ManaPointView mpv in view.ManaPool)
            {
                mana.Items.Add(mpv);
            }
            foreach(CounterView cv in view.Counters)
            {
                counters.Items.Add(cv);
            }
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            MyStack.Items.Clear();

            MyStack.Items.AddRange(views.ToArray());
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            MessageBox.Show("UpdateZoneView: " + zt.ToString() + ", " + PlayerID.ToString());
            ListView lv = (ListView)Controls[PlayerID][zt.ToString()];

            lv.Items.Clear();
            
            foreach(CardView cv in views)
            {
                ListViewItem lvi = new ListViewItem(cv.Name);

                lv.Items.Add(lvi);
            }
        }

    }
}
