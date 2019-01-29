using NUnit.Framework;
using RdlNet2018.Common.Contracts;
using RdlNet2018.Common.Models;
using RdlNet2018.Controllers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        [AsyncStateMachine(typeof(Task<IEnumerable<CareerInfo>>))]
        [Test]
        public async void GetCareerInfo_ShouldReturnAllItems()
        {
            var response = await _controller.GetCareerInfo();
            CareerInfo ci = response.GetEnumerator().Current;

            //CollectionAssert.AllItemsAreNotNull(response.Result, "Should have returned all Items, should not be null if there are CareerInfo items in the datastore.");
            //REMOTE: 58f21038-a7e4-46ec-b036-08d667882bcb
            //LOCAL: 21a61a6a-6554-4e7f-a974-08d663d5d19f
            Assert.True(ci.CareerInfoId.ToString().Equals("21a61a6a-6554-4e7f-a974-08d663d5d19f", StringComparison.InvariantCultureIgnoreCase), "Should have returned all Items, should not be null if there are CareerInfo items in the datastore.");
        }

        [Test]
        public async void GetCareerInfo_ShouldReturnOneItemById()
        {
            //var response = await _controller.GetCareerInfo();
            //CareerInfo ci = response.GetEnumerator().Current;

            ////CollectionAssert.AllItemsAreNotNull(response.Result, "Should have returned all Items, should not be null if there are CareerInfo items in the datastore.");
            ////REMOTE: 58f21038-a7e4-46ec-b036-08d667882bcb
            ////LOCAL: 21a61a6a-6554-4e7f-a974-08d663d5d19f
            //Assert.True(ci.CareerInfoId.ToString().Equals("21a61a6a-6554-4e7f-a974-08d663d5d19f", StringComparison.InvariantCultureIgnoreCase), "Should have returned all Items, should not be null if there are CareerInfo items in the datastore.");

            var guid = Guid.Parse("21a61a6a-6554-4e7f-a974-08d663d5d19f");
            var response = await _controller.GetCareerInfo(guid);

            Assert.IsNotNull(response, "Should return a CareerInfo Item from the datastore that correspomds to  the Guid value as the CareerInfoId field.");
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
