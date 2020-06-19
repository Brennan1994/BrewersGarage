using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BrewersGarage
{
     class GrainBill : INotifyPropertyChanged
    {
        //properties
        public double DryGrainTemp { get; set; }
        public double TargetTemp { get; set; }
        public double BoilVol { get; set; }
        public double GrainWeight { get; set; }
        public double Ratio { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //methods
        double calcStrikeTemp()
        {
            //from John Palmer's How to Brew pg 266,268
            double r = 2.055; // This value is the average density of water across the reasonable range of mash temperatures in lb/qt
            double s = 0.4; // This is the heat capacity of grain relative to water 
            double strikeT = ((s / r) * (TargetTemp - DryGrainTemp)) + TargetTemp;
            return strikeT;
        }

        double calcRetainedWater()
        {
            double r = 0.5; // This is the wet retention factor for grist in quarts per pound.
            double retainedVol = r * GrainWeight;
            return retainedVol;
        }

        double calcStrikeVolume()
        {
            double vol = GrainWeight * Ratio;
            return vol;
        }

        double calcRatioForBatchSparge(double retainedVol)
        {
            Ratio = ((BoilVol * 4 / 2) + retainedVol) / GrainWeight;
            return Ratio;
        }

        double calcSpargeWaterVolume(double strikeVolume, double retainedVol)
        {
            // This method does not use .5 * boil volume just in case the user opts out of the equal runnings goal.
            double spargeVol = BoilVol - (strikeVolume - retainedVol) / 4;
            return spargeVol;
        }

        double calcAdjustedHopWeights(double recipeOz, double recipeAcid, double myAcid)
        {
            double myOz = recipeOz * recipeAcid / myAcid;
            return myOz;
        }
    }
}
