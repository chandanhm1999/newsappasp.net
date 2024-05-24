<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="chandIT.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">Title</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Details</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtDet" runat="server" Height="115px" TextMode="MultiLine" Width="259px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Photo</td>
                    <td class="auto-style2">
                        <input id="File1" type="file" runat="server"/></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Article" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</asp:Content>
