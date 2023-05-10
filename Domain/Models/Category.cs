namespace Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
public class Category
{
    [Key]
    public string Name { get; set; }
    public int? Id { get; set; }
}