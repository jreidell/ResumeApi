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
    public class TestJobSkillController
    {
        private JobSkillController _controller;
        readonly IRepositoryWrapper _repo;

        public TestJobSkillController()
        {
            _controller = new JobSkillController(_repo);
        }


        [Test]
        public void GetJobSkill_ShouldReturnAllItems()
        {
            Task<IEnumerable<JobSkill>> response = _controller.GetJobSkill();

            Assert.IsNotNull(response.Result, "Should have returned all Items, should not be null if there are JobSkill items in the datastore.");
        }

        [Test]
        public void GetJobSkill_ShouldReturnOneItemById()
        {
            var guid = new Guid();
            var response = _controller.GetJobSkill(guid);

            Assert.IsNotNull(response.Result, "Should return a JobSkill Item from the datastore that correspomds to  the Guid value as the JobSkillId field.");
        }

        [Test]
        public void PostJobSkill_ShouldAddNewObjectToDatastore()
        {

        }

        [Test]
        public void PutJobSkill_ShouldUpdateObjectInDatastore()
        {

        }
    }
}
