using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; //karakökunu almak icin cagırdım

namespace KapsamaProblemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string tum;
        string minimum_kap = "";
        int tur = -1;

        ArrayList TumKapsamaListesi = new ArrayList();
        ArrayList TumDurumListesi = new ArrayList();
        int counter = 0;

        DataGridView[] indirgenenTablo = new DataGridView[200];
        ArrayList indirgenmisDurumListesi = new ArrayList();
        ArrayList suankiKapsama = new ArrayList();

        void data_grid_view_kopyala(DataGridView sourceGrid, DataGridView targetGrid)
        {
            //Satir ve sutun kopyalama işlemi

            var targetRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow sourceRow in sourceGrid.Rows)
            {

                if (!sourceRow.IsNewRow)
                {

                    var targetRow = (DataGridViewRow)sourceRow.Clone();


                    foreach (DataGridViewCell cell in sourceRow.Cells)
                    {
                        targetRow.Cells[cell.ColumnIndex].Value = cell.Value;
                    }

                    targetRows.Add(targetRow);

                }

            }

            // Hedef sutunları kaynak sutundan alma işlemi

            targetGrid.Columns.Clear();

            foreach (DataGridViewColumn column in sourceGrid.Columns)
            {
                targetGrid.Columns.Add((DataGridViewColumn)column.Clone());
            }

            // Kullanılan method : AddRange method (if available)

            targetGrid.Rows.AddRange(targetRows.ToArray());
        }

        private void btnTabloOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                int satir = Convert.ToInt32(txtBoxSatir.Text);
                int sutun = Convert.ToInt32(txtBoxSutun.Text);

                sutun++;//Satir isimlerine yer ayirmak için arttiriyoruz 

               TabloOlusturFonk(satir, sutun);

            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen satır ve sutun değerleri girdiğinizden emin olunuz!");
            }
        }

        void TabloOlusturFonk(int str, int stn)
        {
            DataTable tablo = new DataTable();//tabloyu olusturduk

            for (int i = 0; i < stn; i++)
            {
                if (i == 0)
                    tablo.Columns.Add("Satır İsimleri"); //ilk yeri satir adina verdik
                else
                    tablo.Columns.Add("X" + i.ToString()); //sutun isimleri x1 x2 x3.. olacak    
            }

            for (int i = 0; i < str; i++)
                tablo.Rows.Add();//satirlari ekledik 0 dan baslaycak sekilde
           
            AnaTabloView.DataSource = tablo;

            for (int i = 0; i < str; i++)
                AnaTabloView.Rows[i].Cells[0].Value = "Y" + (i + 1).ToString(); //satir isimleri Y1 Y2 olacak ama 0. hücreden baslayacak  

            for (int i = 0; i < stn; i++)
                AnaTabloView.Columns[i].Width = 40; // sutunların boyutunu,genişligini belirlerdik
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            try
            {
                int satir = Convert.ToInt32(txtBoxSatir.Text);
                int sutun = Convert.ToInt32(txtBoxSutun.Text);
                sutun++;

                TabloOlusturFonk(satir, sutun);//random icin önce tablomu almam gerekli
                RastgeleTabloFonk(satir, sutun);

            }
            catch (Exception)
            { 
                MessageBox.Show("Lütfen satır ve sütun değerleri giriniz!");
            }
        }

        void RastgeleTabloFonk(int satir, int sutun)
        {
            int satirKok = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(satir))); //koku aldıgımızda deger double olusur onu int a ceviriyoruz 
            int sutunKok = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(sutun)));

            Random rnd = new Random();
            int sayi;

            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutunKok; j++)
                {
                    sayi = rnd.Next(1, sutun); //sutun kadar dolas içine 1 ata 
                    AnaTabloView.Rows[i].Cells[sayi].Value = "1"; //butun satirlari gez, hücrelere ulaş ,random sayi degeri olarak 1 ata
                }
            }

            for (int i = 1; i < sutun; i++)
            {
                for (int j = 0; j < satirKok; j++)
                {
                    sayi = rnd.Next(1, satir); 
                    AnaTabloView.Rows[sayi].Cells[i].Value = "1"; // sütün kadar hucre dolaş ve 1 degerini ata  ??
                }
            }
        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow satir = AnaTabloView.CurrentRow; // ana tabloda sectigim satiri buldum 
                AnaTabloView.Rows.Remove(satir); //sectigim satiri siliyorum 
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir hücre seçin !");
            }
        }

        private void btnSutunSil_Click(object sender, EventArgs e)
        {
            try
            {
                AnaTabloView.Columns.Remove(AnaTabloView.Columns[AnaTabloView.CurrentCell.ColumnIndex].Name); // ana tabloda suanki hücrenin sutun indeksinin ismini aliıp siliyoruz 
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir hücre seçin !");
            }
        }

        private void btnTumKapsama_Click(object sender, EventArgs e)
        {
            try
            {
                int satir = AnaTabloView.RowCount; //satirlari aldim 
                int sutun = AnaTabloView.ColumnCount; // sutunları aldim 

                VeriCevirmeFonk(satir, sutun);
                VeriSadelestirFonk();
                tumkapgerekli();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen verileri kontol ediniz!");
            }
        }

        void tumkapgerekli()
        {
            tur = 0;
            pndurum.Visible = true;
            pnonceki.Visible = true;
            pnsonraki.Visible = true;
            dsonraki.Visible = false;
            donceki.Visible = false;



            durumlar.Items.Clear();

            for (int i = 0; i < TumDurumListesi.Count; i++)
                durumlar.Items.Add("Durum : " + (i + 1).ToString());

            durumlar.SelectedIndex = 0;

            lbdurum.Text = "";

            lbdurum.Text = TumDurumListesi[0].ToString();


            lbonceki.Text = TumKapsamaListesi[0].ToString();
            lbsonraki.Text = TumKapsamaListesi[0].ToString();

            minumumkapsamam.Text = " ";
        }

        void VeriCevirmeFonk(int satir,int sutun)
        {
            TumKapsamaListesi.Clear(); //diziyi temizledim, kontrol amaclı
            TumDurumListesi.Clear();
            tum = "";

            for (int i = 1; i < sutun; i++)
            {
                tum += "(";             ///////// = değil += yoksa her tur veriyi sıfırlar

                for (int j = 0; j < satir; j++)
                {
                    if (VeriCekmeFonk(j, i) == "1")   /////// sutun değişkeni için i belirlemişsiniz ama j göndermişsiniz
                    {

                        tum += VeriCekmeFonk(j, 0) + "+"; // (s1+s3)*(s4+s1) gibi olması ıcın yaptık   
                    }
                    else { }
                }
                tum += ")*"; // (s1+s3+)*(s4+s1+)* gibi oldu 

            }

            tum = tum.Remove(tum.Length - 1);//en sondaki * isaretini sildim
            tum = tum.Replace("+)", ")"); //veriyi duzenledim 


            TumKapsamaListesi.Add(tum);
            TumDurumListesi.Add("Tabloyu Boole fonksiyonuna çevirdik");
        }

        string VeriCekmeFonk(int a, int b)
        {
            return AnaTabloView.Rows[a].Cells[b].Value.ToString(); //degeri stringe ceviriyor ve satir-sutunu hemen cekmemizi saglar 
        }

        void VeriSadelestirFonk()
        {
            string[] gecici = tum.Split('*'); //tum veriyi * ya gore parcala 
            string ilk = gecici[0]; //ilkini tutuyorum 

            ilk = ilk.Remove(0, 1); //ilk in 0. indisinden itibaren  1 tane sil 
            ilk = ilk.Remove(ilk.Length - 1); //sondaki ) i sildim 

            for (int i = 1; i < gecici.Length; i++) //ilk elemanı ilk e atadım ondan 1 dedim 
            {
                gecici[i] = gecici[i].Remove(0, 1);
                gecici[i] = gecici[i].Remove(gecici[i].Length -  1); //tum elemanları parantezden kurtardım 

                string ikinci = "";

                if(i != gecici.Length - 1)
                {
                    for (int j = i + 1; j < gecici.Length; j++)
                        ikinci += "*" + gecici[j]; 
                }

                ilk = carp(ilk, gecici[i], ikinci);   ///çarp fonksiyonu sorunsuz
                ilk = birinciKural(ilk, ikinci);
                ilk = ikinciKural(ilk, ikinci);
            }

            string[] par = ilk.Split('+');
            string gec = "";

            for (int i = 0; i < par.Length; i++)
                gec += par[i] + "\n\n";

            TumDurumListesi.Add("Kapsamalar  parçalandı");
            TumKapsamaListesi.Add(gec);
        }

        string carp(string x, string y, string z)
        {
            string[] geciciDizi1 = x.Split('+');
            string[] geciciDizi2 = y.Split('+');

            string carpim = "" ;

            for (int i = 0; i < geciciDizi1.Length; i++)
            {
                for (int j = 0; j < geciciDizi2.Length; j++)
                    carpim += geciciDizi1[i] + "*" + geciciDizi2[j] + "+" ;
            }

            carpim = carpim.Remove(carpim.Length - 1); //sondaki + yı sildim

            string gercek = "";

            if (x != carpim)
            {
                gercek = "(" + carpim + ")" + z;
                TumKapsamaListesi.Add(gercek);
                TumDurumListesi.Add("Tablo Boole Cebrine göre dağıtıldı");
            }
            return carpim;
        }

        string birinciKural(string y, string z)
        {
            string[] gecici = y.Split('+');

            string basit = "";

            for (int i = 0; i < gecici.Length; i++)
            {
                string[] geciciDizi1 = gecici[i].Split('*');

                for (int j = 0; j < geciciDizi1.Length; j++)
                {
                    for (int k = 0; k < geciciDizi1.Length; k++)
                    {
                        if (j != k && geciciDizi1[j] == geciciDizi1[k])
                           geciciDizi1[k] = "x";
                        else { }
                    }
                }
                gecici[i] = geciciDizi1[0]; //islem yaparken önce s1 eklesin + koysun istedik

                for (int l = 1; l < geciciDizi1.Length; l++)
                {
                    if (geciciDizi1[l] != "x")
                        gecici[i] += "*" + geciciDizi1[l];  //////////eşitliğin sol tarafı gecici olacak geciciDizi1değil
                    else { }
                }
            }

            basit = gecici[0]; 

            for (int i=1; i<gecici.Length; i++)  //////0. indisi zaten atadın 1. indisten başlamalısın
                 basit += "+" + gecici[i];      ////////////= olmayacak += olacak ekleyerek gidiyorsun

            string gercek = "";

            if (y != basit)
            {
                gercek = "(" + basit + ")" + z ;
                TumKapsamaListesi.Add(gercek);
                TumDurumListesi.Add("Tabloyu Boole Cebrini S1 * S1 = S1 kuralına gore sadeleştirdik ");
            }
            
            return basit;
        }

        string ikinciKural(string y, string z)
        {
            string[] gecici = y.Split('+');

            string tut = "";

            for (int i = 0; i < gecici.Length; i++)
            {
                for (int j = 0; j < gecici.Length; j++)
                {
                    if (i != j && gecici[i].Length <= gecici[j].Length)
                    {
                        if (kapsamaKontrolFonk(gecici[i], gecici[j]) == 1)//kapsıyorsa 1 doner
                            gecici[j] = "x";
                        else { }
                    }
                    else { }
                }
            }
            tut = "";

            for (int i = 0; i < gecici.Length; i++)
            {
                if (tut == "" && gecici[i] != "x") tut = gecici[i];
                else if (tut != "" && gecici[i] != "x") tut += "+" + gecici[i]; 
                else { }
            }

            string gercek = "";

            if(y != tut)
            {
                gercek = "(" + tut + ")" + z;
                TumKapsamaListesi.Add(gercek);
                TumDurumListesi.Add("Tabloyu Boole Cebrine gore Y1 + Y1 * Y2 = Y1 kuralına gore sadeleştirdik ");
            }
            return tut;
        }

        int kapsamaKontrolFonk(string a, string b)
        {
            string[] gecici1 = a.Split('*');
            string[] gecici2 = b.Split('*');

            int kontrol1 = 0, kontrol2 = 0;

            for (int i = 0; i < gecici1.Length; i++)
            {
                for (int j = 0; j < gecici2.Length; j++)
                {
                    if (gecici1[i] == gecici2[j] && kontrol1 == 0)
                    {
                        kontrol1 = 1;
                        kontrol2 = 1;
                        break;
                    }
                    else if (gecici1[i] == gecici2[j] && kontrol1 == 1)
                    {
                        kontrol1 = 1;
                        kontrol2 = 1;
                        break;
                    }
                    else if (gecici1[i] != gecici2[j] && kontrol1 == 1)
                    {
                        kontrol2 = 0;
                        break;
                    }
                    else { }

                    if (gecici1[i] != gecici2[j] && kontrol2 == 0 && j == gecici2.Length - 1)
                        kontrol1 = 0;

                    else { }
                }
                if (kontrol1 == 0)
                    break;
                else { }
            }  
                return kontrol1; 
        }
       
        void TumGizlilerFonk()
        {

        }

        private void btnMinKapasama_Click(object sender, EventArgs e)
        {
            try
            {
                mutlakHazirlikFonk();
                Min_kap_bul();
                minkapgerekli();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen verileri kontrol ediniz");
            }
        }

        void Min_kap_bul()
        {
            while (gereksiz.ColumnCount > 1) 
            {
                while (true)
                {
                    int sutun_sayisi = gereksiz.ColumnCount;
                    int satir_sayisi = gereksiz.RowCount;

                    fullSatirKontrol();
                    if (sutun_sayisi != gereksiz.ColumnCount) break;
                    mutlakSatirKontrolFonk();
                    if (sutun_sayisi != gereksiz.ColumnCount) break;
                    kapsananSatirKontol();
                    if (satir_sayisi != gereksiz.RowCount) break;
                    kapsananSutunrKontol();
                    if (sutun_sayisi != gereksiz.ColumnCount) break;
                    Rota();
                }
            }
        }

        void mutlakHazirlikFonk()
        {
            minimum_kap = "";
            indirgenenTablo = new DataGridView[200];
            indirgenmisDurumListesi.Clear();
            counter = 0;

            data_grid_view_kopyala(AnaTabloView, gereksiz);
            indirgenenTablo[counter] = new DataGridView();
            data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
            indirgenmisDurumListesi.Add("Tablo hafızaya alındı");
            suankiKapsama.Add(minimum_kap);
            counter++;
        }

        void mutlakSatirKontrolFonk()
        {
            data_grid_view_kopyala(indirgenenTablo[counter - 1], gereksiz);
            int satirSayisi = gereksiz.RowCount;
            int sutunSayisi = gereksiz.ColumnCount;
            int onemli_sutun = -2;
            int onemli_satir = -2;

            int count = 0;

            for (int j = 1; j <sutunSayisi; j++)
            {
                count = 0;
                for (int i = 0; i < satirSayisi; i++)
                {
                    if (gereksizcekmeFonk(i, j) == "1")
                        count++;
                }
                if (count == 1)
                {
                    onemli_sutun = j;
                    break;
                }
            }

            if (onemli_sutun != -2)
            {
                for (int i = 0; i < satirSayisi; i++)
                {
                    if (gereksizcekmeFonk(i, onemli_sutun) == "1")
                    {
                        onemli_satir = i;
                        break;
                    }
                }
                indirgenmisDurumListesi.Add(gereksizcekmeFonk(onemli_satir,0) + " satırı mutlak satırdır");

                minimum_kap += gereksizcekmeFonk(onemli_satir, 0) + " ";

                for (int i = sutunSayisi -1 ; i > 0; i--)
                {
                    if(gereksizcekmeFonk(onemli_satir,i)=="1")
                    {
                        gereksiz.Columns.Remove(gereksiz.Columns[i].Name);
                          
                    }
                }

                gereksiz.Rows.Remove(gereksiz.Rows[onemli_satir]);

                suankiKapsama.Add(minimum_kap);

                indirgenenTablo[counter] = new DataGridView();
                data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
                counter++;

            }
        }

        string gereksizcekmeFonk(int a,int b)
        {
            return gereksiz.Rows[a].Cells[b].Value.ToString();
        }

        void kapsananSatirKontol()
        {
            data_grid_view_kopyala(indirgenenTablo[counter - 1], gereksiz);
            int satirSayisi = gereksiz.RowCount;
            int sutunSaysi = gereksiz.ColumnCount;
            int kapsayanSatir = -1;
            int kapsananSatir = -1;

            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j <satirSayisi; j++)
                {
                    if(i != j)
                    {
                        if(satirkapsiyorMuFonk(i,j,sutunSaysi) == 1)
                        {
                            kapsayanSatir = i;
                            kapsananSatir = j;
                            break;
                        }
                    }
                }
                if (kapsayanSatir != -1) break;
            }

            if(kapsayanSatir != -1)
            {
                indirgenmisDurumListesi.Add(gereksizcekmeFonk(kapsayanSatir, 0) + " satırı " + gereksizcekmeFonk(kapsananSatir, 0) + " satırını kapsamaktadır");

                gereksiz.Rows.Remove(gereksiz.Rows[kapsananSatir]);

                suankiKapsama.Add(minimum_kap);

                indirgenenTablo[counter] = new DataGridView();
                data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
                counter++;
            }

        }

        int satirkapsiyorMuFonk(int a,int b,int sutunSayisi)
        {
            int ct1 = 0;

            for (int j = 1; j < sutunSayisi; j++)
            {
                if (gereksizcekmeFonk(a, j) == gereksizcekmeFonk(b, j))
                {
                    ct1 = 1;
                }
                else if(gereksizcekmeFonk(a, j) != gereksizcekmeFonk(b, j) && gereksizcekmeFonk(a,j) == "1")
                {
                    ct1 = 1;

                }
                else if(gereksizcekmeFonk(a, j) != gereksizcekmeFonk(b, j) && gereksizcekmeFonk(a, j) != "1")
                {
                    ct1 = 0;
                    break;
                }
            }


            return ct1;
        }

        void kapsananSutunrKontol()
        {
            data_grid_view_kopyala(indirgenenTablo[counter - 1], gereksiz);
            int satirSayisi = gereksiz.RowCount;
            int sutunSaysi = gereksiz.ColumnCount;
            int kapsayanSutun = -1;
            int kapsananSutun = -1;
            int[] sutun_agirligi = new int[sutunSaysi];
            int count = 0;

            for (int j = 1; j < sutunSaysi; j++)
            {
                count = 0;
                for (int i = 0; i < satirSayisi; i++)
                    if (gereksizcekmeFonk(i, j) == "1") count++;
                sutun_agirligi[j] = count;
            }


            for (int i = 1; i < sutunSaysi; i++)
            {
                for (int j = 1; j < sutunSaysi; j++)
                {
                    if (i != j)
                    {
                        if (sutun_agirligi[i] - sutun_agirligi[j] == 0 || sutun_agirligi[i] - sutun_agirligi[j] == -1)
                        {
                            if (sutunkapsiyorMuFonk(i, j, satirSayisi) == 1)
                            {
                                kapsayanSutun = i;
                                kapsananSutun = j;
                                break;
                            }
                        }
                    }
                }
                if (kapsayanSutun != -1) break;
            }


            if (kapsayanSutun != -1)
            {
                indirgenmisDurumListesi.Add(gereksiz.Columns[kapsayanSutun].Name.ToString() + " sütunu " + gereksiz.Columns[kapsananSutun].Name.ToString() + " sütununu kapsamaktadır");

                gereksiz.Columns.Remove(gereksiz.Columns[kapsananSutun].Name);

                suankiKapsama.Add(minimum_kap);

                indirgenenTablo[counter] = new DataGridView();
                data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
                counter++;
            }
        }

        int sutunkapsiyorMuFonk(int a, int b, int satirnSayisi)
        {
            int ct1 = 0;
            int ct2 = 0;


            for (int j = 0; j < satirnSayisi; j++)
            {
                if (gereksizcekmeFonk(j, a) == gereksizcekmeFonk(j, b))
                {
                    ct1 = 1;
                }
                else if (gereksizcekmeFonk(j, a) != "1" && gereksizcekmeFonk(j, b) == "1" && ct2 == 0)
                {
                    ct1 = 1;
                    ct2 = 1;
                }
                else
                {
                    ct1 = 0;
                    break;
                }

            }

            return ct1;
        }

        void Rota()
        {
            data_grid_view_kopyala(indirgenenTablo[counter - 1], gereksiz);
            int satir = gereksiz.RowCount;
            int sutun = gereksiz.ColumnCount;

            double[] satirAgirligi = new double[satir];
            int[] sutunAgirligi = new int[sutun];
            int count = 0;
            ArrayList minSutunIndis = new ArrayList();

            for (int j = 1; j < sutun; j++)
            {
                count = 0;
                for (int i = 0; i < satir; i++)
                    if(gereksizcekmeFonk(i,j)=="1")
                        count++;
                sutunAgirligi[j] = count;
            }

            int gecici = sutunAgirligi[1];
            for (int i = 2; i < sutun; i++)
                if (gecici > sutunAgirligi[i]) gecici = sutunAgirligi[i];

            for (int j = 1; j < sutun; j++)
                if (sutunAgirligi[j] == gecici) minSutunIndis.Add(j);

            for (int i = 0; i < satir; i++)
            {
                if (SatirAgirligiHesaplayımMı(i, minSutunIndis) == 1) 
                satirAgirligi[i] = satirAgirligiHesapla(i, satir, sutun, sutunAgirligi);
                else
                    satirAgirligi[i] = -1.0;
            }

            double gec = satirAgirligi[0];
            for (int i = 1; i < satir; i++)
            {
                if (gec == -1.0 && satirAgirligi[i] != -1.0) gec = satirAgirligi[i];
                else if (satirAgirligi[i] != -1.0 && gec > satirAgirligi[i]) gec = satirAgirligi[i];
                else { }
            }

            for (int i = 0; i < satir; i++)
                if (satirAgirligi[i] == gec) count = i;

            indirgenmisDurumListesi.Add(gereksizcekmeFonk(count, 0) + " satırı rotaya göre belirlendi");
            gereksiz.Columns.Add("Satır Ağırlığı", "Satır Ağırlığı");
            gereksiz.Rows.Add();

            for (int i = 0; i < satir; i++)
            {
                if (satirAgirligi[i] != -1.0)
                {

                    gereksiz.Rows[i].Cells[sutun].Value = satirAgirligi[i];
                }
            }

            for (int j = 1; j < sutun; j++)
            {
                gereksiz.Rows[satir].Cells[j].Value = sutunAgirligi[j].ToString();

            }

            gereksiz.Rows[count].DefaultCellStyle.ForeColor = Color.Green;
            gereksiz.Rows[count].DefaultCellStyle.BackColor = Color.Black;


            indirgenmisDurumListesi.Add(gereksizcekmeFonk(count, 0) + " satırı rotaya göre silindi");


            suankiKapsama.Add(minimum_kap);

            indirgenenTablo[counter] = new DataGridView();
            data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
            counter++;


            gereksiz.Columns.Remove(gereksiz.Columns[sutun].Name);

            gereksiz.Rows.Remove(gereksiz.Rows[satir]);
            gereksiz.Rows.Remove(gereksiz.Rows[count]);

            suankiKapsama.Add(minimum_kap);

            indirgenenTablo[counter] = new DataGridView();
            data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
            counter++;


        }

        int SatirAgirligiHesaplayımMı(int satir, ArrayList sutunlar)
        {
            int control = 0;
            for (int j = 0; j < sutunlar.Count; j++)
            {
                if(gereksizcekmeFonk(satir,Convert.ToInt32( sutunlar[j]))== "1")
                {
                    control = 1;
                    break;
                }
                else
                {
                    control = 0;
                }
            }

            return control;
        }

        double satirAgirligiHesapla(int satirİndisi , int satir,int sutun, int[] sutunAgirliklari)
        {
            double agirlik = 0.0;

            for (int j = 1; j < sutun; j++)
            {
              if(gereksizcekmeFonk(satirİndisi,j)=="1")
                {
                    agirlik += 1.0 / sutunAgirliklari[j];
                }
            }

            agirlik *= satir;

 

            return agirlik;
        }

        void fullSatirKontrol()
        {
            data_grid_view_kopyala(indirgenenTablo[counter - 1], gereksiz);
            int satirSayisi = gereksiz.RowCount;
            int sutunSayisi = gereksiz.ColumnCount;
            int fullSatir = -1;

            int count = 0;

            for (int i = 0; i < satirSayisi; i++)
            {
                count = 0;
                for (int j = 1; j < sutunSayisi; j++)
                    if (gereksizcekmeFonk(i, j) == "1")
                        count++;

                if (sutunSayisi -1 == count)
                {
                    fullSatir = i;
                    break;
                }
                
            }

            if (fullSatir != -1)
            {

                indirgenmisDurumListesi.Add(gereksizcekmeFonk(fullSatir, 0) + " satırı full satırdır");

                for (int i = sutunSayisi - 1; i > 0; i--)
                        gereksiz.Columns.Remove(gereksiz.Columns[i].Name);

                gereksiz.Rows.Remove(gereksiz.Rows[fullSatir]);


                minimum_kap += gereksizcekmeFonk(fullSatir, 0) + " ";
                suankiKapsama.Add(minimum_kap);

                indirgenenTablo[counter] = new DataGridView();
                data_grid_view_kopyala(gereksiz, indirgenenTablo[counter]);
                counter++;

            }
        }

        private void btnrota_Click(object sender, EventArgs e)
        {
            try
            {
                mutlakHazirlikFonk();
                rota_yap();
                minkapgerekli();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen verileri kontrol ediniz");
            }
        }

        void rota_yap()
        {
            while (gereksiz.ColumnCount > 1)
            {
                while (true)
                {
                    int sutun_sayisi = gereksiz.ColumnCount;
                    int satir_sayisi = gereksiz.RowCount;

                    fullSatirKontrol();
                    if (sutun_sayisi != gereksiz.ColumnCount) break;
                    mutlakSatirKontrolFonk();
                    if (sutun_sayisi != gereksiz.ColumnCount) break;
                    Rota();
                }
            }
        }

        void minkapgerekli()
        {
            tur = 1;
            pndurum.Visible = true;
            pnonceki.Visible = false;
            pnsonraki.Visible = false;
            dsonraki.Visible = true;
            donceki.Visible = true;



            durumlar.Items.Clear();

            for (int i = 0; i < counter; i++)
                durumlar.Items.Add("Durum : " + (i + 1).ToString());

            durumlar.SelectedIndex = 0;


            lbdurum.Text = indirgenmisDurumListesi[0].ToString();

      
            data_grid_view_kopyala(indirgenenTablo[0], donceki);
            data_grid_view_kopyala(indirgenenTablo[0], dsonraki);

        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            if (tur == 0)
            {
                int durum_sayaci = durumlar.SelectedIndex;

                if (durum_sayaci == 0)
                {
                    lbdurum.Text = "";

                    lbdurum.Text = TumDurumListesi[0].ToString();

                    lbonceki.Text = TumKapsamaListesi[0].ToString();
                    lbsonraki.Text = TumKapsamaListesi[0].ToString();

                }
                else
                {
                    lbdurum.Text = "";

                    for (int i = 0; i <= durum_sayaci; i++)
                    {
                        lbdurum.Text += TumDurumListesi[i].ToString() + "\n\n";
                    }

                    lbonceki.Text = TumKapsamaListesi[durum_sayaci - 1].ToString();
                    lbsonraki.Text = TumKapsamaListesi[durum_sayaci].ToString();

                }
            }
            else if (tur == 1)
            {
                int durum_sayaci = durumlar.SelectedIndex;

                if(durum_sayaci==0)
                {
                    lbdurum.Text = "";

                    lbdurum.Text = indirgenmisDurumListesi[0].ToString();

                    data_grid_view_kopyala(indirgenenTablo[0], donceki);
                    data_grid_view_kopyala(indirgenenTablo[0], dsonraki);
                }
                else
                {
                    lbdurum.Text = "";

                    for (int i = 0; i <= durum_sayaci; i++)
                    {
                        lbdurum.Text += indirgenmisDurumListesi[i].ToString() + "\n\n";
                    }

                    minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                    data_grid_view_kopyala(indirgenenTablo[durum_sayaci - 1], donceki);
                    data_grid_view_kopyala(indirgenenTablo[durum_sayaci], dsonraki);
                }
            }
            yukselik();

        }

        private void btnonceki_Click(object sender, EventArgs e)
        {
            try
            {
                if (tur == 0)
                {
                    int durum_sayaci = durumlar.SelectedIndex;

                    if (durum_sayaci == 0)
                    {
                        lbdurum.Text = "";

                        lbdurum.Text = TumDurumListesi[0].ToString();

                        lbonceki.Text = TumKapsamaListesi[0].ToString();
                        lbsonraki.Text = TumKapsamaListesi[0].ToString();

                    }
                    else
                    {
                        durum_sayaci--;
                        durumlar.SelectedIndex = durum_sayaci;

                        lbdurum.Text = "";

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += TumDurumListesi[i].ToString() + "\n\n";
                        }

                        lbonceki.Text = TumKapsamaListesi[durum_sayaci - 1].ToString();
                        lbsonraki.Text = TumKapsamaListesi[durum_sayaci].ToString();

                    }
                }
                else if (tur == 1)
                {
                    int durum_sayaci = durumlar.SelectedIndex;


                    if (durum_sayaci == 0)
                    {
                        lbdurum.Text = "";

                        lbdurum.Text = indirgenmisDurumListesi[0].ToString();

                        data_grid_view_kopyala(indirgenenTablo[0], donceki);
                        data_grid_view_kopyala(indirgenenTablo[0], dsonraki);
                    }
                    else
                    {
                        durum_sayaci--;
                        durumlar.SelectedIndex = durum_sayaci;

                        lbdurum.Text = "";

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += indirgenmisDurumListesi[i].ToString() + "\n\n";
                        }

                        minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                        data_grid_view_kopyala(indirgenenTablo[durum_sayaci - 1], donceki);
                        data_grid_view_kopyala(indirgenenTablo[durum_sayaci], dsonraki);
                    }
                }
                yukselik();

            }
            catch (Exception)
            {

            }
        }

        private void btnsonraki_Click(object sender, EventArgs e)
        {
            try
            {
                if (tur == 0)
                {
                    int durum_sayaci = durumlar.SelectedIndex;

                    if (durum_sayaci == durumlar.Items.Count - 1)
                    {
                        lbdurum.Text = "";
                        durum_sayaci++;

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += TumDurumListesi[i].ToString() + "\n\n";
                        }

                        lbonceki.Text = TumKapsamaListesi[durum_sayaci - 1].ToString();
                        lbsonraki.Text = TumKapsamaListesi[durum_sayaci].ToString();

                    }
                    else
                    {
                        durum_sayaci++;
                        durumlar.SelectedIndex = durum_sayaci;
                        lbdurum.Text = "";

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += TumDurumListesi[i].ToString() + "\n\n";
                        }

                        lbonceki.Text = TumKapsamaListesi[durum_sayaci - 1].ToString();
                        lbsonraki.Text = TumKapsamaListesi[durum_sayaci].ToString();

                    }
                }
                else if (tur == 1)
                {

                    int durum_sayaci = durumlar.SelectedIndex;


                    if (durum_sayaci == durumlar.Items.Count - 1)
                    {
                        lbdurum.Text = "";

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += indirgenmisDurumListesi[i].ToString() + "\n\n";
                        }

                        minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                        data_grid_view_kopyala(indirgenenTablo[durumlar.Items.Count - 2], donceki);
                        data_grid_view_kopyala(indirgenenTablo[durumlar.Items.Count - 1], dsonraki);
                    }
                    else
                    {
                        lbdurum.Text = "";

                        durum_sayaci++;
                        durumlar.SelectedIndex = durum_sayaci;

                        for (int i = 0; i <= durum_sayaci; i++)
                        {
                            lbdurum.Text += indirgenmisDurumListesi[i].ToString() + "\n\n";
                        }

                        minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                        data_grid_view_kopyala(indirgenenTablo[durum_sayaci - 1], donceki);
                        data_grid_view_kopyala(indirgenenTablo[durum_sayaci], dsonraki);
                    }
                }
                yukselik();

            }
            catch (Exception)
            {

            }
        }

        void yukselik()
        {
            pndurum.AutoScrollPosition = new Point(0, lbdurum.Height);
            pnonceki.AutoScrollPosition = new Point(0, lbonceki.Height);
            pnsonraki.AutoScrollPosition = new Point(0, lbsonraki.Height);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tur == 0)
            {
                int durum_sayaci = durumlar.SelectedIndex;

                if (durum_sayaci == durumlar.Items.Count - 1)
                {
                    lbdurum.Text = "";
                    durum_sayaci = 0;
                    durumlar.SelectedIndex = durum_sayaci;

                     lbdurum.Text += TumDurumListesi[0].ToString() + "\n\n";

                    lbonceki.Text = TumKapsamaListesi[0].ToString();
                    lbsonraki.Text = TumKapsamaListesi[0].ToString();

                }
                else
                {
                    durum_sayaci++;
                    durumlar.SelectedIndex = durum_sayaci;
                    lbdurum.Text = "";

                    for (int i = 0; i <= durum_sayaci; i++)
                    {
                        lbdurum.Text += TumDurumListesi[i].ToString() + "\n\n";
                    }

                    lbonceki.Text = TumKapsamaListesi[durum_sayaci - 1].ToString();
                    lbsonraki.Text = TumKapsamaListesi[durum_sayaci].ToString();

                }
            }
            else if (tur == 1)
            {

                int durum_sayaci = durumlar.SelectedIndex;


                if (durum_sayaci == durumlar.Items.Count - 1)
                {
                    lbdurum.Text = "";

                    durum_sayaci = 0;

                    durumlar.SelectedIndex = durum_sayaci;

                    lbdurum.Text += indirgenmisDurumListesi[0].ToString() + "\n\n";

                    minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                    data_grid_view_kopyala(indirgenenTablo[0], donceki);
                    data_grid_view_kopyala(indirgenenTablo[0],dsonraki);
                }
                else
                {
                    lbdurum.Text = "";

                    durum_sayaci++;
                    durumlar.SelectedIndex = durum_sayaci;

                    for (int i = 0; i <= durum_sayaci; i++)
                    {
                        lbdurum.Text += indirgenmisDurumListesi[i].ToString() + "\n\n";
                    }

                    minumumkapsamam.Text = suankiKapsama[durum_sayaci].ToString();

                    data_grid_view_kopyala(indirgenenTablo[durum_sayaci - 1], donceki);
                    data_grid_view_kopyala(indirgenenTablo[durum_sayaci], dsonraki);
                }
            }
            yukselik();

        }

        private void btnbaslat_Click(object sender, EventArgs e)
        {
            if (btnbaslat.Text == "Başlat")
            {
                timer1.Interval = 1000 * Convert.ToInt32(time.Value);
                btnbaslat.Text = "Bitir";
                timer1.Start();
            }
            else if (btnbaslat.Text == "Bitir")
            {
                btnbaslat.Text = "Başlat";
                timer1.Stop();
            }
            else { }
        }
    }
}

