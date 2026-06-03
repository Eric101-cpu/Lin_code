<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="主页面.aspx.cs" Inherits="主页面" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="App_Themes/前台样式/MainStyleSheet.css" type="text/css" />
    <div class="book-container">
        <br />
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="0" CellSpacing="0" CssClass="book-grid">
            <ItemTemplate>
                <div class="book-card">
                    <asp:ImageButton ID="ImageButton1" CssClass="book-image" runat="server" ImageUrl='<%# "Photo/"+Eval("Photo") %>'
                         PostBackUrl='<%# "图书详细信息.aspx?BookId="+Eval("BookId") %>' />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "图书详细信息.aspx?BookId="+Eval("BookId") %>'
                         Text='<%# Eval("Title") %>' CssClass="book-name"></asp:HyperLink>
                    <div>
                        <asp:Label ID="lbAuthor" CssClass="author-label" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
                    </div>
                     <div>
                        <asp:Label ID="LbPrice" CssClass="book-price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>

