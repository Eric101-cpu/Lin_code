<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="图书详细信息.aspx.cs" Inherits="图书详细信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" href="App_Themes/前台样式/BookDetailStyleSheeet.css" type="text/css" />
    <div class="detail-box">
    <table class="auto-style1">
        <tr>
            <td rowspan="8" style="width:300px;">
                <asp:Image ID="imgPhoto" CssClass="detail-img" runat="server" />
            </td>
        </tr>
        <tr>
            <td>书号：</td>
            <td>
                <asp:Label ID="lbBookID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>书名：</td>
            <td>
                <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>作者：</td>
            <td>
                <asp:Label ID="lbAuthor" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>出版社：</td>
            <td>
                <asp:Label ID="lbPress" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>定价：</td>
            <td>
                <asp:Label ID="lbPrice" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>库存：</td>
            <td>
                <asp:Label ID="lbStock" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>销售量：</td>
            <td>
                <asp:Label ID="lbSaleCounts" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
        <h3>内容简介</h3>
        <p> <asp:Label ID="lbAbstractions" runat="server" Text="Label"></asp:Label></p>

        <h3>购买数量</h3>
        <div class="button-container">
            <asp:Button ID="btnSub" runat="server" Text="-"  CssClass="count-btn" OnClick="btnSub_Click" />
            <asp:TextBox ID="txtCounts" runat="server" CssClass="count-input" Text="1" Enabled="false"></asp:TextBox>
             <asp:Button ID="btnAdd" runat="server" Text="+"  CssClass="count-btn" OnClick="btnAdd_Click"/>
        </div>
        <br />
        <div class="button-container">
            <asp:Button ID="btnShop" runat="server" Text="加购物车"  CssClass="btn-buy" OnClick="btnShop_Click"/>
            <asp:Button ID="btnBuy" runat="server" Text="立即购买"   CssClass="btn-buy" OnClick="btnBuy_Click"/>
            <asp:Button ID="btnViewComments" runat="server" Text="查看评论"  CssClass="btn-buy" OnClick="btnViewComments_Click" />
        </div>
   </div>


</asp:Content>

