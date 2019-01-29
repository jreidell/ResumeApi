using NUnit.Framework;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using RdlNet2018.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Test
{
    [TestFixture]
    public class TestAuthUserController
    {

        private AuthUserController _controller;
        readonly IRepositoryWrapper _repo;

        public TestAuthUserController()
        {
            _controller = new AuthUserController(_repo);
        }


        [Test]
        public void GetAuthUser_ShouldReturnAllItems()
        {
            var response = _controller.GetAuthUser();

            Assert.IsNotNull(response.Result, "Should have returned all Items, should not be null if there are AuthUser items in the datastore.");
        }

        [Test]
        public void GetAuthUser_ShouldReturnOneItemById()
        {
            var guid = new Guid();
            var response = _controller.GetAuthUser(guid);

            Assert.IsNotNull(response.Result, "Should return a AuthUser Item from the datastore that correspomds to  the Guid value as the AuthUserId field.");
        }

        [Test]
        public void PostAuthUser_ShouldAddNewObjectToDatastore()
        {

        }

        [Test]
        public void PutAuthUser_ShouldUpdateObjectInDatastore()
        {

        }
    }
}
