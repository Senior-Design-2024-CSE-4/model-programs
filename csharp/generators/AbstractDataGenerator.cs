namespace DataGeneration
{
    public abstract class AbstractDataGenerator<T>
    {
        private int hz;
        private readonly int seed;
        protected readonly Random rand;

        public event EventHandler<EventArgs<T>> NumberGenerated;
        
        public AbstractDataGenerator(int hz)
        {
            this.hz = hz;
            this.seed = new Random().Next();
            this.rand = new Random(this.seed);
        }

        public AbstractDataGenerator(int hz, int seed)
        {
            this.hz = hz;
            this.seed = seed;
            this.rand = new Random(seed);
        }
        
        public abstract T GenerateNewData();

        public void StartGenerator()
        {
            T data = GenerateNewData();
            OnNumberGenerated(new EventArgs<T>(data));
            return;
        }

        public virtual void OnNumberGenerated(EventArgs<T> e)
        {
            NumberGenerated?.Invoke(this, e);
        }
    }

    public class EventArgs<T>: EventArgs
    {
        public T Value {get; private set;}

        public EventArgs(T val)
        {
            Value = val;
        }
    }
}