namespace NLayer.Core.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProuctId { get; set; }
        public Product Product { get; set; }

    }
}
