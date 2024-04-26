namespace Bridge
{
    class CelsiusConverter: ITemperatureConverter
    {
       public (double value, string unit) Convert(double temp) => (temp, "°C");
    }
    class KelvinConverter: ITemperatureConverter
    {
        public (double value, string unit) Convert(double temp) => (temp+273.16, "°C");
    }
}   