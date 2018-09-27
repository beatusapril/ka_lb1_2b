namespace lab1_Puzzle_2b
{
    partial class mnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.btnCollect = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cmbLines = new System.Windows.Forms.ComboBox();
            this.Lines = new System.Windows.Forms.Label();
            this.cmbCol = new System.Windows.Forms.ComboBox();
            this.lb = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(841, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // sheet
            // 
            this.sheet.Location = new System.Drawing.Point(12, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(809, 360);
            this.sheet.TabIndex = 1;
            this.sheet.TabStop = false;
            // 
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(841, 52);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 23);
            this.btnCollect.TabIndex = 2;
            this.btnCollect.Text = "Collect";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 393);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // cmbLines
            // 
            this.cmbLines.FormattingEnabled = true;
            this.cmbLines.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbLines.Location = new System.Drawing.Point(841, 107);
            this.cmbLines.Name = "cmbLines";
            this.cmbLines.Size = new System.Drawing.Size(75, 21);
            this.cmbLines.TabIndex = 5;
            // 
            // Lines
            // 
            this.Lines.AutoSize = true;
            this.Lines.Location = new System.Drawing.Point(838, 91);
            this.Lines.Name = "Lines";
            this.Lines.Size = new System.Drawing.Size(32, 13);
            this.Lines.TabIndex = 6;
            this.Lines.Text = "Lines";
            // 
            // cmbCol
            // 
            this.cmbCol.FormattingEnabled = true;
            this.cmbCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbCol.Location = new System.Drawing.Point(841, 162);
            this.cmbCol.Name = "cmbCol";
            this.cmbCol.Size = new System.Drawing.Size(75, 21);
            this.cmbCol.TabIndex = 7;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(838, 146);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(47, 13);
            this.lb.TabIndex = 8;
            this.lb.Text = "Columns";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(841, 201);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(72, 23);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // mnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 393);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.cmbCol);
            this.Controls.Add(this.Lines);
            this.Controls.Add(this.cmbLines);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.btnStart);
            this.Name = "mnForm";
            this.Text = "MathPuzzle";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button btnCollect;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cmbLines;
        private System.Windows.Forms.Label Lines;
        private System.Windows.Forms.ComboBox cmbCol;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Button btnAbout;
    }
}

