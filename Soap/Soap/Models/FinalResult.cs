using System;
using System.Collections.Generic;
using System.Text;

namespace Soap.Models
{
   public  class FinalResult
    {

        // First table {Quality Summary}
        public string Hardness { get; set; }
        public string Cleansing { get; set; }
        public string Bubbly { get; set; }
        public string Conditioning { get; set; }
        public string Creamy { get; set; }
        public string Silky { get; set; }
        public string Longevity { get; set; }
        public string Comedogenic { get; set; }
        public string Iodine { get; set; }

        public string INS { get; set; }


        // Seconde tabel {Fatty Acid Summary}
        public string Lauric { get; set; }
        public string Myristic { get; set; }
        public string Palmitic { get; set; }
        public string Stearic { get; set; }
        public string Ricinoleic { get; set; }
        public string Oleic { get; set; }
        public string Linoleic { get; set; }
        public string Linolenic { get; set; }
        public string Saturated { get; set; }
        public string Unsaturated { get; set; }

        //{ Third table {Recipe Summary}

        public string MoldCapacity { get; set; }
        public string TotalBatchWeight { get; set; }
        public string TotalOilWeight { get; set; }
        public string LyeDiscountSuperfat { get; set; }
        public string LyeConcentration{ get; set; }
        public string DualLyeNaOH  { get; set; }
        public string DualLyeKOH { get; set; }
        public string WaterDiscount { get; set; }
        public string WaterSubstitution { get; set; }
        public string Fragrance { get; set; }
        // Fourth Table {Lye}

        public string CausticSodaNaOH { get; set; }
        public string CausticPotashKoH { get; set; }
        public string DistilledWater { get; set; }
        public string SubstitutedLiquidID { get; set; }
        public string LyeSolution_LyeWater { get; set; }





    }

}
