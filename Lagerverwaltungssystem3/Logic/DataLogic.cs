using Lagerverwaltungssystem3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem3.Logic
{
    public class DataLogic
    {
        LagerverwaltungssystemContext lagerverwaltungssystemContext = new LagerverwaltungssystemContext();

        /// <summary>
        /// Gets orders from database
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            var orders = lagerverwaltungssystemContext.Orders
                .Include(o => o.EntryExit)
                .Include(o => o.Orderpositions)
                .ToList();
            return orders;
        }

        /// <summary>
        /// Gets orderpositions from database where order is input
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Orderposition> GetOrderpositions()
        {
            var orderpositions = lagerverwaltungssystemContext.Orderpositions
                .Include(op => op.Item)
                .Include(op => op.Order)
                .ToList();
            return orderpositions;
        }

        /// <summary>
        /// Gets orderpositions from database where order is input
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Orderposition> GetOrderpositions(Order order)
        {
            var orderpositions = lagerverwaltungssystemContext.Orderpositions
                .Include(op => op.Item)
                .Include(op => op.Order)
                .Where(op => op.Order == order)
                .ToList();
            return orderpositions;
        }

        /// <summary>
        /// Gets order where EntryExit is in
        /// </summary>
        /// <returns></returns>
        public List<Order> GetIncomingOrder()
        {
            var incoming = lagerverwaltungssystemContext.EntryExits
                .Where(i => i.Title == "IN")
                .First();

            var incomingorder = lagerverwaltungssystemContext.Orders
                .Include(io => io.EntryExit)
                .Where(io => io.EntryExit == incoming)
                .ToList();

            return incomingorder;
        }
        
        /// <summary>
        /// Gets order where EntryExit is out
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOutgoingOrder()
        {
            var outgoing = lagerverwaltungssystemContext.EntryExits
                .Where(o => o.Title == "OUT")
                .First();

            var outgoingorder = lagerverwaltungssystemContext.Orders
                .Include(oo => oo.EntryExit)
                .Where(oo => oo.EntryExit == outgoing)
                .ToList();

            return outgoingorder;
        }

        /// <summary>
        /// Gets Items from database
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems()
        {
            var items = lagerverwaltungssystemContext.Items
                .ToList();
            return items;
        }

        /// <summary>
        /// Gets EntryExits from database
        /// </summary>
        /// <returns></returns>
        public List<EntryExit> GetEntryExits()
        {
            var entryexits = lagerverwaltungssystemContext.EntryExits
                .ToList();
            return entryexits;
        }

        /// <summary>
        /// Adds order to database
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            lagerverwaltungssystemContext.Add(order);
            lagerverwaltungssystemContext.SaveChanges();
        }

        /// <summary>
        /// Adds orderposition to database
        /// </summary>
        /// <param name="orderposition"></param>
        public void AddOrderposition(Orderposition orderposition)
        {
            lagerverwaltungssystemContext.Add(orderposition);
            lagerverwaltungssystemContext.SaveChanges();
        }
    }
}
