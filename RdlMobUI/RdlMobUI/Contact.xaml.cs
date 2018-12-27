using RdlNet2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RdlMobUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Contact : ContentPage
    {

        CareerInfo _careerInfo = null;

        public Contact()
        {
            InitializeComponent();
        }

        public Contact(CareerInfo careerInfo)
        {
            InitializeComponent();
            _careerInfo = careerInfo;
            var ftTitle = new FormattedString();
            var ftTitle2 = new FormattedString();
            var ftFullname = new FormattedString();
            var ftAddress1 = new FormattedString();
            var ftAddress2 = new FormattedString();
            var ftEmailLabel = new FormattedString();
            var ftEmailAddress = new FormattedString();
            var ftHomePhoneLabel = new FormattedString();
            var ftHomePhone = new FormattedString();
            var ftMobilePhoneLabel = new FormattedString();
            var ftMobilePhone = new FormattedString();
            var ftMobileSMS = new FormattedString();

            ftTitle.Spans.Add(new Span { Text = $"Contact Info", ForegroundColor = Color.FromHex("ffffff"), FontSize = 12, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblTitle.FormattedText = ftTitle;

            ftTitle2.Spans.Add(new Span { Text = $"Mailing Address:", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblTitle2.FormattedText = ftTitle2;

            ftFullname.Spans.Add(new Span { Text = $"{_careerInfo.FirstName} {_careerInfo.MiddleName} {_careerInfo.LastName}", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblFullname.FormattedText = ftFullname;

            ftAddress1.Spans.Add(new Span { Text = $"{_careerInfo.Address1}", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblAddress1.FormattedText = ftAddress1;

            ftAddress2.Spans.Add(new Span { Text = $"{ _careerInfo.City}, {_careerInfo.State} {_careerInfo.PostalCode}", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblAddress2.FormattedText = ftAddress2;

            ftEmailLabel.Spans.Add(new Span { Text = $"Email Address: ", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblEmailLabel.FormattedText = ftEmailLabel;

            ftEmailAddress.Spans.Add(new Span { Text = $"{_careerInfo.EmailAddress}", ForegroundColor = Color.Blue, FontSize = 9, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblEmailAddress.FormattedText = ftEmailAddress;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Device.OpenUri(new Uri($"mailto:{_careerInfo.EmailAddress}"));
            };
            lblEmailAddress.GestureRecognizers.Add(tapGestureRecognizer);

            ftHomePhoneLabel.Spans.Add(new Span { Text = $"Home: ", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblHomePhoneLabel.FormattedText = ftHomePhoneLabel;

            ftHomePhone.Spans.Add(new Span { Text = $"{_careerInfo.Phone}", ForegroundColor = Color.Yellow, FontSize = 9, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblHomePhone.FormattedText = ftHomePhone;

            var tapGestureRecognizerTel = new TapGestureRecognizer();
            tapGestureRecognizerTel.Tapped += (s, e) => {
                Device.OpenUri(new Uri($"tel:{_careerInfo.Phone}"));
            };
            lblHomePhone.GestureRecognizers.Add(tapGestureRecognizerTel);

            ftMobilePhoneLabel.Spans.Add(new Span { Text = $"Mobile: ", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            lblMobilePhoneLabel.FormattedText = ftMobilePhoneLabel;

            ftMobilePhone.Spans.Add(new Span { Text = $"{_careerInfo.Mobile}", ForegroundColor = Color.Yellow, FontSize = 9, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblMobilePhone.FormattedText = ftMobilePhone;

            var tapGestureRecognizerMob = new TapGestureRecognizer();
            tapGestureRecognizerMob.Tapped += (s, e) => {
                Device.OpenUri(new Uri($"tel:{_careerInfo.Mobile}"));
            };
            lblMobilePhone.GestureRecognizers.Add(tapGestureRecognizerMob);

            ftMobileSMS.Spans.Add(new Span { Text = $"(Send SMS/Text Msg)", ForegroundColor = Color.Blue, FontSize = 8, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblMobileSMS.FormattedText = ftMobileSMS;

            var tapGestureRecognizerSMS = new TapGestureRecognizer();
            tapGestureRecognizerSMS.Tapped += (s, e) => {
                Device.OpenUri(new Uri($"sms:{_careerInfo.Mobile}"));
            };
            lblMobileSMS.GestureRecognizers.Add(tapGestureRecognizerSMS);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.SendBackButtonPressed();
        }
    }
}