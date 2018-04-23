Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data

Namespace DevExpress.Example03
	Public Class GroupCheckBox
		Inherits CheckBox
		Implements IMultiValueConverter

		Public Sub New()
			MyBase.New()
			AddHandler Me.Loaded, AddressOf GroupCheckBox_Loaded
		End Sub

		Protected Sub WorkOutMouseUp()
			Me._LocalSet = True
			Dim groupLevel As Integer = (TryCast(Me.DataContext, GridGroupValueData)).RowData.GroupLevel
			Me.CheckStates(groupLevel) = Me.IsChecked

			Me.SetValue(GroupCheckBox.CheckStatesProperty, New Dictionary(Of Integer, Boolean?)(Me.CheckStates))
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Input.MouseButtonEventArgs)
			MyBase.OnMouseUp(e)
			Dispatcher.BeginInvoke(New Action(Function() AnonymousMethod1()), System.Windows.Threading.DispatcherPriority.ApplicationIdle)
		End Sub
		
		Private Function AnonymousMethod1() As Boolean
			Me.WorkOutMouseUp()
			Return True
		End Function

		Private Sub GroupCheckBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim mb As New MultiBinding()

			Dim b As New Binding("CheckStates")
			b.Source = Me
			mb.Bindings.Add(b)

			b = New Binding("GroupLevel")
			b.Source = (TryCast(Me.DataContext, GridGroupValueData)).RowData
			mb.Bindings.Add(b)

			mb.Converter = Me
			mb.Mode = BindingMode.OneWay
			Me.SetBinding(GroupCheckBox.IsCheckedProperty, mb)
		End Sub

		Protected _LocalSet As Boolean

		Public Property CheckStates() As Dictionary(Of Integer, Boolean?)
			Get
				Return CType(GetValue(CheckStatesProperty), Dictionary(Of Integer, Boolean?))
			End Get
			Set(ByVal value As Dictionary(Of Integer, Boolean?))
				SetValue(CheckStatesProperty, value)
			End Set
		End Property

		Public Shared ReadOnly CheckStatesProperty As DependencyProperty = DependencyProperty.Register("CheckStates", GetType(Dictionary(Of Integer, Boolean?)), GetType(GroupCheckBox), New PropertyMetadata(Nothing))

		Public Function Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
			If Me._LocalSet Then
				Me._LocalSet = False
				Return Me.IsChecked
			End If

			Dim dic = CType(values(0), Dictionary(Of Integer, Boolean?))
			Dim level = CInt(Fix(values(1)))

			If (Not dic.Keys.Contains(level)) Then
				Return False
			End If

			Return dic(level)
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace
