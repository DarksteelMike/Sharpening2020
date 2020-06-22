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
using Sharpening2020.InputBridges;

namespace DbgUI
{
    public partial class Form1 : Form
    {
        Game Model = Game.Construct();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(SetupGame);
            ts.Invoke();
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
