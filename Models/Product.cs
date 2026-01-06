using Microsoft.EntityFrameworkCore;
using Pronia.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia.Models;

public class Product : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    [Precision(18,2)]
    public decimal Price { get; set; }

    [Required]
    public string MainImagePath { get; set; }

    [Required]
    public string HoverImagePath { get; set; }

    [Required]
    [Precision(2, 1)]
    public decimal Rating { get; set; }

    public string? SKU { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
