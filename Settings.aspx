<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="chandIT.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add User" Height="52px" Width="152px" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Article" Height="52px" Width="151px" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Edit Article" Height="52px" Width="157px" />
        </div>
    </form>
</body>
</asp:Content>
