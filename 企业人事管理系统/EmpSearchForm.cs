using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorke
{
    public partial class EmpSearchForm : Form
    {
        private EmpForm empForm;
        public EmpSearchForm(EmpForm empForm)
        {
           this.empForm  = empForm;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EmpSearchForm_Load(object sender, EventArgs e)
        {
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                //using System. Data, SqlClient;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT did, dname FROM Department order by did";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["did"] = "000";
                    dr["dname"] = "所有";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cbDept.DataSource = ds.Tables[0];
                    cbDept.ValueMember = "did";
                    cbDept.DisplayMember = "dname";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ID, Name, sex, employday, position, dept_id FROM dbo.Employee LEFT JOIN Department ON Employee.dept_id = Department.did ";
            string sqlOrder = " ORDER BY ID";

            StringBuilder sqlwhere = new StringBuilder("WHERE 1=1");
            if (!string.IsNullOrWhiteSpace(tbEmpID.Text))
            {
                sqlwhere.AppendFormat(" AND ID='{0}'", tbEmpID.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(tbName.Text)) ;
            {
                sqlwhere.AppendFormat(" AND Name LIKE '%{0}%'", tbName.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(tbPosition.Text))
            {
                sqlwhere.AppendFormat(" AND position='{0}'", tbPosition.Text.Trim());
            }
            if (cbDept.SelectedIndex >0)
            {
                sqlwhere.AppendFormat(" AND dept_id='{0}'", cbDept.SelectedValue);
            }
            if (ckbEmplyeday.Checked)
            {
                sqlwhere.AppendFormat(" AND employday BETWEEN CAST('{0}'AS Date) AND CAST( '{1}'AS Date)", dtpEmploydayBegin.Value.ToString("yyyy-MM-dd"), 
                    dtpEmploydayEnd.Value.ToString("yyyy-MM-dd"));
            }

            sql = sql + sqlwhere.ToString() + sqlOrder;
           

            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    empForm.GetDataGridView1().DataSource = ds.Tables[0];
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }

        }
    }
}
