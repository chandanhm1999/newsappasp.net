<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="chandIT.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="width: 134px">Username:</td>
                <td style="width: 165px"><asp:TextBox ID="txtUN" runat="server" Height="32px" Width="160px"></asp:TextBox></td>
                <td style="width: 50px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="width: 134px">Password:</td>
                <td style="width: 165px"><asp:TextBox ID="txtPW" runat="server" TextMode="Password" Height="32px" Width="160px"></asp:TextBox></td>
                <td style="width: 50px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Height="32px" Width="56px" />
                </td>
                <td style="width: 50px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 50px">&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
