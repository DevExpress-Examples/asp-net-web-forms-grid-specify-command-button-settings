Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub ASPxGridView1_CommandButtonInitialize(ByVal sender As Object, ByVal e As ASPxGridViewCommandButtonEventArgs)
		If e.VisibleIndex = -1 Then
			Return
		End If

		Select Case e.ButtonType
			Case ColumnCommandButtonType.Edit
				e.Visible = EditButtonVisibleCriteria(CType(sender, ASPxGridView), e.VisibleIndex)
			Case ColumnCommandButtonType.Delete
				e.Visible = DeleteButtonVisibleCriteria(CType(sender, ASPxGridView), e.VisibleIndex)
		End Select
	End Sub
	Protected Sub ASPxGridView1_CustomButtonInitialize(ByVal sender As Object, ByVal e As ASPxGridViewCustomButtonEventArgs)
		If e.VisibleIndex = -1 Then
			Return
		End If

		If e.ButtonID = "btnCustom" AndAlso e.VisibleIndex Mod 2 <> 0 Then
			e.Visible = DefaultBoolean.False
		End If
	End Sub
	Protected Sub AccessDataSource1_Modifying(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
		Throw New InvalidOperationException("Data modifications are not allowed in online examples")
	End Sub
	Private Function EditButtonVisibleCriteria(ByVal grid As ASPxGridView, ByVal visibleIndex As Integer) As Boolean
		Dim row As Object = grid.GetRow(visibleIndex)
		Return (CType(row, DataRowView))("ProductName").ToString().Contains("a")
	End Function
	Private Function DeleteButtonVisibleCriteria(ByVal grid As ASPxGridView, ByVal visibleIndex As Integer) As Boolean
		Dim row As Object = grid.GetRow(visibleIndex)
		Return (CType(row, DataRowView))("ProductName").ToString().Contains("b")
	End Function
End Class