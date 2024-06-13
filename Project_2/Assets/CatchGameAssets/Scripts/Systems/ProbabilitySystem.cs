using UnityEngine;

namespace Catch
{
    public class ProbabilitySystem : MonoBehaviour
    {
        private struct RandomSelection
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

        public int IDontKnowHowToNameIt(int arraySize)
        {
            return 0;
        }
    }
}

