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
    public class TestWorkHistoryDetailController
    {
        private WorkHistoryDetailController _controller;
        readonly IRepositoryWrapper _repo;

        public TestWorkHistoryDetailController()
        {
            _controller = new WorkHistoryDetailController(_repo);
        }


        [Test]
        public void GetWorkHistoryDetail_ShouldReturnAllItems()
        {
            Task<IEnumerable<WorkHistoryDetail>> response = _controller.GetWorkHistoryDetail();

            Assert.IsNotNull(response.Result, "Should have returned all Items, should not be null if there are WorkHistoryDetail items in the datastore.");
        }

        [Test]
        public void GetWorkHistoryDetail_ShouldReturnOneItemById()
        {
            var guid = new Guid();
            var response = _controller.GetWorkHistoryDetail(guid);

            Assert.IsNotNull(response.Result, "Should return a WorkHistoryDetail Item from the datastore that correspomds to  the Guid value as the WorkHistoryDetailId field.");
        }

        [Test]
        public void PostWorkHistoryDetail_ShouldAddNewObjectToDatastore()
        {

        }

        [Test]
        public void PutWorkHistoryDetail_ShouldUpdateObjectInDatastore()
        {

        }
    }
}
