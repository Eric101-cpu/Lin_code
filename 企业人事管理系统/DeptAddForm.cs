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
    public partial class DeptAddForm : Form
    {
        public DeptAddForm()
        {
            InitializeComponent();
        }

        private void DeptAddForm_Load(object sender, EventArgs e)
        {

        }

        private DeptForm deptForm;
        public DeptAddForm(DeptForm form)
        {
            this.deptForm = form;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDeptName.Text))
            {
                MessageBox.Show("部门名称不能为空！");
                return;
            }

            bool added = AddDept(tbDeptName.Text.Trim());
            if (added)
            {
                MessageBox.Show("部门信息添加成功！");
                this.Hide();
                if (deptForm != null)
                {
                    deptForm.DeptForm_Load(null, null);   //直接把主窗体的加载事件调用一遍，刷新数据
                }
            }
            else
            {
                MessageBox.Show("部门信息添加失败！");
            }
        }

        private bool AddDept(string name)  //README中问题3
        {
            bool op = false;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "insert into [dbo].[Department] ([dname]) VALUES (@name)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // 明确指定类型和长度，避免 AddWithValue 的潜在问题
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name ?? (object)DBNull.Value;

                        int rows = cmd.ExecuteNonQuery();
                        op = rows > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
            return op;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
