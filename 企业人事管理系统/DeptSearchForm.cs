using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeWorke
{        
    public partial class DeptSearchForm : Form
    {
        private DeptForm deptForm;
        public DeptSearchForm(DeptForm deptForm)
        {
            this.deptForm = deptForm;
            InitializeComponent(); //初始化组件
        }

        private void DeptName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)  //搜索按钮   Obsidian中【C#中查询】
        {
            string keyword = (this.DeptName.Text ?? string.Empty).Trim();
            //空值合并运算符  ??  ：   当 DeptName.Text 为 null 时返回空字符串                           
            //.Trim()：   移除输入值两端的空格，避免无效查询


            if (string.IsNullOrEmpty(keyword))         //防御性编程：避免空关键字查询全表
            {
                MessageBox.Show("请输入要查询的部门名称");
                this.DeptName.Focus();
                return;
            }



            string sql = "SELECT dname AS 部门名称 FROM [dbo].[Department] WHERE dname LIKE @kw";
            string connstr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" + keyword + "%";

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)   //结果集校验：避免传递空表导致下游窗体异常
                    {
                        MessageBox.Show("没找着啊");
                        return;
                    }

                    // 将查询结果显示在 DeptForm，并确保主窗体可见
                    deptForm.SetDeptGrid(ds.Tables[0]);
                    deptForm.Show();
                    deptForm.BringToFront();

                    this.Close(); //关闭搜索窗口
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: ");


            }
        }

        private void DeptSearchForm_Load(object sender, EventArgs e)
        {

        }
    }

}
