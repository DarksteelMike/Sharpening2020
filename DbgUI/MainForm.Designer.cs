namespace DbgUI
{
    partial class MainForm
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
            this.bNew = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bUndo = new System.Windows.Forms.Button();
            this.bRedo = new System.Windows.Forms.Button();
            this.lblUIDebugMode = new System.Windows.Forms.Label();
            this.cbDbgCardViews = new System.Windows.Forms.CheckBox();
            this.cbDbgCommands = new System.Windows.Forms.CheckBox();
            this.cbDbgContinuousEffects = new System.Windows.Forms.CheckBox();
            this.cbDbgInputStates = new System.Windows.Forms.CheckBox();
            this.cbDbgMana = new System.Windows.Forms.CheckBox();
            this.cbDbgPhases = new System.Windows.Forms.CheckBox();
            this.cbDbgTriggers = new System.Windows.Forms.CheckBox();
            this.sfdSaveReplay = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoadReplay = new System.Windows.Forms.OpenFileDialog();
            this.bReplay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(16, 15);
            this.bNew.Margin = new System.Windows.Forms.Padding(4);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(128, 28);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "New";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bSave
            // 
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(16, 50);
            this.bSave.Margin = new System.Windows.Forms.Padding(4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(128, 28);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(16, 86);
            this.bLoad.Margin = new System.Windows.Forms.Padding(4);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(128, 28);
            this.bLoad.TabIndex = 2;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bUndo
            // 
            this.bUndo.Enabled = false;
            this.bUndo.Location = new System.Drawing.Point(16, 158);
            this.bUndo.Margin = new System.Windows.Forms.Padding(4);
            this.bUndo.Name = "bUndo";
            this.bUndo.Size = new System.Drawing.Size(128, 28);
            this.bUndo.TabIndex = 3;
            this.bUndo.Text = "Undo";
            this.bUndo.UseVisualStyleBackColor = true;
            this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
            // 
            // bRedo
            // 
            this.bRedo.Enabled = false;
            this.bRedo.Location = new System.Drawing.Point(16, 194);
            this.bRedo.Margin = new System.Windows.Forms.Padding(4);
            this.bRedo.Name = "bRedo";
            this.bRedo.Size = new System.Drawing.Size(128, 28);
            this.bRedo.TabIndex = 4;
            this.bRedo.Text = "Redo";
            this.bRedo.UseVisualStyleBackColor = true;
            this.bRedo.Click += new System.EventHandler(this.bRedo_Click);
            // 
            // lblUIDebugMode
            // 
            this.lblUIDebugMode.AutoSize = true;
            this.lblUIDebugMode.Location = new System.Drawing.Point(152, 11);
            this.lblUIDebugMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUIDebugMode.Name = "lblUIDebugMode";
            this.lblUIDebugMode.Size = new System.Drawing.Size(100, 17);
            this.lblUIDebugMode.TabIndex = 6;
            this.lblUIDebugMode.Text = "Debug Modes:";
            // 
            // cbDbgCardViews
            // 
            this.cbDbgCardViews.AutoSize = true;
            this.cbDbgCardViews.Location = new System.Drawing.Point(156, 31);
            this.cbDbgCardViews.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgCardViews.Name = "cbDbgCardViews";
            this.cbDbgCardViews.Size = new System.Drawing.Size(96, 21);
            this.cbDbgCardViews.TabIndex = 7;
            this.cbDbgCardViews.Text = "CardViews";
            this.cbDbgCardViews.UseVisualStyleBackColor = true;
            // 
            // cbDbgCommands
            // 
            this.cbDbgCommands.AutoSize = true;
            this.cbDbgCommands.Location = new System.Drawing.Point(156, 55);
            this.cbDbgCommands.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgCommands.Name = "cbDbgCommands";
            this.cbDbgCommands.Size = new System.Drawing.Size(100, 21);
            this.cbDbgCommands.TabIndex = 8;
            this.cbDbgCommands.Text = "Commands";
            this.cbDbgCommands.UseVisualStyleBackColor = true;
            // 
            // cbDbgContinuousEffects
            // 
            this.cbDbgContinuousEffects.AutoSize = true;
            this.cbDbgContinuousEffects.Location = new System.Drawing.Point(156, 84);
            this.cbDbgContinuousEffects.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgContinuousEffects.Name = "cbDbgContinuousEffects";
            this.cbDbgContinuousEffects.Size = new System.Drawing.Size(144, 21);
            this.cbDbgContinuousEffects.TabIndex = 9;
            this.cbDbgContinuousEffects.Text = "ContinuousEffects";
            this.cbDbgContinuousEffects.UseVisualStyleBackColor = true;
            // 
            // cbDbgInputStates
            // 
            this.cbDbgInputStates.AutoSize = true;
            this.cbDbgInputStates.Location = new System.Drawing.Point(156, 107);
            this.cbDbgInputStates.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgInputStates.Name = "cbDbgInputStates";
            this.cbDbgInputStates.Size = new System.Drawing.Size(101, 21);
            this.cbDbgInputStates.TabIndex = 10;
            this.cbDbgInputStates.Text = "InputStates";
            this.cbDbgInputStates.UseVisualStyleBackColor = true;
            // 
            // cbDbgMana
            // 
            this.cbDbgMana.AutoSize = true;
            this.cbDbgMana.Location = new System.Drawing.Point(156, 127);
            this.cbDbgMana.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgMana.Name = "cbDbgMana";
            this.cbDbgMana.Size = new System.Drawing.Size(65, 21);
            this.cbDbgMana.TabIndex = 11;
            this.cbDbgMana.Text = "Mana";
            this.cbDbgMana.UseVisualStyleBackColor = true;
            // 
            // cbDbgPhases
            // 
            this.cbDbgPhases.AutoSize = true;
            this.cbDbgPhases.Location = new System.Drawing.Point(156, 155);
            this.cbDbgPhases.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgPhases.Name = "cbDbgPhases";
            this.cbDbgPhases.Size = new System.Drawing.Size(77, 21);
            this.cbDbgPhases.TabIndex = 12;
            this.cbDbgPhases.Text = "Phases";
            this.cbDbgPhases.UseVisualStyleBackColor = true;
            // 
            // cbDbgTriggers
            // 
            this.cbDbgTriggers.AutoSize = true;
            this.cbDbgTriggers.Location = new System.Drawing.Point(156, 183);
            this.cbDbgTriggers.Margin = new System.Windows.Forms.Padding(4);
            this.cbDbgTriggers.Name = "cbDbgTriggers";
            this.cbDbgTriggers.Size = new System.Drawing.Size(83, 21);
            this.cbDbgTriggers.TabIndex = 13;
            this.cbDbgTriggers.Text = "Triggers";
            this.cbDbgTriggers.UseVisualStyleBackColor = true;
            // 
            // ofdLoadReplay
            // 
            this.ofdLoadReplay.FileName = "openFileDialog1";
            // 
            // bReplay
            // 
            this.bReplay.Location = new System.Drawing.Point(20, 122);
            this.bReplay.Margin = new System.Windows.Forms.Padding(4);
            this.bReplay.Name = "bReplay";
            this.bReplay.Size = new System.Drawing.Size(128, 28);
            this.bReplay.TabIndex = 14;
            this.bReplay.Text = "Replay";
            this.bReplay.UseVisualStyleBackColor = true;
            this.bReplay.Click += new System.EventHandler(this.bReplay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 276);
            this.Controls.Add(this.bReplay);
            this.Controls.Add(this.cbDbgTriggers);
            this.Controls.Add(this.cbDbgPhases);
            this.Controls.Add(this.cbDbgMana);
            this.Controls.Add(this.cbDbgInputStates);
            this.Controls.Add(this.cbDbgContinuousEffects);
            this.Controls.Add(this.cbDbgCommands);
            this.Controls.Add(this.cbDbgCardViews);
            this.Controls.Add(this.lblUIDebugMode);
            this.Controls.Add(this.bRedo);
            this.Controls.Add(this.bUndo);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bNew);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bUndo;
        private System.Windows.Forms.Button bRedo;
        private System.Windows.Forms.Label lblUIDebugMode;
        private System.Windows.Forms.CheckBox cbDbgCardViews;
        private System.Windows.Forms.CheckBox cbDbgCommands;
        private System.Windows.Forms.CheckBox cbDbgContinuousEffects;
        private System.Windows.Forms.CheckBox cbDbgInputStates;
        private System.Windows.Forms.CheckBox cbDbgMana;
        private System.Windows.Forms.CheckBox cbDbgPhases;
        private System.Windows.Forms.CheckBox cbDbgTriggers;
        private System.Windows.Forms.SaveFileDialog sfdSaveReplay;
        private System.Windows.Forms.OpenFileDialog ofdLoadReplay;
        private System.Windows.Forms.Button bReplay;
    }
}