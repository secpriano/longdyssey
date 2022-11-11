namespace IL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long SpaceMiles { get; set; }
        public bool IsLyMember { get; set; }

        public UserDTO(int id, string firstName, string lastName, string email, long spaceMiles, bool isLyMember)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SpaceMiles = spaceMiles;
            IsLyMember = isLyMember;
        }
    }
}
