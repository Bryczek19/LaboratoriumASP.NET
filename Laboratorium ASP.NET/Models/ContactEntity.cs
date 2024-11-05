using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorium_ASP.NET.Models;
[Table(name:"contacts")]
public class ContactEntity
{

    public int Id { get; set; }
     [Required]
     [MaxLength(length:20)]

    public string FirstName { get; set; }
    [Required]
    [MaxLength(length:20)]

    public string LastName { get; set; }
    [Required]
    [MaxLength(length:50)]
  
    public string Email { get; set; }
    [MaxLength(12)]
    [MinLength(9)]
  
    public string PhoneNumber { get; set; }
    
    
    public DateTime BirthDate { get; set; }
 
    public  Category Category { get; set; }
}