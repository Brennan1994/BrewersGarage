using System.Windows;
using BrewersGarage.ViewModel;

namespace BrewersGarage.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public GrainBill GrainBillObj { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GrainBillObj = new GrainBill();
            DataContext = GrainBillObj;
        }
    }

}
