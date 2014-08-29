<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostPreviewUserControl.ascx.cs" Inherits="PostPreviewUserControl" %>

<a href="Post.aspx?Post=<%: Id %>" style="text-decoration: none">
    <div style="width: 100%; background-color: #85c1e9; color: #ecf0f1">
        <div style="font-size: 2.4em; margin: 0px 10px 10px 10px">
            <asp:Label ID="PostDate" runat="server"></asp:Label>
        </div>
        <div style="font-size: 2.6em; margin: 10px">
            <asp:Label ID="PostName" runat="server"></asp:Label>
        </div>
        <div id="post_text" style="font-size: 1.4em; margin: 10px">
            <asp:PlaceHolder runat="server" ID="contentPHText"></asp:PlaceHolder>
        </div>
    </div>
</a>
a