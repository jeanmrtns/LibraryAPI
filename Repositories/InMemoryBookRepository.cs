using LibraryAPI.Entities;

namespace LibraryAPI.Repositories;

public static class InMemoryBookRepository
{
    public static List<Book> books = new List<Book>();
}
