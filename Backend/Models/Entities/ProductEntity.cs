namespace Backend.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string size { get; set; } = null!;
        public decimal price { get; set; }
        public string price2 { get; set; } = null!;
        //String on price2 so it can be null vet ej vrf jag skrev på eng
        public int rating { get; set; }
        public string Category { get; set; } = null!;

    }
}
