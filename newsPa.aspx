<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="newsPa.aspx.cs" Inherits="chandIT.newsPa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="art" runat="server">

    </div>
    <hr />
    <div id="comments" runat="server">
    </div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 176px">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="274px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 176px; height: 86px">Comment</td>
                <td style="height: 86px">
                    <asp:TextBox ID="txtComment" runat="server" Height="80px" Width="276px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 176px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Button" />
                </td>
            </tr>
        </table>
    
</asp:Content>
