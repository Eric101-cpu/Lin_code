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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HomeWorke
{
    public partial class Main : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
        private bool isEditMode = false;



        public Main(string username, bool adminStatus)
        {
            InitializeComponent(); // 初始化界面上的控件

            // 1. 保存用户信息
            connectionString = username;
            isEditMode = adminStatus;

            // 2. 更新欢迎标签的内容
            labelWelcome.Text = $"欢迎你，{username}！";
        }


        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();  // 确保定时器已启动，开始实时更新时间
        
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
                    this.dgvEmployees.AutoGenerateColumns = true;
                    this.dgvEmployees.DataSource = ds.Tables["Dept"];      //显示資料在dataGridView1上
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);

            }
        }



        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出系统吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpForm empForm = new EmpForm();
            empForm.Show();
        }

        private void 部门管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            DeptForm deptForm = new DeptForm();
            deptForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void 取消_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
