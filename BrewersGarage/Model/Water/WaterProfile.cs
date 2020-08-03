using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersGarage.Model.Water
{
    class WaterProfile
    {
        private float Volume { get; set; }
        private float Calcium { get; set; }
        private float Bicarbonate { get; set; }
        private float AlkAsCalciumCarbonate { get; set; }
        private float Sulfate { get; set; }
        private float Chloride { get; set; }
        private float Magnesium { get; set; }
        private float ResidualAlk { get; set; }
        private float SulfateToChlorideRatio { get; set; }
        private float PH { get; set; }
        private float TargetAlkAsCalciumCarbonate { get; set; }
    }
}
