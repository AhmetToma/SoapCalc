using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Soap.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace Soap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
   
        string[] Unit = { "Grams, g", "Kilograms, kg", "Ounces, oz", "Pounds, lbs" };
        string[] Mold = { "Loaf/Slab", "Cylinder" };
        int id =1;
        string type = "";
        string url = "https://mysoapcalc.com/soap/public/ajax.php/?getAllOils=true";
        double Result;
        double TotalGrams = 0;

        Calculation Clc = new Calculation();
        HttpClient client = new HttpClient();
        List<OilObject> SelectedOil = new List<OilObject>();
        FinalResult finalResult = new FinalResult();
        private ObservableCollection<OilObject> MyList;
        int counter=0;

       

        public Page1()
        {
            InitializeComponent();
            Title = "Soap Calc";
            Application.Current.Properties["RadioUnit"] = 0;
            Application.Current.Properties["RadioMold"] = 0;
           
            RadioUnit.ItemsSource = Unit;
            
            RadioUnit.SelectedIndex = id;
            
            RadioMold.ItemsSource = Mold;
            RadioMold.SelectedIndex =id;
         
            RadioUnit.CheckedChanged += RadioUnit_CheckedChanged;
            RadioMold.CheckedChanged += RadioMold_CheckedChanged;
            
            GetAll();
          






        }
          async  void GetAll()
        {
         
            HttpResponseMessage response = await client.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var _Data = JsonConvert.DeserializeObject<List<OilObject>>(jsonString);
            OilsPicker.ItemsSource = _Data;  
        }

        void LoafClyinderEntryCase(int x)
        {
            if (x == 0)
            {
                Lenght.IsEnabled = true; Lenght.PlaceholderColor = Color.White;
                Width.IsEnabled = true; Width.PlaceholderColor = Color.White;
                Height.IsEnabled = true; Height.PlaceholderColor = Color.White;
                Diamter.IsEnabled = false;


            }
            else
            {

                Lenght.IsEnabled = false; Lenght.PlaceholderColor = Color.Red;
                Width.IsEnabled = false; Width.PlaceholderColor = Color.Red;
                Height.IsEnabled = true; Height.PlaceholderColor = Color.White;
                Diamter.IsEnabled = true; Diamter.PlaceholderColor = Color.White;

            }
        }


        void ClcLoaf(string lenght, string width, string height)
        {
      
            if (lenght == null || lenght == "") lenght = "1";
            if (width == null || width == "") width = "1";
            if (height == null || height == "") height = "1";


            double len = double.Parse(lenght);
            double wid = double.Parse(width);
            double hei = double.Parse(height);
            // Grams
            if (Application.Current.Properties["RadioUnit"].ToString() == "0")
            {

                Result = (len * wid * hei) / 1;

                Capacity.Text = "Capacity is : " + Result + "g";


            }
            //Kg
            else if (Application.Current.Properties["RadioUnit"].ToString() == "1")
            {
                Result = (len * wid * hei) / 1000;
                Capacity.Text = "Capacity is : " + Result + "Kg";
            }
            //ounce 
            else if (Application.Current.Properties["RadioUnit"].ToString() == "2")
            {
                Result = (len * wid * hei) / 28.34952;
                Capacity.Text = "Capacity is :  " + Result + "Oz";
            }
            //pounds 
            else
            {
                Result = (len * wid * hei) / 453.59237;
                Capacity.Text = "Capacity is : " + Result + "Lbs";
            }

        }
        void ClcCylinder(string Height, string diameter)
        {
            if (diameter == null || diameter == "") diameter = "1";
            if (Height == null || Height == "") Height = "1";

         //   double Result;
            double hei = double.Parse(Height);
            double Dia = double.Parse(diameter);
            Result = (3.14 * hei * (Dia / 2) * (Dia / 2));

            // Grams
            if (Application.Current.Properties["RadioUnit"].ToString() == "0")
            {

                Result = Result / 1;

                Capacity.Text = "Capacity is :" + Result + "g";


            }
            //Kg
            else if (Application.Current.Properties["RadioUnit"].ToString() == "1")
            {
                Result = Result / 1000;
                Capacity.Text = "Capacity is : " + Result + "Kg";
            }
            //ounce 
            else if (Application.Current.Properties["RadioUnit"].ToString() == "2")
            {
                Result = Result / 28.34952;
                Capacity.Text = "Capacity is :  " + Result + "Oz";
            }
            //pounds 
            else
            {
                Result = Result / 453.59237;
                Capacity.Text = "Capacity is : " + Result + "Lbs";
            }
        }

        private void RadioUnit_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            Application.Current.Properties["RadioUnit"] = radio.Id;
            TextChange();
        }

        private void RadioMold_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;
            Application.Current.Properties["RadioMold"] = radio.Id;
            if (Application.Current.Properties["RadioMold"].ToString() == "0") LoafClyinderEntryCase(0);
            else LoafClyinderEntryCase(1);
            TextChange();
        }
        private void TextChange()
        {
            string x;
            string len = "", wid = "", hei = "", dia = "";

            len = Lenght.Text;
            wid = Width.Text;
            hei = Height.Text;
            dia = Diamter.Text;
            if (len == null || len == "") len = "1";
            if (wid == null || wid == "") wid = "1";
            if (hei == null || hei == "") hei = "1";
            if (dia == null || dia == "") dia = "1";
            len = Regex.Replace(len, @"[^0-9a-zA-Z]+", "");
            wid = Regex.Replace(wid, @"[^0-9a-zA-Z]+", "");
            hei = Regex.Replace(hei, @"[^0-9a-zA-Z]+", "");
            dia = Regex.Replace(dia, @"[^0-9a-zA-Z]+", "");

            if (len == "" || wid == "" || hei == "" || dia == "")
            {
                if (len == "") Lenght.Text = "";
                else if (wid == "") Width.Text = "";
                else if (hei == "") Height.Text = "";
                else Diamter.Text = "";

                DisplayAlert("titel", "insert a value", "ok");

            }

            else if (Application.Current.Properties["RadioMold"].ToString() == "0")
            {

                ClcLoaf(len, wid, hei);
            }
            else if (Application.Current.Properties["RadioMold"].ToString() == "1")
            {
                ClcCylinder(hei, dia);
            }


        }

        private void SelectSoapType(object sender, EventArgs e)
        {
             type = SoapType.Items[SoapType.SelectedIndex];
          
            if (type == "NaOH(For bar soap)") 
            {
                Naoh.Placeholder = "Naoh";
                KOh.IsVisible = false;
            }
            else if (type == "KOH (For Liquid soap)KOH Purity,% (90-100)")
            {
                Naoh.Placeholder = "KOH";
                KOh.IsVisible = false;

            }
            else
            {

                if (type == "Dual Lye(For hybrid soap)")
                {
                    KOh.IsVisible = true;
                    KOh.Placeholder = "KOh";
                    Naoh.Placeholder = "NaoH";

               
                }
                else
                {
                    KOh.IsVisible = false;
                    Naoh.Placeholder = "NaoH";
                   
                }
            }
            

        }

        private void NaohKoh()
        {
            int TT = 0;
            foreach (var item in SelectedOil)
            {

                TT = TT + Int32.Parse(item.WeightValue);
            }

            int _WaterDiscount, _WaterSubstitution, _WaterSubstitution2, _distilledWater, _lyeSolution, _totalBatchWeight, _lyeSolutionWeight , causticSodaNaoh, causticSodaKoh, lyeTotal;

            int  naoh = Int32.Parse(Naoh.Text);
            int koh = Int32.Parse(KOh.Text);
            int lyeConcentration = Int32.Parse(LyeConcen.Text);
            int WaterDisCount = Int32.Parse( WaterDis.Text);
            int watersubsitution = Int32.Parse(WaterSub.Text);
            int Fragrance = Int32.Parse(Frag.Text);
            if (type == "NaOH(For bar soap)")
            {
                _WaterDiscount = (((100 / 27) * naoh) - naoh) * (WaterDisCount / 100);
                _WaterSubstitution = (((100 / lyeConcentration) * naoh) - naoh) * (watersubsitution / 100);
                _distilledWater = (((100 / lyeConcentration) * naoh) - naoh) - _WaterSubstitution - _WaterDiscount;
                _lyeSolution = (naoh + 0) / (naoh + 0 + _distilledWater);
                _totalBatchWeight = TT + naoh + _distilledWater + _WaterSubstitution + Fragrance;
                _lyeSolutionWeight = naoh + 0 + _distilledWater;

                finalResult.TotalBatchWeight = _totalBatchWeight.ToString();
                var edc = 52;
            }
            else if (type == "KOH (For Liquid soap)KOH Purity,% (90-100)")
            {
                _WaterDiscount = (((100 / 27) * koh) - koh) * (WaterDisCount / 100);
                _WaterSubstitution = (((100 / lyeConcentration) * koh) - koh) * (watersubsitution / 100);
                _distilledWater = (((100 / lyeConcentration) * koh) - koh) - _WaterSubstitution - _WaterDiscount;

                _lyeSolution = (koh + 0) / (koh + 0 + _distilledWater);
                _totalBatchWeight = TT + koh + _distilledWater + _WaterSubstitution + Fragrance;
                _lyeSolutionWeight = koh + 0 + _distilledWater;


                finalResult.TotalBatchWeight = _totalBatchWeight.ToString();
                var wdc = 51;
            }

            else if  (  type  =="Dual Lye(For hybrid soap)" )
            {
                causticSodaNaoh = naoh * (naoh / 100);
                causticSodaKoh = koh * ((100 - naoh) / 100);
                
                lyeTotal = causticSodaNaoh + causticSodaKoh;

                _WaterSubstitution2 = (((100 / lyeConcentration) * lyeTotal) - lyeTotal) * (watersubsitution / 100);

                _WaterDiscount = (((100 / 27) * naoh) - naoh) * (WaterDisCount / 100);
                _WaterSubstitution = (((100 / lyeConcentration) * naoh) - naoh) * (watersubsitution / 100);

                _distilledWater = (((100 /lyeConcentration) * (causticSodaNaoh + causticSodaKoh)) - (causticSodaNaoh + causticSodaKoh)) - _WaterSubstitution - _WaterDiscount;

                _lyeSolution = (causticSodaNaoh + causticSodaKoh) / (causticSodaNaoh + causticSodaKoh + _distilledWater);
                _lyeSolutionWeight = causticSodaNaoh + causticSodaKoh + _distilledWater;
                _totalBatchWeight = TT + (koh + naoh) + _distilledWater + _WaterSubstitution + Fragrance;



                finalResult.TotalBatchWeight = _totalBatchWeight.ToString();
                var edec = 85;
            }

   
        }

        public async Task SelectOil(object context, bool waitUntilClosed = false)
        {
          
            string Percent=""; double Number=1.0;
            string _Weight="";
            var xxx = OilsPicker.Items[OilsPicker.SelectedIndex].ToString();
            var item = OilsPicker.SelectedItem as OilObject;

            if (SelectedOil.Count < 15)
            {


                if (OilsPicker.SelectedIndex != -1)
                {
                    var myPopup = new Page3 { BindingContext = context };
                    await PopupNavigation.Instance.PushAsync(myPopup);
                    if (waitUntilClosed)
                        await myPopup.PopupClosedTask;
               
                    var x = Application.Current.Properties["Value"].ToString(); 

                    if (Application.Current.Properties["WtPerRadio"].ToString()=="0")
                    {
                        Percent = Application.Current.Properties["Value"].ToString();
                        Number = double.Parse(Percent);
                        Number = Number * 4;
                        _Weight = Number.ToString();
                        item.PercentageValue = Percent;
                        item.WeightValue = _Weight;
                        counter = counter + 1;
                        item.MyID = counter;


                    }
                    else 
                    {
                        _Weight= Application.Current.Properties["Value"].ToString();
                        Number = double.Parse(_Weight);
                        Number = Number / 5;
                        Percent = Number.ToString();
                        item.PercentageValue = Percent;
                        item.WeightValue = _Weight;
                        counter = counter + 1;
                        item.MyID = counter;
                    }



                    
                  
                    

                    SelectedOil.Add(item);

                    TotaGrams.Text = Clc.TotalOilsGram(SelectedOil).ToString()+"G";
                    TotalPercent.Text = Clc.TotalOilPercent(SelectedOil).ToString()+"%";
                  MyList = new ObservableCollection<OilObject>(SelectedOil);
                    LLL.ItemsSource = MyList;
                    OilsPicker.SelectedIndex = -1;
                    GetAll();
                }


            }
            else await DisplayAlert("", "", "ok");

            

        }


       
        // Stack layout Is visible //

        private void Button1(object sender, EventArgs e,Page1 x)
        {
            if (First.IsVisible == false)
            {
                First.IsVisible = true;
               
                Bt1.Image = "Menu.png";
              //  First.FadeTo(1, 1000);
            }
            else
            {
                First.IsVisible = false;
                Bt1.Image = "Slide2.png";
              //  First.FadeTo(0, 50);
            }
        }
        private void Button2(object sender, EventArgs e, Page1 x)
        {
            if (Seconde.IsVisible == false)
            {
                Seconde.IsVisible = true;
                Bt2.Image = "Menu.png";
               // Seconde.FadeTo(1, 1000);
            }
            else
            {
                Seconde.IsVisible = false;
                Bt2.Image = "Slide2.png";
           //     Seconde.FadeTo(0, 50);
            }
           
        }
        private void Button3(object sender, EventArgs e, Page1 x)
        {
            if (Third.IsVisible == false)
            {
                Third.IsVisible = true;
                Bt3.Image = "Menu.png";

              //  Third.FadeTo(1, 1000);
             
             
            }
            else
            {
                Third.IsVisible = false;
                Bt3.Image = "Slide2.png";

              //  Third.FadeTo(0, 50);


            }
        }
        private void Button4(object sender, EventArgs e, Page1 x)
        {
            if (Fourth.IsVisible == false)
            {
                Fourth.IsVisible = true;
                Bt4.Image = "Menu.png";
            }
            else
            {
                Fourth.IsVisible = false;
                Bt4.Image = "Slide2.png";
            }

        }

        private void Button5(object sender, EventArgs e)
        {
            if (Fifth.IsVisible == false)
            {
                Fifth.IsVisible = true;
                Bt5.Image = "Menu.png";
            }

            else
            {
                Fifth.IsVisible = false;
                Bt5.Image = "Slide2.png";
            }

        }
        private void Button6(object sender, EventArgs e)
        {
            if (Sixth.IsVisible == false)
            {
                Sixth.IsVisible = true;
                Bt6.Image = "Menu.png";
            }
            else
            {
                Sixth.IsVisible = false;
                Bt6.Image = "Slide2.png";
            }

        }
        // Stack layout Is visible //



        private async void Calc ( object sender ,EventArgs e )
        {
            TotalGrams = 0;
            
            foreach (var item in SelectedOil)
            {
             
                TotalGrams = TotalGrams + double.Parse(item.WeightValue);
            }
            // First Table Results {Quality Summary}
            finalResult.Hardness =  Clc.Hardness(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Cleansing = Clc.Cleansing(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Bubbly = Clc.Bubbly(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Conditioning = Clc.Conditioning(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Creamy = Clc.Creamy(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Silky = Clc.Silky(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Longevity = Clc.Longevity(SelectedOil, TotalGrams, SuperFat.Text).ToString();
             finalResult.Comedogenic = Clc.Comedogenic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Iodine = Clc.Iodine(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.INS = Clc.INS(SelectedOil, TotalGrams, SuperFat.Text).ToString();

            // Seconde Table Results {Fatty Acid Summary}

            finalResult.Lauric = Clc.Lauric(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Myristic = Clc.Myristic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Palmitic = Clc.Palmitic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Stearic = Clc.Stearic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
           finalResult.Ricinoleic = Clc.Ricinoleic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Oleic = Clc.Oleic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Linoleic = Clc.Linoleic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Linolenic = Clc.Linolenic(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Saturated = Clc.Saturated(SelectedOil, TotalGrams, SuperFat.Text).ToString();
            finalResult.Unsaturated = Clc.Unsaturated(SelectedOil, TotalGrams, SuperFat.Text).ToString();

            //Third Table {Recipe Summary}
           
            finalResult.MoldCapacity = Result.ToString()+" " + Clc.RadioUnit(Application.Current.Properties["RadioUnit"].ToString()) ;
            //finalResult.TotalBatchWeight;
            // finalResult.TotalOilWeight;
            finalResult.LyeDiscountSuperfat = SuperFat.Text;
            finalResult.LyeConcentration = LyeConcen.Text;
            finalResult.WaterDiscount = Clc.EmtyEntry(WaterDis.Text); 
            finalResult.WaterSubstitution = Clc.EmtyEntry(WaterSub.Text);
            finalResult.DualLyeNaOH = Clc.EmtyEntry(Naoh.Text);
            finalResult.DualLyeNaOH = Clc.EmtyEntry(KOh.Text);
            finalResult.Fragrance = Frag.Text;
            //Fourth Table {Lye}

           
            NaohKoh();
            var xxx = 0;


            await Navigation.PushAsync( new SoapResult());
        }


        public void DeleteOil( object sender ,EventArgs e )
        {

            var oil = (Image)sender;

            int ClassID = Int32.Parse(oil.ClassId);
            var item = SelectedOil.Single(r=>r.MyID==ClassID);
            SelectedOil.Remove(item);
            TotaGrams.Text = Clc.TotalOilsGram(SelectedOil).ToString() + "G";
            TotalPercent.Text = Clc.TotalOilPercent(SelectedOil).ToString() + "%";
            MyList = new ObservableCollection<OilObject>(SelectedOil);
            LLL.ItemsSource = MyList;
            OilsPicker.SelectedIndex = -1;
            
       
        }
        public  void Visit()
        {
             Device.OpenUri(new Uri("https://mysoapcalc.com/"));
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
                {

                    var result = await this.DisplayAlert("Close App", "Do you want to really exit", "Yes", "No");
                    if (result)
                    {
                        var closer = DependencyService.Get<ICloseApplication>();
                        closer.closeApplication();
                    }

                });
            return true;
        }

    }
}



