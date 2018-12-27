using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RdlMobUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatsView : ContentView
	{
        public StatsView ()
		{
			InitializeComponent ();
        }

        #region TotalEmployers (Bindable string)
        public static readonly BindableProperty TotalEmployersProperty = BindableProperty.Create(
                                                                  "TotalEmployers", //Public name to use
                                                                  typeof(string), //this type
                                                                  typeof(StatsView), //parent type (tihs control)
                                                                  string.Empty, //default value
                                                                  BindingMode.TwoWay);
        public string TotalEmployers
        {
            get { return (string)GetValue(TotalEmployersProperty); }
            set {
                SetValue(TotalEmployersProperty, value);
                SetNumberTotals(value);
            }
        }

        private void totalEmployersPropertyChanged(BindableObject obj, EventArgs e)
        {

        }
        #endregion TotalEmployers (Bindable string)

        private void SetNumberTotals(string secondValueString)
        {
            //Count Months
            DateTime s = new DateTime(1996, 11, 1);
            int cnt = 0;
            DateTime n = DateTime.Now;
            while(n > s)
            {
                s = s.AddMonths(1);
                cnt++;
            }

            lblFirstNumberValue.Text = cnt.ToString();
            lblFirstNumberText.Text = "Months Coding";

            lblBar1.Text = "|";

            //Set Total Employers
            lblSecondNumberValue.Text = secondValueString;
            lblSecondNumberText.Text = "Different Employers";

            lblBar2.Text = "|";

            //Count Years
            s = new DateTime(1996, 11, 1);
            cnt = 0;
            while (s.Month != n.Month && s.Year != n.Year)
            {
                s = s.AddYears(1);
                cnt++;
            }

            lblThirdNumberValue.Text = cnt.ToString();
            lblThirdNumberText.Text = "Years Experience";
        }
    }
}