


namespace SenacStore.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public SalesStatus status { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }
    }
   
    
        public enum SalesStatus : int
        {
            PEDING = 0,
            BILLED = 1,
            CANCELED = 2
        }
    }


