<!-- default file list -->
*Files to look at*:

* [CheckableGroupBehavior.cs](./CS/DevExpress.Example03/CheckableGroupBehavior.cs) (VB: [CheckableGroupBehavior.vb](./VB/DevExpress.Example03/CheckableGroupBehavior.vb))
* [DataHelper.cs](./CS/DevExpress.Example03/DataHelper.cs) (VB: [DataHelper.vb](./VB/DevExpress.Example03/DataHelper.vb))
* [Employee.cs](./CS/DevExpress.Example03/Employee.cs) (VB: [Employee.vb](./VB/DevExpress.Example03/Employee.vb))
* [GroupCheckBox.cs](./CS/DevExpress.Example03/GroupCheckBox.cs) (VB: [GroupCheckBox.vb](./VB/DevExpress.Example03/GroupCheckBox.vb))
* **[MainWindow.xaml](./CS/DevExpress.Example03/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/DevExpress.Example03/MainWindow.xaml.vb))**
* [MainWindow.xaml.cs](./CS/DevExpress.Example03/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DevExpress.Example03/MainWindow.xaml.vb))
<!-- default file list end -->
# How to create Checkable Grouping in GridControl

### Starting with v18.2, this functionality is supported in GridControl out of the box. Use TableView's [GroupRowCheckBoxFieldName](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.GroupRowCheckBoxFieldName?v=18.2) property to show corresponding CheckBoxes in group rows.

<p>The example demonstrates how to add the CheckBox functionality to each GroupRow in TableView in versions prior to v18.2. The basic idea is to allow a user to easily check or uncheck the necessary group of items in GridControl.</p>
<p>The functionality is realized as behavior in the CheckableGroupBehavior class, which can be attached to GridControl. It automatically sets GroupValueTemplate using the GroupCheckBox class, which is inherited from the CheckBox class. The CheckableGroupBehavior's CheckableProperty must be set and has to contain the name of the property in a row data object, which will be used to check items. The property has to be of the Boolean type.</p>
<p>You can easily add the same functionality to your project by using the CheckableGroupBehavior class and attaching it as behavior to your GridControl.</p>

<br/>


