using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_Puzzle_2b
{
    public partial class mnForm : Form
    {
        Graphics gr;
        Bitmap bitmap;
        Puzzle pzl;

        public mnForm()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(sheet.Width, sheet.Height);
            gr = Graphics.FromImage(bitmap);
            sheet.Image = bitmap;
            gr.Clear(Color.White);
            pzl = new Puzzle(3, 3, gr);
            Image img = Image.FromFile("../../images/grid.png");
            gr.DrawImage(img, 40, 30);
            pzl.drawPuzzleStart();
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (pzl.start())
            {
                MessageBox.Show("The puzzle was collected!", "Message");
                bitmap = null;
                bitmap = new Bitmap(sheet.Width, sheet.Height);
                gr = Graphics.FromImage(bitmap);
                sheet.Image = bitmap;
                pzl.gr = gr;
                gr.Clear(Color.White);
                Image img = Image.FromFile("../../images/grid.png");
                gr.DrawImage(img, 350, 30);
                pzl.drawPuzzleFinish();
            }
            else
                MessageBox.Show("The puzzle was not collected!", "Message");
        }


    }
}
