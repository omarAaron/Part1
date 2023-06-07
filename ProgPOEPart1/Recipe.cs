using System.Collections.Generic;

namespace ProgPOEPart2
{
    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> steps { get; set; }
    }
}