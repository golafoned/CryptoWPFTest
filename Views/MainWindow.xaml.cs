using System.Security.Cryptography.X509Certificates;
using System.Windows;
namespace CryptoTest.Views.Pages
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            MainFrame.Navigate(new MainPage());
        }
    }
}
