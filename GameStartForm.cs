using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazLab1.Model;

namespace YazLab1
{
    public partial class GameStartForm : Form
    {
        int TahtaSatirSayisi, TahtaSutunSayisi;
        int KareAltin, GizliKareAltin, kullaniciAltin, AdimAdeti, KareSayisi, KareAltinSayisi, GizliKareAltinSayisi;
        int A_Hamle, A_Hedef, B_Hamle, B_Hedef, C_Hamle, C_Hedef, D_Hamle, D_Hedef;
        string Siradaki = null;
        bool A_Hedef_Kaldi_Mi = true, A_Hamle_Kaldi_Mi = true, A_Bitti;
        bool B_Hedef_Kaldi_Mi = true, B_Hamle_Kaldi_Mi = true, B_Bitti;
        bool C_Hedef_Kaldi_Mi = true, C_Hamle_Kaldi_Mi = true, C_Bitti;
        bool D_Hedef_Kaldi_Mi = true, D_Hamle_Kaldi_Mi = true, D_Bitti;

        List<Board> list = new List<Board>();

        Player A = new Player();
        Player B = new Player();
        Player C = new Player();
        Player D = new Player();

        Way A_Hedef_Yol = new Way();
        Way B_Hedef_Yol = new Way();
        Way C_Hedef_Yol = new Way();
        Way D_Hedef_Yol = new Way();

        List<Way> A_Yollari = new List<Way>();
        List<Way> B_Yollari = new List<Way>();
        List<Way> C_Yollari = new List<Way>();
        List<Way> D_Yollari = new List<Way>();

        public GameStartForm()
        {
            InitializeComponent();
        }
        public GameStartForm(int TahtaSatirSayisi, int TahtaSutunSayisi, int KareAltin, int GizliKareAltin, int kullaniciAltin, int AdimAdeti, int A_Hamle, int A_Hedef, int B_Hamle, int B_Hedef, int C_Hamle, int C_Hedef, int D_Hamle, int D_Hedef)
        {
            this.TahtaSatirSayisi = TahtaSatirSayisi;
            this.TahtaSutunSayisi = TahtaSutunSayisi;
            this.KareAltin = KareAltin;
            this.GizliKareAltin = GizliKareAltin;
            this.kullaniciAltin = kullaniciAltin;
            this.AdimAdeti = AdimAdeti;
            this.A_Hamle = A_Hamle;
            this.A_Hedef = A_Hedef;
            this.B_Hamle = B_Hamle;
            this.B_Hedef = B_Hedef;
            this.C_Hamle = C_Hamle;
            this.C_Hedef = C_Hedef;
            this.D_Hamle = D_Hamle;
            this.D_Hedef = D_Hedef;

            InitializeComponent();
        }
        private void GameStartForm_Load(object sender, EventArgs e)
        {
            KareSayisi = TahtaSatirSayisi * TahtaSutunSayisi;
            KareAltinSayisi = (KareSayisi * KareAltin) / 100;
            GizliKareAltinSayisi = (KareAltinSayisi * GizliKareAltin) / 100;

            Oyun_Tahtasini_Olustur();
            KareAltin_Ekle();
            GizliKareAltin_Ekle();
            Kutu_Degerini_Goster();
        }

