using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Soap.Models
{
    class Calculation
    {


        double SelecktedValue = 0.0;
        double Total1 = 0.0;
        double Total2 = 0.0;
        double Final = 0.0;

       public double TotalOilsGram (List<OilObject> oil)
        {
             SelecktedValue = 0.0;
             Total1 = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue);
                Total1 += SelecktedValue;

            }
            return Total1;
        }
        public double TotalOilPercent(List<OilObject> oil)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
           
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.PercentageValue);
                Total1 += SelecktedValue;

            }
            return Total1;
        }


        // first table { Quality Summary}
        public double Hardness(List<OilObject> oil, double TotalGram, string SuperFat)
        {

            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.hardness);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);
            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));
            return Final;
        }
        public double Cleansing(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.cleansing_lather);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Final;
        }
        public double Conditioning(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.conditioning_lather);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 + double.Parse(SuperFat)) * 0.01));

            return Final;
        }
        public double Bubbly(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.bubbly);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Final;
        }
        public double Creamy(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.creamy_lather);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Final;
        }
        public double Silky(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.silky_feel);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Final;
        }
        public double Longevity(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.longevity);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            //  Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }
        public double Comedogenic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.comedogenic_rating);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Final;
        }

        public double Iodine(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.Iodine);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }
        public double INS(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.ins);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }


        //Second table {Fatty Acid Summary}
        public double Lauric(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.lauric_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }
        public double Myristic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.myristic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }
        public double Palmitic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.palmitic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }

        public double Stearic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.stearic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }

        public double Ricinoleic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.ricinoleic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }


        public double Oleic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.oleic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }

        public double Linoleic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.linoleic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }
        public double Linolenic(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.linolenic_acid);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }

        public double Saturated(List<OilObject> oil, double TotalGram, string SuperFat)
        {
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.saturated_fatty_acids);
                Total1 += SelecktedValue;
            }
            Total2 = Math.Round(Total1 / TotalGram);

            // Final = Math.Round((Total2 * (100 - double.Parse(SuperFat)) * 0.01));

            return Total2;
        }


        public double Unsaturated(List<OilObject> oil, double TotalGram, string SuperFat)
        {

            //unsaturated = (100 - saturated_fatty_acids) >= 0 ? (100 - saturated_fatty_acids) : 0,
            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;


            Total1 = (100 - Saturated(oil, TotalGram, SuperFat));
            if (Total1 >= 0) return Total1;


            return Final;
        }

        // Third Tabl{Recipe Summary}

        public String RadioUnit(string unit)
        {
            if (Application.Current.Properties["RadioUnit"].ToString() == "0") return "g";
            else if (Application.Current.Properties["RadioUnit"].ToString() == "1") return "KG";
            else if (Application.Current.Properties["RadioUnit"].ToString() == "2") return "OZ";
            else if (Application.Current.Properties["RadioUnit"].ToString() == "3") return "lbs";
            return "";
        }
        public string EmtyEntry(string text)
        {
            if (text == "") return "0";
            return text;
        }

        public double NaOH(List<OilObject> oil, string SuperFat, string naoh)
        {

            SelecktedValue = 0.0;
            Total1 = 0.0;
            Total2 = 0.0;
            Final = 0.0;
            foreach (var item in oil)
            {
                SelecktedValue = double.Parse(item.WeightValue) * double.Parse(item.naoh_g);
                Total1 += SelecktedValue;
            }

            Final = Total1 * ((100 - double.Parse(SuperFat)) / double.Parse(naoh));

            return Final;
        }


        // Fourth Table {Lye}

        public double CausticSodaNaOH(List<OilObject> oil, string SuperFat, string naoh)

        {
            Final = 0.0;
            Final = NaOH(oil, SuperFat, naoh) * (double.Parse(naoh) / 100);

            return Final;
        }
    }

}
