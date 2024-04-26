using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queensapp
{
    internal class GuiConfig
    {
        public Color BlackColor { get; set; } = Color.FromArgb(255, 192, 128);
        public Color WhiteColor { get; set; } = Color.FromArgb(224,224,224);

        public string QueenImagePath { get; set; } = "";
        public Image QueenImage
        { get { return  Bitmap.FromFile(QueenImagePath); } }


        public int BoardSize { get; set; } = 5;

    }
}
