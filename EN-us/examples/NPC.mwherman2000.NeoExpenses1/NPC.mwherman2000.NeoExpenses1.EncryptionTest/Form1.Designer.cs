namespace NPC.mwherman2000.NeoExpenses1.EncryptionTest
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
            this.buttonEncryptFile = new System.Windows.Forms.Button();
            this.buttonDecryptFile = new System.Windows.Forms.Button();
            this.buttonCreateAsmKeys = new System.Windows.Forms.Button();
            this.buttonExportPublicKey = new System.Windows.Forms.Button();
            this.buttonImportPublicKey = new System.Windows.Forms.Button();
            this.buttonGetPrivateKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxExportPrivateKey = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEncryptFile
            // 
            this.buttonEncryptFile.Location = new System.Drawing.Point(21, 116);
            this.buttonEncryptFile.Name = "buttonEncryptFile";
            this.buttonEncryptFile.Size = new System.Drawing.Size(146, 37);
            this.buttonEncryptFile.TabIndex = 0;
            this.buttonEncryptFile.Text = "Encrypt File";
            this.buttonEncryptFile.UseVisualStyleBackColor = true;
            this.buttonEncryptFile.Click += new System.EventHandler(this.buttonEncryptFile_Click);
            // 
            // buttonDecryptFile
            // 
            this.buttonDecryptFile.Location = new System.Drawing.Point(211, 21);
            this.buttonDecryptFile.Name = "buttonDecryptFile";
            this.buttonDecryptFile.Size = new System.Drawing.Size(146, 42);
            this.buttonDecryptFile.TabIndex = 1;
            this.buttonDecryptFile.Text = "Decrypt File";
            this.buttonDecryptFile.UseVisualStyleBackColor = true;
            this.buttonDecryptFile.Click += new System.EventHandler(this.buttonDecryptFile_Click);
            // 
            // buttonCreateAsmKeys
            // 
            this.buttonCreateAsmKeys.Location = new System.Drawing.Point(21, 30);
            this.buttonCreateAsmKeys.Name = "buttonCreateAsmKeys";
            this.buttonCreateAsmKeys.Size = new System.Drawing.Size(146, 37);
            this.buttonCreateAsmKeys.TabIndex = 2;
            this.buttonCreateAsmKeys.Text = "Create Asm Keys";
            this.buttonCreateAsmKeys.UseVisualStyleBackColor = true;
            this.buttonCreateAsmKeys.Click += new System.EventHandler(this.buttonCreateAsmKeys_Click);
            // 
            // buttonExportPublicKey
            // 
            this.buttonExportPublicKey.Location = new System.Drawing.Point(21, 73);
            this.buttonExportPublicKey.Name = "buttonExportPublicKey";
            this.buttonExportPublicKey.Size = new System.Drawing.Size(146, 37);
            this.buttonExportPublicKey.TabIndex = 3;
            this.buttonExportPublicKey.Text = "Export Public Key";
            this.buttonExportPublicKey.UseVisualStyleBackColor = true;
            this.buttonExportPublicKey.Click += new System.EventHandler(this.buttonExportPublicKey_Click);
            // 
            // buttonImportPublicKey
            // 
            this.buttonImportPublicKey.Location = new System.Drawing.Point(211, 116);
            this.buttonImportPublicKey.Name = "buttonImportPublicKey";
            this.buttonImportPublicKey.Size = new System.Drawing.Size(146, 37);
            this.buttonImportPublicKey.TabIndex = 4;
            this.buttonImportPublicKey.Text = "Import Public Keys";
            this.buttonImportPublicKey.UseVisualStyleBackColor = true;
            this.buttonImportPublicKey.Click += new System.EventHandler(this.buttonImportPublicKey_Click);
            // 
            // buttonGetPrivateKey
            // 
            this.buttonGetPrivateKey.Location = new System.Drawing.Point(399, 116);
            this.buttonGetPrivateKey.Name = "buttonGetPrivateKey";
            this.buttonGetPrivateKey.Size = new System.Drawing.Size(146, 37);
            this.buttonGetPrivateKey.TabIndex = 5;
            this.buttonGetPrivateKey.Text = "Get Private Key";
            this.buttonGetPrivateKey.UseVisualStyleBackColor = true;
            this.buttonGetPrivateKey.Click += new System.EventHandler(this.buttonGetPrivateKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "--";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxExportPrivateKey);
            this.groupBox1.Controls.Add(this.buttonExportPublicKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonCreateAsmKeys);
            this.groupBox1.Controls.Add(this.buttonGetPrivateKey);
            this.groupBox1.Controls.Add(this.buttonEncryptFile);
            this.groupBox1.Controls.Add(this.buttonImportPublicKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 177);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Management";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDecryptFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decrypt with Current Key";
            // 
            // checkBoxExportPrivateKey
            // 
            this.checkBoxExportPrivateKey.AutoSize = true;
            this.checkBoxExportPrivateKey.Checked = true;
            this.checkBoxExportPrivateKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportPrivateKey.Location = new System.Drawing.Point(211, 82);
            this.checkBoxExportPrivateKey.Name = "checkBoxExportPrivateKey";
            this.checkBoxExportPrivateKey.Size = new System.Drawing.Size(146, 21);
            this.checkBoxExportPrivateKey.TabIndex = 7;
            this.checkBoxExportPrivateKey.Text = "Export Private Key";
            this.checkBoxExportPrivateKey.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "NeoExpenses Demo App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEncryptFile;
        private System.Windows.Forms.Button buttonDecryptFile;
        private System.Windows.Forms.Button buttonCreateAsmKeys;
        private System.Windows.Forms.Button buttonExportPublicKey;
        private System.Windows.Forms.Button buttonImportPublicKey;
        private System.Windows.Forms.Button buttonGetPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxExportPrivateKey;
    }
}

