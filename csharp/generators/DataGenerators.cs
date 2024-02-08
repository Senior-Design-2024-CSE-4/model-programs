namespace DataGeneration
{
    public class IntGenerator: AbstractDataGenerator<int>
    {
        public IntGenerator(double hz): base(hz) {}

        public IntGenerator(double hz, int seed): base(hz, seed) {}
        
        public override int GenerateNewData()
        {
            return rand.Next();
        }
    }
}