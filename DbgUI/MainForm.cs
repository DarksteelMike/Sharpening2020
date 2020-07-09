using System;
using System.Collections.Generic;
using System.IO;
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
            
            DbgCheckboxes.Add(cbDbgCardViews, DebugMode.CardViews);
            DbgCheckboxes.Add(cbDbgCommands, DebugMode.Commands);
            DbgCheckboxes.Add(cbDbgContinuousEffects, DebugMode.ContinuousEffects);
            DbgCheckboxes.Add(cbDbgInputStates, DebugMode.InputStates);
            DbgCheckboxes.Add(cbDbgMana, DebugMode.Mana);
            DbgCheckboxes.Add(cbDbgPhases, DebugMode.Phases);
            DbgCheckboxes.Add(cbDbgTriggers, DebugMode.Triggers);
        }

        MatchForm mf1;
        MatchForm mf2;

        UIBridge bridge1;
        UIBridge bridge2;

        Game model;
        Thread GameThread;

        StreamWriter swLog = null;

        Dictionary<CheckBox, DebugMode> DbgCheckboxes = new Dictionary<CheckBox,DebugMode>();

        private void bNew_Click(object sender, EventArgs e)
        {
            List<DebugMode> dbgModes = new List<DebugMode>();
            foreach(CheckBox cb in DbgCheckboxes.Keys)
            {
                if (cb.Checked)
                    dbgModes.Add(DbgCheckboxes[cb]);
            }

            if(dbgModes.Count > 0)
            {
                if (File.Exists("Debug.log"))
                    File.Delete("Debug.log");
                swLog = File.CreateText("Debug.log");
            }

            mf1 = new MatchForm(swLog,0);
            mf2 = new MatchForm(null,1);
            mf1.Text = "Player 1";
            mf2.Text = "Player 2";
            mf1.Show();
            mf2.Show();

            bridge1 = new UIBridge(mf1);
            bridge2 = new UIBridge(mf2);

            model = Game.Construct();
            model.DebugFlag = dbgModes;

            ThreadStart ts = new ThreadStart(SetupGame);
            GameThread = new Thread(ts);
            GameThread.Start();

            bSave.Enabled = true;
            bLoad.Enabled = false;
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEverything();
        }

        public void CloseEverything()
        {
            GameThread?.Abort();
            swLog?.Flush();
            swLog?.Close();
        }

        public void SetupGame()
        {
            List<String> Deck1 = new List<string>();
            List<String> Deck2 = new List<string>();

            Deck1.Add("Plains");
            Deck1.Add("Plains");
            Deck1.Add("Memnite");
            Deck1.Add("Memnite");
            Deck1.Add("Selfless Cathar");
            Deck1.Add("Soul Warden");

            Deck2.Add("Forest");
            Deck2.Add("Grizzly Bears");
            Deck2.Add("Memnite");
            Deck2.Add("Giant Growth");
            Deck2.Add("Llanowar Elves");

            model.InitGame(new KeyValuePair<InputBridge, List<string>>(bridge1, Deck1), new KeyValuePair<InputBridge, List<string>>(bridge2, Deck2));
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if(sfdSaveReplay.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(sfdSaveReplay.FileName);
                using(FileStream fs = File.OpenWrite(sfdSaveReplay.FileName)) {
                    model.MyExecutor.Save(fs);
                    fs.Close();
                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            model = Game.Construct();
            if(ofdLoadReplay.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenWrite(ofdLoadReplay.FileName))
                {
                    model.MyExecutor.Load(fs);
                    fs.Close();
                }
            }
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
