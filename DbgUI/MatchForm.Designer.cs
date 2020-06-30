namespace DbgUI
{
    partial class MatchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbStack = new System.Windows.Forms.ListBox();
            this.lvBattlefield1 = new System.Windows.Forms.ListView();
            this.lvHand1 = new System.Windows.Forms.ListView();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.cbManaPool1 = new System.Windows.Forms.ComboBox();
            this.cbManaPool2 = new System.Windows.Forms.ComboBox();
            this.tcArea1 = new System.Windows.Forms.TabControl();
            this.tpLibrary1 = new System.Windows.Forms.TabPage();
            this.lvLibrary1 = new System.Windows.Forms.ListView();
            this.tpBattlefield = new System.Windows.Forms.TabPage();
            this.tpGraveyard = new System.Windows.Forms.TabPage();
            this.lvGraveyard1 = new System.Windows.Forms.ListView();
            this.tpExile = new System.Windows.Forms.TabPage();
            this.lvExile1 = new System.Windows.Forms.ListView();
            this.tpCommand = new System.Windows.Forms.TabPage();
            this.lvCommand1 = new System.Windows.Forms.ListView();
            this.grpPlayer2 = new System.Windows.Forms.GroupBox();
            this.bSelectManaPoint2 = new System.Windows.Forms.Button();
            this.bSelectPlayerCounter2 = new System.Windows.Forms.Button();
            this.cbCounters2 = new System.Windows.Forms.ComboBox();
            this.lblUIManapool2 = new System.Windows.Forms.Label();
            this.lblLife2 = new System.Windows.Forms.Label();
            this.lblUILife2 = new System.Windows.Forms.Label();
            this.lblUICounters2 = new System.Windows.Forms.Label();
            this.grpPlayer1 = new System.Windows.Forms.GroupBox();
            this.bSelectManaPoint1 = new System.Windows.Forms.Button();
            this.bSelectPlayerCounter1 = new System.Windows.Forms.Button();
            this.cbCounters1 = new System.Windows.Forms.ComboBox();
            this.lblManapool = new System.Windows.Forms.Label();
            this.lblCounters1 = new System.Windows.Forms.Label();
            this.lblLife1 = new System.Windows.Forms.Label();
            this.lblUILife1 = new System.Windows.Forms.Label();
            this.grpCardDetail = new System.Windows.Forms.GroupBox();
            this.lblPowerToughness = new System.Windows.Forms.Label();
            this.bSelectCardCounter = new System.Windows.Forms.Button();
            this.lblCardDetailID = new System.Windows.Forms.Label();
            this.tbCardDetailText = new System.Windows.Forms.TextBox();
            this.cbCardDetailCounters = new System.Windows.Forms.ComboBox();
            this.lblUICardDetailCounters = new System.Windows.Forms.Label();
            this.lblCardDetailName = new System.Windows.Forms.Label();
            this.tcArea2 = new System.Windows.Forms.TabControl();
            this.tpLibrary2 = new System.Windows.Forms.TabPage();
            this.lvLibrary2 = new System.Windows.Forms.ListView();
            this.tpHand2 = new System.Windows.Forms.TabPage();
            this.lvHand2 = new System.Windows.Forms.ListView();
            this.tpBattlefield2 = new System.Windows.Forms.TabPage();
            this.lvBattlefield2 = new System.Windows.Forms.ListView();
            this.tpGraveyard2 = new System.Windows.Forms.TabPage();
            this.lvGraveyard2 = new System.Windows.Forms.ListView();
            this.tpExile2 = new System.Windows.Forms.TabPage();
            this.lvExile2 = new System.Windows.Forms.ListView();
            this.tpCommand2 = new System.Windows.Forms.TabPage();
            this.lvCommand2 = new System.Windows.Forms.ListView();
            this.tcArea1.SuspendLayout();
            this.tpLibrary1.SuspendLayout();
            this.tpBattlefield.SuspendLayout();
            this.tpGraveyard.SuspendLayout();
            this.tpExile.SuspendLayout();
            this.tpCommand.SuspendLayout();
            this.grpPlayer2.SuspendLayout();
            this.grpPlayer1.SuspendLayout();
            this.grpCardDetail.SuspendLayout();
            this.tcArea2.SuspendLayout();
            this.tpLibrary2.SuspendLayout();
            this.tpHand2.SuspendLayout();
            this.tpBattlefield2.SuspendLayout();
            this.tpGraveyard2.SuspendLayout();
            this.tpExile2.SuspendLayout();
            this.tpCommand2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbStack
            // 
            this.lbStack.FormattingEnabled = true;
            this.lbStack.Location = new System.Drawing.Point(2, 306);
            this.lbStack.Name = "lbStack";
            this.lbStack.Size = new System.Drawing.Size(220, 225);
            this.lbStack.TabIndex = 1;
            // 
            // lvBattlefield1
            // 
            this.lvBattlefield1.HideSelection = false;
            this.lvBattlefield1.Location = new System.Drawing.Point(0, 0);
            this.lvBattlefield1.Name = "lvBattlefield1";
            this.lvBattlefield1.Size = new System.Drawing.Size(533, 209);
            this.lvBattlefield1.TabIndex = 2;
            this.lvBattlefield1.UseCompatibleStateImageBehavior = false;
            this.lvBattlefield1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvBattlefield1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // lvHand1
            // 
            this.lvHand1.HideSelection = false;
            this.lvHand1.Location = new System.Drawing.Point(235, 582);
            this.lvHand1.Name = "lvHand1";
            this.lvHand1.Size = new System.Drawing.Size(529, 135);
            this.lvHand1.TabIndex = 8;
            this.lvHand1.UseCompatibleStateImageBehavior = false;
            this.lvHand1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvHand1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // bOK
            // 
            this.bOK.Enabled = false;
            this.bOK.Location = new System.Drawing.Point(12, 663);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(92, 54);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Enabled = false;
            this.bCancel.Location = new System.Drawing.Point(122, 663);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(92, 54);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(12, 543);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(35, 13);
            this.lblPrompt.TabIndex = 11;
            this.lblPrompt.Text = "label1";
            // 
            // cbManaPool1
            // 
            this.cbManaPool1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManaPool1.FormattingEnabled = true;
            this.cbManaPool1.Location = new System.Drawing.Point(64, 83);
            this.cbManaPool1.Name = "cbManaPool1";
            this.cbManaPool1.Size = new System.Drawing.Size(92, 21);
            this.cbManaPool1.TabIndex = 14;
            // 
            // cbManaPool2
            // 
            this.cbManaPool2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManaPool2.FormattingEnabled = true;
            this.cbManaPool2.Location = new System.Drawing.Point(70, 77);
            this.cbManaPool2.Name = "cbManaPool2";
            this.cbManaPool2.Size = new System.Drawing.Size(92, 21);
            this.cbManaPool2.TabIndex = 15;
            // 
            // tcArea1
            // 
            this.tcArea1.Controls.Add(this.tpLibrary1);
            this.tcArea1.Controls.Add(this.tpBattlefield);
            this.tcArea1.Controls.Add(this.tpGraveyard);
            this.tcArea1.Controls.Add(this.tpExile);
            this.tcArea1.Controls.Add(this.tpCommand);
            this.tcArea1.Location = new System.Drawing.Point(228, 338);
            this.tcArea1.Name = "tcArea1";
            this.tcArea1.SelectedIndex = 0;
            this.tcArea1.Size = new System.Drawing.Size(544, 238);
            this.tcArea1.TabIndex = 16;
            // 
            // tpLibrary1
            // 
            this.tpLibrary1.Controls.Add(this.lvLibrary1);
            this.tpLibrary1.Location = new System.Drawing.Point(4, 22);
            this.tpLibrary1.Name = "tpLibrary1";
            this.tpLibrary1.Size = new System.Drawing.Size(536, 212);
            this.tpLibrary1.TabIndex = 4;
            this.tpLibrary1.Text = "Library";
            this.tpLibrary1.UseVisualStyleBackColor = true;
            // 
            // lvLibrary1
            // 
            this.lvLibrary1.HideSelection = false;
            this.lvLibrary1.Location = new System.Drawing.Point(3, 3);
            this.lvLibrary1.Name = "lvLibrary1";
            this.lvLibrary1.Size = new System.Drawing.Size(529, 206);
            this.lvLibrary1.TabIndex = 0;
            this.lvLibrary1.UseCompatibleStateImageBehavior = false;
            this.lvLibrary1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvLibrary1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpBattlefield
            // 
            this.tpBattlefield.Controls.Add(this.lvBattlefield1);
            this.tpBattlefield.Location = new System.Drawing.Point(4, 22);
            this.tpBattlefield.Name = "tpBattlefield";
            this.tpBattlefield.Padding = new System.Windows.Forms.Padding(3);
            this.tpBattlefield.Size = new System.Drawing.Size(536, 212);
            this.tpBattlefield.TabIndex = 0;
            this.tpBattlefield.Text = "Battlefield";
            this.tpBattlefield.UseVisualStyleBackColor = true;
            // 
            // tpGraveyard
            // 
            this.tpGraveyard.Controls.Add(this.lvGraveyard1);
            this.tpGraveyard.Location = new System.Drawing.Point(4, 22);
            this.tpGraveyard.Name = "tpGraveyard";
            this.tpGraveyard.Padding = new System.Windows.Forms.Padding(3);
            this.tpGraveyard.Size = new System.Drawing.Size(536, 212);
            this.tpGraveyard.TabIndex = 1;
            this.tpGraveyard.Text = "Graveyard";
            this.tpGraveyard.UseVisualStyleBackColor = true;
            // 
            // lvGraveyard1
            // 
            this.lvGraveyard1.HideSelection = false;
            this.lvGraveyard1.Location = new System.Drawing.Point(0, 0);
            this.lvGraveyard1.Name = "lvGraveyard1";
            this.lvGraveyard1.Size = new System.Drawing.Size(536, 209);
            this.lvGraveyard1.TabIndex = 0;
            this.lvGraveyard1.UseCompatibleStateImageBehavior = false;
            this.lvGraveyard1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvGraveyard1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpExile
            // 
            this.tpExile.Controls.Add(this.lvExile1);
            this.tpExile.Location = new System.Drawing.Point(4, 22);
            this.tpExile.Name = "tpExile";
            this.tpExile.Size = new System.Drawing.Size(536, 212);
            this.tpExile.TabIndex = 2;
            this.tpExile.Text = "Exile";
            this.tpExile.UseVisualStyleBackColor = true;
            // 
            // lvExile1
            // 
            this.lvExile1.HideSelection = false;
            this.lvExile1.Location = new System.Drawing.Point(0, 0);
            this.lvExile1.Name = "lvExile1";
            this.lvExile1.Size = new System.Drawing.Size(533, 212);
            this.lvExile1.TabIndex = 0;
            this.lvExile1.UseCompatibleStateImageBehavior = false;
            this.lvExile1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvExile1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpCommand
            // 
            this.tpCommand.Controls.Add(this.lvCommand1);
            this.tpCommand.Location = new System.Drawing.Point(4, 22);
            this.tpCommand.Name = "tpCommand";
            this.tpCommand.Size = new System.Drawing.Size(536, 212);
            this.tpCommand.TabIndex = 3;
            this.tpCommand.Text = "Command";
            this.tpCommand.UseVisualStyleBackColor = true;
            // 
            // lvCommand1
            // 
            this.lvCommand1.HideSelection = false;
            this.lvCommand1.Location = new System.Drawing.Point(3, 0);
            this.lvCommand1.Name = "lvCommand1";
            this.lvCommand1.Size = new System.Drawing.Size(530, 209);
            this.lvCommand1.TabIndex = 0;
            this.lvCommand1.UseCompatibleStateImageBehavior = false;
            this.lvCommand1.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvCommand1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // grpPlayer2
            // 
            this.grpPlayer2.Controls.Add(this.bSelectManaPoint2);
            this.grpPlayer2.Controls.Add(this.bSelectPlayerCounter2);
            this.grpPlayer2.Controls.Add(this.cbCounters2);
            this.grpPlayer2.Controls.Add(this.lblUIManapool2);
            this.grpPlayer2.Controls.Add(this.lblLife2);
            this.grpPlayer2.Controls.Add(this.lblUILife2);
            this.grpPlayer2.Controls.Add(this.lblUICounters2);
            this.grpPlayer2.Controls.Add(this.cbManaPool2);
            this.grpPlayer2.Location = new System.Drawing.Point(2, 12);
            this.grpPlayer2.Name = "grpPlayer2";
            this.grpPlayer2.Size = new System.Drawing.Size(220, 288);
            this.grpPlayer2.TabIndex = 18;
            this.grpPlayer2.TabStop = false;
            this.grpPlayer2.Text = "Player 2";
            // 
            // bSelectManaPoint2
            // 
            this.bSelectManaPoint2.Location = new System.Drawing.Point(166, 75);
            this.bSelectManaPoint2.Name = "bSelectManaPoint2";
            this.bSelectManaPoint2.Size = new System.Drawing.Size(46, 23);
            this.bSelectManaPoint2.TabIndex = 21;
            this.bSelectManaPoint2.Text = "Select";
            this.bSelectManaPoint2.UseVisualStyleBackColor = true;
            this.bSelectManaPoint2.Click += new System.EventHandler(this.bSelectManaPoint2_Click);
            // 
            // bSelectPlayerCounter2
            // 
            this.bSelectPlayerCounter2.Location = new System.Drawing.Point(166, 46);
            this.bSelectPlayerCounter2.Name = "bSelectPlayerCounter2";
            this.bSelectPlayerCounter2.Size = new System.Drawing.Size(46, 23);
            this.bSelectPlayerCounter2.TabIndex = 1;
            this.bSelectPlayerCounter2.Text = "Select";
            this.bSelectPlayerCounter2.UseVisualStyleBackColor = true;
            this.bSelectPlayerCounter2.Click += new System.EventHandler(this.bSelectPlayerCounter2_Click);
            // 
            // cbCounters2
            // 
            this.cbCounters2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCounters2.FormattingEnabled = true;
            this.cbCounters2.Location = new System.Drawing.Point(70, 48);
            this.cbCounters2.Name = "cbCounters2";
            this.cbCounters2.Size = new System.Drawing.Size(92, 21);
            this.cbCounters2.TabIndex = 20;
            // 
            // lblUIManapool2
            // 
            this.lblUIManapool2.AutoSize = true;
            this.lblUIManapool2.Location = new System.Drawing.Point(7, 80);
            this.lblUIManapool2.Name = "lblUIManapool2";
            this.lblUIManapool2.Size = new System.Drawing.Size(57, 13);
            this.lblUIManapool2.TabIndex = 19;
            this.lblUIManapool2.Text = "Manapool:";
            // 
            // lblLife2
            // 
            this.lblLife2.AutoSize = true;
            this.lblLife2.Location = new System.Drawing.Point(40, 22);
            this.lblLife2.Name = "lblLife2";
            this.lblLife2.Size = new System.Drawing.Size(13, 13);
            this.lblLife2.TabIndex = 0;
            this.lblLife2.Text = "0";
            // 
            // lblUILife2
            // 
            this.lblUILife2.AutoSize = true;
            this.lblUILife2.Location = new System.Drawing.Point(7, 22);
            this.lblUILife2.Name = "lblUILife2";
            this.lblUILife2.Size = new System.Drawing.Size(27, 13);
            this.lblUILife2.TabIndex = 16;
            this.lblUILife2.Text = "Life:";
            // 
            // lblUICounters2
            // 
            this.lblUICounters2.AutoSize = true;
            this.lblUICounters2.Location = new System.Drawing.Point(7, 51);
            this.lblUICounters2.Name = "lblUICounters2";
            this.lblUICounters2.Size = new System.Drawing.Size(52, 13);
            this.lblUICounters2.TabIndex = 16;
            this.lblUICounters2.Text = "Counters:";
            // 
            // grpPlayer1
            // 
            this.grpPlayer1.Controls.Add(this.bSelectManaPoint1);
            this.grpPlayer1.Controls.Add(this.bSelectPlayerCounter1);
            this.grpPlayer1.Controls.Add(this.cbCounters1);
            this.grpPlayer1.Controls.Add(this.lblManapool);
            this.grpPlayer1.Controls.Add(this.lblCounters1);
            this.grpPlayer1.Controls.Add(this.lblLife1);
            this.grpPlayer1.Controls.Add(this.lblUILife1);
            this.grpPlayer1.Controls.Add(this.cbManaPool1);
            this.grpPlayer1.Location = new System.Drawing.Point(775, 338);
            this.grpPlayer1.Name = "grpPlayer1";
            this.grpPlayer1.Size = new System.Drawing.Size(221, 288);
            this.grpPlayer1.TabIndex = 19;
            this.grpPlayer1.TabStop = false;
            this.grpPlayer1.Text = "Player 1";
            // 
            // bSelectManaPoint1
            // 
            this.bSelectManaPoint1.Location = new System.Drawing.Point(162, 81);
            this.bSelectManaPoint1.Name = "bSelectManaPoint1";
            this.bSelectManaPoint1.Size = new System.Drawing.Size(46, 23);
            this.bSelectManaPoint1.TabIndex = 23;
            this.bSelectManaPoint1.Text = "Select";
            this.bSelectManaPoint1.UseVisualStyleBackColor = true;
            this.bSelectManaPoint1.Click += new System.EventHandler(this.bSelectManaPoint1_Click);
            // 
            // bSelectPlayerCounter1
            // 
            this.bSelectPlayerCounter1.Location = new System.Drawing.Point(162, 45);
            this.bSelectPlayerCounter1.Name = "bSelectPlayerCounter1";
            this.bSelectPlayerCounter1.Size = new System.Drawing.Size(46, 23);
            this.bSelectPlayerCounter1.TabIndex = 22;
            this.bSelectPlayerCounter1.Text = "Select";
            this.bSelectPlayerCounter1.UseVisualStyleBackColor = true;
            this.bSelectPlayerCounter1.Click += new System.EventHandler(this.bSelectPlayerCounter1_Click);
            // 
            // cbCounters1
            // 
            this.cbCounters1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCounters1.FormattingEnabled = true;
            this.cbCounters1.Location = new System.Drawing.Point(64, 47);
            this.cbCounters1.Name = "cbCounters1";
            this.cbCounters1.Size = new System.Drawing.Size(92, 21);
            this.cbCounters1.TabIndex = 21;
            // 
            // lblManapool
            // 
            this.lblManapool.AutoSize = true;
            this.lblManapool.Location = new System.Drawing.Point(6, 86);
            this.lblManapool.Name = "lblManapool";
            this.lblManapool.Size = new System.Drawing.Size(57, 13);
            this.lblManapool.TabIndex = 18;
            this.lblManapool.Text = "Manapool:";
            // 
            // lblCounters1
            // 
            this.lblCounters1.AutoSize = true;
            this.lblCounters1.Location = new System.Drawing.Point(6, 50);
            this.lblCounters1.Name = "lblCounters1";
            this.lblCounters1.Size = new System.Drawing.Size(52, 13);
            this.lblCounters1.TabIndex = 17;
            this.lblCounters1.Text = "Counters:";
            // 
            // lblLife1
            // 
            this.lblLife1.AutoSize = true;
            this.lblLife1.Location = new System.Drawing.Point(39, 22);
            this.lblLife1.Name = "lblLife1";
            this.lblLife1.Size = new System.Drawing.Size(13, 13);
            this.lblLife1.TabIndex = 17;
            this.lblLife1.Text = "0";
            // 
            // lblUILife1
            // 
            this.lblUILife1.AutoSize = true;
            this.lblUILife1.Location = new System.Drawing.Point(6, 22);
            this.lblUILife1.Name = "lblUILife1";
            this.lblUILife1.Size = new System.Drawing.Size(27, 13);
            this.lblUILife1.TabIndex = 15;
            this.lblUILife1.Text = "Life:";
            // 
            // grpCardDetail
            // 
            this.grpCardDetail.Controls.Add(this.lblPowerToughness);
            this.grpCardDetail.Controls.Add(this.bSelectCardCounter);
            this.grpCardDetail.Controls.Add(this.lblCardDetailID);
            this.grpCardDetail.Controls.Add(this.tbCardDetailText);
            this.grpCardDetail.Controls.Add(this.cbCardDetailCounters);
            this.grpCardDetail.Controls.Add(this.lblUICardDetailCounters);
            this.grpCardDetail.Controls.Add(this.lblCardDetailName);
            this.grpCardDetail.Location = new System.Drawing.Point(766, 12);
            this.grpCardDetail.Name = "grpCardDetail";
            this.grpCardDetail.Size = new System.Drawing.Size(230, 320);
            this.grpCardDetail.TabIndex = 20;
            this.grpCardDetail.TabStop = false;
            this.grpCardDetail.Text = "Card Detail";
            // 
            // lblPowerToughness
            // 
            this.lblPowerToughness.AutoSize = true;
            this.lblPowerToughness.Location = new System.Drawing.Point(173, 294);
            this.lblPowerToughness.Name = "lblPowerToughness";
            this.lblPowerToughness.Size = new System.Drawing.Size(35, 13);
            this.lblPowerToughness.TabIndex = 26;
            this.lblPowerToughness.Text = "label1";
            // 
            // bSelectCardCounter
            // 
            this.bSelectCardCounter.Location = new System.Drawing.Point(162, 30);
            this.bSelectCardCounter.Name = "bSelectCardCounter";
            this.bSelectCardCounter.Size = new System.Drawing.Size(46, 23);
            this.bSelectCardCounter.TabIndex = 24;
            this.bSelectCardCounter.Text = "Select";
            this.bSelectCardCounter.UseVisualStyleBackColor = true;
            this.bSelectCardCounter.Click += new System.EventHandler(this.bSelectCardCounter_Click);
            // 
            // lblCardDetailID
            // 
            this.lblCardDetailID.AutoSize = true;
            this.lblCardDetailID.Location = new System.Drawing.Point(189, 16);
            this.lblCardDetailID.Name = "lblCardDetailID";
            this.lblCardDetailID.Size = new System.Drawing.Size(35, 13);
            this.lblCardDetailID.TabIndex = 25;
            this.lblCardDetailID.Text = "label1";
            // 
            // tbCardDetailText
            // 
            this.tbCardDetailText.Location = new System.Drawing.Point(9, 59);
            this.tbCardDetailText.Multiline = true;
            this.tbCardDetailText.Name = "tbCardDetailText";
            this.tbCardDetailText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCardDetailText.Size = new System.Drawing.Size(215, 229);
            this.tbCardDetailText.TabIndex = 24;
            // 
            // cbCardDetailCounters
            // 
            this.cbCardDetailCounters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardDetailCounters.FormattingEnabled = true;
            this.cbCardDetailCounters.Location = new System.Drawing.Point(64, 32);
            this.cbCardDetailCounters.Name = "cbCardDetailCounters";
            this.cbCardDetailCounters.Size = new System.Drawing.Size(92, 21);
            this.cbCardDetailCounters.TabIndex = 23;
            // 
            // lblUICardDetailCounters
            // 
            this.lblUICardDetailCounters.AutoSize = true;
            this.lblUICardDetailCounters.Location = new System.Drawing.Point(6, 35);
            this.lblUICardDetailCounters.Name = "lblUICardDetailCounters";
            this.lblUICardDetailCounters.Size = new System.Drawing.Size(52, 13);
            this.lblUICardDetailCounters.TabIndex = 22;
            this.lblUICardDetailCounters.Text = "Counters:";
            // 
            // lblCardDetailName
            // 
            this.lblCardDetailName.AutoSize = true;
            this.lblCardDetailName.Location = new System.Drawing.Point(8, 16);
            this.lblCardDetailName.Name = "lblCardDetailName";
            this.lblCardDetailName.Size = new System.Drawing.Size(35, 13);
            this.lblCardDetailName.TabIndex = 0;
            this.lblCardDetailName.Text = "label2";
            // 
            // tcArea2
            // 
            this.tcArea2.Controls.Add(this.tpLibrary2);
            this.tcArea2.Controls.Add(this.tpHand2);
            this.tcArea2.Controls.Add(this.tpBattlefield2);
            this.tcArea2.Controls.Add(this.tpGraveyard2);
            this.tcArea2.Controls.Add(this.tpExile2);
            this.tcArea2.Controls.Add(this.tpCommand2);
            this.tcArea2.Location = new System.Drawing.Point(228, 12);
            this.tcArea2.Name = "tcArea2";
            this.tcArea2.SelectedIndex = 0;
            this.tcArea2.Size = new System.Drawing.Size(544, 320);
            this.tcArea2.TabIndex = 21;
            // 
            // tpLibrary2
            // 
            this.tpLibrary2.Controls.Add(this.lvLibrary2);
            this.tpLibrary2.Location = new System.Drawing.Point(4, 22);
            this.tpLibrary2.Name = "tpLibrary2";
            this.tpLibrary2.Size = new System.Drawing.Size(536, 294);
            this.tpLibrary2.TabIndex = 4;
            this.tpLibrary2.Text = "Library";
            this.tpLibrary2.UseVisualStyleBackColor = true;
            // 
            // lvLibrary2
            // 
            this.lvLibrary2.HideSelection = false;
            this.lvLibrary2.Location = new System.Drawing.Point(3, 3);
            this.lvLibrary2.Name = "lvLibrary2";
            this.lvLibrary2.Size = new System.Drawing.Size(529, 288);
            this.lvLibrary2.TabIndex = 0;
            this.lvLibrary2.UseCompatibleStateImageBehavior = false;
            this.lvLibrary2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvLibrary2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpHand2
            // 
            this.tpHand2.Controls.Add(this.lvHand2);
            this.tpHand2.Location = new System.Drawing.Point(4, 22);
            this.tpHand2.Name = "tpHand2";
            this.tpHand2.Size = new System.Drawing.Size(536, 294);
            this.tpHand2.TabIndex = 5;
            this.tpHand2.Text = "Hand";
            this.tpHand2.UseVisualStyleBackColor = true;
            // 
            // lvHand2
            // 
            this.lvHand2.HideSelection = false;
            this.lvHand2.Location = new System.Drawing.Point(4, 3);
            this.lvHand2.Name = "lvHand2";
            this.lvHand2.Size = new System.Drawing.Size(529, 288);
            this.lvHand2.TabIndex = 1;
            this.lvHand2.UseCompatibleStateImageBehavior = false;
            this.lvHand2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvHand2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpBattlefield2
            // 
            this.tpBattlefield2.Controls.Add(this.lvBattlefield2);
            this.tpBattlefield2.Location = new System.Drawing.Point(4, 22);
            this.tpBattlefield2.Name = "tpBattlefield2";
            this.tpBattlefield2.Padding = new System.Windows.Forms.Padding(3);
            this.tpBattlefield2.Size = new System.Drawing.Size(536, 294);
            this.tpBattlefield2.TabIndex = 0;
            this.tpBattlefield2.Text = "Battlefield";
            this.tpBattlefield2.UseVisualStyleBackColor = true;
            // 
            // lvBattlefield2
            // 
            this.lvBattlefield2.HideSelection = false;
            this.lvBattlefield2.Location = new System.Drawing.Point(0, 0);
            this.lvBattlefield2.Name = "lvBattlefield2";
            this.lvBattlefield2.Size = new System.Drawing.Size(533, 294);
            this.lvBattlefield2.TabIndex = 2;
            this.lvBattlefield2.UseCompatibleStateImageBehavior = false;
            this.lvBattlefield2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvBattlefield2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpGraveyard2
            // 
            this.tpGraveyard2.Controls.Add(this.lvGraveyard2);
            this.tpGraveyard2.Location = new System.Drawing.Point(4, 22);
            this.tpGraveyard2.Name = "tpGraveyard2";
            this.tpGraveyard2.Padding = new System.Windows.Forms.Padding(3);
            this.tpGraveyard2.Size = new System.Drawing.Size(536, 294);
            this.tpGraveyard2.TabIndex = 1;
            this.tpGraveyard2.Text = "Graveyard";
            this.tpGraveyard2.UseVisualStyleBackColor = true;
            // 
            // lvGraveyard2
            // 
            this.lvGraveyard2.HideSelection = false;
            this.lvGraveyard2.Location = new System.Drawing.Point(0, 0);
            this.lvGraveyard2.Name = "lvGraveyard2";
            this.lvGraveyard2.Size = new System.Drawing.Size(536, 292);
            this.lvGraveyard2.TabIndex = 0;
            this.lvGraveyard2.UseCompatibleStateImageBehavior = false;
            this.lvGraveyard2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvGraveyard2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpExile2
            // 
            this.tpExile2.Controls.Add(this.lvExile2);
            this.tpExile2.Location = new System.Drawing.Point(4, 22);
            this.tpExile2.Name = "tpExile2";
            this.tpExile2.Size = new System.Drawing.Size(536, 294);
            this.tpExile2.TabIndex = 2;
            this.tpExile2.Text = "Exile";
            this.tpExile2.UseVisualStyleBackColor = true;
            // 
            // lvExile2
            // 
            this.lvExile2.HideSelection = false;
            this.lvExile2.Location = new System.Drawing.Point(0, 0);
            this.lvExile2.Name = "lvExile2";
            this.lvExile2.Size = new System.Drawing.Size(533, 291);
            this.lvExile2.TabIndex = 0;
            this.lvExile2.UseCompatibleStateImageBehavior = false;
            this.lvExile2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvExile2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // tpCommand2
            // 
            this.tpCommand2.Controls.Add(this.lvCommand2);
            this.tpCommand2.Location = new System.Drawing.Point(4, 22);
            this.tpCommand2.Name = "tpCommand2";
            this.tpCommand2.Size = new System.Drawing.Size(536, 294);
            this.tpCommand2.TabIndex = 3;
            this.tpCommand2.Text = "Command";
            this.tpCommand2.UseVisualStyleBackColor = true;
            // 
            // lvCommand2
            // 
            this.lvCommand2.HideSelection = false;
            this.lvCommand2.Location = new System.Drawing.Point(3, 0);
            this.lvCommand2.Name = "lvCommand2";
            this.lvCommand2.Size = new System.Drawing.Size(530, 291);
            this.lvCommand2.TabIndex = 0;
            this.lvCommand2.UseCompatibleStateImageBehavior = false;
            this.lvCommand2.SelectedIndexChanged += new System.EventHandler(this.lvZone_SelectedIndexChanged);
            this.lvCommand2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvZone_MouseDown);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tcArea2);
            this.Controls.Add(this.grpCardDetail);
            this.Controls.Add(this.grpPlayer1);
            this.Controls.Add(this.grpPlayer2);
            this.Controls.Add(this.tcArea1);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.lvHand1);
            this.Controls.Add(this.lbStack);
            this.Name = "MatchForm";
            this.Text = "Sharpening horrible very bad no good \"UI\"";
            this.tcArea1.ResumeLayout(false);
            this.tpLibrary1.ResumeLayout(false);
            this.tpBattlefield.ResumeLayout(false);
            this.tpGraveyard.ResumeLayout(false);
            this.tpExile.ResumeLayout(false);
            this.tpCommand.ResumeLayout(false);
            this.grpPlayer2.ResumeLayout(false);
            this.grpPlayer2.PerformLayout();
            this.grpPlayer1.ResumeLayout(false);
            this.grpPlayer1.PerformLayout();
            this.grpCardDetail.ResumeLayout(false);
            this.grpCardDetail.PerformLayout();
            this.tcArea2.ResumeLayout(false);
            this.tpLibrary2.ResumeLayout(false);
            this.tpHand2.ResumeLayout(false);
            this.tpBattlefield2.ResumeLayout(false);
            this.tpGraveyard2.ResumeLayout(false);
            this.tpExile2.ResumeLayout(false);
            this.tpCommand2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbStack;
        private System.Windows.Forms.ListView lvBattlefield1;
        private System.Windows.Forms.ListView lvHand1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.ComboBox cbManaPool1;
        private System.Windows.Forms.ComboBox cbManaPool2;
        private System.Windows.Forms.TabControl tcArea1;
        private System.Windows.Forms.TabPage tpBattlefield;
        private System.Windows.Forms.TabPage tpGraveyard;
        private System.Windows.Forms.TabPage tpExile;
        private System.Windows.Forms.TabPage tpCommand;
        private System.Windows.Forms.GroupBox grpPlayer2;
        private System.Windows.Forms.ComboBox cbCounters2;
        private System.Windows.Forms.Label lblUIManapool2;
        private System.Windows.Forms.Label lblLife2;
        private System.Windows.Forms.Label lblUILife2;
        private System.Windows.Forms.Label lblUICounters2;
        private System.Windows.Forms.GroupBox grpPlayer1;
        private System.Windows.Forms.ComboBox cbCounters1;
        private System.Windows.Forms.Label lblManapool;
        private System.Windows.Forms.Label lblCounters1;
        private System.Windows.Forms.Label lblLife1;
        private System.Windows.Forms.Label lblUILife1;
        private System.Windows.Forms.GroupBox grpCardDetail;
        private System.Windows.Forms.ComboBox cbCardDetailCounters;
        private System.Windows.Forms.Label lblUICardDetailCounters;
        private System.Windows.Forms.Label lblCardDetailName;
        private System.Windows.Forms.Label lblCardDetailID;
        private System.Windows.Forms.TextBox tbCardDetailText;
        private System.Windows.Forms.TabPage tpLibrary1;
        private System.Windows.Forms.ListView lvLibrary1;
        private System.Windows.Forms.ListView lvGraveyard1;
        private System.Windows.Forms.ListView lvExile1;
        private System.Windows.Forms.ListView lvCommand1;
        private System.Windows.Forms.TabControl tcArea2;
        private System.Windows.Forms.TabPage tpLibrary2;
        private System.Windows.Forms.ListView lvLibrary2;
        private System.Windows.Forms.TabPage tpBattlefield2;
        private System.Windows.Forms.ListView lvBattlefield2;
        private System.Windows.Forms.TabPage tpGraveyard2;
        private System.Windows.Forms.ListView lvGraveyard2;
        private System.Windows.Forms.TabPage tpExile2;
        private System.Windows.Forms.ListView lvExile2;
        private System.Windows.Forms.TabPage tpCommand2;
        private System.Windows.Forms.ListView lvCommand2;
        private System.Windows.Forms.TabPage tpHand2;
        private System.Windows.Forms.ListView lvHand2;
        private System.Windows.Forms.Button bSelectManaPoint2;
        private System.Windows.Forms.Button bSelectPlayerCounter2;
        private System.Windows.Forms.Button bSelectManaPoint1;
        private System.Windows.Forms.Button bSelectPlayerCounter1;
        private System.Windows.Forms.Button bSelectCardCounter;
        private System.Windows.Forms.Label lblPowerToughness;
    }
}

