public class Author 
{
    public int Id { get; set; }
    public string Fio { get; set; }

    public ICollection<Book> Books { get; set; }
}
