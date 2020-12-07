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
    /// Логика взаимодействия для NewPage.xaml
    /// </summary>
    public partial class NewPage : Page
    {
        public NewPage()
        {
            InitializeComponent();


            var allManufact = AvtoServisEntities.GetContext().Manufacturers.ToList();
            allManufact.Insert(0, new Manufacturer
            {
                Name = "Все производители"
            });
            Manufact.ItemsSource = allManufact;
            Manufact.SelectedIndex = 0;
            actual.IsChecked = true;



            var currentProduct = AvtoServisEntities.GetContext().Products.ToList();
            LViewProduct.ItemsSource = currentProduct;
            UpdateProduct();

        }
        private void  UpdateProduct()
        {
            var currentProduct = AvtoServisEntities.GetContext().Products.ToList();
            if (Manufact.SelectedIndex > 0)
                currentProduct = currentProduct.Where(p=>p.Manufacturer.Equals(Manufact.SelectedItem as Manufacturer)).ToList();
            
            currentProduct = currentProduct.Where(p => p.Title.ToLower().Contains(NameProductSearch.Text.ToLower())).ToList();

            if (actual.IsChecked.Value)
                currentProduct = currentProduct.Where(p => p.IsActive).ToList();
            
           LViewProduct.ItemsSource = currentProduct.OrderBy(p => p.Cost).ToList();
        }

        private void ChangedSearch(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboMan(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ManUnChecked(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void ManChecked(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void HistoryProduct(object sender, MouseButtonEventArgs e)
        {
        }
        

        private void HistoryProduct2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HistoryPage((sender as Button).DataContext as Product));
        }
    }
}
