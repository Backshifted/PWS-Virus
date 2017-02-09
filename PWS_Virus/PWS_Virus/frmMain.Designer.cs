namespace PWS_Virus
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.btnIcon = new System.Windows.Forms.Button();
            this.tbIcon = new System.Windows.Forms.TextBox();
            this.lblPayload = new System.Windows.Forms.Label();
            this.btnPayload = new System.Windows.Forms.Button();
            this.tbPayload = new System.Windows.Forms.TextBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblStorage = new System.Windows.Forms.Label();
            this.rbnNative = new System.Windows.Forms.RadioButton();
            this.rbnManaged = new System.Windows.Forms.RadioButton();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gbFiles.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiles
            // 
            this.gbFiles.Controls.Add(this.lblIcon);
            this.gbFiles.Controls.Add(this.btnIcon);
            this.gbFiles.Controls.Add(this.tbIcon);
            this.gbFiles.Controls.Add(this.lblPayload);
            this.gbFiles.Controls.Add(this.btnPayload);
            this.gbFiles.Controls.Add(this.tbPayload);
            this.gbFiles.Location = new System.Drawing.Point(12, 12);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Size = new System.Drawing.Size(347, 124);
            this.gbFiles.TabIndex = 0;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(11, 70);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(28, 13);
            this.lblIcon.TabIndex = 7;
            this.lblIcon.Text = "Icon";
            // 
            // btnIcon
            // 
            this.btnIcon.Location = new System.Drawing.Point(271, 89);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(66, 23);
            this.btnIcon.TabIndex = 6;
            this.btnIcon.Text = "Browse...";
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // tbIcon
            // 
            this.tbIcon.Location = new System.Drawing.Point(24, 91);
            this.tbIcon.Name = "tbIcon";
            this.tbIcon.Size = new System.Drawing.Size(241, 20);
            this.tbIcon.TabIndex = 5;
            // 
            // lblPayload
            // 
            this.lblPayload.AutoSize = true;
            this.lblPayload.Location = new System.Drawing.Point(11, 21);
            this.lblPayload.Name = "lblPayload";
            this.lblPayload.Size = new System.Drawing.Size(45, 13);
            this.lblPayload.TabIndex = 4;
            this.lblPayload.Text = "Payload";
            // 
            // btnPayload
            // 
            this.btnPayload.Location = new System.Drawing.Point(271, 40);
            this.btnPayload.Name = "btnPayload";
            this.btnPayload.Size = new System.Drawing.Size(66, 23);
            this.btnPayload.TabIndex = 2;
            this.btnPayload.Text = "Browse...";
            this.btnPayload.UseVisualStyleBackColor = true;
            this.btnPayload.Click += new System.EventHandler(this.btnPayload_Click);
            // 
            // tbPayload
            // 
            this.tbPayload.Location = new System.Drawing.Point(24, 42);
            this.tbPayload.Name = "tbPayload";
            this.tbPayload.Size = new System.Drawing.Size(241, 20);
            this.tbPayload.TabIndex = 0;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblStorage);
            this.gbSettings.Controls.Add(this.rbnNative);
            this.gbSettings.Controls.Add(this.rbnManaged);
            this.gbSettings.Controls.Add(this.lblKey);
            this.gbSettings.Controls.Add(this.btnKey);
            this.gbSettings.Controls.Add(this.tbKey);
            this.gbSettings.Location = new System.Drawing.Point(13, 142);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(347, 124);
            this.gbSettings.TabIndex = 8;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(11, 70);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(83, 13);
            this.lblStorage.TabIndex = 7;
            this.lblStorage.Text = "Storage Method";
            // 
            // rbnNative
            // 
            this.rbnNative.AutoSize = true;
            this.rbnNative.Location = new System.Drawing.Point(220, 91);
            this.rbnNative.Name = "rbnNative";
            this.rbnNative.Size = new System.Drawing.Size(105, 17);
            this.rbnNative.TabIndex = 6;
            this.rbnNative.TabStop = true;
            this.rbnNative.Text = "Native Resource";
            this.rbnNative.UseVisualStyleBackColor = true;
            // 
            // rbnManaged
            // 
            this.rbnManaged.AutoSize = true;
            this.rbnManaged.Location = new System.Drawing.Point(24, 91);
            this.rbnManaged.Name = "rbnManaged";
            this.rbnManaged.Size = new System.Drawing.Size(119, 17);
            this.rbnManaged.TabIndex = 5;
            this.rbnManaged.TabStop = true;
            this.rbnManaged.Text = "Managed Resource";
            this.rbnManaged.UseVisualStyleBackColor = true;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(11, 21);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(78, 13);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Encryption Key";
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(270, 40);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(66, 23);
            this.btnKey.TabIndex = 2;
            this.btnKey.Text = "Generate";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(24, 42);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(240, 20);
            this.tbKey.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(99, 272);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(174, 30);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create Trojan";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 309);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "PWS Trojan";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.TextBox tbIcon;
        private System.Windows.Forms.Label lblPayload;
        private System.Windows.Forms.Button btnPayload;
        private System.Windows.Forms.TextBox tbPayload;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.RadioButton rbnNative;
        private System.Windows.Forms.RadioButton rbnManaged;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnCreate;
    }
}

