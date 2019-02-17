using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace RdlMvcUI.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<CareerInfo> resumes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{UriHelper.BuildAbsolute(Request.Scheme, Request.Host)}api/v1/");
                //HTTP GET
                var responseTask = client.GetAsync("CareerInfo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<CareerInfo>>();
                    readTask.Wait();

                    resumes = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    resumes = Enumerable.Empty<CareerInfo>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(resumes);
        }

        public IActionResult Details(Guid? id)
        {
            CareerInfo resume = null;

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44386/api/v1/");
                client.BaseAddress = new Uri($"{UriHelper.BuildAbsolute(Request.Scheme, Request.Host)}api/v1/");
                //HTTP GET
                var responseTask = client.GetAsync($"CareerInfo/{id.GetValueOrDefault()}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CareerInfo>();
                    readTask.Wait();

                    resume = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    resume = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(resume);

        }
    }
}