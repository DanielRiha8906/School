using Queens;
using static Queens.NQueensSolver;

namespace Queens
{
    public partial class Form1 : Form
    {
        GuiConfig config = new GuiConfig();
        List<int[]> configuration_list = new List<int[]>();
        NQueensSolver qs = new NQueensSolver();
        int actual_queens_config = 0;

        public Form1()
        {
            InitializeComponent();
            this.bt_black.BackColor = config.BlackColor;//nastaveni barvy pozadi sachovnice z konfigu
            this.bt_white.BackColor = config.WhiteColor;//nastaveni barvy pozadi sachovnice z konfigu
            this.nm_up_down.Value = config.BoardSize;
            this.config.QueenImagePath = "../../../images/icons/black.png";//trochu prasarna, ale je mozne pridat pres resources
            this.pbox_queen.Image = this.config.QueenImage;
            this.pb_chessboard.Image = ChessBoardVisualiser.GetChessBoardImage(config.BoardSize, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
            /*int[] p = new int[] {0,1,1,2,3};
            this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(p,config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
            */ //testovaci, zda funguje kresleni dam

            qs.QueensConfigFound += AddQueensConfigToList;//registrace obsluzne funkce na udalost
            qs.QueensFinalized += QueensProblemSolved; //registrace obsluzne funkce na udalost

        }

        private void AddQueensConfigToList(object o, QueensConfigFoundEventArgs e)
        {

            /* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
             * Potencialni problem: obsluha udalosti jede na jinem vlakne nez je hlavni app.
             * Pokud budu neco delat s formem, tak hrozi exception.
             * Toto je osetreno napr. v metode nize. Pokud to bude nastavat tady, tak je mozno dodelat
             */
            this.configuration_list.Add(e.QueensConfiguration);
            if (this.configuration_list.Count == 1)//ukaz jen ten prvni, ostatni pres tlacitka
            {
                this.actual_queens_config = 0;
                this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(e.QueensConfiguration, config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
            }
        }
        private void QueensProblemSolved(object o, QueensFinalizedEventArgs e)
        {
            if (lb_position.InvokeRequired)
            {
                QueensFinalizedHandler d = QueensProblemSolved;//nebo jsem mohl pouzit Action<T,T>, ale kdyz uz ty handlery mam
                this.lb_position.Invoke(d, o, e);
            }
            else
                this.lb_position.Text = string.Format($"{actual_queens_config + 1}/{configuration_list.Count}");
        }


        private void SetWhiteColor(object sender, EventArgs e)
        {
            this.colorDialog.Color = config.WhiteColor;
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.config.WhiteColor = this.colorDialog.Color;
                this.bt_white.BackColor = this.config.WhiteColor;
                if (this.configuration_list.Count > 0)
                {
                    this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(this.configuration_list[this.actual_queens_config], config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);

                }
                else
                    this.pb_chessboard.Image = ChessBoardVisualiser.GetChessBoardImage(config.BoardSize, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
            }
        }

        private void SetBlackColor(object sender, EventArgs e)
        {
            this.colorDialog.Color = config.BlackColor;
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.config.BlackColor = this.colorDialog.Color;
                this.bt_black.BackColor = this.config.BlackColor;
                if (this.configuration_list.Count > 0)
                {
                    this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(this.configuration_list[this.actual_queens_config], config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);

                }
                else
                    this.pb_chessboard.Image = ChessBoardVisualiser.GetChessBoardImage(config.BoardSize, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
            }
        }

        private void pbox_queen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.config.QueenImagePath = this.openFileDialog1.FileName;//update cesty
                this.pbox_queen.Image = this.config.QueenImage;

                if (this.configuration_list.Count > 0)
                {
                    this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(this.configuration_list[this.actual_queens_config], config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);

                }
            }
        }

        private void nm_up_down_ValueChanged(object sender, EventArgs e)
        {

            this.config.BoardSize = Decimal.ToInt32(this.nm_up_down.Value);
            this.pb_chessboard.Image = ChessBoardVisualiser.GetChessBoardImage(config.BoardSize, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);

        }

        private async void bt_start_Click(object sender, EventArgs e)
        {
            this.configuration_list.Clear();
            this.actual_queens_config = 0;
            await Task.Run(async () => qs.FindNQueens(config.BoardSize));
        }

        private void bt_left_Click(object sender, EventArgs e)
        {
            if (this.actual_queens_config > 0)
            {
                this.actual_queens_config--;
                this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(this.configuration_list[this.actual_queens_config], config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
                this.lb_position.Text = string.Format($"{actual_queens_config + 1}/{configuration_list.Count}");
            }
        }

        private void bt_right_Click(object sender, EventArgs e)
        {
            if (this.actual_queens_config < this.configuration_list.Count - 1)
            {
                this.actual_queens_config++;
                this.pb_chessboard.Image = ChessBoardVisualiser.GetChessboardWithQueens(this.configuration_list[this.actual_queens_config], config.QueenImage, pb_chessboard.Width, pb_chessboard.Height, config.BlackColor, config.WhiteColor);
                this.lb_position.Text = string.Format($"{actual_queens_config + 1}/{configuration_list.Count}");
            }
        }
    }
}
