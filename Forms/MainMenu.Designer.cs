namespace WinClient.Forms
{
    partial class MainMenu
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
            this.InputUserName = new System.Windows.Forms.TextBox();
            this.InputPassword = new System.Windows.Forms.TextBox();
            this.InputLogin = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoadIndicator = new System.Windows.Forms.ProgressBar();
            this.ActionList = new System.Windows.Forms.ListBox();
            this.IOPanel = new System.Windows.Forms.Panel();
            this.InputRun = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputUserName
            // 
            this.InputUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputUserName.Location = new System.Drawing.Point(6, 7);
            this.InputUserName.Name = "InputUserName";
            this.InputUserName.Size = new System.Drawing.Size(425, 39);
            this.InputUserName.TabIndex = 0;
            // 
            // InputPassword
            // 
            this.InputPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPassword.Location = new System.Drawing.Point(6, 52);
            this.InputPassword.Name = "InputPassword";
            this.InputPassword.PasswordChar = '•';
            this.InputPassword.Size = new System.Drawing.Size(425, 39);
            this.InputPassword.TabIndex = 1;
            // 
            // InputLogin
            // 
            this.InputLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLogin.Location = new System.Drawing.Point(164, 98);
            this.InputLogin.Name = "InputLogin";
            this.InputLogin.Size = new System.Drawing.Size(267, 50);
            this.InputLogin.TabIndex = 2;
            this.InputLogin.Text = "Login";
            this.InputLogin.UseVisualStyleBackColor = true;
            this.InputLogin.Click += new System.EventHandler(this.InputLogin_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LoginPanel.Controls.Add(this.InputLogin);
            this.LoginPanel.Controls.Add(this.InputPassword);
            this.LoginPanel.Controls.Add(this.InputUserName);
            this.LoginPanel.Location = new System.Drawing.Point(1449, 12);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(437, 154);
            this.LoginPanel.TabIndex = 3;
            // 
            // LoadIndicator
            // 
            this.LoadIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadIndicator.Location = new System.Drawing.Point(354, 1289);
            this.LoadIndicator.MarqueeAnimationSpeed = 1;
            this.LoadIndicator.Name = "LoadIndicator";
            this.LoadIndicator.Size = new System.Drawing.Size(1256, 47);
            this.LoadIndicator.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadIndicator.TabIndex = 5;
            this.LoadIndicator.Visible = false;
            // 
            // ActionList
            // 
            this.ActionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ActionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionList.FormattingEnabled = true;
            this.ActionList.ItemHeight = 32;
            this.ActionList.Location = new System.Drawing.Point(12, 12);
            this.ActionList.Name = "ActionList";
            this.ActionList.Size = new System.Drawing.Size(330, 1316);
            this.ActionList.TabIndex = 6;
            this.ActionList.Click += new System.EventHandler(this.ActionList_Click);
            // 
            // IOPanel
            // 
            this.IOPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IOPanel.BackColor = System.Drawing.Color.Transparent;
            this.IOPanel.Location = new System.Drawing.Point(354, 12);
            this.IOPanel.Name = "IOPanel";
            this.IOPanel.Size = new System.Drawing.Size(1529, 1271);
            this.IOPanel.TabIndex = 7;
            // 
            // InputRun
            // 
            this.InputRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputRun.Location = new System.Drawing.Point(1616, 1289);
            this.InputRun.Name = "InputRun";
            this.InputRun.Size = new System.Drawing.Size(267, 50);
            this.InputRun.TabIndex = 3;
            this.InputRun.Text = "Run !";
            this.InputRun.UseVisualStyleBackColor = true;
            this.InputRun.Visible = false;
            this.InputRun.Click += new System.EventHandler(this.InputRun_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1898, 1342);
            this.Controls.Add(this.InputRun);
            this.Controls.Add(this.ActionList);
            this.Controls.Add(this.LoadIndicator);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.IOPanel);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox InputUserName;
        private System.Windows.Forms.TextBox InputPassword;
        private System.Windows.Forms.Button InputLogin;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.ProgressBar LoadIndicator;
        private System.Windows.Forms.ListBox ActionList;
        private System.Windows.Forms.Panel IOPanel;
        private System.Windows.Forms.Button InputRun;
    }
}