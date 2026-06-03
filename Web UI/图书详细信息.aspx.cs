using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity;
using Business;

public partial class 图书详细信息 : System.Web.UI.Page
{
    BookEntity book;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["BookId"] != null)
        {
            string bookId = Request["BookId"].ToString();
            book = BookBusiness.GetBookById(bookId);
            if (book == null)
            {
                Response.Write("<script>alert('未找到图书！');location.href='主页面.aspx';</script>");
                return;
            }
            lbAuthor.Text = book.Author;
            lbBookID.Text = book.BookId;
            lbPress.Text = book.Press;
            lbPrice.Text = book.Price.ToString();
            lbSaleCounts.Text = book.SaleCounts.ToString();
            lbStock.Text = book.Stock.ToString();
            lbTitle.Text = book.Title;
            imgPhoto.ImageUrl = "Photo/" + book.Photo;
            lbAbstractions.Text=book.Descriptions.ToString();
        }
        else
        {
            Response.Write("<script>alert('未选择图书！');location.href='主页面.aspx';</script>");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int num=int.Parse(txtCounts.Text);
        txtCounts.Text = (++num).ToString();
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        int num = int.Parse(txtCounts.Text);
        if(num>1)
             txtCounts.Text = (--num).ToString();
    }

    protected void btnShop_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Write("<script>alert('请先登录！');location.href='用户登录.aspx';</script>");
        }
        else
        {
            //TODO:将图书加入购物车表
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Write("<script>alert('请先登录！');location.href='用户登录.aspx';</script>");
        }
        else
        {
            //TODO:将图书加入订单表
        }
    }

    protected void btnViewComments_Click(object sender, EventArgs e)
    {
        //TODO:跳转到评论页面（传参bookId）
    }
}