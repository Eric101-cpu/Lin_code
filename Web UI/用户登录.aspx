<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="用户登录.aspx.cs" Inherits="用户登录" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" href="App_Themes/前台样式/UserLoginStyleSheet.css" type="text/css" />
    <div class="login-container">
        <div class="login-title">用户登录
            <br />
            <asp:Label ID="lbInfo" CssClass="login-info" runat="server" Text=""></asp:Label>
        </div>
            <span class="form-label">用户账号：</span>
            <asp:TextBox ID="txtID" CssClass="login-input" runat="server"></asp:TextBox>
            <span class="form-label">密码：</span>
            <asp:TextBox ID="txtPwd" CssClass="login-input" TextMode="Password" runat="server"></asp:TextBox>
         <div style="text-align:center;">
             <asp:Button ID="btnReg" runat="server" Text="注册"  CssClass="login-btn"/>
             <asp:Button ID="btnLogin" runat="server" Text="登录"  CssClass="login-btn" OnClick="btnLogin_Click" />
         </div>
    </div>
</asp:Content>

