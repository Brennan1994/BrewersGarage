using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewersGarage.Model.Hops
{
    class Hop
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public float AlphaAcid { get; set; }

        /// <summary>
        /// Increases or Decreases actual hop amounts based on proportion of alpha acid between actual incredients and recipe.
        /// </summary>
        public void ConvertHopsWithProportion(Hop recipeHop)
        {
            float adjustedWeight = Weight / AlphaAcid * recipeHop.AlphaAcid;
            Weight = adjustedWeight;
        }
    }
}
