using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gui_roulette
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            pictureBox1 = new System.Windows.Forms.PictureBox();
            balance = new System.Windows.Forms.Label();
            betamount = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            betred = new System.Windows.Forms.Button();
            betblack = new System.Windows.Forms.Button();
            betodd = new System.Windows.Forms.Button();
            beteven = new System.Windows.Forms.Button();
            reset = new System.Windows.Forms.Button();
            resultat = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            nrbtn = new System.Windows.Forms.TextBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            betbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(131, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(557, 266);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // balance
            // 
            balance.AutoSize = true;
            balance.ForeColor = System.Drawing.Color.White;
            balance.Location = new System.Drawing.Point(666, 31);
            balance.Name = "balance";
            balance.Size = new System.Drawing.Size(100, 20);
            balance.TabIndex = 1;
            balance.Text = "Balance: $100";
            // 
            // betamount
            // 
            betamount.Location = new System.Drawing.Point(21, 61);
            betamount.Name = "betamount";
            betamount.Size = new System.Drawing.Size(125, 27);
            betamount.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(126, 20);
            label1.TabIndex = 3;
            label1.Text = "Enter Bet Amount";
            // 
            // betred
            // 
            betred.BackColor = System.Drawing.Color.Red;
            betred.ForeColor = System.Drawing.Color.White;
            betred.Location = new System.Drawing.Point(174, 366);
            betred.Name = "betred";
            betred.Size = new System.Drawing.Size(94, 29);
            betred.TabIndex = 4;
            betred.Text = "Bet Red";
            betred.UseVisualStyleBackColor = false;
            // 
            // betblack
            // 
            betblack.BackColor = System.Drawing.Color.Black;
            betblack.ForeColor = System.Drawing.Color.White;
            betblack.Location = new System.Drawing.Point(174, 401);
            betblack.Name = "betblack";
            betblack.Size = new System.Drawing.Size(94, 29);
            betblack.TabIndex = 5;
            betblack.Text = "Bet Black";
            betblack.UseVisualStyleBackColor = false;
            // 
            // betodd
            // 
            betodd.BackColor = System.Drawing.Color.Gray;
            betodd.ForeColor = System.Drawing.Color.White;
            betodd.Location = new System.Drawing.Point(563, 401);
            betodd.Name = "betodd";
            betodd.Size = new System.Drawing.Size(94, 29);
            betodd.TabIndex = 6;
            betodd.Text = "Bet Odd";
            betodd.UseVisualStyleBackColor = false;
            // 
            // beteven
            // 
            beteven.BackColor = System.Drawing.Color.SandyBrown;
            beteven.ForeColor = System.Drawing.Color.White;
            beteven.Location = new System.Drawing.Point(563, 366);
            beteven.Name = "beteven";
            beteven.Size = new System.Drawing.Size(94, 29);
            beteven.TabIndex = 7;
            beteven.Text = "Bet Even";
            beteven.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            reset.BackColor = System.Drawing.Color.Gray;
            reset.ForeColor = System.Drawing.Color.White;
            reset.Location = new System.Drawing.Point(672, 61);
            reset.Name = "reset";
            reset.Size = new System.Drawing.Size(94, 29);
            reset.TabIndex = 8;
            reset.Text = "Reset Game";
            reset.UseVisualStyleBackColor = false;
            // 
            // resultat
            // 
            resultat.AutoSize = true;
            resultat.ForeColor = System.Drawing.Color.Yellow;
            resultat.Location = new System.Drawing.Point(384, 61);
            resultat.Name = "resultat";
            resultat.Size = new System.Drawing.Size(0, 20);
            resultat.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(330, 370);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(169, 20);
            label2.TabIndex = 10;
            label2.Text = "Choose a number (0-36)";
            // 
            // nrbtn
            // 
            nrbtn.Location = new System.Drawing.Point(347, 403);
            nrbtn.Name = "nrbtn";
            nrbtn.Size = new System.Drawing.Size(125, 27);
            nrbtn.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(805, 341);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(8, 8);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // betbtn
            // 
            betbtn.BackColor = System.Drawing.SystemColors.GrayText;
            betbtn.ForeColor = System.Drawing.Color.White;
            betbtn.Location = new System.Drawing.Point(152, 61);
            betbtn.Name = "betbtn";
            betbtn.Size = new System.Drawing.Size(94, 29);
            betbtn.TabIndex = 13;
            betbtn.Text = "Bet";
            betbtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DarkGreen;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(betbtn);
            Controls.Add(pictureBox2);
            Controls.Add(nrbtn);
            Controls.Add(label2);
            Controls.Add(resultat);
            Controls.Add(reset);
            Controls.Add(beteven);
            Controls.Add(betodd);
            Controls.Add(betblack);
            Controls.Add(betred);
            Controls.Add(label1);
            Controls.Add(betamount);
            Controls.Add(balance);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Roulette Game";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label balance;
        private System.Windows.Forms.TextBox betamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button betred;
        private System.Windows.Forms.Button betblack;
        private System.Windows.Forms.Button betodd;
        private System.Windows.Forms.Button beteven;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label resultat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nrbtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button betbtn;
    }
}