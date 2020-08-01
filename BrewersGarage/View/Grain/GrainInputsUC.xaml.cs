using System.Windows;
using System.Windows.Controls;

namespace BrewersGarage.View
{
    /// <summary>
    /// Interaction logic for GrainInputsUC.xaml
    /// </summary>
    public partial class GrainInputsUC : UserControl
    {
        public GrainInputsUC()
        {
            InitializeComponent();
        }
        private void SelectText(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {tb.SelectAll();}
        }
    }
}
