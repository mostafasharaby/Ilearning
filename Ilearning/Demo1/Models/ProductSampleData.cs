namespace Demo1.Models
{
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData()
        {
             products  = new List<Product>();
            products?.Add(new Product { Id= 1 , Name = "iphone1", Description = "phones1" , Price = 100000, Image = "wallpaperflare.com_wallpaper (15).jpg"});
            products?.Add(new Product { Id = 2, Name = "iphone2", Description = "mobile2", Price = 90000, Image = "wallpaperflare.com_wallpaper (8).jpg" }); 
            products?.Add(new Product { Id = 3, Name = "iphone3", Description = "mobile3", Price = 70000, Image = "wallpaperflare.com_wallpaper (8).jpg" });

        }
        public  List<Product> Getall()
        {
            return products;
        }
        public Product GetbyId(int id)
        {
            return products.FirstOrDefault(i=>i.Id == id);
        }
    }
}
