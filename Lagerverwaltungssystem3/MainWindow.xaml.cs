using Lagerverwaltungssystem3.Logic;
using Lagerverwaltungssystem3.Model;
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

namespace Lagerverwaltungssystem3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public MainWindow()
        {
            InitializeComponent();
            dgOrder.ItemsSource = dataLogic.GetOrders();
            dgItems.ItemsSource = dataLogic.GetItems();
            cmbBoxEntryExit.ItemsSource = dataLogic.GetEntryExits();
        }

        private void dgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgOrderposition.ItemsSource = dataLogic.GetOrderpositions((Order)dgOrder.SelectedItem);
        }

        /// <summary>
        /// Creates Order and Opens NewOrder window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.EntryExit = (EntryExit)cmbBoxEntryExit.SelectedItem;
            order.Orderdate = DateTime.Now;
            dataLogic.AddOrder(order);
            NewOrder newOrder = new NewOrder(order, dataLogic);
            newOrder.ShowDialog();
        }

        /// <summary>
        /// Opens NewOrder window and passes selected item of datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewOrder newOrder = new NewOrder((Order)dgOrder.SelectedItem, dataLogic);
            newOrder.ShowDialog();
        }
    }
}