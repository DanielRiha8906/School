using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    internal class ChessBoardVisualiser
    {
        public static Bitmap GetChessBoardImage(int size, int width, int height, Color black, Color white)
        {

            float dx = ((float)width) / size;
            float dy = ((float)height) / size;
            Brush white_brush = new SolidBrush(white);
            Brush black_brush = new SolidBrush(black);
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        RectangleF r = new RectangleF(i * dx, j * dy, dx, dy);
                        if ((i + j) % 2 == 0)
                            g.FillRectangle(white_brush, r);
                        else
                            g.FillRectangle(black_brush, r);
                    }
                for (int i = 0; i < size; i++)
                {
                    g.DrawLine(Pens.Red, 0, i * dy, width, i * dy);
                    g.DrawLine(Pens.Red, i * dx, 0, i * dx, height);
                }

                g.DrawLine(Pens.Red, 0, height - 1, width - 1, height - 1);
                g.DrawLine(Pens.Red, width - 1, 0, width - 1, height - 1);
            }
            return bmp;
        }

        public static Bitmap GetChessboardWithQueens(int[] configuration, Image queen_image, int width, int height, Color black, Color white)
        {

            float dx = ((float)width) / configuration.Length;
            float dy = ((float)height) / configuration.Length;

            Bitmap bmp = GetChessBoardImage(configuration.Length, width, height, black, white);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < configuration.Length; i++)
                {
                    RectangleF r = new RectangleF(i * dx, configuration[i] * dy, dx - 1, dy - 1);
                    g.DrawImage(queen_image, r);
                }
            }
            return bmp;
        }
    }
}
