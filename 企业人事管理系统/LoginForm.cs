using HomeWorke;
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
    public partial class LoginForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)  //登录
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           

            string connstr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql = string.Format("select * from [dbo].[Users] where [username]='{0}' and [password]='{1}'", username,password);
            SqlCommand cmd = new SqlCommand(sql, conn);


            int i = (int)cmd.ExecuteScalar();
            if (i > 0)
            {
                new Main(username,false).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show( "用户名或密码错误","登录失败",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }





        private void LoginForm_Load(object sender, EventArgs e)     
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)  //取消
        {
            Application.Exit();
        }
    }
}

