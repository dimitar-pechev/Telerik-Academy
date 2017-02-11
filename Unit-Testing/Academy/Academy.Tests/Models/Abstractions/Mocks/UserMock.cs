using Academy.Models.Abstractions;

namespace Academy.Tests.Models.Abstractions
{
    public class UserMock : User
    {
        public UserMock(string username) : base(username)
        {
        }
    }
}
