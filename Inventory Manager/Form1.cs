using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           database xd = new database();
            xd.initializeDB();
            xd.populateDB();
        }

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        private void addJunkOnDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Inventory (order_no, name , address, status, price, date) VALUES (123452367890,'logan2','herasde and now','0',1, 54.99,datetime('now')),(1232342323890,'logasdasan2','herasde aasdasdnd now','0',1, 34.99,datetime('now')),";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            conn.Open();
            string sql = "SELECT * FROM Inventory";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
            //read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("order_no")),  // Or column name like this
            read.GetValue(read.GetOrdinal("name")),
            read.GetValue(read.GetOrdinal("address")),
            read.GetValue(read.GetOrdinal("company_id")),
            read.GetValue(read.GetOrdinal("del_status")),
            read.GetValue(read.GetOrdinal("price"))
            
            });
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            conn.Open();
            string sql = "SELECT * FROM Inventory";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] {
                    //read.GetValue(0),  // U can use column index
                    read.GetValue(read.GetOrdinal("order_no")),  // Or column name like this
                    read.GetValue(read.GetOrdinal("name")),
                    read.GetValue(read.GetOrdinal("address")),
                    read.GetValue(read.GetOrdinal("company_id")),
                    read.GetValue(read.GetOrdinal("del_status")),
                    read.GetValue(read.GetOrdinal("price"))
                    });
                }
            read.Close();
            }
        }
    }
}
