using BrewersGarage.Model;
using System;
using System.ComponentModel;

namespace BrewersGarage.ViewModel
{
    public class GrainInputsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        

        private Model.GrainInputs _grainInputs = new Model.GrainInputs();
        public float GrainWeight
        {
            get { return _grainInputs.GrainWeight; }
            set
            {
                _grainInputs.GrainWeight = value;
                OnPropertyChanged(nameof(GrainWeight));
            }
        }
        public float TargetMashTemp
        {
            get { return _grainInputs.TargetMashTemp; }
            set
            {
                _grainInputs.TargetMashTemp = value;
                OnPropertyChanged(nameof(TargetMashTemp));
            }
        }
        public float GrainTemp
        {
            get { return _grainInputs.GrainTemp; }
            set
            {
                _grainInputs.GrainTemp = value;
                OnPropertyChanged(nameof(GrainTemp));
            }
        }
        public float Ratio
        {
            get { return _grainInputs.Ratio; }
            set
            {
                _grainInputs.Ratio = value;
                OnPropertyChanged(nameof(Ratio));
            }
        }
        public float BoilVol
        {
            get { return _grainInputs.BoilVol; }
            set
            {
                _grainInputs.BoilVol = value;
                OnPropertyChanged(nameof(BoilVol));
            }
        }

        internal GrainInputs GrainInputs
        {
            get
            {
                return _grainInputs;
            }
        }
    }
}
