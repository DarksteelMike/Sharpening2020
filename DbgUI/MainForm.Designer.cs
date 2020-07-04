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
            this.SuspendLayout();
            // 
            // bNew
            // 
            this.bNew.Location = new System.Drawing.Point(12, 12);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(96, 23);
            this.bNew.TabIndex = 0;
            this.bNew.Text = "New";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // bSave
            // 
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(12, 41);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(96, 23);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(12, 70);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(96, 23);
            this.bLoad.TabIndex = 2;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bUndo
            // 
            this.bUndo.Enabled = false;
            this.bUndo.Location = new System.Drawing.Point(12, 99);
            this.bUndo.Name = "bUndo";
            this.bUndo.Size = new System.Drawing.Size(96, 23);
            this.bUndo.TabIndex = 3;
            this.bUndo.Text = "Undo";
            this.bUndo.UseVisualStyleBackColor = true;
            this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
            // 
            // bRedo
            // 
            this.bRedo.Enabled = false;
            this.bRedo.Location = new System.Drawing.Point(12, 128);
            this.bRedo.Name = "bRedo";
            this.bRedo.Size = new System.Drawing.Size(96, 23);
            this.bRedo.TabIndex = 4;
            this.bRedo.Text = "Redo";
            this.bRedo.UseVisualStyleBackColor = true;
            this.bRedo.Click += new System.EventHandler(this.bRedo_Click);
            // 
            // lblUIDebugMode
            // 
            this.lblUIDebugMode.AutoSize = true;
            this.lblUIDebugMode.Location = new System.Drawing.Point(114, 9);
            this.lblUIDebugMode.Name = "lblUIDebugMode";
            this.lblUIDebugMode.Size = new System.Drawing.Size(77, 13);
            this.lblUIDebugMode.TabIndex = 6;
            this.lblUIDebugMode.Text = "Debug Modes:";
            // 
            // cbDbgCardViews
            // 
            this.cbDbgCardViews.AutoSize = true;
            this.cbDbgCardViews.Location = new System.Drawing.Point(117, 25);
            this.cbDbgCardViews.Name = "cbDbgCardViews";
            this.cbDbgCardViews.Size = new System.Drawing.Size(76, 17);
            this.cbDbgCardViews.TabIndex = 7;
            this.cbDbgCardViews.Text = "CardViews";
            this.cbDbgCardViews.UseVisualStyleBackColor = true;
            // 
            // cbDbgCommands
            // 
            this.cbDbgCommands.AutoSize = true;
            this.cbDbgCommands.Location = new System.Drawing.Point(117, 45);
            this.cbDbgCommands.Name = "cbDbgCommands";
            this.cbDbgCommands.Size = new System.Drawing.Size(78, 17);
            this.cbDbgCommands.TabIndex = 8;
            this.cbDbgCommands.Text = "Commands";
            this.cbDbgCommands.UseVisualStyleBackColor = true;
            // 
            // cbDbgContinuousEffects
            // 
            this.cbDbgContinuousEffects.AutoSize = true;
            this.cbDbgContinuousEffects.Location = new System.Drawing.Point(117, 68);
            this.cbDbgContinuousEffects.Name = "cbDbgContinuousEffects";
            this.cbDbgContinuousEffects.Size = new System.Drawing.Size(112, 17);
            this.cbDbgContinuousEffects.TabIndex = 9;
            this.cbDbgContinuousEffects.Text = "ContinuousEffects";
            this.cbDbgContinuousEffects.UseVisualStyleBackColor = true;
            // 
            // cbDbgInputStates
            // 
            this.cbDbgInputStates.AutoSize = true;
            this.cbDbgInputStates.Location = new System.Drawing.Point(117, 87);
            this.cbDbgInputStates.Name = "cbDbgInputStates";
            this.cbDbgInputStates.Size = new System.Drawing.Size(80, 17);
            this.cbDbgInputStates.TabIndex = 10;
            this.cbDbgInputStates.Text = "InputStates";
            this.cbDbgInputStates.UseVisualStyleBackColor = true;
            // 
            // cbDbgMana
            // 
            this.cbDbgMana.AutoSize = true;
            this.cbDbgMana.Location = new System.Drawing.Point(117, 103);
            this.cbDbgMana.Name = "cbDbgMana";
            this.cbDbgMana.Size = new System.Drawing.Size(53, 17);
            this.cbDbgMana.TabIndex = 11;
            this.cbDbgMana.Text = "Mana";
            this.cbDbgMana.UseVisualStyleBackColor = true;
            // 
            // cbDbgPhases
            // 
            this.cbDbgPhases.AutoSize = true;
            this.cbDbgPhases.Location = new System.Drawing.Point(117, 126);
            this.cbDbgPhases.Name = "cbDbgPhases";
            this.cbDbgPhases.Size = new System.Drawing.Size(61, 17);
            this.cbDbgPhases.TabIndex = 12;
            this.cbDbgPhases.Text = "Phases";
            this.cbDbgPhases.UseVisualStyleBackColor = true;
            // 
            // cbDbgTriggers
            // 
            this.cbDbgTriggers.AutoSize = true;
            this.cbDbgTriggers.Location = new System.Drawing.Point(117, 149);
            this.cbDbgTriggers.Name = "cbDbgTriggers";
            this.cbDbgTriggers.Size = new System.Drawing.Size(64, 17);
            this.cbDbgTriggers.TabIndex = 13;
            this.cbDbgTriggers.Text = "Triggers";
            this.cbDbgTriggers.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 174);
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
    }
}