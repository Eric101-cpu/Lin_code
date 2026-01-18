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
    public partial class EmpForm : Form
    {
        public EmpForm()
        {
            InitializeComponent();
        }

        public void RefreashEmpData()  //公共刷新数据方法
        {
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 选择原始列名并包含 position 列，避免使用中文别名
                    string sql = "SELECT ID, Name, sex, employday, position, dept_id FROM dbo.Employee";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }

        }
        //不将EmpForm_Load改为public，否则会破坏类的封装性，SO：新建一个公共刷新数据方法RefreashEmpData()，给EmpAddForm中第83行代码调用
        private void EmpForm_Load(object sender, EventArgs e)
        {
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // 同上：包含 position，使用原始列名
                    string sql = "SELECT ID, Name, sex, employday, position, dept_id FROM dbo.Employee ORDER BY ID";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)  //添加
        {
            new EmpAddForm(this).ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)  //删除
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的员工记录！");
                return;
            }
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("一次只能删除一条员工记录！");
                return;
            }
            DialogResult dr = MessageBox.Show("确定要删除选中的员工记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }

            string empID = Convert.ToString(dataGridView1.SelectedRows[0].Cells["colID"].Value);
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("DELETE FROM dbo.Employee WHERE ID='{0}'", empID);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int rows = cmd.ExecuteNonQuery();    //执行本次SQL命令，返回受影响的行数
                    if (rows > 0)  
                    {
                        MessageBox.Show("员工记录删除成功！");
                        RefreashEmpData(); //刷新员工列表
                    }
                    else
                    {
                        MessageBox.Show("员工记录删除失败！");
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public DataGridView GetDataGridView1()
        {
            return dataGridView1;
        }

        private void btnEdit_Click(object sender, EventArgs e)  //修改
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要修改的员工记录！");
                return;
            }
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("一次只能修改一条员工记录！");
                return;
            }
            new EmpEditForm(this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new EmpSearchForm(this).ShowDialog();
        }

        public DataGridView DataGridView1
        {
            get
            {
                return this.dataGridView1;
            }
        }
    }
}
