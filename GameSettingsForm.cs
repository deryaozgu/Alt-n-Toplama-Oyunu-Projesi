using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab1
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TahtaSatirSayisi, TahtaSutunSayisi;
            int KareAltin, GizliKareAltin, KullaniciAltin, AdimAdeti;
            int A_HamleMaliyeti, A_HedefMaliyeti, B_HamleMaliyeti, B_HedefMaliyeti, C_HamleMaliyeti, C_HedefMaliyeti, D_HamleMaliyeti, D_HedefMaliyeti;
            TahtaSatirSayisi = Convert.ToInt32(TahtaSatirSayisi_Input.Value);
            TahtaSutunSayisi = Convert.ToInt32(TahtaSutunSayisi_Input.Value);
            KareAltin = Convert.ToInt32(KareAltin_Input.Value);
            GizliKareAltin = Convert.ToInt32(GizliKareAltin_VAlue.Value);
            KullaniciAltin = Convert.ToInt32(KullaniciAltin_Input.Value);
            AdimAdeti = Convert.ToInt32(AdimAdeti_Input.Value);
            A_HamleMaliyeti = Convert.ToInt32(AHamle_Maliyet_Input.Value);
            A_HedefMaliyeti = Convert.ToInt32(AHedef_Maliyet_Input.Value);
            B_HamleMaliyeti = Convert.ToInt32(BHamle_Maliyet_Input.Value);
            B_HedefMaliyeti = Convert.ToInt32(BHedef_Maliyet_Input.Value);
            C_HamleMaliyeti = Convert.ToInt32(CHamle_Maliyet_Input.Value);
            C_HedefMaliyeti = Convert.ToInt32(CHedef_Maliyet_Input.Value);
            D_HamleMaliyeti = Convert.ToInt32(DHamle_Maliyet_Input.Value);
            D_HedefMaliyeti = Convert.ToInt32(DHedef_Maliyet_Input.Value);

            GameStartForm gameForm = new GameStartForm(TahtaSatirSayisi, TahtaSutunSayisi, KareAltin, GizliKareAltin, KullaniciAltin, AdimAdeti, A_HamleMaliyeti, A_HedefMaliyeti, B_HamleMaliyeti, B_HedefMaliyeti, C_HamleMaliyeti, C_HedefMaliyeti, D_HamleMaliyeti, D_HedefMaliyeti);
            gameForm.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
