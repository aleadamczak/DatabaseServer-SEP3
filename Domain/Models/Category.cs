namespace Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
public class Category
{
    
    public int Id { get; set; }
    
    [Key]
    public string Name { get; set; }
   
}