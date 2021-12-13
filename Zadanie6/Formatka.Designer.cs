namespace HopfieldaSiec
{
    partial class Formatka
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
            this.pictureBoxPoletko = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BazaObrazowListView = new System.Windows.Forms.ListView();
            this.DodajObrazDoBazyButton = new System.Windows.Forms.Button();
            this.ObrazRozpoznajButton = new System.Windows.Forms.Button();
            this.informacjeLabel = new System.Windows.Forms.Label();
            this.ObrazNauczButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoletko)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPoletko
            // 
            this.pictureBoxPoletko.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxPoletko.Name = "pictureBoxPoletko";
            this.pictureBoxPoletko.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxPoletko.TabIndex = 0;
            this.pictureBoxPoletko.TabStop = false;
            this.pictureBoxPoletko.Click += new System.EventHandler(this.pictureBoxPoletko_Click);
            this.pictureBoxPoletko.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPoletko_MouseClick);
            this.pictureBoxPoletko.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPoletko_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxPoletko);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Poletko, rysuj myszką";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BazaObrazowListView);
            this.groupBox2.Location = new System.Drawing.Point(182, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 177);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baza obrazow, notatki";
            // 
            // BazaObrazowListView
            // 
            this.BazaObrazowListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BazaObrazowListView.HideSelection = false;
            this.BazaObrazowListView.Location = new System.Drawing.Point(3, 16);
            this.BazaObrazowListView.MultiSelect = false;
            this.BazaObrazowListView.Name = "BazaObrazowListView";
            this.BazaObrazowListView.Size = new System.Drawing.Size(194, 158);
            this.BazaObrazowListView.TabIndex = 9;
            this.BazaObrazowListView.UseCompatibleStateImageBehavior = false;
            this.BazaObrazowListView.Click += new System.EventHandler(this.BazaObrazowListView_Click);
            // 
            // DodajObrazDoBazyButton
            // 
            this.DodajObrazDoBazyButton.Location = new System.Drawing.Point(12, 195);
            this.DodajObrazDoBazyButton.Name = "DodajObrazDoBazyButton";
            this.DodajObrazDoBazyButton.Size = new System.Drawing.Size(75, 35);
            this.DodajObrazDoBazyButton.TabIndex = 6;
            this.DodajObrazDoBazyButton.Text = "Dodaj obraz do bazy";
            this.DodajObrazDoBazyButton.UseVisualStyleBackColor = true;
            this.DodajObrazDoBazyButton.Click += new System.EventHandler(this.DodajObrazDoBazyButton_Click);
            // 
            // ObrazRozpoznajButton
            // 
            this.ObrazRozpoznajButton.Location = new System.Drawing.Point(182, 195);
            this.ObrazRozpoznajButton.Name = "ObrazRozpoznajButton";
            this.ObrazRozpoznajButton.Size = new System.Drawing.Size(83, 35);
            this.ObrazRozpoznajButton.TabIndex = 7;
            this.ObrazRozpoznajButton.Text = "Obraz rozpoznaj";
            this.ObrazRozpoznajButton.UseVisualStyleBackColor = true;
            this.ObrazRozpoznajButton.Click += new System.EventHandler(this.ObrazRozpoznajButton_Click);
            // 
            // informacjeLabel
            // 
            this.informacjeLabel.AutoSize = true;
            this.informacjeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.informacjeLabel.Location = new System.Drawing.Point(108, 256);
            this.informacjeLabel.Name = "informacjeLabel";
            this.informacjeLabel.Size = new System.Drawing.Size(143, 24);
            this.informacjeLabel.TabIndex = 8;
            this.informacjeLabel.Text = "informacjeLabel";
            // 
            // ObrazNauczButton
            // 
            this.ObrazNauczButton.Location = new System.Drawing.Point(93, 195);
            this.ObrazNauczButton.Name = "ObrazNauczButton";
            this.ObrazNauczButton.Size = new System.Drawing.Size(83, 35);
            this.ObrazNauczButton.TabIndex = 9;
            this.ObrazNauczButton.Text = "Obraz naucz";
            this.ObrazNauczButton.UseVisualStyleBackColor = true;
            this.ObrazNauczButton.Click += new System.EventHandler(this.ObrazNauczButton_Click);
            // 
            // Formatka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 304);
            this.Controls.Add(this.ObrazNauczButton);
            this.Controls.Add(this.informacjeLabel);
            this.Controls.Add(this.ObrazRozpoznajButton);
            this.Controls.Add(this.DodajObrazDoBazyButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Formatka";
            this.Text = "Formatka";
            this.Load += new System.EventHandler(this.Formatka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoletko)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPoletko;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DodajObrazDoBazyButton;
        private System.Windows.Forms.Button ObrazRozpoznajButton;
        private System.Windows.Forms.Label informacjeLabel;
        private System.Windows.Forms.ListView BazaObrazowListView;
        private System.Windows.Forms.Button ObrazNauczButton;
    }
}

