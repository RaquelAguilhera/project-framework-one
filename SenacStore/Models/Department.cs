namespace SenacStore.Models
{
    public class Department
    {
        public int Id { get; set; }     
        public string Name { get; set; }

        public List<Seller> Sellers { get; set; } 
            = new List<Seller>();

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(inicial,final));

        }
    }
}
