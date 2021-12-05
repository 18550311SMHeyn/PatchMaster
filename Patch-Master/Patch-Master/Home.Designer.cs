
using System;

namespace Patch_Master
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            System.Environment.Exit(0);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logintoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuIAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connectDbToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requirementsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AprovalToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.processesToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requirementToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requestToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeRequestToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ApproveRequestToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteRequestToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requirmentsByProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.UserFirstName_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenu,
            this.databaseToolStripMenu,
            this.requirementsToolStripMenu,
            this.requestToolStripMenu,
            this.reportToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(887, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked_1);
            this.menuStrip1.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // userToolStripMenu
            // 
            this.userToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logintoolStripMenuItem,
            this.toolStripMenuIAddUser});
            this.userToolStripMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userToolStripMenu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.userToolStripMenu.Name = "userToolStripMenu";
            this.userToolStripMenu.Size = new System.Drawing.Size(152, 24);
            this.userToolStripMenu.Text = "User Maintenance";
            // 
            // logintoolStripMenuItem
            // 
            this.logintoolStripMenuItem.Name = "logintoolStripMenuItem";
            this.logintoolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.logintoolStripMenuItem.Text = "Logout";
            this.logintoolStripMenuItem.Click += new System.EventHandler(this.menuStripLogin_Click);
            // 
            // toolStripMenuIAddUser
            // 
            this.toolStripMenuIAddUser.Name = "toolStripMenuIAddUser";
            this.toolStripMenuIAddUser.Size = new System.Drawing.Size(193, 26);
            this.toolStripMenuIAddUser.Text = "Manage Users";
            this.toolStripMenuIAddUser.Click += new System.EventHandler(this.UserList_Click);
            // 
            // databaseToolStripMenu
            // 
            this.databaseToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectDbToolStripMenu});
            this.databaseToolStripMenu.Name = "databaseToolStripMenu";
            this.databaseToolStripMenu.Size = new System.Drawing.Size(185, 24);
            this.databaseToolStripMenu.Text = "Database Management";
            // 
            // connectDbToolStripMenu
            // 
            this.connectDbToolStripMenu.Name = "connectDbToolStripMenu";
            this.connectDbToolStripMenu.Size = new System.Drawing.Size(151, 26);
            this.connectDbToolStripMenu.Text = "Connect";
            this.connectDbToolStripMenu.Click += new System.EventHandler(this.ConnectDb_Click);
            // 
            // requirementsToolStripMenu
            // 
            this.requirementsToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AprovalToolStripMenu,
            this.processesToolStripMenu,
            this.requirementToolStripMenu,
            this.QueryToolStripMenu});
            this.requirementsToolStripMenu.Name = "requirementsToolStripMenu";
            this.requirementsToolStripMenu.Size = new System.Drawing.Size(196, 24);
            this.requirementsToolStripMenu.Text = "Requirement Processing";
            // 
            // AprovalToolStripMenu
            // 
            this.AprovalToolStripMenu.Name = "AprovalToolStripMenu";
            this.AprovalToolStripMenu.Size = new System.Drawing.Size(268, 26);
            this.AprovalToolStripMenu.Text = "Requisition on Approvals";
            this.AprovalToolStripMenu.Click += new System.EventHandler(this.AprovalToolStripMenu_Click);
            // 
            // processesToolStripMenu
            // 
            this.processesToolStripMenu.Name = "processesToolStripMenu";
            this.processesToolStripMenu.Size = new System.Drawing.Size(268, 26);
            this.processesToolStripMenu.Text = "Processes Definition";
            this.processesToolStripMenu.Click += new System.EventHandler(this.Processes_Click);
            // 
            // requirementToolStripMenu
            // 
            this.requirementToolStripMenu.Name = "requirementToolStripMenu";
            this.requirementToolStripMenu.Size = new System.Drawing.Size(268, 26);
            this.requirementToolStripMenu.Text = "Requirement Definitions";
            this.requirementToolStripMenu.Click += new System.EventHandler(this.DefineRequirements_Click);
            // 
            // QueryToolStripMenu
            // 
            this.QueryToolStripMenu.Name = "QueryToolStripMenu";
            this.QueryToolStripMenu.Size = new System.Drawing.Size(268, 26);
            this.QueryToolStripMenu.Text = "Formulate Query";
            this.QueryToolStripMenu.Click += new System.EventHandler(this.FormulateQuery_Click);
            // 
            // requestToolStripMenu
            // 
            this.requestToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MakeRequestToolStripMenu,
            this.ApproveRequestToolStripMenu,
            this.ExecuteRequestToolStripMenu});
            this.requestToolStripMenu.Name = "requestToolStripMenu";
            this.requestToolStripMenu.Size = new System.Drawing.Size(162, 24);
            this.requestToolStripMenu.Text = "Request Processing";
            // 
            // MakeRequestToolStripMenu
            // 
            this.MakeRequestToolStripMenu.Name = "MakeRequestToolStripMenu";
            this.MakeRequestToolStripMenu.Size = new System.Drawing.Size(214, 26);
            this.MakeRequestToolStripMenu.Text = "Make Request";
            this.MakeRequestToolStripMenu.Click += new System.EventHandler(this.MakeRequestToolStripMenu_Click);
            // 
            // ApproveRequestToolStripMenu
            // 
            this.ApproveRequestToolStripMenu.Name = "ApproveRequestToolStripMenu";
            this.ApproveRequestToolStripMenu.Size = new System.Drawing.Size(214, 26);
            this.ApproveRequestToolStripMenu.Text = "Approve Request";
            this.ApproveRequestToolStripMenu.Click += new System.EventHandler(this.ApproveRequestToolStripMenu_Click);
            // 
            // ExecuteRequestToolStripMenu
            // 
            this.ExecuteRequestToolStripMenu.Name = "ExecuteRequestToolStripMenu";
            this.ExecuteRequestToolStripMenu.Size = new System.Drawing.Size(214, 26);
            this.ExecuteRequestToolStripMenu.Text = "Execute Request";
            this.ExecuteRequestToolStripMenu.Click += new System.EventHandler(this.ExecuteRequestToolStripMenu_Click);
            // 
            // reportToolStripMenu
            // 
            this.reportToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requirmentsByProcessToolStripMenuItem});
            this.reportToolStripMenu.Name = "reportToolStripMenu";
            this.reportToolStripMenu.Size = new System.Drawing.Size(175, 24);
            this.reportToolStripMenu.Text = "Inquiries and Reports";
            // 
            // requirmentsByProcessToolStripMenuItem
            // 
            this.requirmentsByProcessToolStripMenuItem.Name = "requirmentsByProcessToolStripMenuItem";
            this.requirmentsByProcessToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.requirmentsByProcessToolStripMenuItem.Text = "Requirments By Process";
            // 
            // labelWelcome
            // 
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWelcome.ForeColor = System.Drawing.Color.Tomato;
            this.labelWelcome.Location = new System.Drawing.Point(611, 494);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(94, 26);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "Welcome";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserFirstName_label
            // 
            this.UserFirstName_label.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserFirstName_label.ForeColor = System.Drawing.Color.OrangeRed;
            this.UserFirstName_label.Location = new System.Drawing.Point(701, 491);
            this.UserFirstName_label.Name = "UserFirstName_label";
            this.UserFirstName_label.Size = new System.Drawing.Size(186, 29);
            this.UserFirstName_label.TabIndex = 4;
            this.UserFirstName_label.Text = "xxx";
            this.UserFirstName_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(104, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 491);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(887, 529);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserFirstName_label);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "PatchMaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem logintoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuIAddUser;
        private System.Windows.Forms.ToolStripMenuItem connectDbToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem requirementsToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem requestToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem QueryToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem requirementToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem AprovalToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem processesToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem MakeRequestToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ApproveRequestToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ExecuteRequestToolStripMenu;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label UserFirstName_label;
        private System.Windows.Forms.ToolStripMenuItem requirmentsByProcessToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

