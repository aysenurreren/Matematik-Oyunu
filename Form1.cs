using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MatematikOyunu
{
    public partial class Form1 : Form
    {
        // ---- Oyun Durumu ----
        private Random rnd = new Random();
        private int seviye = 1;
        private int blok = 1;
        private int dogruSayisi = 0;
        private const int soruSayisi = 5;
        private int maxDeger = 10;

        // ---- Süre ----
        private Timer seviyeTimer = new Timer();
        private int kalanSaniye = 0;

        // ---- Sorular ----
        private List<(string soru, double cevap)> aktifSorular = new List<(string, double)>();
        // PAS sorularını seviye boyunca biriktir
        private List<(string soru, double cevap)> pasSorular = new List<(string, double)>();

        // PAS turu (20 soru bittikten sonra)
        private bool pasTuru = false;

        // ---- Dosya Yolları ----
        private string dosyaYolu = "oyun_kayit.txt";
        private string skorDosyasi = "skorlar.csv";

        // ---- HİLE ----  
        private bool hileAktif = false;
        private int hileSeviye = 0; // 2..5 veya 0 (yok). "all" için 5 kabul edilir.

        public Form1()
        {
            InitializeComponent();

            // Kayıttan seviye yükle
            if (File.Exists(dosyaYolu))
            {
                int s;
                if (int.TryParse(File.ReadAllText(dosyaYolu), out s))
                {
                    seviye = Math.Max(1, s);
                    MessageBox.Show("Hoş geldin! En son " + seviye + ". seviyedeydin 🎯");
                }
            }

            // >>> HİLE: Komut satırı "open x" kontrolü 
            UygulaHileKomutSatiri();

            // Süre etiketi sağ-üst: yoksa oluştur
            EnsureSureLabel();

            // Sayaç
            seviyeTimer.Interval = 1000;
            seviyeTimer.Tick += SeviyeTimer_Tick;

            // Tasarımda bağlanmamış olabilecek Click event'lerini bağla
            WireEvents();

            // Form yeniden boyutlanınca süre etiketini sağ-üste hizala
            this.Resize -= Form1_Resize;
            this.Resize += Form1_Resize;

            UIYaz();
        }

        // ==================== HİLE METODU ====================
        private void UygulaHileKomutSatiri()
        {
            try
            {
                string[] args = Environment.GetCommandLineArgs();
                // Beklenen biçim: oyun.exe open x   (x: 2/3/4/5 veya "all")
                // args[0] = exe yolu, en az 3 eleman beklenir
                if (args != null && args.Length >= 3)
                {
                    string cmd = args[1];
                    string val = args[2];

                    if (string.Equals(cmd, "open", StringComparison.OrdinalIgnoreCase))
                    {
                        if (string.Equals(val, "all", StringComparison.OrdinalIgnoreCase))
                        {
                            hileAktif = true;
                            hileSeviye = 5;
                        }
                        else
                        {
                            int lvl;
                            if (int.TryParse(val, out lvl))
                            {
                                if (lvl >= 2 && lvl <= 5)
                                {
                                    hileAktif = true;
                                    hileSeviye = lvl;
                                }
                            }
                        }
                    }
                }

                // Hile geçerliyse açılış seviyesini buna ayarla 
                if (hileAktif && hileSeviye >= 2 && hileSeviye <= 5)
                {
                    seviye = hileSeviye;
                }
            }
            catch
            {
                // parametre hatalıysa normal akış sürsün
            }
        }

        // ==================== SAĞ-ÜST SÜRE ETİKETİ ====================
        private void EnsureSureLabel()
        {
            Label lbl = FindCtl<Label>("lblSure");
            if (lbl == null)
            {
                lbl = new Label();
                lbl.Name = "lblSure";
                lbl.AutoSize = true;
                lbl.Font = new Font(Font.FontFamily, 12F, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.TopRight;
                lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                lbl.Text = "Süre: 0 sn";
                this.Controls.Add(lbl);
            }
            PositionSureLabel();
        }

        private void PositionSureLabel()
        {
            Label lbl = FindCtl<Label>("lblSure");
            if (lbl != null)
            {
                lbl.Left = this.ClientSize.Width - lbl.Width - 12;
                lbl.Top = 12;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PositionSureLabel();
        }

        private void YazSureLabel()
        {
            Label lbl = FindCtl<Label>("lblSure");
            if (lbl != null)
            {
                lbl.Text = "Süre: " + kalanSaniye + " sn";
                PositionSureLabel();
            }
        }

        // ==================== EVENT BAĞLAMA ====================
        private void WireEvents()
        {
            // Başla
            Button btnBasla = FindCtl<Button>("btnBasla");
            if (btnBasla != null) { btnBasla.Click -= btnBasla_Click; btnBasla.Click += btnBasla_Click; }

            // Devam Et
            Button btnDevamEt = FindCtl<Button>("btnDevamEt");
            if (btnDevamEt != null) { btnDevamEt.Click -= btnDevamEt_Click; btnDevamEt.Click += btnDevamEt_Click; }

            // Cevapla/PAS 1..5
            for (int i = 1; i <= soruSayisi; i++)
            {
                Button btnCevapla = FindCtl<Button>("btnCevapla" + i);
                if (btnCevapla != null)
                {
                    btnCevapla.Tag = i;
                    btnCevapla.Click -= btnCevapla_Click;
                    btnCevapla.Click += btnCevapla_Click;
                }

                // btnPas1..btnPas5
                Button btnPas = FindCtl<Button>("btnPas" + i);
                if (btnPas != null)
                {
                    btnPas.Tag = i;
                    btnPas.Click -= btnPas_Click;
                    btnPas.Click += btnPas_Click;
                    btnPas.Visible = true; // görünürlüğü garanti
                }
            }
        }

        // ==================== ZAMANLAYICI ====================
        private void SeviyeTimer_Tick(object sender, EventArgs e)
        {
            if (kalanSaniye > 0)
            {
                kalanSaniye--;
                YazSureLabel();
            }

            if (kalanSaniye <= 0)
            {
                seviyeTimer.Stop();
                TumCevapKontrolleriniKapat();
                MessageBox.Show("Süre doldu ⏰");
                SeviyeBitti();
            }
        }

        private void TumCevapKontrolleriniKapat()
        {
            for (int i = 1; i <= soruSayisi; i++)
            {
                TextBox txt = FindCtl<TextBox>("txtCevap" + i);
                Button btnC = FindCtl<Button>("btnCevapla" + i);
                Button btnP = FindCtl<Button>("btnPas" + i);
                if (txt != null) txt.Enabled = false;
                if (btnC != null) btnC.Enabled = false;
                if (btnP != null) btnP.Enabled = false;
            }
        }

        // ==================== BAŞLA / DEVAM ====================
        private void btnBasla_Click(object sender, EventArgs e)
        {
            dogruSayisi = 0;
            blok = 1;
            aktifSorular.Clear();
            pasSorular.Clear();
            pasTuru = false;

            kalanSaniye = 120 + 20 * (seviye - 1);
            YazSureLabel();
            seviyeTimer.Start();

            ListBox lst = FindCtl<ListBox>("lstSkor");
            if (lst != null)
            {
                lst.Items.Clear();
                lst.Items.Add("Seviye " + seviye + " başladı! (Süre: " + kalanSaniye + " sn)");
            }

            SoruOlustur();
            UIYaz();
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            bool eksikVar = false;
            for (int i = 1; i <= soruSayisi; i++)
            {
                TextBox txt = FindCtl<TextBox>("txtCevap" + i);
                if (txt != null && txt.Enabled && string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.BackColor = Color.LightYellow;
                    eksikVar = true;
                }
            }

            // tümü cevaplanmış/PAS'lanmışsa blok veya seviye ilerler
            KontrolEt();

            if (eksikVar)
                MessageBox.Show("Lütfen kalan soruları cevaplayın ya da PAS deyin.");
        }

        // ==================== SORU ÜRET / YAZ ====================
        private void SoruOlustur()
        {
            aktifSorular = new List<(string, double)>();

            maxDeger = 10 + (seviye - 1) * 10;

            for (int i = 0; i < soruSayisi; i++)
                aktifSorular.Add(SoruUret());

            // Ekrana yaz & renkleri sıfırla
            for (int i = 0; i < soruSayisi; i++)
            {
                Label lbl = FindCtl<Label>("lblSoru" + (i + 1));
                TextBox txt = FindCtl<TextBox>("txtCevap" + (i + 1));
                Button btnC = FindCtl<Button>("btnCevapla" + (i + 1));
                Button btnP = FindCtl<Button>("btnPas" + (i + 1));

                if (lbl != null)
                {
                    lbl.Text = aktifSorular[i].soru;
                    lbl.ForeColor = SystemColors.ControlText;
                    lbl.BackColor = Color.Transparent;
                }
                if (txt != null)
                {
                    txt.Text = "";
                    txt.Enabled = true;
                    txt.BackColor = Color.White;
                }
                if (btnC != null) btnC.Enabled = true;
                if (btnP != null) { btnP.Enabled = true; btnP.Visible = true; }
            }
        }

        private (string, double) SoruUret()
        {
            string[] islemler = new string[] { "+", "-", "*", "/" };
            string islem = islemler[rnd.Next(0, 4)];

            int s1 = rnd.Next(1, maxDeger);
            int s2 = rnd.Next(1, maxDeger);
            double cevap = 0;

            switch (islem)
            {
                case "+":
                    cevap = s1 + s2; break;
                case "-":
                    if (s2 > s1) { int tmp = s1; s1 = s2; s2 = tmp; }
                    cevap = s1 - s2; break;
                case "*":
                    s1 = rnd.Next(0, Math.Max(6, maxDeger / 5) + 1);
                    s2 = rnd.Next(0, Math.Max(6, maxDeger / 5) + 1);
                    cevap = s1 * s2; break;
                case "/":
                    s2 = rnd.Next(1, Math.Max(6, maxDeger / 5) + 1);
                    int carpim = rnd.Next(0, Math.Max(6, maxDeger / 5) + 1);
                    s1 = s2 * carpim;
                    cevap = carpim; break;
            }

            return (s1 + " " + islem + " " + s2 + " =", cevap);
        }

        // ==================== CEVAP / PAS ====================
        private void btnCevapla_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            int index = Convert.ToInt32(btn.Tag); // 1..5
            TextBox txt = FindCtl<TextBox>("txtCevap" + index);
            if (txt == null) return;

            double girilen;
            if (!double.TryParse(txt.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out girilen))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
                return;
            }

            string soruMetni = aktifSorular[index - 1].soru;
            double dogru = aktifSorular[index - 1].cevap;

            if (Math.Abs(girilen - dogru) < 0.01)
            {
                MessageBox.Show("Doğru 🎯");
                dogruSayisi++;

                // Renk: DOĞRU
                txt.BackColor = Color.LightGreen;
                Label lblS = FindCtl<Label>("lblSoru" + index);
                if (lblS != null) lblS.ForeColor = Color.DarkGreen;
            }
            else
            {
                MessageBox.Show("Yanlış ❌ Doğru cevap: " + dogru.ToString(CultureInfo.InvariantCulture));

                // Renk: YANLIŞ
                txt.BackColor = Color.LightCoral;
                Label lblS = FindCtl<Label>("lblSoru" + index);
                if (lblS != null) lblS.ForeColor = Color.Maroon;
            }

            // Bu soruyu kapat
            txt.Enabled = false;
            btn.Enabled = false;
            Button pasBtn = FindCtl<Button>("btnPas" + index);
            if (pasBtn != null) pasBtn.Enabled = false;

            SetText("lblDogru", "Doğru: " + dogruSayisi);
            SetText("lblSkor", "Skor: " + HesaplananSkor());

            KontrolEt();
        }

        private void btnPas_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            int index = Convert.ToInt32(btn.Tag);

            // Seviye akışında PAS'lanan soruyu biriktir
            if (!pasTuru)
            {
                pasSorular.Add(aktifSorular[index - 1]);
                MessageBox.Show("Soru " + index + " PAS edildi (seviye sonunda tekrar gelecek).");

                // Renk: PAS
                TextBox txt = FindCtl<TextBox>("txtCevap" + index);
                if (txt != null)
                {
                    txt.BackColor = Color.Khaki;
                    txt.Enabled = false;
                }

                btn.Enabled = false;
                Button cevaplaBtn = FindCtl<Button>("btnCevapla" + index);
                if (cevaplaBtn != null) cevaplaBtn.Enabled = false;

                Label lblS = FindCtl<Label>("lblSoru" + index);
                if (lblS != null) lblS.ForeColor = Color.Goldenrod;

                KontrolEt();
            }
            else
            {
                // === PAS TURUNDA PAS = YANLIŞ ===
                MessageBox.Show("PAS turunda tekrar PAS edilemez. Soru yanlış sayıldı ❌");

                // Kırmızı işaretle ve kilitle
                TextBox txt2 = FindCtl<TextBox>("txtCevap" + index);
                if (txt2 != null) { txt2.BackColor = Color.LightCoral; txt2.Enabled = false; }

                Button cevaplaBtn2 = FindCtl<Button>("btnCevapla" + index);
                if (cevaplaBtn2 != null) cevaplaBtn2.Enabled = false;

                // Bu PAS butonunu da kilitle
                btn.Enabled = false;

                Label lblS2 = FindCtl<Label>("lblSoru" + index);
                if (lblS2 != null) lblS2.ForeColor = Color.Maroon;

                // Blok tamamlandı mı bak ve PAS-turu PAS'ı "yanlış" olarak sonlandır
                KontrolEt();
                return;
            }
        }

        // ==================== BLOK / SEVİYE AKIŞI ====================
        private void KontrolEt()
        {
            bool tumuCevaplandi = true;
            for (int i = 1; i <= soruSayisi; i++)
            {
                TextBox txt = FindCtl<TextBox>("txtCevap" + i);
                if (txt != null && txt.Enabled)
                {
                    tumuCevaplandi = false;
                    break;
                }
            }

            if (!tumuCevaplandi) return;
            BlokBitti();
        }

        private void BlokBitti()
        {
            blok++;
            if (blok > 4)
            {
                // 20 soru bitti
                if (pasSorular.Count > 0)
                {
                    // PAS turuna geç
                    pasTuru = true;
                    ListBox lst = FindCtl<ListBox>("lstSkor");
                    if (lst != null) lst.Items.Add("PAS sorularına geçiliyor...");

                    aktifSorular = new List<(string, double)>(pasSorular);
                    pasSorular.Clear();
                    YazPasTurSorulari();
                }
                else
                {
                    SeviyeBitti();
                }
                return;
            }

            ListBox lst2 = FindCtl<ListBox>("lstSkor");
            if (lst2 != null) lst2.Items.Add("Blok " + blok + " başladı!");

            SoruOlustur();
            UIYaz();
        }

        // PAS turu ekrana yazılır (aktifSorular = pas soruları)
        private void YazPasTurSorulari()
        {
            // Önce tüm slotları sıfırla
            for (int i = 0; i < soruSayisi; i++)
            {
                Label lbl = FindCtl<Label>("lblSoru" + (i + 1));
                TextBox txt = FindCtl<TextBox>("txtCevap" + (i + 1));
                Button btnC = FindCtl<Button>("btnCevapla" + (i + 1));
                Button btnP = FindCtl<Button>("btnPas" + (i + 1));

                if (lbl != null) lbl.Text = "";
                if (txt != null) { txt.Text = ""; txt.Enabled = false; txt.BackColor = Color.White; }
                if (btnC != null) btnC.Enabled = false;
                if (btnP != null) { btnP.Enabled = false; btnP.Visible = true; }
            }

            // Aktif olanları baştan doldur
            int gosterilecek = Math.Min(aktifSorular.Count, soruSayisi);
            for (int i = 0; i < gosterilecek; i++)
            {
                Label lbl = FindCtl<Label>("lblSoru" + (i + 1));
                TextBox txt = FindCtl<TextBox>("txtCevap" + (i + 1));
                Button btnC = FindCtl<Button>("btnCevapla" + (i + 1));
                Button btnP = FindCtl<Button>("btnPas" + (i + 1));

                if (lbl != null) { lbl.Text = aktifSorular[i].soru; lbl.ForeColor = SystemColors.ControlText; }
                if (txt != null) { txt.Text = ""; txt.Enabled = true; txt.BackColor = Color.White; }
                if (btnC != null) btnC.Enabled = true;

                // PAS turunda PAS butonları AKTİF — kritik satır
                if (btnP != null) { btnP.Enabled = true; btnP.Visible = true; }
            }

            // Eğer gösterilecek pas sorusu yoksa seviye biter
            if (aktifSorular.Count == 0)
                SeviyeBitti();
        }

        private void SeviyeBitti()
        {
            seviyeTimer.Stop();
            TumCevapKontrolleriniKapat();

            ListBox lst = FindCtl<ListBox>("lstSkor");
            if (lst != null)
            {
                lst.Items.Add("Seviye " + seviye + " bitti!");
                lst.Items.Add("Toplam doğru: " + dogruSayisi);
            }

            string yildiz = (dogruSayisi >= 19) ? "***" :
                            (dogruSayisi >= 16) ? "**" :
                            (dogruSayisi >= 11) ? "*" : "—";

            MessageBox.Show("Seviye " + seviye + " tamamlandı!\nDoğru sayısı: " + dogruSayisi + "\nYıldız: " + yildiz);

            KaydetSkor(seviye, dogruSayisi, HesaplananSkor(), yildiz, kalanSaniye);

            if (dogruSayisi >= 11)
            {
                seviye++;
                File.WriteAllText(dosyaYolu, seviye.ToString());
                MessageBox.Show("Tebrikler! " + seviye + ". seviyeye geçtin 🎉");
            }
            else
            {
                MessageBox.Show("Maalesef geçemedin. Tekrar dene 💪");
            }

            UIYaz();
        }

        // ==================== SKOR ====================
        private int HesaplananSkor()
        {
            // Basit skor: doğru sayısı * (seviye + 4)
            int carp = Math.Max(5, seviye + 4);
            return dogruSayisi * carp;
        }

        private void KaydetSkor(int lvl, int dogru, int skor, string yildiz, int kalanSureSn)
        {
            bool headerYaz = !File.Exists(skorDosyasi);
            using (var sw = new StreamWriter(skorDosyasi, true))
            {
                if (headerYaz)
                    sw.WriteLine("TarihSaat;Seviye;Dogru;Skor;Yildiz;KalanSureSn");

                sw.WriteLine(
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ";" +
                    lvl + ";" + dogru + ";" + skor + ";" + yildiz + ";" + kalanSureSn);
            }
        }

        // ==================== UI YARDIMCILAR ====================
        private T FindCtl<T>(string name) where T : Control
        {
            return Controls.Find(name, true).FirstOrDefault() as T;
        }

        private void UIYaz()
        {
            SetText("lblSeviye", "Seviye: " + seviye);
            SetText("lblBlok", "Blok: " + blok + "/4");
            SetText("lblDogru", "Doğru: " + dogruSayisi);
            SetText("lblSkor", "Skor: " + HesaplananSkor());
            YazSureLabel();
        }

        private void SetText(string name, string text)
        {
            Control c = FindCtl<Control>(name);
            if (c != null) c.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void btnBasla_Click_1(object sender, EventArgs e) { }
        private void txtCevap1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void Form1_Load_1(object sender, EventArgs e) { }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }
    }
}