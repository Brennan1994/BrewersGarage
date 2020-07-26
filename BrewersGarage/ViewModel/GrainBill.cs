using System.ComponentModel;

namespace BrewersGarage.ViewModel
{
    public class GrainBill : INotifyPropertyChanged
    {
        private ViewModel.GrainInputsVM _grainInputs = new ViewModel.GrainInputsVM();
        private ViewModel.GrainOutputsVM _grainOutputs = new ViewModel.GrainOutputsVM();

        public GrainBill()
        {
            _grainInputs.PropertyChanged += _grainInputs_PropertyChanged;
        }

        private void _grainInputs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _grainOutputs.grainOutput = Model.Compute.Calculate(((ViewModel.GrainInputsVM)sender).GrainInputs);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModel.GrainInputsVM GrainInputs
        {
            get { return _grainInputs; }
        }
        public ViewModel.GrainOutputsVM GrainOutputs
        {
            get { return _grainOutputs; }
        }
    }
}





