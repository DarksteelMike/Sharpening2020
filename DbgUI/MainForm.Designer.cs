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
            this.cbDebugMode = new System.Windows.Forms.ComboBox();
            this.lblUIDebugMode = new System.Windows.Forms.Label();
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
            // cbDebugMode
            // 
            this.cbDebugMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDebugMode.FormattingEnabled = true;
            this.cbDebugMode.Location = new System.Drawing.Point(114, 25);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(85, 21);
            this.cbDebugMode.TabIndex = 5;
            // 
            // lblUIDebugMode
            // 
            this.lblUIDebugMode.AutoSize = true;
            this.lblUIDebugMode.Location = new System.Drawing.Point(114, 9);
            this.lblUIDebugMode.Name = "lblUIDebugMode";
            this.lblUIDebugMode.Size = new System.Drawing.Size(72, 13);
            this.lblUIDebugMode.TabIndex = 6;
            this.lblUIDebugMode.Text = "Debug Mode:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 164);
            this.Controls.Add(this.lblUIDebugMode);
            this.Controls.Add(this.cbDebugMode);
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
        private System.Windows.Forms.ComboBox cbDebugMode;
        private System.Windows.Forms.Label lblUIDebugMode;
    }
}