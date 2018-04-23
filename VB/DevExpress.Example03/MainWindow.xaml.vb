Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace DevExpress.Example03

	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Me.DataContext = Me
		End Sub

		Protected _Employees As ObservableCollection(Of Employee)

		Public ReadOnly Property Employees() As ObservableCollection(Of Employee)
			Get
				If Me._Employees Is Nothing Then
					Me._Employees = New ObservableCollection(Of Employee)(DataHelper.GenerateEmployees(200))
				End If

				Return Me._Employees
			End Get
		End Property

		Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			For Each item In DataHelper.GenerateEmployees(100)
				Me.Employees.Add(item)
			Next item

		End Sub

		Private Sub Button_Click_2(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.Employees.Clear()
		End Sub

	End Class
End Namespace