        public void Oyun_Tahtasini_Olustur()
        {
            int k = 1;
            for (int i = 1; i <= TahtaSatirSayisi; i++)
            {
                for (int j = 1; j <= TahtaSutunSayisi; j++)
                {
                    Button x = new Button
                    {
                        Name = "btn" + k,
                        Size = new Size(30, 25),
                        Location = new Point(30 * j, 25 * i)
                    };
                    Controls.Add(x);

                    Board tahta = new Board
                    {
                        Adi = "btn" + k,
                        X_Koordinat = 30 * j,
                        Y_Koordinat = 25 * i,
                        Satir = i,
                        Sutun = j
                    };
                    list.Add(tahta);

                    if (i == 1 && j == 1)
                    {
                        Button a = new Button
                        {
                            Text = "A",
                            Name = "A",
                            Size = new Size(30, 25),
                            Location = new Point(30 * (j - 2), 25 * i)
                        };
                        Controls.Add(a);

                        A.Adi = "A";
                        A.Kalan_Altin = kullaniciAltin;
                        A.X_Koordinat = 30 * (j - 1);
                        A.Y_Koordinat = 25 * i;
                        A.Satir = i;
                        A.Sutun = j - 1;
                    }
                    else if (i == 1 && j == TahtaSutunSayisi)
                    {
                        Button b = new Button
                        {
                            Text = "B",
                            Name = "B",
                            Size = new Size(30, 25),
                            Location = new Point(30 * (j + 1), 25 * i)
                        };
                        Controls.Add(b);

                        B.Adi = "B";
                        B.Kalan_Altin = kullaniciAltin;
                        B.X_Koordinat = 30 * (j + 1);
                        B.Y_Koordinat = 25 * i;
                        B.Satir = i;
                        B.Sutun = j + 1;
                    }
                    else if (i == TahtaSatirSayisi && j == 1)
                    {
                        Button c = new Button
                        {
                            Text = "C",
                            Name = "C",
                            Size = new Size(30, 25),
                            Location = new Point(30 * (j - 1), 25 * i)
                        };
                        Controls.Add(c);

                        C.Adi = "C";
                        C.Kalan_Altin = kullaniciAltin;
                        C.X_Koordinat = 30 * (j - 1);
                        C.Y_Koordinat = 25 * i;
                        C.Satir = i;
                        C.Sutun = j - 1;
                    }
                    else if (i == TahtaSatirSayisi && j == TahtaSutunSayisi)
                    {
                        Button d = new Button
                        {
                            Text = "D",
                            Name = "D",
                            Size = new Size(30, 25),
                            Location = new Point(30 * (j + 1), 25 * i)
                        };
                        Controls.Add(d);

                        D.Adi = "D";
                        D.Kalan_Altin = kullaniciAltin;
                        D.X_Koordinat = 30 * (j + 1);
                        D.Y_Koordinat = 25 * i;
                        D.Satir = i;
                        D.Sutun = j + 1;
                    }
                    k++;
                }
            }
        }
        public void KareAltin_Ekle()
        {
            int i = 1;
            int[] degerler = { 5, 10, 15, 20 };
            List<int> randomList = new List<int>();
            while (i <= KareAltinSayisi)
            {
                Random rastgeleKareSec = new Random();
                Random rastgeleDegerSec = new Random();
                int kareToplami = TahtaSatirSayisi * TahtaSutunSayisi;
                int sayi = rastgeleKareSec.Next(kareToplami);
                if (!randomList.Contains(sayi))
                {
                    randomList.Add(sayi);
                    int index = rastgeleDegerSec.Next(degerler.Length);
                    list[sayi].Deger = degerler[index];
                    i++;
                }
            }
        }
        public void GizliKareAltin_Ekle()
        {
            int i = 1;
            List<int> randomList = new List<int>();
            var altinListe = list.Where(n => n.Deger != 0).ToList();
            while (i <= GizliKareAltinSayisi)
            {
                Random rastgeleKareSec = new Random();
                int sayi = rastgeleKareSec.Next(KareAltinSayisi);
                if (!randomList.Contains(sayi))
                {
                    randomList.Add(sayi);
                    altinListe[sayi].GizliMi = true;
                    i++;
                }
            }
        }
        public void Kutu_Degerini_Goster()
        {
            var buttons = list.Where(x => x.Deger != 0 && x.GizliMi == false).ToList();
            foreach (var item in buttons)
            {
                var control = this.Controls.OfType<Button>().Where(x => x.Name == item.Adi).FirstOrDefault();
                control.Text = item.Deger.ToString();
            }
        }
        public Way A_Hedef_Belirle()
        {
            Way hedef = new Way();
            if (A_Hedef < A.Kalan_Altin)
            {
                List<Range> Mesafeler = new List<Range>();

                foreach (var item in list.Where(x => x.Deger != 0 && !x.GizliMi))
                {
                    Range mesafe = new Range
                    {
                        Uzaklik = Math.Sqrt(Math.Pow((item.Y_Koordinat - A.Y_Koordinat), 2) + Math.Pow((item.X_Koordinat - A.X_Koordinat), 2)),
                        X_Koordinat = item.X_Koordinat,
                        Y_Koordinat = item.Y_Koordinat
                    };
                    Mesafeler.Add(mesafe);
                }

                Range enKisa = new Range
                {
                    Uzaklik = Mesafeler[0].Uzaklik,
                    X_Koordinat = Mesafeler[0].X_Koordinat,
                    Y_Koordinat = Mesafeler[0].Y_Koordinat
                };

                for (int i = 1; i < Mesafeler.Count; i++)
                {
                    if (Mesafeler[i].Uzaklik < enKisa.Uzaklik)
                    {
                        enKisa.Uzaklik = Mesafeler[i].Uzaklik;
                        enKisa.X_Koordinat = Mesafeler[i].X_Koordinat;
                        enKisa.Y_Koordinat = Mesafeler[i].Y_Koordinat;
                    }
                }

                var deger = list.Where(x => x.X_Koordinat == enKisa.X_Koordinat && x.Y_Koordinat == enKisa.Y_Koordinat).FirstOrDefault();


                hedef.Satir = deger.Satir;
                hedef.Sutun = deger.Sutun;

                A.Kalan_Altin -= A_Hedef;
                A.Harcanan_Altin += A_Hedef;

                return hedef;
            }
            else
            {
                A_Hedef_Kaldi_Mi = false;
                A_Bitti = true;
                Siradaki = Siraki_Kim("A");
                MessageBox.Show("A'nın altını bitti.");
                return hedef;
            }

        }
        public Way B_Hedef_Belirle()
        {
            Way hedef = new Way();
            if (B_Hedef < B.Kalan_Altin)
            {
                List<Range> Mesafeler = new List<Range>();

                foreach (var item in list.Where(x => x.Deger != 0 && !x.GizliMi))
                {
                    Range mesafe = new Range
                    {
                        Uzaklik = Math.Sqrt(Math.Pow((item.Y_Koordinat - B.Y_Koordinat), 2) + Math.Pow((item.X_Koordinat - B.X_Koordinat), 2)),
                        X_Koordinat = item.X_Koordinat,
                        Y_Koordinat = item.Y_Koordinat
                    };
                    int xFark = Math.Abs(item.Satir - B.Satir);
                    int yFark = Math.Abs(item.Sutun - B.Sutun);
                    int toplam = xFark + yFark;
                    int hamleSayisi = toplam % AdimAdeti == 0 ? (toplam / AdimAdeti) : (toplam / AdimAdeti) + 1;
                    int gidenAltin = hamleSayisi * B_Hamle;
                    mesafe.Kazanc = item.Deger - gidenAltin;

                    Mesafeler.Add(mesafe);
                }

                Range En_Kazancli = new Range
                {
                    Uzaklik = Mesafeler[0].Uzaklik,
                    X_Koordinat = Mesafeler[0].X_Koordinat,
                    Y_Koordinat = Mesafeler[0].Y_Koordinat,
                    Kazanc = Mesafeler[0].Kazanc
                };

                foreach (var item in Mesafeler)
                {
                    if (item.Kazanc >= En_Kazancli.Kazanc)
                    {
                        if (item.Kazanc == En_Kazancli.Kazanc)
                        {
                            if (item.Uzaklik < En_Kazancli.Uzaklik)
                                En_Kazancli = item;
                        }
                        else
                            En_Kazancli = item;
                    }
                }

                var deger = list.Where(x => x.X_Koordinat == En_Kazancli.X_Koordinat && x.Y_Koordinat == En_Kazancli.Y_Koordinat).FirstOrDefault();

                hedef.Satir = deger.Satir;
                hedef.Sutun = deger.Sutun;

                B.Kalan_Altin -= B_Hedef;
                B.Harcanan_Altin += B_Hedef;

                return hedef;
            }
            else
            {
                B_Hedef_Kaldi_Mi = false;
                B_Bitti = true;
                Siradaki = Siraki_Kim("B");
                MessageBox.Show("B'nin altını bitti.");
                return hedef;
            }
        }
        public Way C_Hedef_Belirle()
        {
            Way hedef = new Way();
            if (C_Hedef < C.Kalan_Altin)
            {
                List<Range> Mesafeler = new List<Range>();

                foreach (var item in list.Where(x => x.Deger != 0 && !x.GizliMi))
                {
                    Range mesafe = new Range
                    {
                        Uzaklik = Math.Sqrt(Math.Pow((item.Y_Koordinat - C.Y_Koordinat), 2) + Math.Pow((item.X_Koordinat - C.X_Koordinat), 2)),
                        X_Koordinat = item.X_Koordinat,
                        Y_Koordinat = item.Y_Koordinat
                    };
                    int xFark = Math.Abs(item.Satir - C.Satir);
                    int yFark = Math.Abs(item.Sutun - C.Sutun);
                    int toplam = xFark + yFark;
                    int hamleSayisi = toplam % AdimAdeti == 0 ? (toplam / AdimAdeti) : (toplam / AdimAdeti) + 1;
                    int gidenAltin = hamleSayisi * B_Hamle;
                    mesafe.Kazanc = item.Deger - gidenAltin;

                    Mesafeler.Add(mesafe);
                }

                Range En_Kazancli = new Range
                {
                    Uzaklik = Mesafeler[0].Uzaklik,
                    X_Koordinat = Mesafeler[0].X_Koordinat,
                    Y_Koordinat = Mesafeler[0].Y_Koordinat,
                    Kazanc = Mesafeler[0].Kazanc
                };

                foreach (var item in Mesafeler)
                {
                    if (item.Kazanc >= En_Kazancli.Kazanc)
                    {
                        if (item.Kazanc == En_Kazancli.Kazanc)
                        {
                            if (item.Uzaklik < En_Kazancli.Uzaklik)
                                En_Kazancli = item;
                        }
                        else
                            En_Kazancli = item;
                    }
                }

                var deger = list.Where(x => x.X_Koordinat == En_Kazancli.X_Koordinat && x.Y_Koordinat == En_Kazancli.Y_Koordinat).FirstOrDefault();

                hedef.Satir = deger.Satir;
                hedef.Sutun = deger.Sutun;

                C.Kalan_Altin -= C_Hedef;
                C.Harcanan_Altin += C_Hedef;

                return hedef;
            }
            else
            {
                C_Hedef_Kaldi_Mi = false;
                C_Bitti = true;
                Siradaki = Siraki_Kim("C");
                MessageBox.Show("C'nin altını bitti.");
                return hedef;
            }
        }
        public Way D_Hedef_Belirle()
        {
            Way hedef = new Way();
            if (D_Hedef < D.Kalan_Altin)
            {
                List<Range> Mesafeler = new List<Range>();
                Way alinmayacakAYol = new Way();

                List<Way> alinmayacakYollar = new List<Way>();
                int xFark, yFark, xToplam, dXFark, dYFark, dToplam;

                xFark = Math.Abs(A.Satir - A_Hedef_Yol.Satir);
                yFark = Math.Abs(A.Sutun - A_Hedef_Yol.Sutun);
                xToplam = xFark + yFark;

                dXFark = Math.Abs(D.Satir - A_Hedef_Yol.Satir);
                dYFark = Math.Abs(D.Sutun - A_Hedef_Yol.Sutun);
                dToplam = dXFark + dYFark;

                if (xToplam < dToplam)
                {
                    alinmayacakAYol.Satir = A_Hedef_Yol.Satir;
                    alinmayacakAYol.Sutun = A_Hedef_Yol.Sutun;
                    alinmayacakYollar.Add(alinmayacakAYol);
                }

                Way alinmayacakBYol = new Way();

                xFark = Math.Abs(B.Satir - B_Hedef_Yol.Satir);
                yFark = Math.Abs(B.Sutun - B_Hedef_Yol.Sutun);
                xToplam = xFark + yFark;

                dXFark = Math.Abs(D.Satir - B_Hedef_Yol.Satir);
                dYFark = Math.Abs(D.Sutun - B_Hedef_Yol.Sutun);
                dToplam = dXFark + dYFark;

                if (xToplam < dToplam)
                {
                    alinmayacakBYol.Satir = B_Hedef_Yol.Satir;
                    alinmayacakBYol.Sutun = B_Hedef_Yol.Sutun;
                    alinmayacakYollar.Add(alinmayacakBYol);
                }

                Way alinmayacakCYol = new Way();

                xFark = Math.Abs(C.Satir - C_Hedef_Yol.Satir);
                yFark = Math.Abs(C.Sutun - C_Hedef_Yol.Sutun);
                xToplam = xFark + yFark;

                dXFark = Math.Abs(D.Satir - C_Hedef_Yol.Satir);
                dYFark = Math.Abs(D.Sutun - C_Hedef_Yol.Sutun);
                dToplam = dXFark + dYFark;

                if (xToplam < dToplam)
                {
                    alinmayacakCYol.Satir = C_Hedef_Yol.Satir;
                    alinmayacakCYol.Sutun = C_Hedef_Yol.Sutun;
                    alinmayacakYollar.Add(alinmayacakCYol);
                }
                foreach (var item in list.Where(x => x.Deger != 0 && !x.GizliMi))
                {
                    if (!alinmayacakYollar.Exists(x => x.Satir == item.Satir && x.Sutun == item.Sutun))
                    {
                        Range mesafe = new Range
                        {
                            Uzaklik = Math.Sqrt(Math.Pow((item.Y_Koordinat - D.Y_Koordinat), 2) + Math.Pow((item.X_Koordinat - D.X_Koordinat), 2)),
                            X_Koordinat = item.X_Koordinat,
                            Y_Koordinat = item.Y_Koordinat
                        };
                        int xxFark = Math.Abs(item.Satir - D.Satir);
                        int yyFark = Math.Abs(item.Sutun - D.Sutun);
                        int toplam = xxFark + yyFark;
                        int hamleSayisi = toplam % AdimAdeti == 0 ? (toplam / AdimAdeti) : (toplam / AdimAdeti) + 1;
                        int gidenAltin = hamleSayisi * B_Hamle;
                        mesafe.Kazanc = item.Deger - gidenAltin;

                        Mesafeler.Add(mesafe);

                    }
                }

                if (Mesafeler.Count() > 0)
                {
                    Range En_Kazancli = new Range
                    {
                        Uzaklik = Mesafeler[0].Uzaklik,
                        X_Koordinat = Mesafeler[0].X_Koordinat,
                        Y_Koordinat = Mesafeler[0].Y_Koordinat,
                        Kazanc = Mesafeler[0].Kazanc
                    };

                    foreach (var item in Mesafeler)
                    {
                        if (item.Kazanc >= En_Kazancli.Kazanc)
                        {
                            if (item.Kazanc == En_Kazancli.Kazanc)
                            {
                                if (item.Uzaklik < En_Kazancli.Uzaklik)
                                    En_Kazancli = item;
                            }
                            else
                                En_Kazancli = item;
                        }
                    }

                    var deger = list.Where(x => x.X_Koordinat == En_Kazancli.X_Koordinat && x.Y_Koordinat == En_Kazancli.Y_Koordinat).FirstOrDefault();

                    hedef.Satir = deger.Satir;
                    hedef.Sutun = deger.Sutun;

                    D.Kalan_Altin -= D_Hedef;
                    D.Harcanan_Altin += D_Hedef;
                }

                return hedef;
            }
            else
            {
                D_Hedef_Kaldi_Mi = false;
                D_Bitti = true;
                Siradaki = Siraki_Kim("D");
                MessageBox.Show("D'nin altını bitti.");
                return hedef;
            }

        }
        public void Cebini_KontrolEt(Player Oyuncu)
        {
            if (Oyuncu.Adi == "A")
            {
                if (Oyuncu.Kalan_Altin < A_Hedef)
                {
                    A_Hamle_Kaldi_Mi = false;
                    A_Bitti = true;
                    Siradaki = Siraki_Kim("A");
                    MessageBox.Show("A'nın hamle için yeterli altını yok. Sıra " + Siradaki + "'da");
                    return;
                }
            }
            else if (Oyuncu.Adi == "B")
            {
                if (Oyuncu.Kalan_Altin < A_Hedef)
                {
                    B_Hamle_Kaldi_Mi = false;
                    B_Bitti = true;
                    Siradaki = Siraki_Kim("A");
                    MessageBox.Show("B'nın hamle için yeterli altını yok. Sıra " + Siradaki + "'da");
                    return;
                }
            }
            else if (Oyuncu.Adi == "C")
            {
                if (Oyuncu.Kalan_Altin < A_Hedef)
                {
                    C_Hamle_Kaldi_Mi = false;
                    C_Bitti = true;
                    Siradaki = Siraki_Kim("A");
                    MessageBox.Show("C'nın hamle için yeterli altını yok. Sıra " + Siradaki + "'da");
                    return;
                }
            }
            else if (Oyuncu.Adi == "D")
            {
                if (Oyuncu.Kalan_Altin < A_Hedef)
                {
                    D_Hamle_Kaldi_Mi = false;
                    D_Bitti = true;
                    Siradaki = Siraki_Kim("A");
                    MessageBox.Show("D'nın hamle için yeterli altını yok. Sıra " + Siradaki + "'da");
                    return;
                }
            }
        }

