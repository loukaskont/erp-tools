﻿using ektiposeis.MyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ektiposeis.ektyposeis
{
    public partial class Ektyposi3 : Form
    {
        public Ektyposi3()
        {
            InitializeComponent();
        }

        private void Ektyposi3_Load(object sender, EventArgs e)
        {
            richTextBox2.Text = "Praktiker Hellas Α.Ε \n ΑΦΜ: 094317955 / Δ.Ο.Υ ΦΑΕ ΑΘΗΝΩΝ \n Ταύρο Αττικής - Πειραιώς 176, 177 78.";
            DataTable proiontaTable = new DataTable("proionta");
            proiontaTable.Columns.Add("ΠΕΡΙΓΡΑΦΗ ΑΓΑΘΩΝ");
            proiontaTable.Columns.Add("ΜΜ");
            proiontaTable.Columns.Add("ΠΟΣΟΤΗΤΑ");
            proiontaTable.Columns.Add("ΤΙΜΗ ΜΟΝΑΔΟΣ");
            proiontaTable.Columns.Add("ΑΞΙΑ");
            proiontaDataGridView.DataSource = fillProiontaDataTable(proiontaTable);
            proiontaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            convertFormToHTML.convertToHTML(panel1);
        }
    }
}
