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
using System.Windows.Shapes;

namespace Lagerverwaltungssystem3
{
    /// <summary>
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        Order order;
        DataLogic dataLogic;
        public NewOrder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creates a NewOrder window.
        /// Takes dataLogic as an argument so it doesnt initiate it twice.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="dataLogic"></param>
        public NewOrder(Order order, DataLogic dataLogic)
        {
            InitializeComponent();
            this.order = order;
            this.dataLogic = dataLogic;
            dgItems.ItemsSource = dataLogic.GetItems();
            lblOrderID.Content = order.OrderID;
        }
        /// <summary>
        /// Adds Orderposition to Order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Orderposition orderposition = new Orderposition();
            orderposition.Order = order;
            orderposition.Item = (Item)dgItems.SelectedItem;
            orderposition.Quantity = Convert.ToInt32(txtBoxQuantity.Text);

            dataLogic.AddOrderposition(orderposition);
            dgOrderposition.ItemsSource = dataLogic.GetOrderpositions(order);
        }

        /// <summary>
        /// Closes Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
