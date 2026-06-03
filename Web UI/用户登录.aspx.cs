using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity;
using System.Data;
using System.Web.Globalization;

public partial class 用户登录 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userId=txtID.Text.Trim();
        if (UserBusiness.IsExistUserID(userId))
        {
            if (!UserBusiness.IsLockedUserID(userId))
            {
                if (UserBusiness.IsRightPwd(userId, txtPwd.Text.Trim()))
                {
                    lbInfo.Text = "密码正确";
                    //TODO:更新用户登录信息
                    Session["userid"] = userId;
                    Response.Redirect("主页面.aspx");
                }
                else
                {
                    lbInfo.Text = "密码错误";
                }
            }
            else
            {
                lbInfo.Text = "账号已被锁定";
            }
        }
        else 
        {
            lbInfo.Text = "账号不存在";
        }
    }
}