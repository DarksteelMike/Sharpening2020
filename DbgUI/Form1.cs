using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sharpening2020;
using Sharpening2020.Commands;
using Sharpening2020.InputBridges;

namespace DbgUI
{
    public partial class Form1 : Form
    {
        Game Model = Game.Construct();

        public Form1()
        {
            InitializeComponent();
            Model.MyExecutor.CommandPerformed += MyExecutor_CommandPerformed;
        }

        private void MyExecutor_CommandPerformed(CommandBase cb)
        {
            this.Invoke((MethodInvoker)delegate { tbCardDetailText.Text += Environment.NewLine + cb.GetType().ToString(); });
            
        }

        public ListView GetLibrary(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvLibrary1;

            return lvLibrary2;
        }

        public ListView GetHand(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvHand1;

            return lvHand2;
        }

        public ListView GetBattlefield(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvBattlefield1;

            return lvBattlefield2;
        }

        public ListView GetGraveyard(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvGraveyard1;

            return lvGraveyard2;
        }

        public ListView GetExile(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvExile1;

            return lvExile2;
        }

        public ListView GetCommand(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lvCommand1;

            return lvCommand2;
        }

        public Label GetLife(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return lblLife1;

            return lblLife2;
        }

        public ComboBox GetCounters(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return cbCounters1;

            return cbCounters2;
        }

        public ComboBox GetManaPool(Int32 PlayerNum)
        {
            if (PlayerNum == 0)
                return cbManaPool1;

            return cbManaPool2;
        }

        public Label GetPrompt()
        {
            return lblPrompt;
        }

        public ListBox GetStack()
        {
            return lbStack;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(SetupGame);
            Thread t = new Thread(ts);
            t.Start();
        }
        
        public void SetupGame()
        {
            List<String> Deck1 = new List<string>();
            List<String> Deck2 = new List<string>();

            for(int i=0;i<24;i++)
            {
                Deck1.Add("Forest");
                Deck2.Add("Forest");
            }
            for (int i = 0; i < 4; i++)
            {
                Deck1.Add("Grizzly Bears");
                Deck1.Add("Memnite");
                Deck2.Add("Grizzly Bears");
                Deck2.Add("Memnite");
            }

            InputBridge IB1, IB2;

            IB1 = new UIBridge(this);
            IB2 = new RandomPlayerBridge();

            Model.InitGame(new KeyValuePair<InputBridge, List<string>>(IB1, Deck1), new KeyValuePair<InputBridge, List<string>>(IB2, Deck2));
        }
    }
}
