using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HomeWorke
{
    public partial class DeptEditForm : Form
    {
        private string oldDname;
        private DeptForm deptForm;       
        

        public DeptEditForm(DeptForm deptForm,string dept_dname) : this()  //获取传递过来的参数
        {
            this.deptForm = deptForm;
            
            this.oldDname = dept_dname;
        }

        public DeptEditForm() 
        {
            InitializeComponent();
           
        }
        
        private void btEdit_Click(object sender, EventArgs e)  //修改按钮
        {
            if (string.IsNullOrWhiteSpace(tbDeptName.Text))
            {
                MessageBox.Show("部门名称不能为空");
                tbDeptName.Focus();
                return;
            }
            
            string newDeptName = tbDeptName.Text.Trim(); //获得新的部门名称

            bool edited = EditDept(newDeptName,oldDname);
            if (edited)
            {
                MessageBox.Show("修改成功");
                this.Close();

                deptForm.DeptForm_Load(null, null); //刷新DeptForm的数据

            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }


        //数据库修改
        private bool EditDept(string newDname,string oldDname)
        {
            bool op = false;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True";
            try
            {
                using(SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "UPDATE [dbo].[Department] SET dname =@newDname WHERE dname=@oldDname ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    
                    cmd.Parameters.AddWithValue("@newDname", newDname);
                    cmd.Parameters.AddWithValue("@oldDname", oldDname);


                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                        op = true;                  
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("数据库异常");
            }
            return op;
        }

        private void DeptEditForm_Load(object sender, EventArgs e)
        {
            tbDeptName.Text = this.oldDname;
            
        }
    }
}
