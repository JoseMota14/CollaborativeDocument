using EventSourcingCollaborativeDocs.Models;
using Xunit;

namespace Tester
{
    public class UserTester
    {
        [Fact]
        public void Creation()
        {
            var user = new User();
            Assert.NotNull(user);
        }

        [Fact]
        public void ValidName()
        {
            string expectedName = "User test";
            var user = new User()
            {
                Name = expectedName
            };

            Assert.Equal(expectedName, user.Name);
        }
    }
}