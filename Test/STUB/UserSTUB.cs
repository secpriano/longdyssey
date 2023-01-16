using IL.DTO;

namespace Test.STUB
{
    public class UserSTUB
    {
        public List<UserDTO> users = new()
        {
            new(1, "ano", "niem", "amo@niem.nl", 500, true),
            new(2, "toby", "maguire", "toby@maguire.nl", 5005, false),
            new(3, "harry", "kane", "harry@kane.nl", 500, true),
            new(4, "bas", "rutten", "bas@rutten.nl", 2500, false)
        };
        
        public UserDTO GetById(long id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }
    }
}
