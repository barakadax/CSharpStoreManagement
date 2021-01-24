namespace genericsForm {
    partial class saveMsg {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(saveMsg));
            this.savelbl = new System.Windows.Forms.Label();
            this.conBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // savelbl
            // 
            this.savelbl.AutoSize = true;
            this.savelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.savelbl.Location = new System.Drawing.Point(12, 9);
            this.savelbl.Name = "savelbl";
            this.savelbl.Size = new System.Drawing.Size(29, 31);
            this.savelbl.TabIndex = 0;
            this.savelbl.Text = "a";
            // 
            // conBtn
            // 
            this.conBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.conBtn.Location = new System.Drawing.Point(196, 293);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(153, 145);
            this.conBtn.TabIndex = 1;
            this.conBtn.Text = "Continue";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // saveMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.Controls.Add(this.conBtn);
            this.Controls.Add(this.savelbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "saveMsg";
            this.Text = "thanks for saving";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label savelbl;
        private System.Windows.Forms.Button conBtn;
    }
}