using System.Data;
using InventoryManager.Models;
using InventoryManager.Services;

namespace InventoryManager.Views;

public partial class ProductsPage : ContentPage
{
    public static List<Product> products { get; set; }
    public static List<Category> categories { get; set; }
    public string categoryName;
    public ProductsPage()
    {
        InitializeComponent();
        string user = Preferences.Get("User", "Welcome");
        Header.Text = "Welcome, " + user;

        run();

    }

    async void run()
    {
        products = await ProductService.GetProducts();
        categories = await CategoryService.GetCategories();
        List<string> categoryNames = new List<string>();
        for( var i =0; i < categories.Count(); i++)
        {
            categoryNames.Add(categories[i].name);

        }
        ProductsView.ItemsSource = products;
        Picker.ItemsSource = categoryNames;
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            categoryName = (string)picker.ItemsSource[selectedIndex];
        }
    }

    async void addCategory(object sender, EventArgs args)
    {
        string name = CategoryName.Text;
      
        if (string.IsNullOrEmpty(name))
        {
            await DisplayAlert("Alert", "Enter Category Name", "OK");
            return;
        }

        Category category = await CategoryService.GetCategoryByName(name);


        if(category != null)
        {
            await DisplayAlert("Alert", "Category Already Exist", "OK");
            return;
        }

        int res = await CategoryService.AddCategory(new Category() { name = name });

        if(res == 1)
        {
            await DisplayAlert("Alert", "Category Added Successfully", "OK");
            run();
            return;

        }
        else
        {
            await DisplayAlert("Alert", "Failed to add category", "OK");

        }

    }

 async  void addProduct(object sender, EventArgs args)
    {
        string name = ProductName.Text;
        int quantity = Convert.ToInt32(ProductQuantity.Text);
        double price = Convert.ToDouble(ProductPrice.Text);
        int categoryId;

        if (string.IsNullOrEmpty(name))
        {
            await DisplayAlert("Alert", "Enter Product Name", "OK");
            return;
        }

        if (string.IsNullOrEmpty(ProductQuantity.Text))
        {
            await DisplayAlert("Alert", "Enter Product Quantity", "OK");
            return;
        }

        if (string.IsNullOrEmpty(ProductPrice.Text))
        {
            await DisplayAlert("Alert", "Enter Product Price", "OK");
            return;
        }

        if (string.IsNullOrEmpty(categoryName))
        {
            await DisplayAlert("Alert", "Enter Product Category", "OK");
            return;
        }

        Product product = await ProductService.GetProductByName(name);

        if(product != null)
        {
            await DisplayAlert("Alert", "Product Already Exist", "OK");
            return;
        }
        Category category = await CategoryService.GetCategoryByName(categoryName);

        if(category == null)
        {
            await DisplayAlert("Alert", "Category not found", "OK");
            return;
        }

        categoryId = category.id;

        int res = await ProductService.AddProduct(new Product() { categoryId = categoryId, name = name, price = price, quantity = quantity });


        if (res == 1)
        {
            await DisplayAlert("Alert", "Product Added Successfully", "OK");
            run();
            return;

        }
        else
        {
            await DisplayAlert("Alert", "Failed to add product", "OK");

        }


    }

}
