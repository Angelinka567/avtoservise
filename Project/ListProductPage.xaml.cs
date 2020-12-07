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
    /// Логика взаимодействия для ListProductPage.xaml
    /// </summary>
    public partial class ListProductPage : Page
    {
        public ListProductPage()
        {
            InitializeComponent();
            TableProduct.ItemsSource = AvtoServisEntities.GetContext().Products.ToList();
        }

        private void BtnProductRedactor_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CreatProductPage((sender as Button).DataContext as Product));

        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CreatProductPage(null));
        }

        private void BtnDeletProduct_Click(object sender, RoutedEventArgs e)
        {
            var DeletProduct = TableProduct.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {DeletProduct.Count()} элементов?","Внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AvtoServisEntities.GetContext().Products.RemoveRange(DeletProduct);
                    AvtoServisEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    TableProduct.ItemsSource = AvtoServisEntities.GetContext().Products.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void changeVisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AvtoServisEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                TableProduct.ItemsSource = AvtoServisEntities.GetContext().Products.ToList();
            }

        }
    }
}
