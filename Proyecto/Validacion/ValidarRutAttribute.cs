using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Proyecto.Validacion
{
    public class ValidarRutAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var rut = value.ToString();
            var resultado = ValidarRut(rut);
            return resultado;
        }
        public static ValidationResult ValidarRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return new ValidationResult($"Rut Invalido");
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return new ValidationResult($"Rut Incorrecto");
            }
            return ValidationResult.Success;
        }
        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
    }
    public class ValidaFechaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _minDate = DateTime.Today.AddYears(-120);
            if (value is DateTime dateValue)
            {
                if (dateValue < _minDate)
                {
                    return new ValidationResult($"La fecha no puede ser menor a {_minDate.ToShortDateString()}.");
                }
            }

            return ValidationResult.Success;
        }
    }
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeraletra = value.ToString()[0].ToString();
            if (primeraletra != primeraletra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayuscula");
            }
            return ValidationResult.Success;
        }
    }
}
