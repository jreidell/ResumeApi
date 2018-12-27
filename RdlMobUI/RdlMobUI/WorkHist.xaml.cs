using RdlNet2018.Common.Models;
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
	public partial class WorkHist : ContentPage
	{
        public WorkHist()
        {
            InitializeComponent();
        }

        public WorkHist(List<WorkHistory> _workHistoryList)
        {
            InitializeComponent();
            var formattedText = new FormattedString();

            foreach (WorkHistory wh in _workHistoryList)
            {
                formattedText.Spans.Add(new Span { Text = $"{wh.Employer}, {wh.StartDate.ToString("MMM yyyy")} - {wh.EndDate.ToString("MMM yyyy")} \n", ForegroundColor = Color.FromHex("ffffff"), FontSize = 6, FontAttributes = FontAttributes.Bold });
                formattedText.Spans.Add(new Span { Text = $"{wh.JobTitle}\n", ForegroundColor = Color.FromHex("ffffff"), FontSize = 5, FontAttributes = FontAttributes.Bold });
                formattedText.Spans.Add(new Span { Text = $"{wh.JobDescription}\n\n", ForegroundColor = Color.FromHex("ffffff"), FontSize = 5, FontAttributes = FontAttributes.None });
            }

            var ftTitle = new FormattedString();
            ftTitle.Spans.Add(new Span { Text = "Work History", ForegroundColor = Color.FromHex("ffffff"), FontSize = 12, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblTitle.FormattedText = ftTitle;
            lblText.FormattedText = formattedText;
        }

        public WorkHist(FormattedString formattedText)
        {
            InitializeComponent();
            var ftTitle = new FormattedString();
            ftTitle.Spans.Add(new Span { Text = "Work History", ForegroundColor = Color.FromHex("ffffff"), FontSize = 12, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblTitle.FormattedText = ftTitle;
            lblText.FormattedText = formattedText;
        }

        public WorkHist(string _workHistory)
        {
            InitializeComponent();
            lblTitle.Text = "Work History";
            lblText.Text = _workHistory;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.SendBackButtonPressed();
        }
    }
}