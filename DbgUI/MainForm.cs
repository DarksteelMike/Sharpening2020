using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using Sharpening2020;
using Sharpening2020.InputBridges;

namespace DbgUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        MatchForm mf1;
        MatchForm mf2;

        UIBridge bridge1;
        UIBridge bridge2;

        Game model;
        Thread GameThread;

        private void bNew_Click(object sender, EventArgs e)
        {
            mf1 = new MatchForm();
            mf2 = new MatchForm();
            mf1.Text = "Player 1";
            mf2.Text = "Player 2";
            mf1.Show();
            mf2.Show();

            bridge1 = new UIBridge(mf1);
            bridge2 = new UIBridge(mf2);

            model = Game.Construct();
            model.DebugFlag = cbDebug.Checked;

            ThreadStart ts = new ThreadStart(SetupGame);
            GameThread = new Thread(ts);
            GameThread.Start();
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameThread?.Abort();
        }

        public void SetupGame()
        {
            List<String> Deck1 = new List<string>();
            List<String> Deck2 = new List<string>();

            for (int i = 0; i < 24; i++)
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

            model.InitGame(new KeyValuePair<InputBridge, List<string>>(bridge1, Deck1), new KeyValuePair<InputBridge, List<string>>(bridge2, Deck2));
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void bLoad_Click(object sender, EventArgs e)
        {

        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            model.MyExecutor.Undo();
        }

        private void bRedo_Click(object sender, EventArgs e)
        {
            model.MyExecutor.Redo();
        }
    }
}
