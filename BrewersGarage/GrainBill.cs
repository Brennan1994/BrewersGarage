using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Automation.Peers;
using System.Windows.Documents;

namespace BrewersGarage
{
    public class GrainBill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        }
        //Equal Runnings or no?

       

        //outputs
        private string strikeWaterVol;
        private string strikeTemp;
        private string spargeVol;

        //inputs
        private string grainWeight;
        private string targetMashTemp;
        private string grainTemp;

        //inputs-outputs
        private string boilVol;
        private string ratio;

        //Analysis Controls
        private bool setRatio;
        public bool SetRatio
        {
            get
            {
                return setRatio;
            }
            set
            {
                setRatio = value;
                OnPropertyChanged("SetRatio");
            }
        }
        //Output Properties
        public string StrikeWaterVol
        {
            get
            {
                strikeWaterVol = CalcStrikeVolume().ToString();
                return strikeWaterVol;

            }

        }
        public string StrikeTemp
        {
            get
            {
                strikeTemp = CalcStrikeTemp().ToString();
                return strikeTemp;

            }
        }
        public string SpargeVol
        {
            get
            {
                spargeVol = CalcSpargeWaterVolume().ToString();
                return spargeVol;
            }
        }
        //Input Properties
        public string GrainWeight
        {
            get { return grainWeight; }
            set
            {
                bool res = float.TryParse(value, out _);
                if (res) grainWeight = value;
                RetainedVol = CalcRetainedWater().ToString();
                OnPropertyChanged("RetainedVol");
                OnPropertyChanged("GrainWeight");
                OnPropertyChanged("StrikeWaterVol");
                OnPropertyChanged("SpargeVol");
                OnPropertyChanged("Ratio");
            }
        }

        public string TargetMashTemp
        {
            get { return targetMashTemp; }
            set
            {
                bool res = float.TryParse(value, out _);
                if (res) targetMashTemp = value;
                OnPropertyChanged("TargetMashTemp");
                OnPropertyChanged("StrikeTemp");
            }
        }
        public string GrainTemp
        {
            get { return grainTemp; }
            set
            {
                bool res = float.TryParse(value, out _);
                if (res) grainTemp = value;
                OnPropertyChanged("GrainTemp");
                OnPropertyChanged("StrikeTemp");
            }
        }
        public string Ratio
        {
            get
            {
                if (!setRatio)
                {
                    ratio = CalcRatioForBatchSparge().ToString();
                    return ratio;
                }
                else
                {
                    return ratio;
                }
            }
            set
            {
                    bool res = float.TryParse(value, out _);
                    if (res) ratio = value;
                    OnPropertyChanged("Ratio");
                    OnPropertyChanged("StrikeWaterVol");
                    OnPropertyChanged("StrikeTemp");
            }
        }


        public string RetainedVol { get; private set; }
        public string BoilVol
        {
            get { return boilVol; }
            set
            {
                bool res = float.TryParse(value, out _);
                if (res) boilVol = value;
                OnPropertyChanged("BoilVol");
                OnPropertyChanged("SpargeVol");
                OnPropertyChanged("Ratio");
            }
        }
        public float CalcStrikeTemp()
        {
            //from John Palmer's How to Brew III edition pg 266,268
            float roe = 2.055F; // This value is the average density of water across the reasonable range of mash temperatures in lb/qt
            float s = 0.4F; // This is the heat capacity of grain relative to water 
            float R = (float.Parse(ratio) * roe); //weight per weight ratio water per grist

            float strikeT = ((s / R) * (float.Parse(targetMashTemp) - float.Parse(grainTemp))) + float.Parse(targetMashTemp);
            return strikeT;
        }
        float CalcRetainedWater()
        {
            float r = 0.5F; // This is the wet retention factor for grist in quarts per pound.
            float retainedVol = r * float.Parse(grainWeight) / 4;
            return retainedVol;
        }
        float CalcStrikeVolume()
        {
            float vol = (float.Parse(grainWeight) * float.Parse(ratio)) / 4;
            return vol;
        }
        float CalcSpargeWaterVolume()
        {
            // This method does not use .5 * boil volume just in case the user opts out of the equal runnings goal.
            float spargeVol = float.Parse(boilVol) - (float.Parse(strikeWaterVol) - float.Parse(RetainedVol));
            return spargeVol;
        }
        float CalcRatioForBatchSparge()
        {
            float ratio = ((float.Parse(boilVol) * 4 / 2) + float.Parse(RetainedVol)) / float.Parse(grainWeight);
            return ratio;
        }
    }
}

