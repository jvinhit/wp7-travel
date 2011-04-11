using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Model.Provider
{
    public interface IProvider
    {
        void Login(string userName, string password);
        void Logout();

        //ObservableCollection<CustomerModel> GetCustomers(string sortExpression);
        //CustomerModel GetCustomer(int customerId);

        //int AddCustomer(CustomerModel customer);
        //int UpdateCustomer(CustomerModel customer);
        //int DeleteCustomer(int customerId);

        //ObservableCollection<OrderModel> GetOrders(int customerId);
    }
}
