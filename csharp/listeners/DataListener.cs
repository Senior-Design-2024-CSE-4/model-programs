namespace DataGeneration
{
    public class DataListener<T>
    {
        private readonly List<AbstractDataGenerator<T>> _generators;

        private double _fps_window = 1.0;
        private DateTime _last_update = DateTime.Now;
        private int _frame_counter = 0;

        public DataListener()
        {
            _generators = new List<AbstractDataGenerator<T>>();
        }

        public void AddGenerator(AbstractDataGenerator<T> generator)
        {
            _generators.Add(generator);
            generator.DataGenerated += HandleDataGenerated;
        }

        private void HandleDataGenerated(object sender, EventArgs<T> e)
        {
            if (sender is AbstractDataGenerator<T> generator)
            {
                _frame_counter++;
                DateTime current_time = DateTime.Now;
                if ((current_time - _last_update).TotalSeconds >= _fps_window) {

                    Console.WriteLine($"fps: {_frame_counter/_fps_window}");
                    _last_update = current_time;
                    _frame_counter = 0;
                }
            }
        }
    }
}