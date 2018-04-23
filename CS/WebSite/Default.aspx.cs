using System;
using System.Data;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    protected void ASPxGridView1_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e) {
        if (e.VisibleIndex == -1) return;

        switch (e.ButtonType) {
            case ColumnCommandButtonType.Edit:
                e.Visible = EditButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);
                break;
            case ColumnCommandButtonType.Delete:
                e.Visible = DeleteButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);
                break;
        }
    }
    protected void ASPxGridView1_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e) {
        if (e.VisibleIndex == -1) return;

        if (e.ButtonID == "btnCustom" && e.VisibleIndex % 2 != 0)
            e.Visible = DefaultBoolean.False;
    }
    protected void AccessDataSource1_Modifying(object sender, SqlDataSourceCommandEventArgs e) {
        throw new InvalidOperationException("Data modifications are not allowed in online examples");
    }
    private bool EditButtonVisibleCriteria(ASPxGridView grid, int visibleIndex) {
        object row = grid.GetRow(visibleIndex);
        return ((DataRowView)row)["ProductName"].ToString().Contains("a");
    }
    private bool DeleteButtonVisibleCriteria(ASPxGridView grid, int visibleIndex) {
        object row = grid.GetRow(visibleIndex);
        return ((DataRowView)row)["ProductName"].ToString().Contains("b");
    }
}