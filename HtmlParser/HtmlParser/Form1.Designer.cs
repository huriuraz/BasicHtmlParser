namespace HtmlParser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtAddressBar = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.men�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLA�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabloListesiVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabloSat�rlar�n�ListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabloH�creleriListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tablolar�DataTableYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTableViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.�rnekHTMLA�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddressBar
            // 
            this.txtAddressBar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAddressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAddressBar.Location = new System.Drawing.Point(0, 0);
            this.txtAddressBar.Name = "txtAddressBar";
            this.txtAddressBar.Size = new System.Drawing.Size(608, 20);
            this.txtAddressBar.TabIndex = 0;
            this.txtAddressBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAddressBar.Click += new System.EventHandler(this.txtAddressBar_Click);
            this.txtAddressBar.TextChanged += new System.EventHandler(this.txtAddressBar_TextChanged);
            this.txtAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressBar_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 20);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(608, 402);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(182, 400);
            this.treeView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.webBrowser1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(420, 402);
            this.splitContainer2.SplitterDistance = 242;
            this.splitContainer2.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(418, 240);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Location = new System.Drawing.Point(0, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(418, 130);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.men�ToolStripMenuItem,
            this.dataTableViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(418, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // men�ToolStripMenuItem
            // 
            this.men�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hTMLA�ToolStripMenuItem,
            this.�rnekHTMLA�ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.tabloListesiVerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tabloSat�rlar�n�ListeleToolStripMenuItem,
            this.tabloH�creleriListeleToolStripMenuItem,
            this.toolStripMenuItem2,
            this.tablolar�DataTableYapToolStripMenuItem});
            this.men�ToolStripMenuItem.Name = "men�ToolStripMenuItem";
            this.men�ToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.men�ToolStripMenuItem.Text = "Men�";
            // 
            // hTMLA�ToolStripMenuItem
            // 
            this.hTMLA�ToolStripMenuItem.Name = "hTMLA�ToolStripMenuItem";
            this.hTMLA�ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hTMLA�ToolStripMenuItem.Text = "HTML A�";
            this.hTMLA�ToolStripMenuItem.Click += new System.EventHandler(this.hTMLOpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(201, 6);
            // 
            // tabloListesiVerToolStripMenuItem
            // 
            this.tabloListesiVerToolStripMenuItem.Name = "tabloListesiVerToolStripMenuItem";
            this.tabloListesiVerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.tabloListesiVerToolStripMenuItem.Text = "Tablo Listesi Ver";
            this.tabloListesiVerToolStripMenuItem.Click += new System.EventHandler(this.tabloListesiVerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // tabloSat�rlar�n�ListeleToolStripMenuItem
            // 
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Enabled = false;
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Name = "tabloSat�rlar�n�ListeleToolStripMenuItem";
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Text = "Tablo Sat�rlar�n� Listele";
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Click += new System.EventHandler(this.tabloSat�rlar�n�ListeleToolStripMenuItem_Click);
            // 
            // tabloH�creleriListeleToolStripMenuItem
            // 
            this.tabloH�creleriListeleToolStripMenuItem.Enabled = false;
            this.tabloH�creleriListeleToolStripMenuItem.Name = "tabloH�creleriListeleToolStripMenuItem";
            this.tabloH�creleriListeleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.tabloH�creleriListeleToolStripMenuItem.Text = "Tablo H�creleri Listele";
            this.tabloH�creleriListeleToolStripMenuItem.Click += new System.EventHandler(this.tabloH�creleriListeleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 6);
            // 
            // tablolar�DataTableYapToolStripMenuItem
            // 
            this.tablolar�DataTableYapToolStripMenuItem.Enabled = false;
            this.tablolar�DataTableYapToolStripMenuItem.Name = "tablolar�DataTableYapToolStripMenuItem";
            this.tablolar�DataTableYapToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.tablolar�DataTableYapToolStripMenuItem.Text = "Tablolar� DataTable yap !";
            this.tablolar�DataTableYapToolStripMenuItem.Click += new System.EventHandler(this.tablolar�DataTableYapToolStripMenuItem_Click);
            // 
            // dataTableViewToolStripMenuItem
            // 
            this.dataTableViewToolStripMenuItem.Enabled = false;
            this.dataTableViewToolStripMenuItem.Name = "dataTableViewToolStripMenuItem";
            this.dataTableViewToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.dataTableViewToolStripMenuItem.Text = "Data Table View";
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "Program-File1-4.ico");
            // 
            // �rnekHTMLA�ToolStripMenuItem
            // 
            this.�rnekHTMLA�ToolStripMenuItem.Name = "�rnekHTMLA�ToolStripMenuItem";
            this.�rnekHTMLA�ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.�rnekHTMLA�ToolStripMenuItem.Text = "�rnek HTML A�";
            this.�rnekHTMLA�ToolStripMenuItem.Click += new System.EventHandler(this.�rnekHTMLA�ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 422);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtAddressBar);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HTML Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem men�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabloListesiVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tablolar�DataTableYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabloSat�rlar�n�ListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabloH�creleriListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dataTableViewToolStripMenuItem;
        private System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.ToolStripMenuItem hTMLA�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem �rnekHTMLA�ToolStripMenuItem;
    }
}

