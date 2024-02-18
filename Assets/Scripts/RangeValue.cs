namespace Balloonatics
{
    [System.Serializable]
    public class RangeValue
    {
        public float Min;
        public float Max;

        public float Range()
        {
            return Max - Min;
        }

        public float Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }
    }
}
