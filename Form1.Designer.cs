using System;

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
        ///Display hangman body parts when guesses are wrong
        
    }
            

        private void InitializeComponent()
        {
            this.hangmanart1 = new System.Windows.Forms.PictureBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblChosenLetters = new System.Windows.Forms.Label();
            this.cmdA = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.GuessWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.hangmanart1)).BeginInit();
            this.SuspendLayout();
            // 
            // hangmanart1
            // 
            this.hangmanart1.BackColor = System.Drawing.SystemColors.Info;
            this.hangmanart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hangmanart1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hangmanart1.Image = global::HangmanProj.Properties.Resources.Art1;
            this.hangmanart1.Location = new System.Drawing.Point(43, 35);
            this.hangmanart1.Name = "hangmanart1";
            this.hangmanart1.Size = new System.Drawing.Size(283, 193);
            this.hangmanart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hangmanart1.TabIndex = 0;
            this.hangmanart1.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblResult.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(452, 64);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(201, 55);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChosenLetters
            // 
            this.lblChosenLetters.BackColor = System.Drawing.Color.Chartreuse;
            this.lblChosenLetters.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChosenLetters.Location = new System.Drawing.Point(181, 251);
            this.lblChosenLetters.Name = "lblChosenLetters";
            this.lblChosenLetters.Size = new System.Drawing.Size(431, 32);
            this.lblChosenLetters.TabIndex = 5;
            this.lblChosenLetters.Text = "Used Letters";
            this.lblChosenLetters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChosenLetters.Click += new System.EventHandler(this.LblChosenLetters_Click);
            // 
            // cmdA
            // 
            this.cmdA.BackColor = System.Drawing.Color.Chartreuse;
            this.cmdA.Location = new System.Drawing.Point(43, 300);
            this.cmdA.Name = "cmdA";
            this.cmdA.Size = new System.Drawing.Size(50, 47);
            this.cmdA.TabIndex = 6;
            this.cmdA.Text = "a";
            this.cmdA.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chartreuse;
            this.button1.Location = new System.Drawing.Point(99, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "b";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Chartreuse;
            this.button2.Location = new System.Drawing.Point(155, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "c";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Chartreuse;
            this.button3.Location = new System.Drawing.Point(211, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 47);
            this.button3.TabIndex = 9;
            this.button3.Text = "d";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Chartreuse;
            this.button4.Location = new System.Drawing.Point(267, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 47);
            this.button4.TabIndex = 10;
            this.button4.Text = "e";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Chartreuse;
            this.button5.Location = new System.Drawing.Point(323, 300);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 47);
            this.button5.TabIndex = 11;
            this.button5.Text = "f";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Chartreuse;
            this.button6.Location = new System.Drawing.Point(379, 300);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 47);
            this.button6.TabIndex = 12;
            this.button6.Text = "g";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Chartreuse;
            this.button7.Location = new System.Drawing.Point(435, 300);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 47);
            this.button7.TabIndex = 13;
            this.button7.Text = "h";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Chartreuse;
            this.button8.Location = new System.Drawing.Point(491, 300);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 47);
            this.button8.TabIndex = 14;
            this.button8.Text = "i";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Chartreuse;
            this.button9.Location = new System.Drawing.Point(547, 300);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 47);
            this.button9.TabIndex = 15;
            this.button9.Text = "j";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Chartreuse;
            this.button10.Location = new System.Drawing.Point(603, 300);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 47);
            this.button10.TabIndex = 16;
            this.button10.Text = "k";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Chartreuse;
            this.button11.Location = new System.Drawing.Point(659, 300);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 47);
            this.button11.TabIndex = 17;
            this.button11.Text = "l";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Chartreuse;
            this.button12.Location = new System.Drawing.Point(715, 300);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 47);
            this.button12.TabIndex = 18;
            this.button12.Text = "m";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Chartreuse;
            this.button13.Location = new System.Drawing.Point(43, 353);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(50, 47);
            this.button13.TabIndex = 19;
            this.button13.Text = "n";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Chartreuse;
            this.button14.Location = new System.Drawing.Point(99, 353);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 47);
            this.button14.TabIndex = 20;
            this.button14.Text = "o";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Chartreuse;
            this.button15.Location = new System.Drawing.Point(155, 353);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(50, 47);
            this.button15.TabIndex = 21;
            this.button15.Text = "p";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Chartreuse;
            this.button16.Location = new System.Drawing.Point(211, 353);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(50, 47);
            this.button16.TabIndex = 22;
            this.button16.Text = "q";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Chartreuse;
            this.button17.Location = new System.Drawing.Point(267, 353);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(50, 47);
            this.button17.TabIndex = 23;
            this.button17.Text = "r";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Chartreuse;
            this.button18.Location = new System.Drawing.Point(323, 353);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(50, 47);
            this.button18.TabIndex = 24;
            this.button18.Text = "s";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Chartreuse;
            this.button19.Location = new System.Drawing.Point(379, 353);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(50, 47);
            this.button19.TabIndex = 25;
            this.button19.Text = "t";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Chartreuse;
            this.button20.Location = new System.Drawing.Point(435, 353);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(50, 47);
            this.button20.TabIndex = 26;
            this.button20.Text = "u";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Chartreuse;
            this.button21.Location = new System.Drawing.Point(491, 353);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(50, 47);
            this.button21.TabIndex = 27;
            this.button21.Text = "v";
            this.button21.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Chartreuse;
            this.button22.Location = new System.Drawing.Point(547, 353);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(50, 47);
            this.button22.TabIndex = 28;
            this.button22.Text = "w";
            this.button22.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Chartreuse;
            this.button23.Location = new System.Drawing.Point(603, 353);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(50, 47);
            this.button23.TabIndex = 29;
            this.button23.Text = "x";
            this.button23.UseVisualStyleBackColor = false;
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Chartreuse;
            this.button24.Location = new System.Drawing.Point(659, 353);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(50, 47);
            this.button24.TabIndex = 30;
            this.button24.Text = "y";
            this.button24.UseVisualStyleBackColor = false;
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Chartreuse;
            this.button25.Location = new System.Drawing.Point(715, 353);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(50, 47);
            this.button25.TabIndex = 31;
            this.button25.Text = "z";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // GuessWord
            // 
            this.GuessWord.Location = new System.Drawing.Point(396, 161);
            this.GuessWord.Name = "GuessWord";
            this.GuessWord.Size = new System.Drawing.Size(313, 22);
            this.GuessWord.TabIndex = 32;
            this.GuessWord.TextChanged += new System.EventHandler(this.GuessWord_TextChanged);
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GuessWord);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdA);
            this.Controls.Add(this.lblChosenLetters);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.hangmanart1);
            this.Name = "Hangman";
            this.Text = "Hangman";
            ((System.ComponentModel.ISupportInitialize)(this.hangmanart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GuessWord_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.PictureBox hangmanart1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblChosenLetters;
        private System.Windows.Forms.Button cmdA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.TextBox GuessWord;
    }
}

