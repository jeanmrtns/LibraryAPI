using LibraryAPI.Enums;

namespace LibraryAPI.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
