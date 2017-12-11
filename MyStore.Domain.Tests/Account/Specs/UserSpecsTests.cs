using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using System.Collections.Generic;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();

            _users.Add(new User("jhones.goncalves@outlook.com", "jhonesgoncalves", "123456"));
            _users.Add(new User("luis.goncalves@outlook.com", "luis", "123456"));
            _users.Add(new User("batman@outlook.com", "batman", "123456"));
            _users.Add(new User("ironman@outlook.com", "ironman", "123456"));
            _users.Add(new User("daniel@outlook.com", "daniel", "123456"));
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldReturnValue()
        {
            var user = _users.AsQueryable().Where(UserSpecs.GetByUsername("jhonesgoncalves")).FirstOrDefault();

            Assert.AreNotEqual(null, user);

        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldNotReturnValue()
        {
            var user = _users.AsQueryable().Where(UserSpecs.GetByUsername("jhonesgoncalves56456")).FirstOrDefault();

            Assert.AreEqual(null, user);

        }
    }
}
