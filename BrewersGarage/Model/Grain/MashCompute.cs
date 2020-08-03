namespace BrewersGarage.Model
{
    public class MashCompute
    {
        public static MashOutput Calculate(MashInputs grainInputs)
        {
            MashOutput ret = new MashOutput
            {
                StrikeTemp = CalcStrikeTemp(grainInputs),
                StrikeVol = CalcStrikeVolume(grainInputs),
                SpargeVol = CalcSpargeWaterVolume(grainInputs)
            };
            return ret;
        }
        public static float CalcStrikeTemp(MashInputs grainInputs)
        {
            //from John Palmer's How to Brew III edition pg 266,268
            float roe = 2.055F; // This value is the average density of water across the reasonable range of mash temperatures in lb/qt
            float s = 0.4F; // This is the heat capacity of grain relative to water 
            float R = (grainInputs.Ratio * roe); //weight per weight ratio water per grist

            float strikeT = ((s / R) * (grainInputs.TargetMashTemp - grainInputs.GrainTemp) + grainInputs.TargetMashTemp);
            return strikeT;
        }
        public static float CalcRetainedWater(MashInputs grainInputs)
        {
            float r = 0.5F; // This is the wet retention factor for grist in quarts per pound.
            float retainedVol = r * grainInputs.GrainWeight / 4;
            return retainedVol;
        }
        public static float CalcStrikeVolume(MashInputs grainInputs)
        {
            float vol = (grainInputs.GrainWeight * grainInputs.Ratio) / 4;
            return vol;
        }
        public static float CalcSpargeWaterVolume(MashInputs grainInputs)
        {
            // This method does not use .5 * boil volume just in case the user opts out of the equal runnings goal.
            float spargeVol = grainInputs.BoilVol - CalcStrikeVolume(grainInputs) + CalcRetainedWater(grainInputs);
            return spargeVol;
        }
        public static float CalcRatioForBatchSparge(MashInputs grainInputs)
        {
            float ratio = ((grainInputs.BoilVol * 4 / 2) + CalcRetainedWater(grainInputs)) / grainInputs.GrainWeight;
            return ratio;
        }
    }
}