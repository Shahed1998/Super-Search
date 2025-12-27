using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
       public int Id { get; set; } 
	   public string? Name { get; set; }
    }
}
