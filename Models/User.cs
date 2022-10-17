namespace Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Number { get; set; }

        public UserName[]? names { get; set; }


    }

    public class UserName 
    {
        public string Name { get; set; } = string.Empty;
    }
}