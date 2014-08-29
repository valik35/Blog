<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<%@ Reference Control="Client_User_Controls/PostUserControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <body style="background-color: #3498db; color: #ecf0f1; font-size: 1.4em; font-family: Lato, 'Helvetica Neue', Arial, sans-serif; margin: 0 0 0 0;">
        <form id="form1" runat="server">
            <div style="width: 50%; margin: auto">
                <asp:PlaceHolder runat="server" ID="PostsPH"></asp:PlaceHolder>
            </div>
        </form>
    </body>
</asp:Content>
