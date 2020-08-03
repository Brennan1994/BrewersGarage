using BrewersGarage.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace BrewersGarage.ViewModel
{
    public class GrainInputsVM : INotifyPropertyChanged 
    {
        //EVENTS
        //Property Changed fires whenever a property changes.
        public event PropertyChangedEventHandler PropertyChanged;


        //VARIABLES
        private MashInputs _grainInputs = new MashInputs();

        //METHODS
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        //PROPERTIES
        public MashInputs GrainInputs
        {
            get
            {
                return _grainInputs;
            }
        }
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
    }
}
