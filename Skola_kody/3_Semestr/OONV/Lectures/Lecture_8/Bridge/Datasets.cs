namespace Bridge
{
    class ConstantTemperatureSource: ITemperatureSource
    {
        public ConstantTemperatureSource(double temp) => this.Temperature = temp;
        public double Temperature {get; private set;}
    }
    class RandomTemperatureSource: ITemperatureSource
    {   public double Max {get;set;}
        public double Min {get;set;}
        private Random r = new Random();
        public RandomTemperatureSource(double min, double max){Min=min; Max=max;}
        public double Temperature {get => (Max- Min)*r.NextDouble() + Min;}
    }
}