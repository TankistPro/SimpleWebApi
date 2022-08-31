namespace WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }  
        public string Gener { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
