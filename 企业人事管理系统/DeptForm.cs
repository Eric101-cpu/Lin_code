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
    public partial class DeptForm : Form
    {
        public DeptForm()
        {
            InitializeComponent();
        }//控件初始化

        public void DeptForm_Load(object sender, EventArgs e)
        {
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True";
            try
            {
                //using System.Data.SqlClient;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT did AS 部门编号, dname AS 部门名称 FROM [dbo].[Department] ORDER BY did";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Dept");                               //将资料填入DataSet的Dept表
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds.Tables["Dept"];      //显示資料在dataGridView1上
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
               
            }
        }

        // 新增：由外部调用以安全刷新 DataGridView 的公有方法（避免直接访问私有控件）
        //DeptSearchForm中要访问这里的dataGridView1控件，so要创建如下的方法
        public void SetDeptGrid(DataTable table)
        {
            if (table == null) return;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = table;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //增加
        {
            this.Hide();
            DeptAddForm deptAddForm = new DeptAddForm();
            deptAddForm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)  //修改
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("不支持多行修改");
                return;
            }
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要修改的部门");
                return;
            }

            string dname = (string)dataGridView1.SelectedRows[0].Cells["部门名称"].Value;
            //将选中的部门名称传递给变量dname



            // 使用带参构造传入选中部门名，避免 oldDname 为 null
            DeptEditForm deptEditForm = new DeptEditForm(this, dname);    //创建窗口并且传参

            // 在编辑窗口关闭后恢复并刷新当前窗体的数据
            deptEditForm.FormClosed += (s, args) => 
            {
                // 显示主窗体并刷新数据（确保 UI 返回并展示最新结果）
                this.Show();
                this.DeptForm_Load(null, null);
            };//关掉修改窗口后显示主窗口并刷新数据，并重新执行DeptForm_Load方法

            this.Hide();
            deptEditForm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)  //查找
        {
            this.Hide();
            DeptSearchForm deptSearchForm = new DeptSearchForm(this); //为什么会有this参数传入，见README
            deptSearchForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)  //删除
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的部门记录");
                return;
            }
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("一次只能删除一条部门记录");
                return;
            }


            DialogResult dr = MessageBox.Show("确定要删除选中的部门记录吗？", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "DELETE FROM [dbo].[Department] WHERE did = @did"; //删除和did是自增列属性没啥关系
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        int did = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["部门编号"].Value);
                        cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("部门记录删除成功！");
                            DeptForm_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("部门记录删除失败！");
                        }
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
