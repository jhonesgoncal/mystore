using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Scopes;

namespace MyStore.Domain.Tests.Account
{
    [TestClass]
    public class UserScopeTests
    {
        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterScopeIsValid()
        {
            var user = new User("jhones.goncalves@outlook.com", "jhonesgoncalves", "123456");
            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterScopeIsInvalidWhenUsernameIsNull()
        {
            var user = new User("jhones.goncalves@outlook.com", "", "123456");
            Assert.AreEqual(false, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationScopeIsValid()
        {
            var user = new User("jhones.goncalves@outlook.com", "jhonesgoncalves", "123456");
            var verificationCode = user.VerificationCode;
            Assert.AreEqual(true, user.VerificationScopeIsValid(verificationCode));
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationScopeIsInvalid()
        {
            var user = new User("jhones.goncalves@outlook.com", "jhonesgoncalves", "123456");
            var verificationCode = "2131";
            Assert.AreEqual(false, user.VerificationScopeIsValid(verificationCode));
        }
    }
}
