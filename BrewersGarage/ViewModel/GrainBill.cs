using System.ComponentModel;
using System.Linq;

namespace BrewersGarage.ViewModel
{
    public class GrainBill : INotifyPropertyChanged
    {
        private Model.GrainInputs _grainInputs = new Model.GrainInputs();
        private Model.GrainOutput _grainOutputs = new Model.GrainOutput();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            // if the property being changed is not an output (so it's an input), recalculate. Otherwise just update because the model already computed when the input changed
            if (!outputProperties.Contains(property)) 
            {
                _grainOutputs = Model.Compute.compute(_grainInputs);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        //Output Properties
        // an array of the output properties to reference when deciding if a compute is necessary 
        private string[] outputProperties = { nameof(StrikeWaterVol), nameof(StrikeTemp), nameof(SpargeVol) };
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
                OnPropertyChanged(nameof(GrainWeight));
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
                OnPropertyChanged(nameof(TargetMashTemp));
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
                OnPropertyChanged(nameof(GrainTemp));
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
                OnPropertyChanged(nameof(Ratio));
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
                OnPropertyChanged(nameof(BoilVol));
                OnPropertyChanged(nameof(SpargeVol));
                OnPropertyChanged(nameof(StrikeWaterVol));
                OnPropertyChanged(nameof(StrikeTemp));
            }
        }
    }
}









