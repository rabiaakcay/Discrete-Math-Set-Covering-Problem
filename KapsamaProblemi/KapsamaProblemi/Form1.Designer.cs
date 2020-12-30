namespace KapsamaProblemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnaTabloView = new System.Windows.Forms.DataGridView();
            this.lblSatir = new System.Windows.Forms.Label();
            this.lblSutun = new System.Windows.Forms.Label();
            this.btnTabloOlustur = new System.Windows.Forms.Button();
            this.btnSatirSil = new System.Windows.Forms.Button();
            this.btnSutunSil = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnMinKapasama = new System.Windows.Forms.Button();
            this.btnTumKapsama = new System.Windows.Forms.Button();
            this.txtBoxSatir = new System.Windows.Forms.TextBox();
            this.txtBoxSutun = new System.Windows.Forms.TextBox();
            this.gereksiz = new System.Windows.Forms.DataGridView();
            this.btnrota = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnonceki = new System.Windows.Forms.Button();
            this.btnbaslat = new System.Windows.Forms.Button();
            this.btngetir = new System.Windows.Forms.Button();
            this.btnsonraki = new System.Windows.Forms.Button();
            this.durumlar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minumumkapsamam = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.pndurum = new System.Windows.Forms.Panel();
            this.lbdurum = new System.Windows.Forms.Label();
            this.pnonceki = new System.Windows.Forms.Panel();
            this.lbonceki = new System.Windows.Forms.Label();
            this.pnsonraki = new System.Windows.Forms.Panel();
            this.lbsonraki = new System.Windows.Forms.Label();
            this.donceki = new System.Windows.Forms.DataGridView();
            this.dsonraki = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AnaTabloView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gereksiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.pndurum.SuspendLayout();
            this.pnonceki.SuspendLayout();
            this.pnsonraki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donceki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsonraki)).BeginInit();
            this.SuspendLayout();
            // 
            // AnaTabloView
            // 
            this.AnaTabloView.AllowUserToAddRows = false;
            this.AnaTabloView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnaTabloView.Location = new System.Drawing.Point(546, 12);
            this.AnaTabloView.Name = "AnaTabloView";
            this.AnaTabloView.RowTemplate.Height = 24;
            this.AnaTabloView.Size = new System.Drawing.Size(790, 293);
            this.AnaTabloView.TabIndex = 0;
            // 
            // lblSatir
            // 
            this.lblSatir.AutoSize = true;
            this.lblSatir.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSatir.Location = new System.Drawing.Point(2, 37);
            this.lblSatir.Name = "lblSatir";
            this.lblSatir.Size = new System.Drawing.Size(140, 27);
            this.lblSatir.TabIndex = 1;
            this.lblSatir.Text = "Satır Giriniz :";
            // 
            // lblSutun
            // 
            this.lblSutun.AutoSize = true;
            this.lblSutun.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSutun.Location = new System.Drawing.Point(2, 118);
            this.lblSutun.Name = "lblSutun";
            this.lblSutun.Size = new System.Drawing.Size(145, 27);
            this.lblSutun.TabIndex = 2;
            this.lblSutun.Text = "Sütun Giriniz :";
            // 
            // btnTabloOlustur
            // 
            this.btnTabloOlustur.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTabloOlustur.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTabloOlustur.Location = new System.Drawing.Point(132, 215);
            this.btnTabloOlustur.Name = "btnTabloOlustur";
            this.btnTabloOlustur.Size = new System.Drawing.Size(100, 80);
            this.btnTabloOlustur.TabIndex = 5;
            this.btnTabloOlustur.Text = "Tablo Oluştur";
            this.btnTabloOlustur.UseVisualStyleBackColor = false;
            this.btnTabloOlustur.Click += new System.EventHandler(this.btnTabloOlustur_Click);
            // 
            // btnSatirSil
            // 
            this.btnSatirSil.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSatirSil.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatirSil.Location = new System.Drawing.Point(284, 113);
            this.btnSatirSil.Name = "btnSatirSil";
            this.btnSatirSil.Size = new System.Drawing.Size(100, 80);
            this.btnSatirSil.TabIndex = 6;
            this.btnSatirSil.Text = "Satır Sil";
            this.btnSatirSil.UseVisualStyleBackColor = false;
            this.btnSatirSil.Click += new System.EventHandler(this.btnSatirSil_Click);
            // 
            // btnSutunSil
            // 
            this.btnSutunSil.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSutunSil.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSutunSil.Location = new System.Drawing.Point(428, 113);
            this.btnSutunSil.Name = "btnSutunSil";
            this.btnSutunSil.Size = new System.Drawing.Size(100, 80);
            this.btnSutunSil.TabIndex = 7;
            this.btnSutunSil.Text = "Sütun Sil";
            this.btnSutunSil.UseVisualStyleBackColor = false;
            this.btnSutunSil.Click += new System.EventHandler(this.btnSutunSil_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRandom.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRandom.Location = new System.Drawing.Point(284, 12);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(100, 80);
            this.btnRandom.TabIndex = 8;
            this.btnRandom.Text = "Random Değer";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnMinKapasama
            // 
            this.btnMinKapasama.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnMinKapasama.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMinKapasama.Location = new System.Drawing.Point(428, 214);
            this.btnMinKapasama.Name = "btnMinKapasama";
            this.btnMinKapasama.Size = new System.Drawing.Size(100, 80);
            this.btnMinKapasama.TabIndex = 9;
            this.btnMinKapasama.Text = "Minimum Kapsama";
            this.btnMinKapasama.UseVisualStyleBackColor = false;
            this.btnMinKapasama.Click += new System.EventHandler(this.btnMinKapasama_Click);
            // 
            // btnTumKapsama
            // 
            this.btnTumKapsama.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTumKapsama.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumKapsama.Location = new System.Drawing.Point(284, 214);
            this.btnTumKapsama.Name = "btnTumKapsama";
            this.btnTumKapsama.Size = new System.Drawing.Size(100, 80);
            this.btnTumKapsama.TabIndex = 10;
            this.btnTumKapsama.Text = "Tüm Kapsama";
            this.btnTumKapsama.UseVisualStyleBackColor = false;
            this.btnTumKapsama.Click += new System.EventHandler(this.btnTumKapsama_Click);
            // 
            // txtBoxSatir
            // 
            this.txtBoxSatir.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxSatir.Location = new System.Drawing.Point(158, 37);
            this.txtBoxSatir.Name = "txtBoxSatir";
            this.txtBoxSatir.Size = new System.Drawing.Size(102, 33);
            this.txtBoxSatir.TabIndex = 11;
            this.txtBoxSatir.Text = "6";
            // 
            // txtBoxSutun
            // 
            this.txtBoxSutun.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxSutun.Location = new System.Drawing.Point(158, 118);
            this.txtBoxSutun.Name = "txtBoxSutun";
            this.txtBoxSutun.Size = new System.Drawing.Size(102, 33);
            this.txtBoxSutun.TabIndex = 12;
            this.txtBoxSutun.Text = "6";
            // 
            // gereksiz
            // 
            this.gereksiz.AllowUserToAddRows = false;
            this.gereksiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gereksiz.Location = new System.Drawing.Point(746, 105);
            this.gereksiz.Name = "gereksiz";
            this.gereksiz.RowTemplate.Height = 24;
            this.gereksiz.Size = new System.Drawing.Size(156, 156);
            this.gereksiz.TabIndex = 15;
            this.gereksiz.Visible = false;
            // 
            // btnrota
            // 
            this.btnrota.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnrota.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnrota.Location = new System.Drawing.Point(428, 12);
            this.btnrota.Name = "btnrota";
            this.btnrota.Size = new System.Drawing.Size(100, 80);
            this.btnrota.TabIndex = 16;
            this.btnrota.Text = "Rotaya Git";
            this.btnrota.UseVisualStyleBackColor = false;
            this.btnrota.Click += new System.EventHandler(this.btnrota_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 322);
            this.label1.MaximumSize = new System.Drawing.Size(1324, 387);
            this.label1.MinimumSize = new System.Drawing.Size(1324, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1324, 387);
            this.label1.TabIndex = 17;
            // 
            // btnonceki
            // 
            this.btnonceki.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnonceki.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnonceki.Location = new System.Drawing.Point(38, 528);
            this.btnonceki.Name = "btnonceki";
            this.btnonceki.Size = new System.Drawing.Size(120, 30);
            this.btnonceki.TabIndex = 18;
            this.btnonceki.Text = "Önceki";
            this.btnonceki.UseVisualStyleBackColor = false;
            this.btnonceki.Click += new System.EventHandler(this.btnonceki_Click);
            // 
            // btnbaslat
            // 
            this.btnbaslat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnbaslat.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbaslat.Location = new System.Drawing.Point(38, 626);
            this.btnbaslat.Name = "btnbaslat";
            this.btnbaslat.Size = new System.Drawing.Size(120, 30);
            this.btnbaslat.TabIndex = 20;
            this.btnbaslat.Text = "Başlat";
            this.btnbaslat.UseVisualStyleBackColor = false;
            this.btnbaslat.Click += new System.EventHandler(this.btnbaslat_Click);
            // 
            // btngetir
            // 
            this.btngetir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btngetir.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngetir.Location = new System.Drawing.Point(38, 479);
            this.btngetir.Name = "btngetir";
            this.btngetir.Size = new System.Drawing.Size(120, 30);
            this.btngetir.TabIndex = 21;
            this.btngetir.Text = "Durum Getir";
            this.btngetir.UseVisualStyleBackColor = false;
            this.btngetir.Click += new System.EventHandler(this.btngetir_Click);
            // 
            // btnsonraki
            // 
            this.btnsonraki.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnsonraki.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsonraki.Location = new System.Drawing.Point(38, 577);
            this.btnsonraki.Name = "btnsonraki";
            this.btnsonraki.Size = new System.Drawing.Size(120, 30);
            this.btnsonraki.TabIndex = 22;
            this.btnsonraki.Text = "Sonraki";
            this.btnsonraki.UseVisualStyleBackColor = false;
            this.btnsonraki.Click += new System.EventHandler(this.btnsonraki_Click);
            // 
            // durumlar
            // 
            this.durumlar.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.durumlar.FormattingEnabled = true;
            this.durumlar.Location = new System.Drawing.Point(38, 429);
            this.durumlar.Name = "durumlar";
            this.durumlar.Size = new System.Drawing.Size(121, 33);
            this.durumlar.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(38, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Min Kapsam";
            // 
            // minumumkapsamam
            // 
            this.minumumkapsamam.AutoSize = true;
            this.minumumkapsamam.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.minumumkapsamam.Location = new System.Drawing.Point(38, 386);
            this.minumumkapsamam.Name = "minumumkapsamam";
            this.minumumkapsamam.Size = new System.Drawing.Size(106, 25);
            this.minumumkapsamam.TabIndex = 25;
            this.minumumkapsamam.Text = "Min Kapsam";
            // 
            // time
            // 
            this.time.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.time.Location = new System.Drawing.Point(38, 675);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(120, 28);
            this.time.TabIndex = 26;
            this.time.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pndurum
            // 
            this.pndurum.AutoScroll = true;
            this.pndurum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pndurum.Controls.Add(this.lbdurum);
            this.pndurum.Location = new System.Drawing.Point(194, 333);
            this.pndurum.Name = "pndurum";
            this.pndurum.Size = new System.Drawing.Size(364, 364);
            this.pndurum.TabIndex = 27;
            this.pndurum.Visible = false;
            // 
            // lbdurum
            // 
            this.lbdurum.AutoSize = true;
            this.lbdurum.Location = new System.Drawing.Point(12, 17);
            this.lbdurum.MaximumSize = new System.Drawing.Size(320, 0);
            this.lbdurum.MinimumSize = new System.Drawing.Size(320, 0);
            this.lbdurum.Name = "lbdurum";
            this.lbdurum.Size = new System.Drawing.Size(320, 17);
            this.lbdurum.TabIndex = 0;
            this.lbdurum.Text = "label3";
            // 
            // pnonceki
            // 
            this.pnonceki.AutoScroll = true;
            this.pnonceki.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnonceki.Controls.Add(this.lbonceki);
            this.pnonceki.Location = new System.Drawing.Point(576, 333);
            this.pnonceki.Name = "pnonceki";
            this.pnonceki.Size = new System.Drawing.Size(364, 364);
            this.pnonceki.TabIndex = 28;
            this.pnonceki.Visible = false;
            // 
            // lbonceki
            // 
            this.lbonceki.AutoSize = true;
            this.lbonceki.Location = new System.Drawing.Point(14, 17);
            this.lbonceki.MaximumSize = new System.Drawing.Size(320, 0);
            this.lbonceki.MinimumSize = new System.Drawing.Size(320, 0);
            this.lbonceki.Name = "lbonceki";
            this.lbonceki.Size = new System.Drawing.Size(320, 17);
            this.lbonceki.TabIndex = 0;
            this.lbonceki.Text = "label4";
            // 
            // pnsonraki
            // 
            this.pnsonraki.AutoScroll = true;
            this.pnsonraki.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnsonraki.Controls.Add(this.lbsonraki);
            this.pnsonraki.Location = new System.Drawing.Point(958, 333);
            this.pnsonraki.Name = "pnsonraki";
            this.pnsonraki.Size = new System.Drawing.Size(364, 364);
            this.pnsonraki.TabIndex = 28;
            this.pnsonraki.Visible = false;
            // 
            // lbsonraki
            // 
            this.lbsonraki.AutoSize = true;
            this.lbsonraki.Location = new System.Drawing.Point(12, 17);
            this.lbsonraki.MaximumSize = new System.Drawing.Size(320, 0);
            this.lbsonraki.MinimumSize = new System.Drawing.Size(320, 0);
            this.lbsonraki.Name = "lbsonraki";
            this.lbsonraki.Size = new System.Drawing.Size(320, 17);
            this.lbsonraki.TabIndex = 0;
            this.lbsonraki.Text = "label5";
            // 
            // donceki
            // 
            this.donceki.AllowUserToAddRows = false;
            this.donceki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.donceki.Location = new System.Drawing.Point(576, 333);
            this.donceki.Name = "donceki";
            this.donceki.RowTemplate.Height = 24;
            this.donceki.Size = new System.Drawing.Size(364, 364);
            this.donceki.TabIndex = 29;
            this.donceki.Visible = false;
            // 
            // dsonraki
            // 
            this.dsonraki.AllowUserToAddRows = false;
            this.dsonraki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsonraki.Location = new System.Drawing.Point(958, 333);
            this.dsonraki.Name = "dsonraki";
            this.dsonraki.RowTemplate.Height = 24;
            this.dsonraki.Size = new System.Drawing.Size(364, 364);
            this.dsonraki.TabIndex = 30;
            this.dsonraki.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.dsonraki);
            this.Controls.Add(this.donceki);
            this.Controls.Add(this.pnsonraki);
            this.Controls.Add(this.pnonceki);
            this.Controls.Add(this.pndurum);
            this.Controls.Add(this.time);
            this.Controls.Add(this.minumumkapsamam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.durumlar);
            this.Controls.Add(this.btnsonraki);
            this.Controls.Add(this.btngetir);
            this.Controls.Add(this.btnbaslat);
            this.Controls.Add(this.btnonceki);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnrota);
            this.Controls.Add(this.gereksiz);
            this.Controls.Add(this.txtBoxSutun);
            this.Controls.Add(this.txtBoxSatir);
            this.Controls.Add(this.btnTumKapsama);
            this.Controls.Add(this.btnMinKapasama);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnSutunSil);
            this.Controls.Add(this.btnSatirSil);
            this.Controls.Add(this.btnTabloOlustur);
            this.Controls.Add(this.lblSutun);
            this.Controls.Add(this.lblSatir);
            this.Controls.Add(this.AnaTabloView);
            this.Name = "Form1";
            this.Text = "Kapsama Problemi - Rabia AKÇAY";
            ((System.ComponentModel.ISupportInitialize)(this.AnaTabloView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gereksiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.pndurum.ResumeLayout(false);
            this.pndurum.PerformLayout();
            this.pnonceki.ResumeLayout(false);
            this.pnonceki.PerformLayout();
            this.pnsonraki.ResumeLayout(false);
            this.pnsonraki.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donceki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsonraki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AnaTabloView;
        private System.Windows.Forms.Label lblSatir;
        private System.Windows.Forms.Label lblSutun;
        private System.Windows.Forms.Button btnTabloOlustur;
        private System.Windows.Forms.Button btnSatirSil;
        private System.Windows.Forms.Button btnSutunSil;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnMinKapasama;
        private System.Windows.Forms.Button btnTumKapsama;
        private System.Windows.Forms.TextBox txtBoxSatir;
        private System.Windows.Forms.TextBox txtBoxSutun;
        private System.Windows.Forms.DataGridView gereksiz;
        private System.Windows.Forms.Button btnrota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnonceki;
        private System.Windows.Forms.Button btnbaslat;
        private System.Windows.Forms.Button btngetir;
        private System.Windows.Forms.Button btnsonraki;
        private System.Windows.Forms.ComboBox durumlar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minumumkapsamam;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.Panel pndurum;
        private System.Windows.Forms.Label lbdurum;
        private System.Windows.Forms.Panel pnonceki;
        private System.Windows.Forms.Label lbonceki;
        private System.Windows.Forms.Panel pnsonraki;
        private System.Windows.Forms.Label lbsonraki;
        private System.Windows.Forms.DataGridView donceki;
        private System.Windows.Forms.DataGridView dsonraki;
        private System.Windows.Forms.Timer timer1;
    }
}

