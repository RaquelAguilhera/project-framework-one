using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SenacStore.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [MinLength(1), MaxLength(35)]
        public string Name { get; set; }
        [EmailAddress]
        [MinLength(6, ErrorMessage = "email invalido"), MaxLength(30, ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Display(Name="BIRTH DATE")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayFormat(DataFormatString ="{0:#,##0.00}")]
        public double Slary { get; set; }
        [Display(Name = "Departament Name")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<SalesRecord> Sales { get; set; }
            = new List<SalesRecord>();


        public double TotalSales (DateTime inicial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= inicial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}
