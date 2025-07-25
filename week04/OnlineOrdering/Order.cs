public class Order {
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer) {
        _products = products;
        _customer = customer;
    }

    public float CalculateTotal() {
        float sum = 0;
        foreach(Product product in _products) {
            sum += product.GetTotalCost();
        }
        return sum + (_customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel() {
        string totalLabel = "";

        bool first = true;
        foreach(Product product in _products) {
            if(first) {
                first = false;
            }
            else {
                totalLabel += "\n";
            }
            totalLabel += product.GetLabel();
        }

        return totalLabel;
    }

    public string GetShippingLabel() {
        return _customer.GetLabel();
    }
}