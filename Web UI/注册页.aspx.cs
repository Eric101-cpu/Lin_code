using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Business;

public partial class 注册页 : System.Web.UI.Page
{
    UserEntity user;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        user = new UserEntity();
        user.UserName=txtUserName.Text.Trim();
        user.Pwd=txtPwd.Text.Trim();
        user.LoginTime=DateTime.Now;
        user.LastLoginTime=DateTime.Now;
        user.LoginCounts = 0;
        user.ErrorCounts=0;
        user.IsLocked=false;
        if (UserBusiness.InsertUserInfo(user))
        {
            //TODO： Session["userid"] = 最新注册的Userid;
            Response.Write("<script>alert('注册成功');</script>");
        }

    }
}