using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Queens
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            bt_left = new Button();
            bt_right = new Button();
            pb_chessboard = new PictureBox();
            lb_position = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            nm_up_down = new NumericUpDown();
            bt_black = new Button();
            bt_white = new Button();
            bt_start = new Button();
            bt_stop = new Button();
            pbox_queen = new PictureBox();
            menuStrip1 = new MenuStrip();
            chessToolStripMenuItem = new ToolStripMenuItem();
            blackColorToolStripMenuItem = new ToolStripMenuItem();
            whiteColorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            èxitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            colorDialog = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_chessboard).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nm_up_down).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbox_queen).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 542);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(846, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 28);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(846, 514);
            splitContainer1.SplitterDistance = 690;
            splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.3853207F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.1681938F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.2324162F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(bt_left, 1, 1);
            tableLayoutPanel2.Controls.Add(bt_right, 3, 1);
            tableLayoutPanel2.Controls.Add(pb_chessboard, 0, 0);
            tableLayoutPanel2.Controls.Add(lb_position, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 88.31776F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6822433F));
            tableLayoutPanel2.Size = new Size(690, 514);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // bt_left
            // 
            bt_left.Dock = DockStyle.Fill;
            bt_left.Location = new Point(143, 458);
            bt_left.Margin = new Padding(5);
            bt_left.Name = "bt_left";
            bt_left.Size = new Size(75, 51);
            bt_left.TabIndex = 1;
            bt_left.Text = "<=";
            bt_left.UseVisualStyleBackColor = true;
            bt_left.Click += bt_left_Click;
            // 
            // bt_right
            // 
            bt_right.Dock = DockStyle.Fill;
            bt_right.Location = new Point(471, 458);
            bt_right.Margin = new Padding(5);
            bt_right.Name = "bt_right";
            bt_right.Size = new Size(74, 51);
            bt_right.TabIndex = 0;
            bt_right.Text = "=>";
            bt_right.UseVisualStyleBackColor = true;
            bt_right.Click += bt_right_Click;
            // 
            // pb_chessboard
            // 
            tableLayoutPanel2.SetColumnSpan(pb_chessboard, 5);
            pb_chessboard.Dock = DockStyle.Fill;
            pb_chessboard.Location = new Point(3, 3);
            pb_chessboard.Name = "pb_chessboard";
            pb_chessboard.Size = new Size(684, 447);
            pb_chessboard.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_chessboard.TabIndex = 2;
            pb_chessboard.TabStop = false;
            // 
            // lb_position
            // 
            lb_position.AutoSize = true;
            lb_position.Dock = DockStyle.Fill;
            lb_position.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lb_position.Location = new Point(226, 453);
            lb_position.Name = "lb_position";
            lb_position.Size = new Size(237, 61);
            lb_position.TabIndex = 3;
            lb_position.Text = "0";
            lb_position.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(nm_up_down, 0, 1);
            tableLayoutPanel1.Controls.Add(bt_black, 1, 3);
            tableLayoutPanel1.Controls.Add(bt_white, 0, 3);
            tableLayoutPanel1.Controls.Add(bt_start, 0, 5);
            tableLayoutPanel1.Controls.Add(bt_stop, 0, 7);
            tableLayoutPanel1.Controls.Add(pbox_queen, 0, 8);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(152, 514);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // nm_up_down
            // 
            tableLayoutPanel1.SetColumnSpan(nm_up_down, 2);
            nm_up_down.Dock = DockStyle.Fill;
            nm_up_down.Location = new Point(3, 54);
            nm_up_down.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nm_up_down.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            nm_up_down.Name = "nm_up_down";
            nm_up_down.Size = new Size(146, 27);
            nm_up_down.TabIndex = 0;
            nm_up_down.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nm_up_down.ValueChanged += nm_up_down_ValueChanged;
            // 
            // bt_black
            // 
            bt_black.BackColor = Color.FromArgb(255, 192, 128);
            bt_black.Dock = DockStyle.Fill;
            bt_black.Location = new Point(79, 156);
            bt_black.Name = "bt_black";
            bt_black.Size = new Size(70, 45);
            bt_black.TabIndex = 1;
            bt_black.UseVisualStyleBackColor = false;
            bt_black.Click += SetBlackColor;
            // 
            // bt_white
            // 
            bt_white.BackColor = Color.FromArgb(224, 224, 224);
            bt_white.Dock = DockStyle.Fill;
            bt_white.Location = new Point(3, 156);
            bt_white.Name = "bt_white";
            bt_white.Size = new Size(70, 45);
            bt_white.TabIndex = 2;
            bt_white.UseVisualStyleBackColor = false;
            bt_white.Click += SetWhiteColor;
            // 
            // bt_start
            // 
            tableLayoutPanel1.SetColumnSpan(bt_start, 2);
            bt_start.Dock = DockStyle.Fill;
            bt_start.Location = new Point(3, 258);
            bt_start.Name = "bt_start";
            bt_start.Size = new Size(146, 45);
            bt_start.TabIndex = 3;
            bt_start.Text = "&Run";
            bt_start.UseVisualStyleBackColor = true;
            bt_start.Click += bt_start_Click;
            // 
            // bt_stop
            // 
            tableLayoutPanel1.SetColumnSpan(bt_stop, 2);
            bt_stop.Dock = DockStyle.Fill;
            bt_stop.Location = new Point(3, 360);
            bt_stop.Name = "bt_stop";
            bt_stop.Size = new Size(146, 45);
            bt_stop.TabIndex = 4;
            bt_stop.Text = "&Stop";
            bt_stop.UseVisualStyleBackColor = true;
            // 
            // pbox_queen
            // 
            tableLayoutPanel1.SetColumnSpan(pbox_queen, 2);
            pbox_queen.Dock = DockStyle.Fill;
            pbox_queen.Location = new Point(3, 411);
            pbox_queen.Name = "pbox_queen";
            tableLayoutPanel1.SetRowSpan(pbox_queen, 2);
            pbox_queen.Size = new Size(146, 100);
            pbox_queen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbox_queen.TabIndex = 5;
            pbox_queen.TabStop = false;
            pbox_queen.MouseDoubleClick += pbox_queen_MouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chessToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(846, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // chessToolStripMenuItem
            // 
            chessToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blackColorToolStripMenuItem, whiteColorToolStripMenuItem, toolStripSeparator1, toolStripMenuItem1, stopToolStripMenuItem, toolStripSeparator2, èxitToolStripMenuItem });
            chessToolStripMenuItem.Name = "chessToolStripMenuItem";
            chessToolStripMenuItem.Size = new Size(60, 24);
            chessToolStripMenuItem.Text = "Chess";
            // 
            // blackColorToolStripMenuItem
            // 
            blackColorToolStripMenuItem.Name = "blackColorToolStripMenuItem";
            blackColorToolStripMenuItem.Size = new Size(167, 26);
            blackColorToolStripMenuItem.Text = "BlackColor";
            blackColorToolStripMenuItem.Click += SetBlackColor;
            // 
            // whiteColorToolStripMenuItem
            // 
            whiteColorToolStripMenuItem.Name = "whiteColorToolStripMenuItem";
            whiteColorToolStripMenuItem.Size = new Size(167, 26);
            whiteColorToolStripMenuItem.Text = "WhiteColor";
            whiteColorToolStripMenuItem.Click += SetWhiteColor;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(164, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(167, 26);
            toolStripMenuItem1.Text = "Run";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(167, 26);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(164, 6);
            // 
            // èxitToolStripMenuItem
            // 
            èxitToolStripMenuItem.Name = "èxitToolStripMenuItem";
            èxitToolStripMenuItem.Size = new Size(167, 26);
            èxitToolStripMenuItem.Text = "Èxit";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 564);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Queensapp";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_chessboard).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nm_up_down).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbox_queen).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button bt_right;
        private Button bt_left;
        private PictureBox pb_chessboard;
        private NumericUpDown nm_up_down;
        private Button bt_black;
        private Button bt_white;
        private Button bt_start;
        private Button bt_stop;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chessToolStripMenuItem;
        private ToolStripMenuItem blackColorToolStripMenuItem;
        private ToolStripMenuItem whiteColorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem èxitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ColorDialog colorDialog;
        private PictureBox pbox_queen;
        private OpenFileDialog openFileDialog1;
        private Label lb_position;
    }
}
