using System.Windows;
using Cennik.ViewModel;

namespace Cennik.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow Mainwindow { get; set; }

        public Window1(MainWindow mainWindow)
        {
            Mainwindow = mainWindow;
            InitializeComponent();
            this.DataContext = new ViewModelWindow1(this, Mainwindow);
        }
    }
}
