﻿namespace BrewersGarage.Model
{
    class GrainInputs
    {
        //Input Properties
        private float _grainWeight=0;
        private float _targetMashTemp = 0;
        private float _grainTemp = 0;
        private float _ratio = 0;
        private float _boilVol = 0;
        public float GrainWeight
        {
            get { return _grainWeight; }
            set {_grainWeight = value;}
        }
        public float TargetMashTemp
        {
            get { return _targetMashTemp; }
            set {_targetMashTemp = value; }
        }
        public float GrainTemp
        {
            get { return _grainTemp; }
            set {_grainTemp = value; }
        }
        public float Ratio
        {
            get{ return _ratio;}
            set{_ratio = value;}
        }
        public float BoilVol
        {
            get { return _boilVol; }
            set { _boilVol = value; }
        }
    }
}
