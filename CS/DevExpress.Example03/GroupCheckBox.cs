using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DevExpress.Example03 {
    public class GroupCheckBox : CheckBox , IMultiValueConverter {

        public GroupCheckBox()
            : base() {
            this.Loaded += GroupCheckBox_Loaded;
        }

        protected void WorkOutMouseUp() {
            this._LocalSet = true;
            int groupLevel = (this.DataContext as GridGroupValueData).RowData.GroupLevel;
            this.CheckStates[groupLevel] = this.IsChecked;

            this.SetValue(GroupCheckBox.CheckStatesProperty, new Dictionary<int, bool?>(this.CheckStates));
        }

        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e) {
            base.OnMouseUp(e);
            Dispatcher.BeginInvoke(new Action(() => { this.WorkOutMouseUp(); }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        void GroupCheckBox_Loaded(object sender, RoutedEventArgs e) {
            MultiBinding mb = new MultiBinding();
            
            Binding b = new Binding("CheckStates");
            b.Source = this;
            mb.Bindings.Add(b);
            
            b = new Binding("GroupLevel");
            b.Source = (this.DataContext as GridGroupValueData).RowData;
            mb.Bindings.Add(b);

            mb.Converter = this;
            mb.Mode = BindingMode.OneWay;
            this.SetBinding(GroupCheckBox.IsCheckedProperty, mb);
        }

        protected bool _LocalSet;

        public Dictionary<int, bool?> CheckStates {
            get { return (Dictionary<int, bool?>)GetValue(CheckStatesProperty); }
            set { SetValue(CheckStatesProperty, value); }
        }

        public static readonly DependencyProperty CheckStatesProperty =
            DependencyProperty.Register("CheckStates", typeof(Dictionary<int, bool?>), typeof(GroupCheckBox), new PropertyMetadata(null));

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(this._LocalSet) {
                this._LocalSet = false;
                return this.IsChecked;
            }
            
            var dic = (Dictionary<int, bool?>)values[0];
            var level = (int)values[1];
            
            if(!dic.Keys.Contains(level)) {
                return false;
            }

            return dic[level];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            return null;
        }
    }
}
