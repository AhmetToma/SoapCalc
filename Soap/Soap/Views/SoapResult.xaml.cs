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
    public partial class SoapResult : ContentPage
    {
        public SoapResult()
        {
            InitializeComponent();
        }
        void Tab1(object sender, EventArgs e,StackLayout s)
        {
            
            if (Fatty.IsVisible == false)
                Fatty.IsVisible = true;
            else
                Fatty.IsVisible = false;
        }
        void Tab2(object sender, EventArgs e, StackLayout s)
        {

            if (Recipe.IsVisible == false)
                Recipe.IsVisible = true;
            else
                Recipe.IsVisible = false;
        }
        void Tab3(object sender, EventArgs e, StackLayout s)
        {

            if (Lye.IsVisible == false)
                Lye.IsVisible = true;
            else
                Lye.IsVisible = false;
        }
        void Tab4(object sender, EventArgs e, StackLayout s)
        {

            if (Quality.IsVisible == false)
                Quality.IsVisible = true;
            else
                Quality.IsVisible = false;
        }
        void Tab5(object sender, EventArgs e, StackLayout s)
        {

            if (BenchMark.IsVisible == false)
                BenchMark.IsVisible = true;
            else
                BenchMark.IsVisible = false;
        }




    }
}