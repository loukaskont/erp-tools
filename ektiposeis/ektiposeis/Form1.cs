using ektiposeis.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ektiposeis
{
    public partial class timologioForm : Form
    {
        public timologioForm()
        {
            InitializeComponent();
        }
        Globals globals = new Globals();
        private void timologioForm_Load(object sender, EventArgs e)
        {
            DataTable proiontaTable = new DataTable("proionta");
            proiontaTable.Columns.Add("ΠΕΡΙΓΡΑΦΗ ΑΓΑΘΩΝ");
            proiontaTable.Columns.Add("ΜΜ");
            proiontaTable.Columns.Add("ΠΟΣΟΤΗΤΑ");
            proiontaTable.Columns.Add("ΤΙΜΗ ΜΟΝΑΔΟΣ");
            proiontaTable.Columns.Add("ΑΞΙΑ");
            proiontaDataGridView.DataSource = fillProiontaDataTable(proiontaTable);
            proiontaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            globals.database = new Database("mySql");
            globals.database.connectInDatabase("server=192.168.1.16; uid=loukas; pwd=knvProject_1; database=knv_project_schema; port=3307;");
        }
        private DataTable fillProiontaDataTable(DataTable proiontaTable) 
        {
            int rowsCount = 5;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow proiontaDataRow = proiontaTable.NewRow();
                for (int j = 0; j < proiontaTable.Columns.Count; j++) 
                {
                    String columnName = proiontaTable.Columns[j].ColumnName;
                    proiontaDataRow[columnName] = "" + i + "," + j;
                }
                proiontaTable.Rows.Add(proiontaDataRow);
            }
            return proiontaTable;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            ConvertFormToHTML convertFormToHTML = new ConvertFormToHTML();
            convertFormToHTML.convertToHTML(mainPanel);
            String sqlSelect = "SELECT customer.customer_id,customer.customer_name,customer.job_title,customer.street,customer.street_number,customer.city,customer.afm,customer.doy,customer.descriprion FROM knv_project_schema.customer where customer_id = '2';";
            DataTable customerDt = globals.database.select(sqlSelect, "customer");
            MessageBox.Show(""+customerDt.Rows.Count);
        }
    }
}
