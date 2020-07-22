using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrewersGarage
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
            GrainBillObj = new GrainBill{ Ratio = "0", GrainWeight = "0", BoilVol = "0", GrainTemp = "0", TargetMashTemp = "0"};
            this.DataContext = GrainBillObj;

        }
    }
}
