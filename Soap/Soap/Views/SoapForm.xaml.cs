using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soap.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SoapForm : ContentPage
	{

        string[] Test = { "wddl", "dwdw", "dwddw" };
		public SoapForm ()
		{
			InitializeComponent ();
            RadioTest.ItemsSource = Test;
		}

        void SellectItem(object sender ,EventArgs e)
        {
            var selected = UnitPicker.Items[UnitPicker.SelectedIndex];
            Unit.Text = "Weight will be in (" + selected + ")";
            Unit.FontSize = 20.0;
        }

    }
}