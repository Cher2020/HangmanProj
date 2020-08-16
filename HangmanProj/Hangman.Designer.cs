namespace HangmanProj
{
    partial class Hangman
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
            this.lbl = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblWrongGuesses = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblGuessLeft = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxWord = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.SystemColors.Info;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(308, 244);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(154, 32);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Wrong Guesses";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnswer
            // 
            this.lblAnswer.Location = new System.Drawing.Point(0, 0);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(100, 23);
            this.lblAnswer.TabIndex = 38;
            // 
            // lblWrongGuesses
            // 
            this.lblWrongGuesses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWrongGuesses.Location = new System.Drawing.Point(468, 249);
            this.lblWrongGuesses.Name = "lblWrongGuesses";
            this.lblWrongGuesses.Size = new System.Drawing.Size(124, 27);
            this.lblWrongGuesses.TabIndex = 37;
            this.lblWrongGuesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 32);
            this.label2.TabIndex = 39;
            this.label2.Text = "Length";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(753, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 40;
            this.label3.Text = "Guess Left";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLength
            // 
            this.lblLength.BackColor = System.Drawing.SystemColors.Menu;
            this.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLength.Location = new System.Drawing.Point(692, 244);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(46, 32);
            this.lblLength.TabIndex = 41;
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGuessLeft
            // 
            this.lblGuessLeft.BackColor = System.Drawing.SystemColors.Menu;
            this.lblGuessLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGuessLeft.Location = new System.Drawing.Point(870, 244);
            this.lblGuessLeft.Name = "lblGuessLeft";
            this.lblGuessLeft.Size = new System.Drawing.Size(46, 32);
            this.lblGuessLeft.TabIndex = 42;
            this.lblGuessLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(96, 438);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 36);
            this.btnStart.TabIndex = 43;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // groupBoxWord
            // 
            this.groupBoxWord.Location = new System.Drawing.Point(331, 63);
            this.groupBoxWord.Name = "groupBoxWord";
            this.groupBoxWord.Size = new System.Drawing.Size(592, 100);
            this.groupBoxWord.TabIndex = 44;
            this.groupBoxWord.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(42, 389);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(247, 46);
            this.lblInfo.TabIndex = 45;
            this.lblInfo.Text = "\r\n";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.Click += new System.EventHandler(this.LblInfo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(312, 290);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(604, 205);
            this.flowLayoutPanel1.TabIndex = 46;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(45, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 347);
            this.panel1.TabIndex = 47;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.groupBoxWord);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblGuessLeft);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWrongGuesses);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lbl);
            this.Name = "Hangman";
            this.Text = "Hangman";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblWrongGuesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblGuessLeft;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBoxWord;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}

