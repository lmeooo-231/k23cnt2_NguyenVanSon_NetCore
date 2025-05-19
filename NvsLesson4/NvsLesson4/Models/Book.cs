using Microsoft.AspNetCore.Mvc.Rendering;


namespace NvsLesson04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }


        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book() {
                    Id=1,
                    Title = "AspNetCoreMVC",
                    AuthorId = -1,
                    GenreId = 1,
                    Image = "/images/book-1.jpg",
                    price = 12000,
                    TotalPage = 100,
                    Summary = ""},
                new Book() {
                    Id = 2,
                    Title = "C#NetCore",
                    AuthorId = -1,
                    GenreId = 1,
                    Image = "/images/book-2.jpg",
                    price = 15000,
                    TotalPage = 150,
                    Summary = ""},
                 new Book() {
                    Id=3,
                    Title = "Thiết kế web",
                    AuthorId = -1,
                    GenreId = 1,
                    Image = "/images/book-3.jpg",
                    price = 25000,
                    TotalPage = 250,
                    Summary = ""},
            };

            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = this.GetBookList()
                .FirstOrDefault(b => b.Id == id);
            return book;
        }

        // Author
        public List<SelectListItem> Authors { get; } =
            new List<SelectListItem>
            {
                new SelectListItem{Value="1",Text="Nam cao"},
                new SelectListItem{Value="2",Text="Ngô Tất Tố"},
                new SelectListItem{Value="3",Text="AdamKhoom"},
                new SelectListItem{Value="4",Text="Donal Trump"}
            };

        // Genres
        public List<SelectListItem> Genres { get; }
            = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Truyện Tranh" },
                new SelectListItem { Value = "2", Text = "Văn học đương đại" },
                new SelectListItem { Value = "3", Text = "Truyện cười" },
                new SelectListItem { Value = "4", Text = "Phật học" }
            };

    }
}