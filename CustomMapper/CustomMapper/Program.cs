namespace CustomMapper
{
    public class User
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
    }
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MapperConfig.Register<User, UserDto>(user => new UserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
            });

            var mapper = new Mapper();
            var user = new User { Name = "Peter", Surname = "Steele", Age = 40 };
            var userDto = mapper.Map<User, UserDto>(user);

            Console.WriteLine($"User Name: {userDto.Name}, \n" +
                $"User Surname: {userDto.Surname}, \n" +
                $"User Age: {userDto.Age}");

        }
    }
    
}
