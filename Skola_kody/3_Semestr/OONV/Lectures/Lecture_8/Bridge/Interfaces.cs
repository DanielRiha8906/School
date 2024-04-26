namespace Bridge
{
    interface ITemperatureDisplay // Abstraction interface
    {
        void Display();
    }
    interface ITemperatureSource // Implementation interface
    {
        double Temperature { get; } // Display the Temperature in Celsius scale -> °C
    }
    interface ITemperatureConverter //Abstraction interface numero duo
    {
        (double value, string unit) Convert(double temp);//Tuple<double,string> wouldn't display names
    }
}
