namespace MatematikOyunu
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
            this.lblSeviye = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSoru5 = new System.Windows.Forms.Label();
            this.lblSoru4 = new System.Windows.Forms.Label();
            this.lblSoru3 = new System.Windows.Forms.Label();
            this.lblSoru2 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.lblDogru = new System.Windows.Forms.Label();
            this.lblYanlis = new System.Windows.Forms.Label();
            this.lblSoru1 = new System.Windows.Forms.Label();
            this.txtCevap1 = new System.Windows.Forms.TextBox();
            this.txtCevap2 = new System.Windows.Forms.TextBox();
            this.txtCevap3 = new System.Windows.Forms.TextBox();
            this.txtCevap4 = new System.Windows.Forms.TextBox();
            this.txtCevap5 = new System.Windows.Forms.TextBox();
            this.btnCevapla1 = new System.Windows.Forms.Button();
            this.btnCevapla2 = new System.Windows.Forms.Button();
            this.btnCevapla3 = new System.Windows.Forms.Button();
            this.btnCevapla4 = new System.Windows.Forms.Button();
            this.btnCevapla5 = new System.Windows.Forms.Button();
            this.btnPas1 = new System.Windows.Forms.Button();
            this.btnPas2 = new System.Windows.Forms.Button();
            this.btnPas3 = new System.Windows.Forms.Button();
            this.btnPas4 = new System.Windows.Forms.Button();
            this.btnPas5 = new System.Windows.Forms.Button();
            this.btnBasla = new System.Windows.Forms.Button();
            this.btnDevamEt = new System.Windows.Forms.Button();
            this.lstSkor = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSeviye
            // 
            this.lblSeviye.Location = new System.Drawing.Point(33, 25);
            this.lblSeviye.Name = "lblSeviye";
            this.lblSeviye.Size = new System.Drawing.Size(100, 23);
            this.lblSeviye.TabIndex = 0;
            this.lblSeviye.Text = "label1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(385, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "MATEMATİK OYUNU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblSoru5
            // 
            this.lblSoru5.AutoSize = true;
            this.lblSoru5.Location = new System.Drawing.Point(237, 424);
            this.lblSoru5.Name = "lblSoru5";
            this.lblSoru5.Size = new System.Drawing.Size(46, 16);
            this.lblSoru5.TabIndex = 3;
            this.lblSoru5.Text = "Soru-5";
            // 
            // lblSoru4
            // 
            this.lblSoru4.AutoSize = true;
            this.lblSoru4.Location = new System.Drawing.Point(237, 351);
            this.lblSoru4.Name = "lblSoru4";
            this.lblSoru4.Size = new System.Drawing.Size(46, 16);
            this.lblSoru4.TabIndex = 4;
            this.lblSoru4.Text = "Soru-4";
            // 
            // lblSoru3
            // 
            this.lblSoru3.AutoSize = true;
            this.lblSoru3.Location = new System.Drawing.Point(237, 301);
            this.lblSoru3.Name = "lblSoru3";
            this.lblSoru3.Size = new System.Drawing.Size(46, 16);
            this.lblSoru3.TabIndex = 5;
            this.lblSoru3.Text = "Soru-3";
            // 
            // lblSoru2
            // 
            this.lblSoru2.AutoSize = true;
            this.lblSoru2.Location = new System.Drawing.Point(237, 231);
            this.lblSoru2.Name = "lblSoru2";
            this.lblSoru2.Size = new System.Drawing.Size(46, 16);
            this.lblSoru2.TabIndex = 6;
            this.lblSoru2.Text = "Soru-2";
            // 
            // lblSure
            // 
            this.lblSure.Location = new System.Drawing.Point(807, 25);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(44, 16);
            this.lblSure.TabIndex = 7;
            this.lblSure.Text = "sure";
            // 
            // lblDogru
            // 
            this.lblDogru.Location = new System.Drawing.Point(807, 71);
            this.lblDogru.Name = "lblDogru";
            this.lblDogru.Size = new System.Drawing.Size(44, 16);
            this.lblDogru.TabIndex = 8;
            this.lblDogru.Text = "dogru";
            // 
            // lblYanlis
            // 
            this.lblYanlis.Location = new System.Drawing.Point(807, 118);
            this.lblYanlis.Name = "lblYanlis";
            this.lblYanlis.Size = new System.Drawing.Size(44, 16);
            this.lblYanlis.TabIndex = 9;
            this.lblYanlis.Text = "yanlıs";
            // 
            // lblSoru1
            // 
            this.lblSoru1.AutoSize = true;
            this.lblSoru1.Location = new System.Drawing.Point(237, 159);
            this.lblSoru1.Name = "lblSoru1";
            this.lblSoru1.Size = new System.Drawing.Size(46, 16);
            this.lblSoru1.TabIndex = 10;
            this.lblSoru1.Text = "Soru-1";
            // 
            // txtCevap1
            // 
            this.txtCevap1.Location = new System.Drawing.Point(385, 152);
            this.txtCevap1.Name = "txtCevap1";
            this.txtCevap1.Size = new System.Drawing.Size(100, 22);
            this.txtCevap1.TabIndex = 11;
            // 
            // txtCevap2
            // 
            this.txtCevap2.Location = new System.Drawing.Point(385, 231);
            this.txtCevap2.Name = "txtCevap2";
            this.txtCevap2.Size = new System.Drawing.Size(100, 22);
            this.txtCevap2.TabIndex = 12;
            // 
            // txtCevap3
            // 
            this.txtCevap3.Location = new System.Drawing.Point(385, 295);
            this.txtCevap3.Name = "txtCevap3";
            this.txtCevap3.Size = new System.Drawing.Size(100, 22);
            this.txtCevap3.TabIndex = 13;
            // 
            // txtCevap4
            // 
            this.txtCevap4.Location = new System.Drawing.Point(385, 345);
            this.txtCevap4.Name = "txtCevap4";
            this.txtCevap4.Size = new System.Drawing.Size(100, 22);
            this.txtCevap4.TabIndex = 14;
            // 
            // txtCevap5
            // 
            this.txtCevap5.Location = new System.Drawing.Point(385, 418);
            this.txtCevap5.Name = "txtCevap5";
            this.txtCevap5.Size = new System.Drawing.Size(100, 22);
            this.txtCevap5.TabIndex = 15;
            // 
            // btnCevapla1
            // 
            this.btnCevapla1.BackColor = System.Drawing.Color.Silver;
            this.btnCevapla1.Location = new System.Drawing.Point(570, 152);
            this.btnCevapla1.Name = "btnCevapla1";
            this.btnCevapla1.Size = new System.Drawing.Size(75, 23);
            this.btnCevapla1.TabIndex = 16;
            this.btnCevapla1.Text = "Cevapla";
            this.btnCevapla1.UseVisualStyleBackColor = false;
            this.btnCevapla1.Click += new System.EventHandler(this.btnCevapla_Click);
            // 
            // btnCevapla2
            // 
            this.btnCevapla2.BackColor = System.Drawing.Color.Silver;
            this.btnCevapla2.Location = new System.Drawing.Point(570, 231);
            this.btnCevapla2.Name = "btnCevapla2";
            this.btnCevapla2.Size = new System.Drawing.Size(75, 23);
            this.btnCevapla2.TabIndex = 17;
            this.btnCevapla2.Text = "Cevapla";
            this.btnCevapla2.UseVisualStyleBackColor = false;
            this.btnCevapla2.Click += new System.EventHandler(this.btnCevapla_Click);
            // 
            // btnCevapla3
            // 
            this.btnCevapla3.BackColor = System.Drawing.Color.Silver;
            this.btnCevapla3.Location = new System.Drawing.Point(570, 294);
            this.btnCevapla3.Name = "btnCevapla3";
            this.btnCevapla3.Size = new System.Drawing.Size(75, 23);
            this.btnCevapla3.TabIndex = 18;
            this.btnCevapla3.Text = "Cevapla";
            this.btnCevapla3.UseVisualStyleBackColor = false;
            this.btnCevapla3.Click += new System.EventHandler(this.btnCevapla_Click);
            // 
            // btnCevapla4
            // 
            this.btnCevapla4.BackColor = System.Drawing.Color.Silver;
            this.btnCevapla4.Location = new System.Drawing.Point(570, 351);
            this.btnCevapla4.Name = "btnCevapla4";
            this.btnCevapla4.Size = new System.Drawing.Size(75, 23);
            this.btnCevapla4.TabIndex = 19;
            this.btnCevapla4.Text = "Cevapla";
            this.btnCevapla4.UseVisualStyleBackColor = false;
            this.btnCevapla4.Click += new System.EventHandler(this.btnCevapla_Click);
            // 
            // btnCevapla5
            // 
            this.btnCevapla5.BackColor = System.Drawing.Color.Silver;
            this.btnCevapla5.Location = new System.Drawing.Point(570, 418);
            this.btnCevapla5.Name = "btnCevapla5";
            this.btnCevapla5.Size = new System.Drawing.Size(75, 23);
            this.btnCevapla5.TabIndex = 20;
            this.btnCevapla5.Text = "Cevapla";
            this.btnCevapla5.UseVisualStyleBackColor = false;
            this.btnCevapla5.Click += new System.EventHandler(this.btnCevapla_Click);
            // 
            // btnPas1
            // 
            this.btnPas1.BackColor = System.Drawing.Color.Silver;
            this.btnPas1.Location = new System.Drawing.Point(692, 152);
            this.btnPas1.Name = "btnPas1";
            this.btnPas1.Size = new System.Drawing.Size(75, 23);
            this.btnPas1.TabIndex = 21;
            this.btnPas1.Text = "Pas";
            this.btnPas1.UseVisualStyleBackColor = false;
            this.btnPas1.Click += new System.EventHandler(this.btnPas_Click);
            // 
            // btnPas2
            // 
            this.btnPas2.BackColor = System.Drawing.Color.Silver;
            this.btnPas2.Location = new System.Drawing.Point(692, 231);
            this.btnPas2.Name = "btnPas2";
            this.btnPas2.Size = new System.Drawing.Size(75, 23);
            this.btnPas2.TabIndex = 22;
            this.btnPas2.Text = "Pas";
            this.btnPas2.UseVisualStyleBackColor = false;
            this.btnPas2.Click += new System.EventHandler(this.btnPas_Click);
            // 
            // btnPas3
            // 
            this.btnPas3.BackColor = System.Drawing.Color.Silver;
            this.btnPas3.Location = new System.Drawing.Point(692, 294);
            this.btnPas3.Name = "btnPas3";
            this.btnPas3.Size = new System.Drawing.Size(75, 23);
            this.btnPas3.TabIndex = 23;
            this.btnPas3.Text = "Pas";
            this.btnPas3.UseVisualStyleBackColor = false;
            this.btnPas3.Click += new System.EventHandler(this.btnPas_Click);
            // 
            // btnPas4
            // 
            this.btnPas4.BackColor = System.Drawing.Color.Silver;
            this.btnPas4.Location = new System.Drawing.Point(692, 348);
            this.btnPas4.Name = "btnPas4";
            this.btnPas4.Size = new System.Drawing.Size(75, 23);
            this.btnPas4.TabIndex = 24;
            this.btnPas4.Text = "Pas";
            this.btnPas4.UseVisualStyleBackColor = false;
            this.btnPas4.Click += new System.EventHandler(this.btnPas_Click);
            // 
            // btnPas5
            // 
            this.btnPas5.BackColor = System.Drawing.Color.Silver;
            this.btnPas5.Location = new System.Drawing.Point(692, 417);
            this.btnPas5.Name = "btnPas5";
            this.btnPas5.Size = new System.Drawing.Size(75, 23);
            this.btnPas5.TabIndex = 25;
            this.btnPas5.Text = "Pas";
            this.btnPas5.UseVisualStyleBackColor = false;
            this.btnPas5.Click += new System.EventHandler(this.btnPas_Click);
            // 
            // btnBasla
            // 
            this.btnBasla.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBasla.Location = new System.Drawing.Point(270, 482);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(94, 41);
            this.btnBasla.TabIndex = 26;
            this.btnBasla.Text = "BAŞLA";
            this.btnBasla.UseVisualStyleBackColor = false;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // btnDevamEt
            // 
            this.btnDevamEt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDevamEt.Location = new System.Drawing.Point(666, 482);
            this.btnDevamEt.Name = "btnDevamEt";
            this.btnDevamEt.Size = new System.Drawing.Size(91, 41);
            this.btnDevamEt.TabIndex = 27;
            this.btnDevamEt.Text = "DEVAM ET";
            this.btnDevamEt.UseVisualStyleBackColor = false;
            this.btnDevamEt.Click += new System.EventHandler(this.btnDevamEt_Click);
            // 
            // lstSkor
            // 
            this.lstSkor.FormattingEnabled = true;
            this.lstSkor.ItemHeight = 16;
            this.lstSkor.Location = new System.Drawing.Point(36, 71);
            this.lstSkor.Name = "lstSkor";
            this.lstSkor.Size = new System.Drawing.Size(76, 20);
            this.lstSkor.TabIndex = 28;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(890, 549);
            this.Controls.Add(this.lstSkor);
            this.Controls.Add(this.btnDevamEt);
            this.Controls.Add(this.btnBasla);
            this.Controls.Add(this.btnPas5);
            this.Controls.Add(this.btnPas4);
            this.Controls.Add(this.btnPas3);
            this.Controls.Add(this.btnPas2);
            this.Controls.Add(this.btnPas1);
            this.Controls.Add(this.btnCevapla5);
            this.Controls.Add(this.btnCevapla4);
            this.Controls.Add(this.btnCevapla3);
            this.Controls.Add(this.btnCevapla2);
            this.Controls.Add(this.btnCevapla1);
            this.Controls.Add(this.txtCevap5);
            this.Controls.Add(this.txtCevap4);
            this.Controls.Add(this.txtCevap3);
            this.Controls.Add(this.txtCevap2);
            this.Controls.Add(this.txtCevap1);
            this.Controls.Add(this.lblSoru1);
            this.Controls.Add(this.lblYanlis);
            this.Controls.Add(this.lblDogru);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.lblSoru2);
            this.Controls.Add(this.lblSoru3);
            this.Controls.Add(this.lblSoru4);
            this.Controls.Add(this.lblSoru5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSeviye);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_2);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeviye;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSoru5;
        private System.Windows.Forms.Label lblSoru4;
        private System.Windows.Forms.Label lblSoru3;
        private System.Windows.Forms.Label lblSoru2;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label lblDogru;
        private System.Windows.Forms.Label lblYanlis;
        private System.Windows.Forms.Label lblSoru1;
        private System.Windows.Forms.TextBox txtCevap1;
        private System.Windows.Forms.TextBox txtCevap2;
        private System.Windows.Forms.TextBox txtCevap3;
        private System.Windows.Forms.TextBox txtCevap4;
        private System.Windows.Forms.TextBox txtCevap5;
        private System.Windows.Forms.Button btnCevapla1;
        private System.Windows.Forms.Button btnCevapla2;
        private System.Windows.Forms.Button btnCevapla3;
        private System.Windows.Forms.Button btnCevapla4;
        private System.Windows.Forms.Button btnCevapla5;
        private System.Windows.Forms.Button btnPas1;
        private System.Windows.Forms.Button btnPas2;
        private System.Windows.Forms.Button btnPas3;
        private System.Windows.Forms.Button btnPas4;
        private System.Windows.Forms.Button btnPas5;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.Button btnDevamEt;
        private System.Windows.Forms.ListBox lstSkor;
        private System.Windows.Forms.Timer timer1;
    }
}

