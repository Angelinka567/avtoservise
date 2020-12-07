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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private Product _currentProduct = new Product();

        public HistoryPage(Product selectedProduct)
        {
            InitializeComponent();

            
            var allProduct = AvtoServisEntities.GetContext().Products.ToList();
            allProduct.Insert(0, new Product
            {
                Title = "Все товары"
            });
            ComboBoxTovar.ItemsSource = allProduct;
           

            if (selectedProduct != null)
            {
                ComboBoxTovar.Text = selectedProduct.Title;
                _currentProduct = selectedProduct;
            }
            else
                ComboBoxTovar.SelectedIndex = 0;


            DataContext = _currentProduct;
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            var currentProductSale = AvtoServisEntities.GetContext().ProductSales.ToList();
            if (ComboBoxTovar.SelectedIndex > 0)
                currentProductSale = currentProductSale.Where(p => p.Product.Equals(ComboBoxTovar.SelectedItem as Product)).ToList();
                
            LViewProduct.ItemsSource = currentProductSale.OrderBy(p => p.SaleDate).ToList();
        }



        private void ComboBoxChangeProduct(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
