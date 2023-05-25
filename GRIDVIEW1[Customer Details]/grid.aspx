<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid.aspx.cs" Inherits="GRIDVIEW1_Customer_Details_.grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
            width: 140px;
        }
        .auto-style3 {
            width: 322px;
        }
        .auto-style4 {
            width: 140px;
            text-align: left;
        }
        .auto-style5 {
            width: 322px;
            text-align: left;
        }
        .auto-style6 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <u><h2>Customer Details</h2></u>
        </div>
        <div align="center">

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Eid</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtid" runat="server"  Width="220px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">EName</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtna" runat="server" Width="220px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Esalary</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtsal" runat="server" Width="220px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">
                        <br />
                        <asp:Button ID="btnsav" runat="server" Text="SAVE" CssClass="auto-style6" Height="32px" OnClick="btnsav_Click" Width="79px" />  &nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Button ID="btncan" runat="server" Text="CANCEL" Height="33px" OnClick="btncan_Click" Width="75px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
        <br/>
        <div align="center">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="eid" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="374px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="eid" HeaderText="EID" ReadOnly="True" />
                    <asp:BoundField DataField="ename" HeaderText="EName" />
                    <asp:BoundField DataField="esalary" HeaderText="ESalary" />
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
