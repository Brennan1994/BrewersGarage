using BrewersGarage.ViewModel;
using BrewersGarage.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrainTest
{
    [TestClass]
    public class GrainTest
    {

        private GrainInputsVM _grainInputs = new GrainInputsVM() { BoilVol = 8, GrainTemp = 70, GrainWeight = 11, Ratio = 1.5f, TargetMashTemp = 156 };
        private GrainOutputsVM _grainOutputs = new GrainOutputsVM();



        [TestMethod]
        public void TestGrainBillOutputAccuracy()
        {
            _grainOutputs.GrainOutput = GrainCompute.Calculate(_grainInputs.GrainInputs);
            Assert.AreEqual(167.159772911598, _grainOutputs.StrikeTemp);
            Assert.AreEqual(4.125, _grainOutputs.StrikeWaterVol);
            Assert.AreEqual(5.25, _grainOutputs.SpargeVol);
        }

        public void TestIntermediateMethods()
        {
            Assert.AreEqual(null, GrainCompute.CalcStrikeTemp(_grainInputs.GrainInputs));
        }

    }
}
