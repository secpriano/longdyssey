namespace IL.DTO
{
    public class UserDTO
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public long SpaceMiles { get; }
        public bool IsLyMember { get; }

        public UserDTO(long id, string firstName, string lastName, string email, long spaceMiles, bool isLyMember)
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
