namespace Core.Models
{
    public class User
    {
        public int UserId;
        public string Name;
        public List<Book> PublishedBooks;

        public User(int userId, string name)
        {
            UserId = userId;
            Name = name;
            PublishedBooks = new List<Book>();
        }

     
    }
}
