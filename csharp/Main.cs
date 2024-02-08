using DataGeneration;

namespace Main
{
    public class ConstantOutputProgram
    {
        static void Main(string[] args)
        {
            IntGenerator generator = new IntGenerator(120);
            DataListener<int> listener = new DataListener<int>();

            listener.AddGenerator(generator);

            generator.StartGenerator();
        }
    }
}