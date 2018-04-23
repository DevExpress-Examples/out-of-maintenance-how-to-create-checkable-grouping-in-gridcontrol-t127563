using System.Collections.ObjectModel;
using System.Windows;

namespace DevExpress.Example03 {
    
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        protected ObservableCollection<Employee> _Employees;

        public ObservableCollection<Employee> Employees {
            get {
                if(this._Employees == null) {
                    this._Employees = new ObservableCollection<Employee>(DataHelper.GenerateEmployees(200));
                }

                return this._Employees;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            foreach(var item in DataHelper.GenerateEmployees(100)) {
                this.Employees.Add(item);
            }
    
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            this.Employees.Clear();
        }

    }
}
