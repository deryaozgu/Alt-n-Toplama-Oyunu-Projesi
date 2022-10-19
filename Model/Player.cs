using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLab1.Model
{
    public class Player
    {
        public string Adi { get; set; }
        public int AdimSayisi { get; set; }
        public int Toplanan_Altin { get; set; }
        public int Harcanan_Altin { get; set; }
        public int Kalan_Altin { get; set; }
        public int Satir { get; set; }
        public int Sutun { get; set; }
        public int X_Koordinat { get; set; }
        public int Y_Koordinat { get; set; }
        public bool ilk_Hedef_Mi { get; set; }
        public Color Color { get; set; }
        public bool Hedefe_Varildi_Mi { get; set; }
        public Player()
        {
            this.ilk_Hedef_Mi = true;
        }
    }
}
