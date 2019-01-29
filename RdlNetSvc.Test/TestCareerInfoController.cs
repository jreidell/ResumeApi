using NUnit.Framework;
using RdlNetSvc.Common.Contracts;
using RdlNetSvc.Common.Models;
using RdlNetSvc.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RdlNet2018.Test
{
    [TestFixture]
    public class TestCareerInfoController
    {

        private CareerInfoController _controller;
        readonly IRepositoryWrapper _repo;

        public TestCareerInfoController()
        {
            _controller = new CareerInfoController(_repo);
        }


        [Test]
        public void GetCareerInfo_ShouldReturnAllItems()
        {
            Task<IEnumerable<CareerInfo>> response = _controller.GetCareerInfo();

            Assert.IsNotNull(response.Result, "Should have returned all Items, should not be null if there are CareerInfo items in the datastore.");
        }

        [Test]
        public void GetCareerInfo_ShouldReturnOneItemById()
        {
            var guid = new Guid();
            var response = _controller.GetCareerInfo(guid);

            Assert.IsNotNull(response.Result, "Should return a CareerInfo Item from the datastore that correspomds to  the Guid value as the CareerInfoId field.");
        }

        [Test]
        public void PostCareerInfo_ShouldAddNewObjectToDatastore()
        {

        }

        [Test]
        public void PutCareerInfo_ShouldUpdateObjectInDatastore()
        {

        }

    }
}