        public void HamleYap(Player Oyuncu, Way hedef, int AdimAdeti, int k)
        {
            Cebini_KontrolEt(Oyuncu);
            Way temp = new Way();
            if (!Oyuncu.ilk_Hedef_Mi)
            {
                var Onceki_Deger = list.Where(x => x.Satir == Oyuncu.Satir && x.Sutun == Oyuncu.Sutun).FirstOrDefault();
                var Onceki_Button = this.Controls.OfType<Button>().Where(x => x.Name == Onceki_Deger.Adi).FirstOrDefault();
                Onceki_Button.BackColor = default;
                Onceki_Button.Text = "";
            }

            while (AdimAdeti != 0 && !(Oyuncu.Satir == hedef.Satir && Oyuncu.Sutun == hedef.Sutun))
            {
                List<Way> tempYollar = new List<Way>();
                int fark;
                if (hedef.Sutun > Oyuncu.Sutun) // Sağa git
                {
                    fark = hedef.Sutun - Oyuncu.Sutun;
                    temp.Satir = Oyuncu.Satir;
                    if (AdimAdeti > fark)
                    {
                        temp.Sutun = Oyuncu.Sutun + fark;
                        Oyuncu.X_Koordinat = 30 * temp.Sutun;
                        AdimAdeti -= fark;
                        for (int i = 0; i < fark; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir,
                                Sutun = Oyuncu.Sutun + i
                            };
                            tempYollar.Add(adim);
                        }
                    }
                    else
                    {
                        temp.Sutun = Oyuncu.Sutun + AdimAdeti;
                        Oyuncu.X_Koordinat = 30 * temp.Sutun;
                        for (int i = 0; i < AdimAdeti; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir,
                                Sutun = Oyuncu.Sutun + i
                            };
                            tempYollar.Add(adim);
                        }
                        AdimAdeti = 0;
                    }
                    k = 1;
                }
                if (hedef.Sutun < Oyuncu.Sutun) // Sola git
                {
                    fark = Oyuncu.Sutun - hedef.Sutun;
                    temp.Satir = Oyuncu.Satir;
                    if (AdimAdeti > fark)
                    {
                        temp.Sutun = Oyuncu.Sutun - fark;
                        Oyuncu.X_Koordinat = 30 * temp.Sutun;
                        AdimAdeti -= fark;
                        for (int i = 0; i < fark; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir,
                                Sutun = Oyuncu.Sutun - i
                            };
                            tempYollar.Add(adim);
                        }
                    }
                    else
                    {
                        temp.Sutun = Oyuncu.Sutun - AdimAdeti;
                        Oyuncu.X_Koordinat = 30 * temp.Sutun;
                        for (int i = 0; i < AdimAdeti; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir,
                                Sutun = Oyuncu.Sutun - i
                            };
                            tempYollar.Add(adim);
                        }
                        AdimAdeti = 0;
                    }
                    k = 1;
                }
                if (hedef.Sutun == Oyuncu.Sutun && hedef.Satir > Oyuncu.Satir) // Aşağı git
                {
                    fark = hedef.Satir - Oyuncu.Satir;
                    temp.Sutun = Oyuncu.Sutun;
                    if (AdimAdeti > fark)
                    {
                        temp.Satir = Oyuncu.Satir + fark;
                        Oyuncu.Y_Koordinat = 25 * temp.Satir;
                        AdimAdeti -= fark;
                        for (int i = 0; i < fark; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir + i,
                                Sutun = Oyuncu.Sutun
                            };
                            tempYollar.Add(adim);
                        }
                    }
                    else
                    {
                        temp.Satir = Oyuncu.Satir + AdimAdeti;
                        Oyuncu.Y_Koordinat = 25 * temp.Satir;
                        for (int i = 0; i < AdimAdeti; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir + i,
                                Sutun = Oyuncu.Sutun
                            };
                            tempYollar.Add(adim);
                        }
                        AdimAdeti = 0;
                    }
                    k = 1;
                }
                if (hedef.Sutun == Oyuncu.Sutun && hedef.Satir < Oyuncu.Satir) // Yukarı git
                {
                    fark = Oyuncu.Satir - hedef.Satir;
                    temp.Sutun = Oyuncu.Sutun;
                    if (AdimAdeti > fark)
                    {
                        temp.Satir = Oyuncu.Satir - fark;
                        Oyuncu.Y_Koordinat = 25 * temp.Satir;
                        AdimAdeti -= fark;
                        for (int i = 0; i < fark; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir - i,
                                Sutun = Oyuncu.Sutun
                            };
                            tempYollar.Add(adim);
                        }
                    }
                    else
                    {
                        temp.Satir = Oyuncu.Satir - AdimAdeti;
                        Oyuncu.Y_Koordinat = 25 * temp.Satir;

                        for (int i = 0; i < AdimAdeti; i++)
                        {
                            Way adim = new Way
                            {
                                Satir = Oyuncu.Satir - i,
                                Sutun = Oyuncu.Sutun
                            };
                            tempYollar.Add(adim);
                        }
                        AdimAdeti = 0;
                    }
                    k = 1;
                }

                Oyuncu.Satir = temp.Satir;
                Oyuncu.Sutun = temp.Sutun;

                if (Oyuncu.Adi == "A")
                    A_Yollari.AddRange(tempYollar);
                if (Oyuncu.Adi == "B")
                    B_Yollari.AddRange(tempYollar);
                if (Oyuncu.Adi == "C")
                    C_Yollari.AddRange(tempYollar);
                if (Oyuncu.Adi == "D")
                    D_Yollari.AddRange(tempYollar);

                foreach (var item in tempYollar)
                {
                    if (item.Sutun != 0 && item.Sutun != (TahtaSutunSayisi + 1))
                    {
                        var deger = list.Where(x => x.Satir == item.Satir && x.Sutun == item.Sutun).FirstOrDefault();
                        if (deger.GizliMi)
                        {
                            var button = this.Controls.OfType<Button>().Where(x => x.Name == deger.Adi).FirstOrDefault();
                            button.Text = deger.Deger.ToString();
                            deger.GizliMi = false;
                        }
                    }
                }
            }

            if (Oyuncu.Adi == "A")
            {
                Oyuncu.Harcanan_Altin += A_Hamle;
                Oyuncu.Kalan_Altin -= A_Hamle;
            }
            else if (Oyuncu.Adi == "B")
            {
                Oyuncu.Harcanan_Altin += B_Hamle;
                Oyuncu.Kalan_Altin -= B_Hamle;
            }
            else if (Oyuncu.Adi == "C")
            {
                Oyuncu.Harcanan_Altin += C_Hamle;
                Oyuncu.Kalan_Altin -= C_Hamle;
            }
            else if (Oyuncu.Adi == "D")
            {
                Oyuncu.Harcanan_Altin += D_Hamle;
                Oyuncu.Kalan_Altin -= D_Hamle;
            }
        }
        private void BtnOyna_Click(object sender, EventArgs e)
        {
            Siradaki = String.IsNullOrEmpty(Siradaki) ? "A" : Siradaki;
            if (Siradaki == "A")
            {
                if (A_Hamle_Kaldi_Mi && A_Hedef_Kaldi_Mi)
                {
                    if (A.ilk_Hedef_Mi)
                    {
                        ButtonVisibleFalse("A");
                        A_Hedef_Yol = A_Hedef_Belirle();
                        HamleYap(A, A_Hedef_Yol, AdimAdeti, 0);
                        Hamleyi_Kontrol_Et(A, A_Hedef_Yol);
                        RenkVer(A);
                        A.ilk_Hedef_Mi = false;
                        if (A.Hedefe_Varildi_Mi)
                        {
                            A_Hedef_Yol = A_Hedef_Belirle();
                        }
                        Siradaki = "B";
                    }
                    else
                    {
                        bool Hedef_Duruyor_Mu = Hedefi_Kontrol_Et(A_Hedef_Yol);
                        if (Hedef_Duruyor_Mu)
                            HamleYap(A, A_Hedef_Yol, AdimAdeti, 1);
                        else
                        {
                            A_Hedef_Yol = A_Hedef_Belirle();
                            HamleYap(A, A_Hedef_Yol, AdimAdeti, 1);
                        }
                        Hamleyi_Kontrol_Et(A, A_Hedef_Yol);
                        RenkVer(A);
                        if (A.Hedefe_Varildi_Mi)
                        {
                            if (KareAltinSayisi != 0)
                                A_Hedef_Belirle();
                        }
                        Siradaki = "B";
                    }
                }
                else
                {
                    Siradaki = "B";
                    BtnOyna_Click(null, EventArgs.Empty);
                }
            }
            else if (Siradaki == "B")
            {
                if (B_Hamle_Kaldi_Mi && B_Hedef_Kaldi_Mi)
                {
                    if (B.ilk_Hedef_Mi)
                    {
                        ButtonVisibleFalse("B");
                        B_Hedef_Yol = B_Hedef_Belirle();
                        HamleYap(B, B_Hedef_Yol, AdimAdeti, 0);
                        Hamleyi_Kontrol_Et(B, B_Hedef_Yol);
                        RenkVer(B);
                        B.ilk_Hedef_Mi = false;
                        if (B.Hedefe_Varildi_Mi)
                        {
                            B_Hedef_Yol = B_Hedef_Belirle();
                        }
                        Siradaki = "C";
                    }
                    else
                    {
                        bool Hedef_Duruyor_Mu = Hedefi_Kontrol_Et(B_Hedef_Yol);
                        if (Hedef_Duruyor_Mu)
                            HamleYap(B, B_Hedef_Yol, AdimAdeti, 1);
                        else
                        {
                            B_Hedef_Yol = B_Hedef_Belirle();
                            HamleYap(B, B_Hedef_Yol, AdimAdeti, 1);
                        }
                        Hamleyi_Kontrol_Et(B, B_Hedef_Yol);
                        RenkVer(B);
                        if (B.Hedefe_Varildi_Mi)
                        {
                            if (KareAltinSayisi != 0)
                                B_Hedef_Belirle();
                        }
                        Siradaki = "C";
                    }
                }
                else
                {
                    Siradaki = "C";
                    BtnOyna_Click(null, EventArgs.Empty);
                }
            }
            else if (Siradaki == "C")
            {
                if (C_Hamle_Kaldi_Mi && C_Hedef_Kaldi_Mi)
                {
                    if (C.ilk_Hedef_Mi)
                    {
                        ButtonVisibleFalse("C");
                        C_Hedef_Yol = C_Hedef_Belirle();
                        HamleYap(C, C_Hedef_Yol, AdimAdeti, 0);
                        Hamleyi_Kontrol_Et(C, C_Hedef_Yol);
                        RenkVer(C);
                        C.ilk_Hedef_Mi = false;
                        if (C.Hedefe_Varildi_Mi)
                        {
                            if (KareAltinSayisi != 0)
                                C_Hedef_Yol = C_Hedef_Belirle();
                        }
                        Siradaki = "D";

                    }
                    else
                    {
                        bool Hedef_Duruyor_Mu = Hedefi_Kontrol_Et(C_Hedef_Yol);
                        if (Hedef_Duruyor_Mu)
                            HamleYap(C, C_Hedef_Yol, AdimAdeti, 1);
                        else
                        {

                            C_Hedef_Yol = C_Hedef_Belirle();
                            HamleYap(C, C_Hedef_Yol, AdimAdeti, 1);
                        }
                        Hamleyi_Kontrol_Et(C, C_Hedef_Yol);
                        RenkVer(C);
                        if (C.Hedefe_Varildi_Mi)
                        {
                            if (KareAltinSayisi != 0)
                                C_Hedef_Belirle();
                        }
                        Siradaki = "D";
                    }
                }
                else
                {
                    Siradaki = "D";
                    BtnOyna_Click(null, EventArgs.Empty);

                }
            }
            else if (Siradaki == "D")
            {
                if (D_Hamle_Kaldi_Mi && D_Hedef_Kaldi_Mi)
                {
                    if (D.ilk_Hedef_Mi)
                    {
                        ButtonVisibleFalse("D");
                        D_Hedef_Yol = D_Hedef_Belirle();
                        HamleYap(D, D_Hedef_Yol, AdimAdeti, 0);
                        Hamleyi_Kontrol_Et(D, D_Hedef_Yol);
                        RenkVer(D);
                        D.ilk_Hedef_Mi = false;
                        if (D.Hedefe_Varildi_Mi)
                        {
                            D_Hedef_Yol = D_Hedef_Belirle();
                        }
                        Siradaki = "A";
                    }
                    else
                    {
                        if (!(D_Hedef_Yol.Satir == 0 && D_Hedef_Yol.Sutun == 0))
                        {
                            bool Hedef_Duruyor_Mu = Hedefi_Kontrol_Et(D_Hedef_Yol);
                            if (Hedef_Duruyor_Mu)
                                HamleYap(D, D_Hedef_Yol, AdimAdeti, 1);
                            else
                            {
                                D_Hedef_Yol = D_Hedef_Belirle();
                                if (!(D_Hedef_Yol.Satir == 0 && D_Hedef_Yol.Sutun == 0))
                                    HamleYap(D, D_Hedef_Yol, AdimAdeti, 1);
                                else
                                {
                                    Siradaki = "A";
                                    return;
                                }
                            }
                            Hamleyi_Kontrol_Et(D, D_Hedef_Yol);
                            RenkVer(D);
                            if (D.Hedefe_Varildi_Mi)
                            {
                                if (D_Hedef_Kaldi_Mi && KareAltinSayisi != 0)
                                    D_Hedef_Belirle();
                            }
                        }
                        Siradaki = "A";
                    }
                }
                else
                {
                    Siradaki = "A";
                    BtnOyna_Click(null, EventArgs.Empty);
                }
            }
            if (KareAltinSayisi == 0)
            {
                MessageBox.Show("....Oyun bitti....");
                btnOyna.Enabled = false;
                return;
            }
            if (A_Bitti && B_Bitti && C_Bitti && D_Bitti)
            {
                MessageBox.Show("Oyuncuların altını bitti. ....Oyun bitti....");
                btnOyna.Enabled = false;
                return;
            }
            if (Siradaki == "C")
            {
                if (C.Kalan_Altin != 0)
                {
                    Uc_Gizli_Kutuyu_Ac();
                }
            }

        }
        public void ButtonVisibleFalse(string adi)
        {
            var button = this.Controls.OfType<Button>().Where(x => x.Name == adi).FirstOrDefault();
            button.Visible = false;
        }
        public bool Hedefi_Kontrol_Et(Way hedef)
        {
            var item = list.Where(x => x.Satir == hedef.Satir && x.Sutun == hedef.Sutun).FirstOrDefault();
            if (item.Deger != 0)
                return true;
            else
                return false;
        }
        public void Hamleyi_Kontrol_Et(Player Oyuncu, Way hedef)
        {
            if (Oyuncu.Satir == hedef.Satir && Oyuncu.Sutun == hedef.Sutun)
            {
                var item = list.Where(x => x.Satir == Oyuncu.Satir && x.Sutun == Oyuncu.Sutun).FirstOrDefault();
                item.Deger = 0;
                var button = this.Controls.OfType<Button>().Where(x => x.Name == item.Adi).FirstOrDefault();
                Oyuncu.Toplanan_Altin += item.Deger;
                Oyuncu.Kalan_Altin += item.Deger;
                button.Text = "";
                Oyuncu.Hedefe_Varildi_Mi = true;
                KareAltinSayisi -= 1;
            }
            else
            {
                Oyuncu.Hedefe_Varildi_Mi = false;
            }
        }
        public void RenkVer(Player Oyuncu)
        {
            var control = list.Where(x => x.Satir == Oyuncu.Satir && x.Sutun == Oyuncu.Sutun).FirstOrDefault();
            var button = this.Controls.OfType<Button>().Where(x => x.Name == control.Adi).FirstOrDefault();
            button.BackColor = Oyuncu.Color;
            button.Text = Oyuncu.Adi;
        }
        public void Uc_Gizli_Kutuyu_Ac()
        {
            List<Range> Mesafeler = new List<Range>();

            if (list.Where(x => x.GizliMi).Count() != 0)
            {
                foreach (var item in list.Where(x => x.GizliMi))
                {
                    Range mesafe = new Range
                    {
                        Uzaklik = Math.Sqrt(Math.Pow((item.Y_Koordinat - C.Y_Koordinat), 2) + Math.Pow((item.X_Koordinat - C.X_Koordinat), 2)),
                        X_Koordinat = item.X_Koordinat,
                        Y_Koordinat = item.Y_Koordinat
                    };
                    Mesafeler.Add(mesafe);
                }

                if (Mesafeler.Count() >= 3)
                    Mesafeler = Mesafeler.OrderBy(x => x.Uzaklik).Take(2).ToList();
                else
                    Mesafeler = Mesafeler.OrderBy(x => x.Uzaklik).Take(1).ToList();

                foreach (var item in Mesafeler)
                {
                    var value = list.Where(x => x.X_Koordinat == item.X_Koordinat && x.Y_Koordinat == item.Y_Koordinat).FirstOrDefault();
                    value.GizliMi = false;
                    var button = this.Controls.OfType<Button>().Where(x => x.Name == value.Adi).FirstOrDefault();
                    button.Text = value.Deger.ToString();
                }
            }
        }
        public string Siraki_Kim(string oynayan)
        {
            if (oynayan == "A")
            {
                if (B_Hamle_Kaldi_Mi && B_Hedef_Kaldi_Mi)
                    Siradaki = "B";
                else if (C_Hamle_Kaldi_Mi && C_Hedef_Kaldi_Mi)
                    Siradaki = "C";
                else if (D_Hamle_Kaldi_Mi && D_Hedef_Kaldi_Mi)
                    Siradaki = "D";

            }
            else if (oynayan == "B")
            {
                if (C_Hamle_Kaldi_Mi && C_Hedef_Kaldi_Mi)
                    Siradaki = "C";
                else if (D_Hamle_Kaldi_Mi && D_Hedef_Kaldi_Mi)
                    Siradaki = "D";
                else if (A_Hamle_Kaldi_Mi && A_Hedef_Kaldi_Mi)
                    Siradaki = "A";
            }
            else if (oynayan == "C")
            {
                if (D_Hamle_Kaldi_Mi && D_Hedef_Kaldi_Mi)
                    Siradaki = "D";
                else if (A_Hamle_Kaldi_Mi && A_Hedef_Kaldi_Mi)
                    Siradaki = "A";
                else if (B_Hamle_Kaldi_Mi && B_Hedef_Kaldi_Mi)
                    Siradaki = "B";
            }
            else if (oynayan == "D")
            {
                if (A_Hamle_Kaldi_Mi && A_Hedef_Kaldi_Mi)
                    Siradaki = "A";
                else if (B_Hamle_Kaldi_Mi && B_Hedef_Kaldi_Mi)
                    Siradaki = "B";
                else if (D_Hamle_Kaldi_Mi && D_Hedef_Kaldi_Mi)
                    Siradaki = "D";
            }
            return Siradaki;
        }
    }
}
