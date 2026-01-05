namespace ProniaAdmin.Models;

public class Shipping
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}