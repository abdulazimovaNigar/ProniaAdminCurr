using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaAdmin.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public string MainImagePath { get; set; }

    public string HoverImagePath { get; set; }

    [Column(TypeName = "decimal(2,1)")]
    public decimal Rating { get; set; }

    public string SKU { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
