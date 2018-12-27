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
	public partial class Summary : ContentPage
	{
        public Summary()
        {
            InitializeComponent();
        }

        public Summary(string summaryText)
        {
            InitializeComponent();

            var ftTitle = new FormattedString();
            ftTitle.Spans.Add(new Span { Text = "Summary", ForegroundColor = Color.FromHex("ffffff"), FontSize = 11, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblTitle.FormattedText = ftTitle;

            var formattedText = new FormattedString();
            formattedText.Spans.Add(new Span { Text = $"{summaryText}\n", ForegroundColor = Color.FromHex("ffffff"), FontSize = 8, FontAttributes = FontAttributes.Bold });
            lblText.FormattedText = formattedText;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.SendBackButtonPressed();
        }
    }
}