namespace practica
{
    partial class FormAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.countryButton = new System.Windows.Forms.Button();
            this.nationButton = new System.Windows.Forms.Button();
            this.populationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Добро пожаловать! ";
            // 
            // countryButton
            // 
            this.countryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.countryButton.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.countryButton.Location = new System.Drawing.Point(-2, 109);
            this.countryButton.Name = "countryButton";
            this.countryButton.Size = new System.Drawing.Size(804, 56);
            this.countryButton.TabIndex = 2;
            this.countryButton.Text = "Страна";
            this.countryButton.UseVisualStyleBackColor = true;
            this.countryButton.Click += new System.EventHandler(this.countryButton_Click);
            // 
            // nationButton
            // 
            this.nationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nationButton.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.nationButton.Location = new System.Drawing.Point(-2, 197);
            this.nationButton.Name = "nationButton";
            this.nationButton.Size = new System.Drawing.Size(804, 56);
            this.nationButton.TabIndex = 3;
            this.nationButton.Text = "Национальность";
            this.nationButton.UseVisualStyleBackColor = true;
            this.nationButton.Click += new System.EventHandler(this.nationButton_Click);
            // 
            // populationButton
            // 
            this.populationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.populationButton.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold);
            this.populationButton.Location = new System.Drawing.Point(-2, 281);
            this.populationButton.Name = "populationButton";
            this.populationButton.Size = new System.Drawing.Size(804, 56);
            this.populationButton.TabIndex = 4;
            this.populationButton.Text = "Население";
            this.populationButton.UseVisualStyleBackColor = true;
            this.populationButton.Click += new System.EventHandler(this.populationButton_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.populationButton);
            this.Controls.Add(this.nationButton);
            this.Controls.Add(this.countryButton);
            this.Controls.Add(this.label1);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button countryButton;
        private System.Windows.Forms.Button nationButton;
        private System.Windows.Forms.Button populationButton;
    }
}