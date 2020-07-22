using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersGarage.Model
{
    class GrainInputs
    {
        //Input Properties
        private float _grainWeight;
        public float GrainWeight
        {
            get { return _grainWeight; }
            set
            {
                _grainWeight = value;
            }
        }
        private float _targetMashTemp;
        public float TargetMashTemp
        {
            get { return _targetMashTemp; }
            set
            {
                _targetMashTemp = value;
            }
        }
        private float _grainTemp;
        public float GrainTemp
        {
            get { return _grainTemp; }
            set
            {
                _grainTemp = value;
            }
        }
        private float _ratio;
        public float Ratio
        {
            get
            {
                {
                    return _ratio;
                }
            }
            set
            {
                _ratio = value;

            }
        }


        public float RetainedVol { get; private set; }

        private float _boilVol;
        public float BoilVol
        {
            get { return _boilVol; }
            set
            {
                _boilVol = value;
            }
        }
    }
}
