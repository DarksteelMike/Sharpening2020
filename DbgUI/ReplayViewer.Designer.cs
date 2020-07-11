namespace DbgUI
{
    partial class ReplayViewer
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
            this.lbReplay = new System.Windows.Forms.ListBox();
            this.bDo = new System.Windows.Forms.Button();
            this.bUndo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbReplay
            // 
            this.lbReplay.FormattingEnabled = true;
            this.lbReplay.Location = new System.Drawing.Point(12, 12);
            this.lbReplay.Name = "lbReplay";
            this.lbReplay.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbReplay.Size = new System.Drawing.Size(287, 433);
            this.lbReplay.TabIndex = 0;
            // 
            // bDo
            // 
            this.bDo.Location = new System.Drawing.Point(305, 12);
            this.bDo.Name = "bDo";
            this.bDo.Size = new System.Drawing.Size(75, 23);
            this.bDo.TabIndex = 1;
            this.bDo.Text = "Do";
            this.bDo.UseVisualStyleBackColor = true;
            this.bDo.Click += new System.EventHandler(this.bDo_Click);
            // 
            // bUndo
            // 
            this.bUndo.Location = new System.Drawing.Point(305, 41);
            this.bUndo.Name = "bUndo";
            this.bUndo.Size = new System.Drawing.Size(75, 23);
            this.bUndo.TabIndex = 2;
            this.bUndo.Text = "Undo";
            this.bUndo.UseVisualStyleBackColor = true;
            // 
            // ReplayViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.bUndo);
            this.Controls.Add(this.bDo);
            this.Controls.Add(this.lbReplay);
            this.Name = "ReplayViewer";
            this.Text = "ReplayViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbReplay;
        private System.Windows.Forms.Button bDo;
        private System.Windows.Forms.Button bUndo;
    }
}