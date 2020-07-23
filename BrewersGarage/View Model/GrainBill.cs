
using System.ComponentModel;

namespace BrewersGarage
{
    public class GrainBill : INotifyPropertyChanged
    {
        private Model.GrainInputs _grainInputs = new Model.GrainInputs();
        private Model.GrainOutput _grainOutputs = new Model.GrainOutput();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {

            _grainOutputs = Model.Compute.compute(_grainInputs);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

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
                OnPropertyChanged(nameof(SetRatio));
            }
        }
        //Output Properties
        private float strikeWaterVol;
        public float StrikeWaterVol
        {
            get
            {
                strikeWaterVol = _grainOutputs.StrikeVol;
                return strikeWaterVol;

            }

        }
        private float strikeTemp;
        public float StrikeTemp
        {
            get
            {
                strikeTemp = _grainOutputs.StrikeTemp;
                return strikeTemp;

            }
        }
        private float spargeVol;
        public float SpargeVol
        {
            get
            {
                spargeVol = _grainOutputs.SpargeVol;
                return spargeVol;
            }
        }




        //Input Properties
        public float GrainWeight
        {
            get { return _grainInputs.GrainWeight; }
            set
            {
                _grainInputs.GrainWeight = value;
                OnPropertyChanged("GrainWeight");

            }
        }
        public float TargetMashTemp
        {
            get
            {
                return _grainInputs.TargetMashTemp;
            }
            set
            {
                _grainInputs.TargetMashTemp = value;
                OnPropertyChanged("TargetMashTemp");

            }
        }
        public float GrainTemp
        {
            get { return _grainInputs.GrainTemp; }
            set
            {
                _grainInputs.GrainTemp = value;
                OnPropertyChanged("GrainTemp");

            }
        }
        //public float Ratio
        //{
        //    get
        //    {
        //        if (!setRatio)
        //        {
        //            ratio = CalcRatioForBatchSparge().ToString();
        //            return ratio;
        //        }
        //        else
        //        {
        //            return ratio;
        //        }
        //    }
        //    set
        //    {
        //            bool res = float.TryParse(value, out _);
        //            if (res) ratio = value;
        //            OnPropertyChanged("Ratio");
        //            OnPropertyChanged("StrikeWaterVol");
        //            OnPropertyChanged("StrikeTemp");
        //    }
        //}
        public float BoilVol
        {
            get { return _grainInputs.BoilVol; }
            set
            {
                _grainInputs.BoilVol = value;
                OnPropertyChanged("BoilVol");
            }
        }
    }
}





//        float CalcRatioForBatchSparge()
//        {
//            float ratio = ((float.Parse(boilVol) * 4 / 2) + float.Parse(RetainedVol)) / float.Parse(grainWeight);
//            return ratio;
//        }
//    }


