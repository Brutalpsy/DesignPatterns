using System;
using System.Net.Mail;

namespace Facade.Services
{
    public class ConverterService
    {
        public int ConvertFahrenheitToCelcious(int fahrenheit)
        {
            // int celsius = (fahrenheit * 9) / (5 + 32);
            double celsius = (5.0 / 9.0) * (fahrenheit - 32);
            
            return (int) celsius;
        }
    }
}