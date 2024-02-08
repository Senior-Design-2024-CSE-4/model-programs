namespace DataGeneration
{
    public abstract class AbstractDataGenerator<T>
    {
        private double update_time;
        private readonly int seed;
        protected readonly Random rand;

        private DateTime _last_frame = DateTime.Now;

        public event EventHandler<EventArgs<T>> DataGenerated;
        
        public AbstractDataGenerator(double hz)
        {
            this.update_time = 1.0 / hz;
            this.seed = new Random().Next();
            this.rand = new Random(this.seed);
        }

        public AbstractDataGenerator(double hz, int seed)
        {
            this.update_time = 1.0 / hz;
            this.seed = seed;
            this.rand = new Random(seed);
        }
        
        public abstract T GenerateNewData();

        public void StartGenerator()
        {
            while (true) {
                DateTime current_time = DateTime.Now;
                if ((current_time - _last_frame).TotalSeconds >= update_time)
                {
                    T data = GenerateNewData();
                    OnDataGenerated(new EventArgs<T>(data));
                    _last_frame = current_time;
                }
            }
        }

        public virtual void OnDataGenerated(EventArgs<T> e)
        {
            DataGenerated?.Invoke(this, e);
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