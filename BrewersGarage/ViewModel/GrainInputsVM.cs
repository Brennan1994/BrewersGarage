using BrewersGarage.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;

namespace BrewersGarage.ViewModel
{
    public class GrainInputsVM : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;//

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public IEnumerable GetErrors(string propertyName)//
        {
            if (propertyName.Equals(nameof(GrainTemp)))
            {
                return _errors;
            }
            return null;
        }

        private List<string> _errors = new List<string>();

        private GrainInputs _grainInputs = new Model.GrainInputs();
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
                _errors = new List<string>();

                _grainInputs.GrainTemp = value;
                if (_grainInputs.GrainTemp > 120)
                {
                    _errors.Add("That's Pretty High. Are you sure that's right?");
                    
                }
                else if (_grainInputs.GrainTemp < 0)
                {
                    _errors.Add("Grain too cold");
                }
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

        public bool HasErrors
        {
            get
            {
                return _errors.Count != 0;
            }
        }

    }
}
