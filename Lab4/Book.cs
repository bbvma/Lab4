using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genres { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Annotation { get; set; }
        [Key]
        public string ISBN { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Название книги: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Жанры: {Genres}");
            Console.WriteLine($"Дата публикации: {PublicationDate.ToShortDateString()}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine();
        }
    }
}
