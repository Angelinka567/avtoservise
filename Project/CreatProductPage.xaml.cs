using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для CreatProductPage.xaml
    /// </summary>
    public partial class CreatProductPage : Page
    {
        private Product _currentProduct = new Product();

        public CreatProductPage(Product selectedProduct)
        {
            InitializeComponent();

            if(selectedProduct != null)
                _currentProduct = selectedProduct;

            DataContext = _currentProduct;
            cb.ItemsSource = AvtoServisEntities.GetContext().Manufacturers.ToList();

        }

        private void SaveProduct(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentProduct.Title))
            {
                errors.AppendLine("Не указано название товара.");
            }
            if (string.IsNullOrWhiteSpace(_currentProduct.Cost))
            {
                errors.AppendLine("Не указана стоимость товара.");
            }
            if (string.IsNullOrWhiteSpace(_currentProduct.Description))
            {
                errors.AppendLine("Не указано описание товара.");
            }
            if (string.IsNullOrWhiteSpace(_currentProduct.MainImagePath))
            {
                errors.AppendLine("Не указан путь к изображению.");
            }
            if (_currentProduct.Manufacturer == null)
            {
                errors.AppendLine("Не указан производитель товара.");
            }


            if (errors.Length > 0)
            {
                System.Windows.MessageBox.Show(errors.ToString());
                return;
            }
            
            if (_currentProduct.ID == 0)
            {
                AvtoServisEntities.GetContext().Products.Add(_currentProduct);
            }

            try
            {

                 AvtoServisEntities.GetContext().SaveChanges();
                 System.Windows.MessageBox.Show("Информация сохранена");
                 Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString());
            }
        }

       
    }
}
