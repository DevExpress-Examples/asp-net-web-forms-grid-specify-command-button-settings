<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function OnCustomButtonClick(s, e) {
            alert('keyValue = ' + s.GetRowKey(e.visibleIndex));
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1"
            KeyFieldName="ProductID" OnCommandButtonInitialize="ASPxGridView1_CommandButtonInitialize"
            OnCustomButtonInitialize="ASPxGridView1_CustomButtonInitialize">
            <ClientSideEvents CustomButtonClick="OnCustomButtonClick" />
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnCustom" Text="CustomButton">
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?" InsertCommand="INSERT INTO [Products] ([ProductName], [UnitPrice]) VALUES (?, ?)"
            UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [UnitPrice] = ? WHERE [ProductID] = ?"
            OnUpdating="AccessDataSource1_Modifying" OnDeleting="AccessDataSource1_Modifying"
            OnInserting="AccessDataSource1_Modifying">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
            </InsertParameters>
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>