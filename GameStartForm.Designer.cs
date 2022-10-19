namespace YazLab1
{
    partial class GameStartForm
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
            this.btnOyna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOyna
            // 
            this.btnOyna.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOyna.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOyna.Location = new System.Drawing.Point(339, 618);
            this.btnOyna.Margin = new System.Windows.Forms.Padding(2);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(401, 104);
            this.btnOyna.TabIndex = 0;
            this.btnOyna.Text = "Oyna (TIKLA)";
            this.btnOyna.UseVisualStyleBackColor = false;
            this.btnOyna.Click += new System.EventHandler(this.BtnOyna_Click);
            // 
            // GameStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1077, 735);
            this.Controls.Add(this.btnOyna);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameStartForm";
            this.Text = "ALTIN TOPLAMA OYUNU";
            this.Load += new System.EventHandler(this.GameStartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOyna;
    }
}