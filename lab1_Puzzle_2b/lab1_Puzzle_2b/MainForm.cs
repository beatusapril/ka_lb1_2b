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
        int countCol;
        int countLine;

        public mnForm()
        {
            InitializeComponent();
            btnCollect.Visible = false;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (getNumber())
            {
                bitmap = new Bitmap(sheet.Width, sheet.Height);
                gr = Graphics.FromImage(bitmap);
                sheet.Image = bitmap;
                gr.Clear(Color.White);
                pzl = new Puzzle(countCol, countLine, gr);
                pzl.drawMatrix(10, 10);
                pzl.randomGeneratePuzzle();
                pzl.drawPuzzle(Detail.Width * (countCol + 4), 60);
                btnCollect.Visible = true;
            }
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
                pzl.drawPuzzleFinish(60, 60);
                pzl.drawMatrix((Detail.Width * (countCol + 4)), 10);
            }
            else
                MessageBox.Show("The puzzle was not collected!", "Message");
            btnCollect.Visible = false;
        }

        private bool getNumber()
        {
            bool result = false;
            try
            {
                countCol = Convert.ToInt32(cmbCol.Text);
                countLine = Convert.ToInt32(cmbLines.Text);
                result = true;
            }
            catch (FormatException e)
            {
                MessageBox.Show("Enter the arguments!", "Message");
            }
            return result;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
             MessageBox.Show("You should to assemble: \n  0 + 0 \n -1 + 1 \n -2 + 2 \n Sides should to be - 0", "About puzzle");
        }
    }
}
