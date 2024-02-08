namespace DataGeneration
{
    public class IntGenerator: AbstractDataGenerator<int>
    {
        public IntGenerator(int hz): base(hz) {}

        public IntGenerator(int hz, int seed): base(hz, seed) {}
        
        public override int GenerateNewData()
        {
            return rand.Next();
        }
    }
}