using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=ShamilTestDB;Integrated Security=True";

        SqlConnection sqlConnection = null;

        DataSet set;

        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            pivotGridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            set = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from employees", sqlConnection);

            adapter.Fill(set);

            pivotGridControl1.DataSource = set.Tables[0];

            SetData(set.Tables[0]);
        }

        public void SetData(DataTable table)
        {
            foreach(DataColumn column in set.Tables[0].Columns)
            {
                PivotGridField field = new PivotGridField(column.ColumnName, PivotArea.FilterArea);
                pivotGridControl1.Fields.Add(field);
            }
        }
        
    }
}
