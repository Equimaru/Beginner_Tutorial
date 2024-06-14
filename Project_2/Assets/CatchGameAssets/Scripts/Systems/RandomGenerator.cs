using System;
using Random = UnityEngine.Random;

namespace Catch
{
    public class RandomGenerator
    {
        private int[] _indexes;
        private float[] _probabilities;

        private RandomSelection[] selections;
        
        public struct RandomSelection
        {
            private readonly int _value;
            public float probability;

            public RandomSelection(int value, float probability)
            {
                _value = value;
                this.probability = probability;
            }

            public int GetValue()
            {
                return _value;
            }
        }

        public RandomGenerator(int[] indexes, float[] probabilities)
        {
            _indexes = indexes;
            _probabilities = probabilities;
            
            selections = new RandomSelection[_indexes.Length];
            foreach (int i in _indexes)
            {
                selections[i] = new RandomSelection(_indexes[i], _probabilities[i]);
            }
        }

        public int GetRandomResult()
        {
            float rand = Random.value;
            float currentProb = 0;

            foreach (var selection in selections)
            {
                currentProb += selection.probability;
                if (rand <= currentProb)
                {
                    return selection.GetValue();
                }
            }

            throw new ArgumentException("Impossible probability calculation");
        }
    }
}

