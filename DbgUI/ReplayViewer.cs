using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sharpening2020.Commands;

namespace DbgUI
{
    public partial class ReplayViewer : Form
    {
        public ReplayViewer(CommandBase[] commands)
        {
            InitializeComponent();

            replay.AddRange(commands);

            UpdateListBox();
        }

        List<CommandBase> replay = new List<CommandBase>();
        Int32 CurrentIndex = 0;

        private void UpdateListBox()
        {
            lbReplay.Items.Clear();

            for(int i=0;i<replay.Count;i++)
            {
                lbReplay.Items.Add(replay[i].ToString());
            }

            lbReplay.SelectedIndex = CurrentIndex;
        }

        private void bDo_Click(object sender, EventArgs e)
        {

        }
    }
}
