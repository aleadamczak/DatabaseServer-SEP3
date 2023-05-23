using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public class PrivateFileUser
{
    
    public int HaveAccessId { get; set; }
    public int SharedWithMeId { get; set; }
}