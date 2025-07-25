using System;

class Program {
    static void Main(string[] args) {
        List<Order> orders = new List<Order>{
            new Order(
                new List<Product>{
                    new Product("Wireless Mouse", 1001, 25.99f, 2),
                    new Product("Mechanical Keyboard", 2045, 89.50f, 1),
                    new Product("USB-C Hub", 3300, 45.00f, 1)
                },
                new Customer(
                    "Alice Johnson",
                    new Address("123 Maple St.", "Seattle", "WA", "United States")
                )
            ),
            new Order(
                new List<Product>{
                    new Product("Bluetooth Speaker", 5022, 55.75f, 1),
                    new Product("Noise-Cancelling Headphones", 7788, 120.00f, 1),
                    new Product("Portable Charger", 4400, 35.20f, 3)
                },
                new Customer(
                    "Carlos Méndez",
                    new Address("Avenida Reforma 123", "Ciudad de México", "CDMX", "Mexico")
                )
            )
        };

        foreach(Order order in orders) {
            Console.WriteLine($"\nPacking Label:\n\n{order.GetPackingLabel()}\n");
            Console.WriteLine($"Shipping Label:\n\n{order.GetShippingLabel()}\n");
            Console.WriteLine($"Total: {order.CalculateTotal()}\n");
        }
    }
}