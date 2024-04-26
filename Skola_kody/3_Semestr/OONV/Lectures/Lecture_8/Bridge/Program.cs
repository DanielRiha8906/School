namespace Bridge
{
    class Program
    {
        public static void Main(string[] args)
        {
         ITemperatureDisplay display = new ConsoleDisplay(new KelvinConverter(), new RandomTemperatureSource(0,10));
         display.Display();
        }
    }
}