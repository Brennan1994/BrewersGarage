
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

        //Output Properties
        public float StrikeWaterVol
        {
            get{return _grainOutputs.StrikeVol;}
        }
        public float StrikeTemp
        {
            get{return _grainOutputs.StrikeTemp;}
        }
        public float SpargeVol
        {
            get { return _grainOutputs.SpargeVol; }
        }

        //Input Properties
        public float GrainWeight
        {
            get { return _grainInputs.GrainWeight; }
            set
            {
                _grainInputs.GrainWeight = value;
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
        public float TargetMashTemp
        {
            get{return _grainInputs.TargetMashTemp;}
            set
            {
                _grainInputs.TargetMashTemp = value;
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
        public float GrainTemp
        {
            get { return _grainInputs.GrainTemp; }
            set
            {
                _grainInputs.GrainTemp = value;
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
        public float Ratio
        {
            get { return _grainInputs.Ratio; }
            set
            {
                _grainInputs.Ratio = value;
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
        public float BoilVol
        {
            get { return _grainInputs.BoilVol; }
            set
            {
                _grainInputs.BoilVol = value;
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
    }
}









