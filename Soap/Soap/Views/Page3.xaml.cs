using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace Soap.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : PopupPage
	{
        string[] Value = { "Percentage", "Weight" };
        private TaskCompletionSource<bool> taskCompletionSource;
        public Task PopupClosedTask { get { return taskCompletionSource.Task; } }

        int id = 1;
        public Page3 ()
		{
			InitializeComponent ();
            Application.Current.Properties["Value"] = "";
            Application.Current.Properties["WtPerRadio"] = "";
            
            ValueUnit.ItemsSource = Value;
            ValueUnit.SelectedIndex = id;
            ValueUnit.CheckedChanged += ValueUnit_CheckedChanged1;
        }

        private void ValueUnit_CheckedChanged1(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            Application.Current.Properties["WtPerRadio"] = radio.Id;
            string x = Application.Current.Properties["WtPerRadio"].ToString();
   
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            taskCompletionSource = new TaskCompletionSource<bool>();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            taskCompletionSource.SetResult(true);
        }
     
        private async void OkClicked(object sender, EventArgs e)
        {
            if (OilValue.Text == null)
            {
                await DisplayAlert("Invalid Value", "Please Insert A value", "Ok");
                return;
            }
            else
            {

                Application.Current.Properties["Value"] = OilValue.Text;


                await PopupNavigation.Instance.PopAsync(true);
            }
        }
        private async void Cancell(object sender, EventArgs e)
        {
            
            await PopupNavigation.Instance.PopAsync(true);
        }

        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }
    }
}