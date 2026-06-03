using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;

public partial class UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            plGuest.Visible = true;
            plUser.Visible = false;
        }
        else
        {
            plGuest.Visible = false;
            plUser.Visible = true;
            string uid = Session["userid"].ToString().Trim();
            UserEntity user = UserBusiness.GetUserById(uid);
            lbtnUserName.Text = user.UserName;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("主页面.aspx");
    }
}
