namespace Demo1.Models
{
    public class Customer_oders
    {

        List<Customer> Orders;
        public Customer_oders()
        {
            Orders = new List<Customer>();
            Orders.Add(new Customer { Id = 1, Email = "Mos@gamil", Name = "Mostafa", OrderId = 1, Phone ="0120" , Image ="IMG_0060.JPG"}) ;
            Orders.Add(new Customer { Id = 2, Email = "Ali@gamil", Name = "Ali", OrderId = 2, Phone = "0120", Image = "IMG_0063.JPG" });
            Orders.Add(new Customer { Id = 3, Email = "Mo@gamil", Name = "Shady", OrderId = 3, Phone = "0120", Image = "IMG_0065.JPG" });
        }
        public Customer GetCustomer(int id)
        {
            var customer = Orders.FirstOrDefault(o => o.Id == id);
            return customer;
        }
        public List<Customer> GetAllCustomer()
        {
          return Orders;
        }
    }
}
