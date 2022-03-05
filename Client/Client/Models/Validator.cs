using System.Collections.Generic;

namespace Client.Models
{
    class Validator
    {
        public static int MIN_LENGTH_FIRSTNAME = 5;
        public static int MIN_LENGTH_SURNAME = 5;

        public List<string> ValidateUser(User user)
        {
            List<string> errors = new List<string>();
            if (user.Firstname == null || user.Firstname.Length < MIN_LENGTH_FIRSTNAME) errors.Add($"Минимальная длина имени должна быть {MIN_LENGTH_FIRSTNAME}");
            if (user.Surname == null || user.Surname.Length < MIN_LENGTH_SURNAME) errors.Add($"Минимальная длина фамилии должна быть {MIN_LENGTH_SURNAME}");
            return errors;
        }
    }
}
