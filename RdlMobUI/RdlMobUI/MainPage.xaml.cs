using Newtonsoft.Json;
using RdlNet2018.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RdlMobUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGetResume_Click(object sender, EventArgs e)
        {
            var url = "https://rdlsvc.azurewebsites.net/api/v1/CareerInfo?id=58f21038-a7e4-46ec-b036-08d667882bcb";

            var client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(url);
                //lblText.Text = response;
                if (!string.IsNullOrEmpty(response))
                {
                    List<CareerInfo> data = await Task.Run(() => JsonConvert.DeserializeObject<List<CareerInfo>>(response));
                    CareerInfo careerInfo = data[0];
                    lblText.Text = careerInfo.FirstName;
                }
                else
                {
                    lblText.Text = "No Data";
                }
            }
            catch (Exception)
            {
                lblText.Text = "Error!";
            }
        }
    }
}
