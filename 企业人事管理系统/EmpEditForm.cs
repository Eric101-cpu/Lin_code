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
    public partial class EmpEditForm : Form
    {
        private EmpForm empForm;
        public EmpEditForm(EmpForm empForm)
        {
            this.empForm = empForm;
            InitializeComponent();
        }

        private void EmpEditForm_Load(object sender, EventArgs e)
        {
            tbEmpID.Text = (string)empForm.GetDataGridView1().SelectedRows[0].Cells["colID"].Value;
            tbName.Text = (string)empForm.GetDataGridView1().SelectedRows[0].Cells["colName"].Value;
            rbMale.Checked = ((string)empForm.GetDataGridView1().SelectedRows[0].Cells["colsex"].Value) == "男" ? true : false;
            rbFemale.Checked = !rbMale.Checked;
            dtpEmployday.Value = (DateTime)empForm.GetDataGridView1().SelectedRows[0].Cells["colemployday"].Value;
            tbPosition.Text = (string)empForm.GetDataGridView1().SelectedRows[0].Cells["colposition"].Value;

            InitDeptComboBox(); //初始化部门下拉列表
            string deptName = (string)empForm.GetDataGridView1().SelectedRows[0].Cells["coldept_id"].Value;
            for (int i = 0; i < cbDept.Items.Count; i++)
            {
                DataRowView item = (DataRowView)cbDept.Items[i];
                if (deptName == item.Row.ItemArray[1].ToString())          //
                {
                    cbDept.SelectedIndex = i;
                    break;
                }

            }
        }

        private void InitDeptComboBox()
        {
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    string sql = "SELECT did , dname FROM dbo.Department ORDER BY did";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);                               //将资料填入DataSet的Dept表
                    cbDept.DisplayMember = "dname";
                    cbDept.ValueMember = "did";
                    cbDept.DataSource = ds.Tables[0];      //显示資料在dataGridView1上
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("姓名不能为空"); tbName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPosition.Text))
            {
                MessageBox.Show("职位不能为空"); tbPosition.Focus();
                return;
            }

            string ID = tbEmpID.Text;
            string Name = tbName.Text;
            string sexName = rbMale.Checked ? "男" : "女";
            DateTime employday = this.dtpEmployday.Value;
            string position = tbPosition.Text.Trim();
            string dept_id = cbDept.SelectedValue?.ToString();

            bool edited = EditEmp(ID, Name, sexName, employday, position, dept_id);

            if (edited)
            {
                MessageBox.Show("员工信息修改成功！");
                this.empForm.RefreashEmpData(); //调用EmpForm中的公共刷新数据方法
                this.Close();
            }
            else
            {
                MessageBox.Show("员工信息修改失败！");
            }
        }

        private bool EditEmp(string ID, string Name, string sex, DateTime employday, string position, string dept_id)
        {
            bool op = false;
            string connStr = @"Data Source=.;Initial Catalog=HomeWorke;Integrated Security=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("UPDATE dbo.Employee SET Name='{1}', sex='{2}', employday=CAST( '{3}'AS Date), position='{4}', dept_id={5} WHERE ID='{0}'",
                        ID, Name, sex, employday.ToString("yyyy-MM-dd"), position, dept_id);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        op = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常: " + ex.Message);
            }
            return op;

        }

        private void tbEmpID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
