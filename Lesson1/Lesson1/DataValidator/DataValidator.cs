using System.Text.RegularExpressions;

namespace Lesson1.DataValidator
{
    public static class DataValidator
    {
        public static bool Validate(string parameter, ValidateMethod validateMethod, out string errorMessage)
        {
            switch (validateMethod)
            {
                case ValidateMethod.Name:
                    return CheckNameOrLastname(parameter, out errorMessage);
                
                case ValidateMethod.Age:
                    return CheckAge(parameter, out errorMessage);
                
                case ValidateMethod.None:
                default:
                    errorMessage = "Without validate";
                    return true;
            }
        }

        private static bool CheckNameOrLastname(string name, out string errorMessage)
        {
            if (!Regex.IsMatch(name.Trim(), @"^[\p{L} \.\-]+$"))
            {
                errorMessage = "Incorrect name or lastname";
                return false;
            }
            else
            {
                errorMessage = "Validate OK";
                return true;
            }
        }

        private static bool CheckAge(string age, out string errorMessage)
        {
            if (!int.TryParse(age, out var ageInt) || ageInt is < 0 or > 150)
            {
                errorMessage = "Incorrect age";
                return false;
            }
            else
            {
                errorMessage = "Validate OK";
                return true;
            }
        }
    }
}