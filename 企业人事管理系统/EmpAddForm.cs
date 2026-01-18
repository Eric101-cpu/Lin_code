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
    public partial class EmpAddForm : Form
    {

        private EmpForm empForm;
        public EmpAddForm(EmpForm empForm)
        {
            this.empForm = empForm;
            InitializeComponent();
        }

        private void EmpAddForm_Load(object sender, EventArgs e)
        {
            string connStr =@"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                //using System.Data.SqlClient;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT did,dname FROM [dbo].[Department] ORDER BY did";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);                               //将资料填入DataSet的Dept表
                    cbDept.DataSource = ds.Tables[0];
                    cbDept.DisplayMember = "dname";
                    cbDept.ValueMember = "did";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEmpID.Text))
            {
                MessageBox.Show("请输入员工编号！");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("请输入员工姓名！");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPosition.Text))
            {
                MessageBox.Show("请选择员工职位！");
                return;
            }

            bool existed = Exist(tbEmpID.Text.Trim());
            if (existed)
            {
                MessageBox.Show("员工编号已存在，请重新输入！");
                return;
            }

            string ID = tbEmpID.Text.Trim();
            string Name = tbName.Text.Trim();
            string sex = rbMale.Checked ? "男" : "女";
            string position = tbPosition.Text.Trim();
            DateTime employDay = dtpEmployday.Value;
            int dept_id = (int)cbDept.SelectedValue;

            bool added = AddEmp(ID, Name, sex, position,employDay, dept_id);
            if (added)
            {
                MessageBox.Show("员工添加成功！");
                this.empForm.RefreashEmpData(); //刷新员工列表
                this.Close();
            }
            else
            {
                MessageBox.Show("员工添加失败！");
            }
        }

        private bool Exist(string empID)
        {
            bool existed = false;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("SELECT COUNT(*) FROM [dbo].[Employee] WHERE ID='{0}'",tbEmpID.Text.Trim());
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int row = (int)cmd.ExecuteScalar();
                    if (row > 0)
                    {
                        existed = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
            return existed;
        }

        private bool AddEmp(string ID, string Name, string sex,string position, DateTime employDay, int deptId)
        {
            bool added = false;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("INSERT  dbo.Employee (ID, Name, sex,position,employday,dept_id) VALUES ('{0}', '{1}', '{2}','{3}',CAST( '{4}'AS Date),{5})",
                        ID, Name, sex,position,employDay.ToString("yyyy-MM-dd"), deptId);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        added = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
            return added;
        }

        private void tbPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

