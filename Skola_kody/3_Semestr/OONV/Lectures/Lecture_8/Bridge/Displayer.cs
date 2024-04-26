namespace Bridge
{
    class ConsoleDisplay : ITemperatureDisplay
    {   
        private ITemperatureConverter converter;
        private ITemperatureSource source;
        public ConsoleDisplay(ITemperatureConverter converter, ITemperatureSource source)
        {
            this.converter = converter;
            this.source = source;
        }
        public void Display()
        {   
            //var (value, unit) = converter.Convert(source.Temperature); alternative solution
           var result = converter.Convert(source.Temperature);
           Console.WriteLine($"{result.value} {result.unit}");
    }
}
}