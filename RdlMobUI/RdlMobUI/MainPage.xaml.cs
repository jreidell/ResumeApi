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
        private CareerInfo _careerInfo = null;

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
                    _careerInfo = data[0];
                    //await Navigation.PushAsync(new StackLayoutEx(_careerInfo));
                    lblFullName.Text = $"{_careerInfo.FirstName} {_careerInfo.MiddleName} {_careerInfo.LastName}, {_careerInfo.Suffix}\n"
                    + $"{_careerInfo.Address1}, {_careerInfo.City}, {_careerInfo.State} {_careerInfo.PostalCode}\n"
                    + $"{_careerInfo.EmailAddress}, {_careerInfo.Phone}, Mobile: {_careerInfo.Mobile}\n"
                    + $"{_careerInfo.CareerInfoTitle}";
                    lblSummary.Text = $"{_careerInfo.Summary}";
                }
                else
                {
                    lblError.Text = "No Data";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void FillResumeFields(CareerInfo careerInfo)
        {
            lblFullName.Text = $"{careerInfo.FirstName} {careerInfo.MiddleName} {careerInfo.LastName}, {careerInfo.Suffix}";
            lblAddress.Text = $"{careerInfo.Address1}, {careerInfo.City}, {careerInfo.State} {careerInfo.PostalCode}";
            lblContactInfo.Text = $"{careerInfo.EmailAddress}, {careerInfo.Phone}, Mobile: {careerInfo.Mobile}";
            lblResumeTitle.Text = $"{careerInfo.CareerInfoTitle}";

            //lblFullName.Text = $"{careerInfo.FirstName} {careerInfo.MiddleName} {careerInfo.LastName}, {careerInfo.Suffix}\n"
            //+ $"{careerInfo.Address1}, {careerInfo.City}, {careerInfo.State} {careerInfo.PostalCode}\n"
            //+ $"{careerInfo.EmailAddress}, {careerInfo.Phone}, Mobile: {careerInfo.Mobile}\n"
            //+ $"{careerInfo.CareerInfoTitle}";
            //lblSummary.Text = $"{careerInfo.Summary}";
        }

    }

    public class StackLayoutEx : ContentPage
    {
        public StackLayoutEx(CareerInfo careerInfo)
        {
            var content = new StackLayout
            {
                Children = {
                new Label {Text = $"{careerInfo.FirstName} {careerInfo.MiddleName} {careerInfo.LastName}, {careerInfo.Suffix}\n"
                            + $"{careerInfo.Address1}, {careerInfo.City}, {careerInfo.State} {careerInfo.PostalCode}\n"
                            + $"{careerInfo.EmailAddress}, {careerInfo.Phone}, Mobile: {careerInfo.Mobile}\n"
                            + $"{careerInfo.CareerInfoTitle}"},
                new Label { Text = $"{careerInfo.Summary}" }
            }
            };
        }
    }

}
