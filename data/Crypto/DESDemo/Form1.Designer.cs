﻿namespace DESDemo
{
    partial class Form1
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox6;
            System.Windows.Forms.GroupBox groupBox7;
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outputEncrypt = new System.Windows.Forms.TextBox();
            this.inputEncrypt = new System.Windows.Forms.TextBox();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.outputDecrypt = new System.Windows.Forms.TextBox();
            this.inputDecrypt = new System.Windows.Forms.TextBox();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.vectorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            groupBox7 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(this.vectorTextBox);
            groupBox1.Controls.Add(this.label2);
            groupBox1.Controls.Add(this.keyTextBox);
            groupBox1.Controls.Add(this.label1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(702, 48);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.tableLayoutPanel2);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Location = new System.Drawing.Point(3, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(348, 429);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alice";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(groupBox5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(groupBox4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EncryptBtn, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(342, 410);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.outputEncrypt);
            groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox5.Location = new System.Drawing.Point(3, 188);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(336, 179);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Encrypted";
            // 
            // outputEncrypt
            // 
            this.outputEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputEncrypt.Location = new System.Drawing.Point(3, 16);
            this.outputEncrypt.Multiline = true;
            this.outputEncrypt.Name = "outputEncrypt";
            this.outputEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputEncrypt.Size = new System.Drawing.Size(330, 160);
            this.outputEncrypt.TabIndex = 3;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.inputEncrypt);
            groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox4.Location = new System.Drawing.Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(336, 179);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Input";
            // 
            // inputEncrypt
            // 
            this.inputEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputEncrypt.Location = new System.Drawing.Point(3, 16);
            this.inputEncrypt.Multiline = true;
            this.inputEncrypt.Name = "inputEncrypt";
            this.inputEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputEncrypt.Size = new System.Drawing.Size(330, 160);
            this.inputEncrypt.TabIndex = 3;
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncryptBtn.Location = new System.Drawing.Point(3, 373);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(336, 34);
            this.EncryptBtn.TabIndex = 2;
            this.EncryptBtn.Text = "Encrypt";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.OnEncryptBtnClick);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.tableLayoutPanel3);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox3.Location = new System.Drawing.Point(357, 57);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(348, 429);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bob";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(groupBox6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(groupBox7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DecryptBtn, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(342, 410);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(this.outputDecrypt);
            groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox6.Location = new System.Drawing.Point(3, 188);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(336, 179);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Decrypted";
            // 
            // outputDecrypt
            // 
            this.outputDecrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDecrypt.Location = new System.Drawing.Point(3, 16);
            this.outputDecrypt.Multiline = true;
            this.outputDecrypt.Name = "outputDecrypt";
            this.outputDecrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputDecrypt.Size = new System.Drawing.Size(330, 160);
            this.outputDecrypt.TabIndex = 3;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(this.inputDecrypt);
            groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox7.Location = new System.Drawing.Point(3, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(336, 179);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Input";
            // 
            // inputDecrypt
            // 
            this.inputDecrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputDecrypt.Location = new System.Drawing.Point(3, 16);
            this.inputDecrypt.Multiline = true;
            this.inputDecrypt.Name = "inputDecrypt";
            this.inputDecrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputDecrypt.Size = new System.Drawing.Size(330, 160);
            this.inputDecrypt.TabIndex = 3;
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecryptBtn.Location = new System.Drawing.Point(3, 373);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(336, 34);
            this.DecryptBtn.TabIndex = 2;
            this.DecryptBtn.Text = "Decrypt";
            this.DecryptBtn.UseVisualStyleBackColor = true;
            this.DecryptBtn.Click += new System.EventHandler(this.OnDecryptBtnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(groupBox3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.24744F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.75256F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 489);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(41, 17);
            this.keyTextBox.MaxLength = 8;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(100, 20);
            this.keyTextBox.TabIndex = 1;
            this.keyTextBox.Text = "ABCDEFGH";
            // 
            // vectorTextBox
            // 
            this.vectorTextBox.Location = new System.Drawing.Point(216, 17);
            this.vectorTextBox.MaxLength = 8;
            this.vectorTextBox.Name = "vectorTextBox";
            this.vectorTextBox.Size = new System.Drawing.Size(100, 20);
            this.vectorTextBox.TabIndex = 3;
            this.vectorTextBox.Text = "ABCDEFGH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vector";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 489);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button DecryptBtn;
        private System.Windows.Forms.TextBox outputDecrypt;
        private System.Windows.Forms.TextBox inputDecrypt;
        private System.Windows.Forms.TextBox outputEncrypt;
        private System.Windows.Forms.TextBox inputEncrypt;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vectorTextBox;
        private System.Windows.Forms.Label label2;
    }
}

