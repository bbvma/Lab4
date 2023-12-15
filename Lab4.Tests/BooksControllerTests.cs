using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Lab4.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public void PostGetAllBooks_Test()
        {
            // Arrange
            Lab4Context context = new Lab4Context();
            context.Database.EnsureCreated();
            context.SaveChanges();
            var catalog = new Catalog(context);
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
            //Act
            controller.AddBook(expectedBooks[0]);
            controller.AddBook(expectedBooks[1]);
            var result = controller.GetAllBooks();
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);

            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void GetBooksByTitle_Test()
        {
            // Arrange
            Lab4Context context = new Lab4Context();
            context.Database.EnsureCreated();
            context.SaveChanges();
            var catalog = new Catalog(context);
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
            //Act
            controller.AddBook(expectedBooks[0]);
            controller.AddBook(expectedBooks[1]);
            var result = controller.GetBooksByTitle("Параллельные миры");
            expectedBooks.Remove(expectedBooks[0]);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);


            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void GetBooksByAuthor_Test()
        {
            // Arrange
            Lab4Context context = new Lab4Context();
            context.Database.EnsureCreated();
            context.SaveChanges();
            var catalog = new Catalog(context);
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
            //Act
            controller.AddBook(expectedBooks[0]);
            controller.AddBook(expectedBooks[1]);
            var result = controller.GetBooksByAuthor("Джейн");
            expectedBooks.Remove(expectedBooks[1]);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);

            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void GetBooksByISBN_Test()
        {
            // Arrange
            Lab4Context context = new Lab4Context();
            context.Database.EnsureCreated();
            context.SaveChanges();
            var catalog = new Catalog(context);
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
            //Act
            controller.AddBook(expectedBooks[0]);
            controller.AddBook(expectedBooks[1]);
            var result = controller.GetBookByISBN("02930284938437");
            Book expectedBook = expectedBooks[0];
            //Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBook = Assert.IsType<Book>(okResult.Value);

            Assert.True(BookEqual(expectedBook, actualBook));
        }
        [Fact]
        public void GetBooksByKeywords_Test()
        {
            // Arrange
            Lab4Context context = new Lab4Context();
            context.Database.EnsureCreated();
            context.SaveChanges();
            var catalog = new Catalog(context);
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
            //Act
            controller.AddBook(expectedBooks[0]);
            controller.AddBook(expectedBooks[1]);
            List<string> list = new List<string>();
            list.Add("верят");
            list.Add("Гордость");
            var result = controller.GetBooksByKeywords(list);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualBooks = Assert.IsType<List<Book>>(okResult.Value);

            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }

        public bool BooksEqual(List<Book> b1, List<Book> b2)
        {
            if (b1.Count() != b2.Count())
            {
                return false;
            }
            var flag = true;
            for (int i = 0; i < b1.Count(); i++)
            {
                if (!BookEqual(b1[i], b2[i]))
                {
                    flag = false;
                }
            }
            return flag;
        }
        private bool BookEqual(Book b1, Book b2)
        {
            if(b1.Title == b2.Title && b1.Author == b2.Author && b1.Genres == b2.Genres && b1.PublicationDate == b2.PublicationDate && b1.ISBN == b2.ISBN && b1.Annotation == b2.Annotation)
            {
                return true;
            }
            return false;
        }

    }
}
