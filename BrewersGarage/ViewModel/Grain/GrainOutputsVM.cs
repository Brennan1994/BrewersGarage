﻿using System.ComponentModel;
namespace BrewersGarage.ViewModel
{
    public class GrainOutputsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private Model.MashOutput _grainOutputs = new Model.MashOutput();
        //Output Properties
        public float StrikeWaterVol
        {
            get { return _grainOutputs.StrikeVol; }
        }
        public float StrikeTemp
        {
            get { return _grainOutputs.StrikeTemp; }
        }
        public float SpargeVol
        {
            get { return _grainOutputs.SpargeVol; }
        }
        public Model.MashOutput GrainOutput
        {
            set { _grainOutputs = value;
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
                OnPropertyChanged(nameof(SpargeVol));
            }
        }
    }
}
