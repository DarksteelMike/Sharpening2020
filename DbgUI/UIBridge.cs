using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Sharpening2020.Input;
using Sharpening2020.InputBridges;
using Sharpening2020.Views;
using Sharpening2020.Zones;
using Sharpening2020.Phases;

namespace DbgUI
{
    class UIBridge : InputBridge
    { 
        private readonly MatchForm FormRef;

        public UIBridge(MatchForm fr)
        {
            FormRef = fr;
        }

        public override void Prompt(String s)
        {
            FormRef.Invoke((MethodInvoker)delegate { FormRef.Prompt(s); }) ;
        }

        public override GameAction SelectActionFromList(List<GameAction> actions)
        {
            FormRef.Invoke((Action<List<GameAction>>) delegate(List<GameAction> act)
            {
                FormRef.SetupActions(act);
            },actions);

            while (FormRef.SelectedAction == null)
            {
                Thread.Sleep(100);
            }

            GameAction sel = FormRef.SelectedAction;
            FormRef.Invoke((MethodInvoker)delegate 
            {
                FormRef.Reset();
            });

            return sel;
        }

        public override void UpdateCardView(CardView view)
        {
            FormRef.Invoke((MethodInvoker)delegate {
                FormRef.UpdateCardView(view);
            });
        }

        public override void UpdatePlayerView(PlayerView view)
        {
            FormRef.Invoke((MethodInvoker)delegate {
                FormRef.UpdatePlayerView(view);
            });            
        }

        public override void UpdateStackView(List<StackInstanceView> views)
        {
            FormRef.Invoke((MethodInvoker)delegate
            {
                FormRef.UpdateStackView(views);
            });
        }

        public override void UpdateZoneView(ZoneType zt, Int32 PlayerID, List<CardView> views)
        {
            FormRef.Invoke((MethodInvoker)delegate {
                FormRef.UpdateZoneView(zt, PlayerID, views);
            });
        }

        public override void DebugAlert(string msg)
        {
            FormRef.Invoke((MethodInvoker)delegate
            {
                FormRef.DebugAlert(msg);
            });
        }

        public override void UpdatePhase(PhaseType pt)
        {
            FormRef.Invoke((MethodInvoker)delegate
            {
                FormRef.UpdatePhase(pt);
            });
        }
    }
}
