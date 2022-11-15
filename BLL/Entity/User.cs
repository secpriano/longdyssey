using IL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long SpaceMiles { get; set; }
        public bool IsLyMember { get; set; }

        public User(long id, string firstName, string lastName, string email, long spaceMiles, bool isLyMember)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SpaceMiles = spaceMiles;
            IsLyMember = isLyMember;
        }

        public User(UserDTO dto)
        {
            Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            SpaceMiles = dto.SpaceMiles;
            IsLyMember = dto.IsLyMember;
        }

        public UserDTO GetDTO() => new(Id, FirstName, LastName, Email, SpaceMiles, IsLyMember);
    }
}
