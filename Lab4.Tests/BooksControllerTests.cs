using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Lab4.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public void GetAllBooks_ReturnsListOfBooks()
        {
            // Arrange
            var catalog = Substitute.For<Catalog>(Substitute.For<Lab4Context>());
            var controller = new BooksController(catalog);

            var expectedBooks = new List<Book>
            {
                new Book { Title = "Гордость и предубеждение",
                           Author = "Джейн Остен",
                           Genres = "драма, мелодрама, историческое",
                           PublicationDate = new DateTime(),
                           Annotation = "Одно из самых известных произведений английской писательницы",
                           ISBN= "02930284938437",
                          },
                new Book { Title = "Параллельные миры",
                           Author = "Нелли Юки",
                           Genres = "драма, фантастика",
                           PublicationDate = new DateTime(),
                           Annotation = "Смотрят на обложку и верят ей.",
                           ISBN= "923782873829739",
                          },
            };

            catalog.GetAllBooks().Returns(expectedBooks);

            // Act
            var result = controller.GetAllBooks();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);

            Assert.Equal(expectedBooks, actualBooks);
        }

        [Fact]
        public void GetBooksByTitle_ReturnsBooksByTitle()
        {
            // Arrange
            var catalog = Substitute.For<Catalog>(Substitute.For<Lab4Context>());
            var controller = new BooksController(catalog);

            var expectedBooks = new List<Book>
            {
                new Book { Title = "C# Programming" },
                new Book { Title = "ASP.NET Core" }
            };

            catalog.SearchByTitle("C#").Returns(expectedBooks);

            // Act
            var result = controller.GetBooksByTitle("C#");

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);

            Assert.Equal(expectedBooks, actualBooks);
        }

    }
}
