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
	public partial class JobSkills : ContentPage
	{
        public JobSkills()
        {
            InitializeComponent();
        }

        public JobSkills(string jobSkillsText)
        {
            InitializeComponent();
            lblTitle.Text = "Job Skils";
            lblText.Text = jobSkillsText;
        }

        public JobSkills(List<JobSkill> _jobSkillList)
        {
            InitializeComponent();
            var formattedText = new FormattedString();

            foreach (JobSkill js in _jobSkillList)
            {
                formattedText.Spans.Add(new Span { Text = $"* {js.JobSkillTitle}\n", ForegroundColor = Color.FromHex("ffffff"), FontSize = 9, FontAttributes = FontAttributes.Bold });
            }

            var ftTitle = new FormattedString();
            ftTitle.Spans.Add(new Span { Text = $"Job Skils", ForegroundColor = Color.FromHex("ffffff"), FontSize = 12, FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline });
            lblTitle.FormattedText = ftTitle;
            lblText.FormattedText = formattedText;
        }

        public JobSkills(FormattedString formattedText)
        {
            InitializeComponent();
            var ftTitle = new FormattedString();
            ftTitle.Spans.Add(new Span { Text = $"Job Skils", ForegroundColor = Color.FromHex("ffffff"), FontSize = 11, FontAttributes = FontAttributes.Bold });
            lblTitle.FormattedText = ftTitle;
            lblText.FormattedText = formattedText;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.SendBackButtonPressed();
        }
    }
}