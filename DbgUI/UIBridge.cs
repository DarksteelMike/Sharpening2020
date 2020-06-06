using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sharpening2020.Input;
using Sharpening2020.InputBridges;
using Sharpening2020.Views;

namespace DbgUI
{
    class UIBridge : InputBridge
    {
        public GameAction SelectedAction = null;

        public override void Prompt(String s)
        {

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

        public override void UpdateView(ViewObject view)
        {

        }

    }
}
