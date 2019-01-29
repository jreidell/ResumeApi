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
    public class TestWorkHistoryController
    {
        private WorkHistoryController _controller;
        readonly IRepositoryWrapper _repo;

        public TestWorkHistoryController()
        {
            _controller = new WorkHistoryController(_repo);
        }


        [Test]
        public void GetWorkHistory_ShouldReturnAllItems()
        {
            Task<IEnumerable<WorkHistory>> response = _controller.GetWorkHistory();

            Assert.IsNotNull(response.Result, "Should have returned all Items, should not be null if there are WorkHistory items in the datastore.");
        }

        [Test]
        public void GetWorkHistory_ShouldReturnOneItemById()
        {
            var guid = new Guid();
            var response = _controller.GetWorkHistory(guid);

            Assert.IsNotNull(response.Result, "Should return a WorkHistory Item from the datastore that correspomds to  the Guid value as the WorkHistoryId field.");
        }

        [Test]
        public void PostWorkHistory_ShouldAddNewObjectToDatastore()
        {

        }

        [Test]
        public void PutWorkHistory_ShouldUpdateObjectInDatastore()
        {

        }
    }
}
