﻿namespace Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
   
}