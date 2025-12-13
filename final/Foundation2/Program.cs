using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "A123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "C789", 75.00, 1));

        Console.WriteLine("Order 1:");
        order1.DisplayPackingLabel();
        Console.WriteLine();
        order1.DisplayShippingLabel();
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "D101", 299.99, 2));
        order2.AddProduct(new Product("Webcam", "E202", 89.99, 1));

        Console.WriteLine("Order 2:");
        order2.DisplayPackingLabel();
        Console.WriteLine();
        order2.DisplayShippingLabel();
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
    }
}