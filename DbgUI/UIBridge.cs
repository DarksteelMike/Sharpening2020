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

        private Form1 FormRef;

        public UIBridge(Form1 fr)
        {
            FormRef = fr;
        }

        public override void Prompt(String s)
        {
            FormRef.Invoke((MethodInvoker)delegate { FormRef.GetPrompt().Text = s; }) ;
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

        }

        public override void UpdatePlayerView(PlayerView view)
        {
            FormRef.Invoke((MethodInvoker)delegate {
                FormRef.GetLife(view.ID).Text = view.Life.ToString();
                FormRef.GetCounters(view.ID).Items.Clear();
                FormRef.GetManaPool(view.ID).Items.Clear();

                foreach (ManaPointView mpv in view.ManaPool)
                {
                    FormRef.GetManaPool(view.ID).Items.Add(mpv);
                }
                foreach (CounterView cv in view.Counters)
                {
                    FormRef.GetCounters(view.ID).Items.Add(cv);
                }
            });            
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            FormRef.Invoke((MethodInvoker)delegate
            {
                FormRef.GetStack().Items.Clear();

                FormRef.GetStack().Items.AddRange(views.ToArray());
            });
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            FormRef.Invoke((MethodInvoker)delegate {
                ListView Zone = null;
                switch(zt)
                {
                    case (ZoneType.Library): Zone = FormRef.GetLibrary(PlayerID); break;
                    case (ZoneType.Hand): Zone = FormRef.GetHand(PlayerID); break;
                    case (ZoneType.Battlefield): Zone = FormRef.GetBattlefield(PlayerID); break;
                    case (ZoneType.Graveyard): Zone = FormRef.GetGraveyard(PlayerID); break;
                    case (ZoneType.Exile): Zone = FormRef.GetExile(PlayerID); break;
                    case (ZoneType.Command): Zone = FormRef.GetCommand(PlayerID); break;
                }

                Zone.Items.Clear(); 
            
                foreach (CardView cv in views)
                {
                    ListViewItem lvi = new ListViewItem(cv.Name);
                    lvi.Text = cv.Name;

                    Zone.Items.Add(lvi);
                }

                Zone.Update();
            });
        }

        public override void DebugAlert(string msg)
        {
            FormRef.Invoke((MethodInvoker)delegate
            {
                FormRef.GetCardDetailText().Text += msg + "\n=======\n";
            });
        }
    }
}
