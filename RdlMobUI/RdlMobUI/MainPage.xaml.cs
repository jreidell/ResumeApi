using Newtonsoft.Json;
using RdlNet2018.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RdlMobUI
{
    public partial class MainPage : CarouselPage
    {
        private CareerInfo _careerInfo = null;
        private string _contactInfo = string.Empty;
        private string _summary = string.Empty;
        private string _jobSkills = string.Empty;
        private string _workHistory = string.Empty;
        private string _workHistoryDetail = string.Empty;
        private string _errorMessage = string.Empty;

        public MainPage()
        {
            GetResumeData(Guid.Parse("58f21038-a7e4-46ec-b036-08d667882bcb"));
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                DisplayAlert("Error", $"{_errorMessage}", "Close");
            }
            InitializeComponent();
        }

        private async void GetResumeData(Guid? id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://rdlsvc.azurewebsites.net/api/v1/");
                    //HTTP GET
                    var responseTask = client.GetAsync($"CareerInfo/{id.GetValueOrDefault()}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        _careerInfo = await Task.Run(() => JsonConvert.DeserializeObject<CareerInfo>(readTask.Result));

                        svStats.TotalEmployers = _careerInfo.WorkHistory.Count.ToString();

                        lblFullName.Text = $"{_careerInfo.FirstName} {_careerInfo.MiddleName} {_careerInfo.LastName}, {_careerInfo.Suffix}";
                        lblTitle.Text = $"{_careerInfo.CareerInfoTitle}";
                        _contactInfo = $"{_careerInfo.Address1}\n{_careerInfo.City}, {_careerInfo.State} {_careerInfo.PostalCode}\n"
                                    + $"{_careerInfo.EmailAddress}\nHome: {_careerInfo.Phone}\nMobile: {_careerInfo.Mobile}\n";

                        _summary = $"{_careerInfo.Summary}";
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        _careerInfo = null;

                        _errorMessage = "Server error. Please contact administrator.";
                    }
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                }
            }

        }

        private void btnContact_Clicked(object sender, EventArgs e)
        {
            if(_careerInfo != null)
                Navigation.PushModalAsync(new Contact(_careerInfo));
        }

        private void btnSummary_Clicked(object sender, EventArgs e)
        {
            if (_careerInfo != null)
                Navigation.PushModalAsync(new Summary(_summary));
        }
        private void btnJobSkills_Clicked(object sender, EventArgs e)
        {
            if (_careerInfo != null)
                Navigation.PushModalAsync(new JobSkills(_careerInfo.JobSkills));
        }

        private void btnWorkHistory_Clicked(object sender, EventArgs e)
        {
            if (_careerInfo != null)
                Navigation.PushModalAsync(new WorkHist(_careerInfo.WorkHistory));
        }
        private void btnGitHub_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/jreidell/ResumeApi"));
        }

        private void btnLinkedIn_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.linkedin.com/in/joereidell/"));
        }

    }
}
