using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }
        
        private void BtnListProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NewPage());
        }

        private void BtnCreatProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ListProductPage());
        }

        private void BtnHistoryProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HistoryPage(null));
        }
    }
}
