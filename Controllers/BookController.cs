using LibraryAPI.Communication.Requests;
using LibraryAPI.Entities;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

public class BookController : LibraryApiBaseController
{
    
    [HttpGet]
    [ProducesResponseType<List<Book>>(StatusCodes.Status200OK)]
    public IActionResult GetBooks()
    {
        return Ok(InMemoryBookRepository.books);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddBook([FromBody] RequestCreateNewBookJson request)
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Author = request.Author,
            Genre = (Enums.Genre)request.Genre,
            Price = request.Price,
            Stock = request.Stock
        };

        InMemoryBookRepository.books.Add(book);

        return Created();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateBook(Guid id, [FromBody] RequestUpdateBookJson request)
    {
        var book = InMemoryBookRepository.books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = (Enums.Genre)request.Genre;
        book.Price = request.Price;
        book.Stock = request.Stock;

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook(Guid id)
    {
        var book = InMemoryBookRepository.books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        InMemoryBookRepository.books.Remove(book);

        return NoContent();
    }
}
