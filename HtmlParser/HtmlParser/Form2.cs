using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


namespace HtmlParser
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void SetDataTable(DataTable dt)
        {
            this.Text = dt.TableName;
            this.dataGridView1.DataSource = dt;
        }


        #region XML Export

        public void CreateXmlFile(DataTable dt, string fileName)
        {
            try
            {
                /*
                 * DataTable nesnesinin WriteXML metodu ile XmlSchema ile tablo yaz�l�r..
                 */
                dt.WriteXml(fileName, XmlWriteMode.WriteSchema, true);

                MessageBox.Show("Tablo XML olarak kaydedildi..", "XML Kay�t Ba�ar�l�..", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void tabloyuXMLYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Data Table To XML File";
            sfd.Filter = "XML Dosyalar(*.xml)|*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.CreateXmlFile((DataTable)dataGridView1.DataSource, sfd.FileName);
            }
        }

        #endregion



        #region Excel Export

        public void CreateExcelFile(DataTable dt, SaveFileDialog sfd)
        {

            //Excel dosyas� i�in ba�lant� ve sorgu �al��t�r�c� tam�nlan�r..
            OleDbConnection conOleDBConnection = new OleDbConnection();
            OleDbCommand comOleDBCommand = new OleDbCommand();

            switch (sfd.FilterIndex)
            {
                case 1:
                    /*
                     * Excel 2007 i�in..
                     */
                    conOleDBConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sfd.FileName + ";Extended Properties=" + Char.ConvertFromUtf32(34) + "Excel 12.0" + Char.ConvertFromUtf32(34) + ";";
                    break;
                case 2:
                    /*
                     * Excel 2003 i�in..
                     */
                    conOleDBConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sfd.FileName + ";Extended Properties=" + Char.ConvertFromUtf32(34) + "Excel 8.0" + Char.ConvertFromUtf32(34) + ";";
                    break;
                default:
                    break;
            }

            

            //Command connection �zelli�i ayarlan�r...
            comOleDBCommand.Connection = conOleDBConnection;

            //Ba�lant� a��l�r..
            conOleDBConnection.Open();

            #region Export Excel

            /*
             * Excel dosyas�nda tablo olu�turmak i�in kolon isimleri s�ralan�r.
             */
            System.Text.StringBuilder columnText = new StringBuilder();

            foreach (DataColumn dc in dt.Columns)
            {
                columnText.Append("[" + dc.ColumnName + "] string, ");
            }

            columnText = columnText.Remove(columnText.Length - 2, 2);

            /*
             * Excel dosyas�nda tablo olu�turulur..
             */
            comOleDBCommand.CommandText = "CREATE TABLE [" + dt.TableName.Replace("-", "").ToString() + "] (" + columnText + ");";
            comOleDBCommand.ExecuteNonQuery();


            /*
             * Kolon isimleri insert sorgusu i�in s�ralan�r..
             */
            System.Text.StringBuilder columns = new StringBuilder();

            foreach (DataColumn dc in dt.Columns)
            {
                columns.Append("[" + dc.ColumnName + "], ");
            }

            columns = columns.Remove(columns.Length - 2, 2);

            /*
             * Datatable'daki her bir sat�r excel dosyas�ndaki tabloya eklenir..
             */
            foreach (DataRow datRow in dt.Rows)
            {
                comOleDBCommand.CommandType = CommandType.Text;

                /*
                 * Kolon de�erleri insert sorgusu i�in s�ralan�r..
                 */
                System.Text.StringBuilder values = new StringBuilder();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    values.Append("'" + datRow[i].ToString() + "', ");
                }

                values = values.Remove(values.Length - 2, 2);

                /*
                 * Insert c�mlesi olu�turulur..
                 */
                comOleDBCommand.CommandText = "INSERT INTO [" + dt.TableName.Replace("-", "").ToString() + "$] (" + columns + ") VALUES (" + values + ");";

                /*
                 * Sat�r eklenir..
                 */
                comOleDBCommand.ExecuteNonQuery();
            }


            MessageBox.Show("Kay�t i�lemi ba�ar�l�..", "Kay�t i�lemi Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            #endregion

            //Ba�lant� kapat�l�r..
            conOleDBConnection.Close();

        }

        private void tabloyuExcelYapToolStripMenuItem_Click(object sender, EventArgs e)
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
                        /*
                         * Excel 2007 i�in..
                         */
                       excelFile = new System.IO.FileInfo(Application.StartupPath + "\\" + "dosya.xlsx");
                        break;
                    case 2:
                        /*
                         * Excel 2003 i�in..
                         */
                        excelFile = new System.IO.FileInfo(Application.StartupPath + "\\" + "dosya.xls");
                        break;
                    default:
                        break;
                }

                //Kaydet denilen konuma excel dosyas� kopyalan�r..
                excelFile.CopyTo(sfd.FileName, true);

                //Excel'e yaz�lmak �zere datatable yollan�r..
                this.CreateExcelFile((DataTable)this.dataGridView1.DataSource, sfd);
            }
        }

        #endregion



        #region SQL Process

        private void RadioButtons_CheckedChange(object sender, EventArgs e)
        {
            if (this.rdbWinAut.Checked)
            {
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
            }
            else
            {
                this.txtUserName.Enabled = true;
                this.txtPassword.Enabled = true;
            }
        }

        /// <summary>
        /// Ba�lant�y� kuracak �zellik..
        /// </summary>
        private Server _srv;
        public Server Srv
        {
            get { return _srv; }
            set { _srv = value; }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            /*
             * Ba�lant� �ekline g�re server nesnesi olu�turulur..
             */
            if (this.rdbWinAut.Checked)
            {
                this._srv = new Server(new ServerConnection(txtServerName.Text));
            }
            else
            {
                this._srv = new Server(new ServerConnection(txtServerName.Text, txtUserName.Text, txtPassword.Text));
            }

            /*
             * Database'ler listelenir..
             */
            foreach (Database db in Srv.Databases)
            {
                this.lstDatabases.Items.Add(db);
            }

            if (this.lstDatabases.Items.Count != 0)
            {
                this.tabloyuSQLeExportEtToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Tabloyu kaydedecek bir database listesi yap�lamad�.. L�tfen ilk �nce sisteminize bir database ekleyiniz..", "Database listesi mevcut de�il !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        #region SQL Export

        private void tabloyuSQLeExportEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * E�er tabloyu kaydedecek bir database se�ilmediyse i�lem durur..
             */
            if (this.lstDatabases.SelectedIndex == -1)
            {
                MessageBox.Show("L�tfen tabloyu Export etmek i�in bir database se�iniz..", "Se�ili database yok !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                /*
             * Kaydedilecek tablo okunur..
             */
                DataTable dt = (DataTable)this.dataGridView1.DataSource;

                /*
                 * Tablo olu�turulur..
                 */
                Table tbl = new Table((Database)this.lstDatabases.SelectedItem, dt.TableName);

                /*
                 * Tablo kolonlar� eklenir..
                 */
                foreach (DataColumn dc in dt.Columns)
                {
                    Column clm = new Column(tbl, dc.ColumnName, new DataType(SqlDataType.NVarCharMax));

                    tbl.Columns.Add(clm);
                }

                /*
                 * Se�ili database'de tablo olu�turulur..
                 */
                tbl.Create();

                /*
                 * Tablonun olu�turuldu�u database'e ba�lant� �evrilir..
                 */
                this.Srv.ConnectionContext.SqlConnectionObject.Open();
                this.Srv.ConnectionContext.SqlConnectionObject.ChangeDatabase(((Database)this.lstDatabases.SelectedItem).Name);

                /*
                 * Insert cumlesini otomatik olu�turmak i�in CommandBuilder kulland�m..
                 * CommandBUilder ise DataAdapter nesnesi ister..
                 * DataAdapter nesnesinede Hangi tablonun insert c�mlesini olu�turacaksan onun select sorgusu yaz�l�r..
                 * Ba�lant�da zaten vard�, bidaha olu�turulmaz verilir..
                 */
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [" + dt.TableName + "]", this.Srv.ConnectionContext.SqlConnectionObject);
                System.Data.SqlClient.SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);

                /*
                 * Insert c�mlesi olu�turulur..
                 */
                cmdBuilder.DataAdapter.InsertCommand = cmdBuilder.GetInsertCommand(false);

                /*
                 * S�rayla datatable'�m�zdaki sat�rlar parametre �eklinde de�erleri ile beraber eklenir ve
                 * insert i�lemi execute edilir..
                 */
                foreach (DataRow dr in dt.Rows)
                {
                    //Her defada parametreleri temzilemezsek ayn� parametreleri birden fazla kere eklemi� oluruz..
                    cmdBuilder.DataAdapter.InsertCommand.Parameters.Clear();

                    int i = 0;

                    foreach (Column c in tbl.Columns)
                    {
                        cmdBuilder.DataAdapter.InsertCommand.Parameters.AddWithValue("@p" + (i + 1).ToString(), dr[i].ToString());
                        i++;
                    }

                    //De�erler insert edilir..
                    cmdBuilder.DataAdapter.InsertCommand.ExecuteNonQuery();
                }

                /*
                 * E�er bu noktaya ula��l�rsa sorunsuzca tablo SQL 'e at�lm�� demektir..
                 */
                MessageBox.Show("Tablo ba�ar�yla database'e kaydedilmi�tir..", "SQL Export Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                /*
                 * SQL HATA !
                 */
                System.Windows.Forms.MessageBox.Show(sqlEx.Message, sqlEx.Source, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                /*
                 * GENEL HATA !
                 */
                System.Windows.Forms.MessageBox.Show(ex.Message, ex.Source, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            finally
            {
                //E�er hata sonucunda ba�lant� a��k kald�ysa kapat�l�r..
                if (this.Srv.ConnectionContext.SqlConnectionObject.State == System.Data.ConnectionState.Open)
                {
                    this.Srv.ConnectionContext.SqlConnectionObject.Close();
                }
            }
        }

        #endregion

        #endregion


        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}