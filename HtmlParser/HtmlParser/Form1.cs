using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HtmlParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Private Methods

        //Olu�turdu�um web sayfas�n� otomatik a�ar...
        //�rnek olarak benzer bi sayfa yap�labilir..
        private void hTMLOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.FileName = string.Empty;
            ofd.Filter = "HTML Files(*.html;*.htm)|*.html;*.htm";
            ofd.FilterIndex = 0;
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;
            ofd.Title = "HTML Dosya A�";
            
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtAddressBar.Text = ofd.FileName;
                this.txtAddressBar_KeyDown(this.txtAddressBar, new KeyEventArgs(Keys.Enter));
            }
        }

        private List<HtmlTagPointer> ReadTableTag(string[] KaynakKodSatirlari)
        {
            /*
             * Buradaki ama�;
             * 
             * RichTextBox'daki sat�rlarda tek tek "<table" ifadesi ar�yoruz.. Dikkat "<table>" de�il ��nk� table'�n style
             * ayar� yap�lm��sa "<table Border="1px" >" gibi bi�imler mevcut olabilir. Fakat "<table" ifadesi olmas� gerekir 
             * ve sabittir.. Bir table tag a��ld���n� bildirir.
             * 
             * Burada RichTextBox sat�rlar�nda tek tek gezerken o an ki sat�rda bir table tag a��l�p a��lmad���n�
             * Contains(i�erir) metodu ile yakal�yoruz.. Amac�m, HtmlTagPointer isimli class ile ilk for d�ng�s� ile
             * a��lan table tag'lerinin sat�r numaras�n� kaydetmek.
             * 
             * Ikinci for d�ng�s� ile de kapan�� sat�r numaralar�n� yakalamak.. B�ylece tablolar belirlenir..
             */
            List<HtmlTagPointer> tagPointerList = new List<HtmlTagPointer>();

            for (int i = 1; i < KaynakKodSatirlari.Length; i++)
            {
                if (KaynakKodSatirlari[i].Contains("<table"))
                {
                    HtmlTagPointer tagPointer = new HtmlTagPointer();
                    tagPointer.StartLineNumber = i;

                    tagPointerList.Add(tagPointer);
                }
            }

            int k = 0;

            if (tagPointerList.Count != 0)
            {
                for (int i = 1; i < KaynakKodSatirlari.Length; i++)
                {
                    if (KaynakKodSatirlari[i].Contains("</table"))
                    {
                        HtmlTagPointer tagPointer = tagPointerList[k];
                        tagPointer.EndLineNumber = i;

                        k++;
                    }
                }
            }
            return tagPointerList;
        }

        /// <summary>
        /// H�cre de�erini alan metod..
        /// </summary>
        /// <param name="cellPointer">H�cre 'nin td tag sat�r nolar�..
        /// </param>
        /// <returns></returns>
        private string ReadCellValue(HtmlTagPointer cellPointer)
        {
            /*
             * 8) <td> deger
             * 9) </td>
             * 
             * �eklinde de�erler saklan�r..
             * Burada CellPointer iki de�er tutuyor StartLineNumber=8 ve EndLineNumber=9 bizim amac�m�z StartLineNumber nolu 
             * sat�rda ">" etiketinden EndLineNumber nolu sat�rsa "<" etiketi aras�na kadar okuma yapaca��z..
             */

            System.Text.StringBuilder strValue = new System.Text.StringBuilder();

            for (int i = cellPointer.StartLineNumber; i <= cellPointer.EndLineNumber; i++)
            {
                if (i != cellPointer.EndLineNumber)
                {
                    /*
                     * Html de okuyaca��m�z de�erin sat�rda ba�lad��� index..
                     */
                    int degerBaslangic = this.richTextBox1.Lines[i].IndexOf('>');
                    strValue.AppendLine(this.richTextBox1.Lines[i].Substring(degerBaslangic + 1, this.richTextBox1.Lines[i].Length - degerBaslangic - 1));
                }
                else
                {
                    /*
                     * Html de "</td>" tag'inden �nceki ks��mda okunur..
                     */
                    int degerSonu = this.richTextBox1.Lines[i].IndexOf('<');
                    strValue.AppendLine(this.richTextBox1.Lines[i].Substring(0, degerSonu));
                }
            }

            //De�erin sonuda bo�luk varsa temizlenir..
            return strValue.ToString().TrimEnd();

        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtAddressBar.Text = " ";
            this.treeView1.Nodes.Add("Tablolar");
        }

        private void txtAddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Enter 'a bas�l�nca..
             */
            if (e.KeyCode == Keys.Enter)
            {
                /*
                 * E�er adres yaz�lm��sa..
                 * Adresi Bar'� kontrol ediyoruz adres var m�? Bo� de�ilse..
                 * Bu sefer adres kontrol edilir.. Ge�erli bir web Url 'simi diye e�er ge�erli bir url ise..
                 * System.UriTypeConverter ile  URL'ye d�n��t�r�l�r..
                 * WebBrowser navigate metodu ile adres a��l�r..
                 */
                if (txtAddressBar.Text.Trim() != "")
                {
                    System.UriTypeConverter uriConverter = new UriTypeConverter();

                    if (uriConverter.IsValid(txtAddressBar.Text))
                    {
                        this.webBrowser1.Navigate(uriConverter.ConvertFromString(txtAddressBar.Text).ToString());
                    }
                    else
                    {
                        MessageBox.Show("L�tfen ge�erli bir internet adresi giriniz..");
                    }
                }
                else
                {
                    MessageBox.Show("Bir web adresi giriniz..");
                }
            }
        }

        private void txtAddressBar_TextChanged(object sender, EventArgs e)
        {
            /*
             * Biraz g�rselite kat�yorum..
             */
            if (this.txtAddressBar.Text.Trim() == "" || this.txtAddressBar.Text == "Bir web adresi giriniz..")
            {
                this.txtAddressBar.Text = "Bir web adresi giriniz..";
                this.txtAddressBar.Font = new Font("Segoe Print", 8, FontStyle.Bold | FontStyle.Italic);
                this.txtAddressBar.ForeColor = Color.White;
                return;
            }
            else
            {
                this.txtAddressBar.Font = new Font("Segoe Print", 9, FontStyle.Bold | FontStyle.Italic);
                this.txtAddressBar.ForeColor = Color.Navy;
            }
        }

        private void txtAddressBar_Click(object sender, EventArgs e)
        {
            this.txtAddressBar.SelectAll();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /*
             * Web sayfan�n kaynak kodunu okur..
             * 
             * Kaynak kodu i�eren bir dosya sistemi(stream) olu�turulur..
             * Dosya okuyucu(streamReader) olu�turulur ve okuyaca�� dosya belirtilir..
             */
            System.IO.Stream stream = this.webBrowser1.DocumentStream;
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);

            //Kaynak kod okunur ve richtextbox 'a aktar�l�r..
            this.richTextBox1.Text = reader.ReadToEnd();
        }

        private void tabloListesiVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * Her liste ver denildi�inde temizleme yap�l�r..
             * S�rekli ayn� Node'lar olu�mas�n diye
             * 
             * Tablolar isimli node genel node'd�r.. 
             * Bir de�i�kene aktar�l�r..
             */
            this.treeView1.Nodes[0].Nodes.Clear();
            TreeNode rootNode = this.treeView1.Nodes[0];

            /*
             * Tablolar�n bilgisinin listesi al�n�r..
             */
            List<HtmlTagPointer> TagPointerList = this.ReadTableTag(richTextBox1.Lines);

            /*
             * E�er web sayfas�nda tablo varsa..
             */
            if (TagPointerList.Count != 0)
            {
                /*
                 * Kaydedilen tablolar s�ras�yla rootNode'a eklenir..
                 * Bu ekleme i�leminde HtmlTagPointer class'lar� node'�n tag �zelli�ine at�l�r.
                 */
                for (int i = 0; i < TagPointerList.Count; i++)
                {
                    HtmlTagPointer tagPointer = TagPointerList[i];

                    TreeNode tn = new TreeNode("Tablo-" + (i + 1).ToString());
                    tn.Tag = tagPointer;

                    rootNode.Nodes.Add(tn);
                }
            }


            /*
             * aktifle�en butonlar..
             */
            this.tabloSat�rlar�n�ListeleToolStripMenuItem.Enabled = true;
        }

        private void tabloSat�rlar�n�ListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode rootNode = this.treeView1.Nodes[0];

            if (rootNode.Nodes.Count != 0)
            {
                foreach (TreeNode tn in rootNode.Nodes)
                {
                    HtmlTagPointer tablePoint = (HtmlTagPointer)tn.Tag;

                    List<HtmlTagPointer> RowPointerList = new List<HtmlTagPointer>();

                    /*
                     * tr ba�lang��lar� kaydedilir..
                     */
                    for (int i = tablePoint.StartLineNumber; i < tablePoint.EndLineNumber; i++)
                    {
                        if (this.richTextBox1.Lines[i].Contains("<tr"))
                        {
                            HtmlTagPointer rowPointer = new HtmlTagPointer();
                            rowPointer.StartLineNumber = i;

                            RowPointerList.Add(rowPointer);
                        }
                    }

                    int k = 0;
                    /*
                     * tr biti�leri kaydedilir..
                     */
                    for (int i = tablePoint.StartLineNumber; i < tablePoint.EndLineNumber; i++)
                    {
                        if (this.richTextBox1.Lines[i].Contains("</tr"))
                        {
                            HtmlTagPointer rowPointer = RowPointerList[k];
                            rowPointer.EndLineNumber = i;

                            k++;
                        }
                    }

                    /*
                     * Yakalanan tr 'ler treeView'a eklenir..
                     */
                    if (RowPointerList.Count != 0)
                    {
                        for (int i = 0; i < RowPointerList.Count; i++)
                        {
                            TreeNode rowTreeNode = new TreeNode("Row-" + (i + 1).ToString());
                            rowTreeNode.Tag = RowPointerList[i];

                            tn.Nodes.Add(rowTreeNode);
                        }
                    }
                }
            }

            /*
             * aktifle�en butonlar..
             */
            this.tabloH�creleriListeleToolStripMenuItem.Enabled = true;
        }

        private void tabloH�creleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * tabloSat�rlar�n�ListeleToolStripMenuItem_Click event'i ile ayn� kod sat�r� asl�nda
             * sadece en ba��nda t�m tablolar i�in d�n var bide "<tr" de�il "<td" tag aran�yor..
             */

            /*
             * T�m tablolar i�in d�n..
             */
            foreach (TreeNode t in this.treeView1.Nodes[0].Nodes)
            {
                TreeNode tableNode = t;
                /*
                 * Tablonun sat�rlar� varsa..
                 */
                if (tableNode.Nodes.Count != 0)
                {
                    /*
                     * T�m sat�rlarda d�n..
                     */
                    foreach (TreeNode rowNode in tableNode.Nodes)
                    {
                        HtmlTagPointer RowPoint = (HtmlTagPointer)rowNode.Tag;

                        List<HtmlTagPointer> CellPointerList = new List<HtmlTagPointer>();

                        /*
                         * td ba�lang��lar� kaydedilir..
                         */
                        for (int i = RowPoint.StartLineNumber; i < RowPoint.EndLineNumber; i++)
                        {
                            if (this.richTextBox1.Lines[i].Contains("<td"))
                            {
                                HtmlTagPointer cellPointer = new HtmlTagPointer();
                                cellPointer.StartLineNumber = i;

                                CellPointerList.Add(cellPointer);
                            }
                        }

                        int k = 0;
                        /*
                         * td biti�leri kaydedilir..
                         */
                        for (int i = RowPoint.StartLineNumber; i < RowPoint.EndLineNumber; i++)
                        {
                            if (this.richTextBox1.Lines[i].Contains("</td"))
                            {
                                HtmlTagPointer cellPointer = CellPointerList[k];
                                cellPointer.EndLineNumber = i;

                                k++;
                            }
                        }

                        /*
                         * Yakalanan td 'ler treeView'a eklenir..
                         */
                        if (CellPointerList.Count != 0)
                        {
                            for (int i = 0; i < CellPointerList.Count; i++)
                            {
                                TreeNode cellTreeNode = new TreeNode("Cell-" + (i + 1).ToString());
                                cellTreeNode.Tag = CellPointerList[i];

                                rowNode.Nodes.Add(cellTreeNode);
                            }
                        }
                    }
                }
            }

            /*
             * aktifle�en butonlar..
             */
            this.tablolar�DataTableYapToolStripMenuItem.Enabled = true;
        }

        private void tablolar�DataTableYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode rootNode = this.treeView1.Nodes[0];

            this.dataTableViewToolStripMenuItem.DropDownItems.Clear();

            foreach (TreeNode tableNode in rootNode.Nodes)
            {
                //O an ki tablo i�in datatatble olu�turulur..
                System.Data.DataTable dt = new DataTable(tableNode.Text);

                int rowCount = tableNode.Nodes.Count;
                int cellCount = tableNode.Nodes[0].Nodes.Count;

                //Datatable kolonlar� olu�turulur..
                for (int i = 0; i < cellCount; i++)
                {
                    dt.Columns.Add("Column-" + (i + 1).ToString());
                }

                //Sat�rlar� olu�turulur..
                for (int i = 0; i < rowCount; i++)
                {
                    TreeNode rowNode = tableNode.Nodes[i];
                    DataRow dr = dt.NewRow();

                    //Sat�rlara de�erler eklenir..
                    for (int j = 0; j < cellCount; j++)
                    {
                        TreeNode cellNode = rowNode.Nodes[j];
                        HtmlTagPointer cellPointer = (HtmlTagPointer)cellNode.Tag;

                        //Sat�r de�eri bir metod ile al�n�r..
                        string cellValue = this.ReadCellValue(cellPointer);
                        //sat�ra de�er yaz�l�r..
                        dr[j] = cellValue;
                    }

                    //sat�r tabloya eklenir..
                    dt.Rows.Add(dr);
                }


                //dataTableViewToolStripMenuItem alt�na men� Item'lar eklenir....
                ToolStripItem tsi = new ToolStripButton();
                tsi.Text = tableNode.Text;
                tsi.Image = ImageList1.Images[0];
                tsi.Tag = dt;

                //Ekledi�imiz item'lar t�klan�nca �al��acak void yaz�l�r..
                tsi.Click += new EventHandler(tsi_Click);

                this.dataTableViewToolStripMenuItem.DropDownItems.Add(tsi);
            }

            ToolStripItem tsItm = new ToolStripSeparator();
            tsItm.Text = "-";

            this.dataTableViewToolStripMenuItem.DropDownItems.Add(tsItm);

            /*
             * T�m tablolar�n kaydedilmeisini otomatik sa�layan bir item..(Excel ve XML i�in..)
             */
            tsItm = new ToolStripButton();
            tsItm.Text = "T�m Tablolar� Excel 'e Kaydet !";
            tsItm.Click += new EventHandler(tsItmDoExcel_Click);

            this.dataTableViewToolStripMenuItem.DropDownItems.Add(tsItm);

            tsItm = new ToolStripButton();
            tsItm.Text = "T�m Tablolar� XML Yap !";
            tsItm.Click += new EventHandler(tsItmDoXML_Click);

            this.dataTableViewToolStripMenuItem.DropDownItems.Add(tsItm);

            /*
             * menu aktifle�tirilir..
             */
            this.dataTableViewToolStripMenuItem.Enabled = true;
        }

        void tsItmDoExcel_Click(object sender, EventArgs e)
        {
            //Dosya kaydet dialog penceresi �zellikleri ayarlan�r..
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Excel Export";
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo excelFile = null;

                switch (sfd.FilterIndex)
                {
                    case 1:
                        excelFile = new System.IO.FileInfo(Application.StartupPath + "\\" + "dosya.xlsx");
                        break;
                    case 2:
                        excelFile = new System.IO.FileInfo(Application.StartupPath + "\\" + "dosya.xls");
                        break;
                    default:
                        break;
                }

                //Kaydet denilen konuma excel dosyas� kopyalan�r..
                excelFile.CopyTo(sfd.FileName, true);

                Form2 frm2 = new Form2();

                /*
                 * Tablolar yaz�l�r..
                 */
                foreach (ToolStripItem tsi in this.dataTableViewToolStripMenuItem.DropDownItems)
                {
                    if (tsi is ToolStripButton && tsi.Image != null)
                    {
                        ToolStripButton tsb = tsi as ToolStripButton;
                        frm2.CreateExcelFile((DataTable)tsb.Tag, sfd);
                    }
                }
            }
        }

        void tsItmDoXML_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.SelectedPath = System.IO.Directory.GetCurrentDirectory();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Form2 frm2 = new Form2();

                /*
                 * Tablolar yaz�l�r..
                 */
                foreach (ToolStripItem tsi in this.dataTableViewToolStripMenuItem.DropDownItems)
                {
                    if (tsi is ToolStripButton && tsi.Image != null)
                    {
                        ToolStripButton tsb = tsi as ToolStripButton;
                        frm2.CreateXmlFile((DataTable)tsb.Tag, fbd.SelectedPath + "\\" + tsb.Text + ".xml");
                    }
                }
            }
        }

        /// <summary>
        /// Data table View men�s�nden bir item se�ilince �al��acak olan metod..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsi_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripButton)sender;

            Form2 frm2 = new Form2();
            frm2.SetDataTable((DataTable)tsi.Tag);

            frm2.Show();
        }

        #endregion

        private void �rnekHTMLA�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtAddressBar.Text = Application.StartupPath + "\\" + "htmlsample.htm";
            this.txtAddressBar_KeyDown(this.txtAddressBar, new KeyEventArgs(Keys.Enter));
        }

    }
}