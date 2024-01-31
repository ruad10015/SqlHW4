using Lesson4SQL.Model;
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

namespace Lesson4SQL
{
    public partial class MainWindow : Window
    {

        private DataClassespProductAndOrderDataContext context;
        public MainWindow()
        {
            InitializeComponent();
            context=new DataClassespProductAndOrderDataContext();
        }

        private void ShowProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = from p in context.Products
                          select p;

            myDataGrid.ItemsSource = product;
        }

        private void ShowOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = from o in context.Orders
                          select o;

            myDataGrid.ItemsSource = order;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product
            {
                ProductID=555,
                ProductName="Sprite",
                SupplierID=500,
                CategoryID=1000,
                QuantityPerUnit="5 - 50 Sugar",
                UnitPrice=100,
                UnitsInStock=2000,
                UnitsOnOrder=50,
                ReorderLevel=100,
                Discontinued=true,
            };

            try
            {
                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var productUpdate = context.Products.FirstOrDefault(p => p.ProductID == 555);
            productUpdate.ProductName = "CocaCola";
            productUpdate.UnitPrice = 150;
            context.SubmitChanges();
        }
    }
}
