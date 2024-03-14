namespace LibraryAPI.Communication.Requests;

public class RequestCreateNewBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
