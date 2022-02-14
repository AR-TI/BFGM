namespace BFGM.Models
{
    public class ModelBook
    {
        public string NameBooksBook { get; set; }
        public string NameBooksAuthor { get; set; }

        public ModelBook(string nameBooksBook, string nameBooksAuthor)
        {
            NameBooksBook = nameBooksBook;
            NameBooksAuthor = nameBooksAuthor;
        }
    }
}
