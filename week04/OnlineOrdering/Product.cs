public class Product {
    private string _name;
    private int _productId;
    private float _price;
    private int _quantity;

    public Product(string name, int id, float price, int qty) {
        _name = name;
        _productId = id;
        _price = price;
        _quantity = qty;
    }

    public string GetLabel() {
        return $"{_name} (#{_productId})";
    }

    public float GetTotalCost() {
        return _price * _quantity;
    }
}