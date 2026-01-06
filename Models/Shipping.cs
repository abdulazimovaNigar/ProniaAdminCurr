using Pronia.Models.Common;

namespace Pronia.Models;

public class Shipping : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }
}