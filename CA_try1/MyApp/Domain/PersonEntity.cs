using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Domain
{
    public class PersonEntity
    {
        public Guid Id { get; set; }
        public string Code { get; private set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";


        protected PersonEntity()
        {
        }


        public PersonEntity(string code, string firstname, string lastname, string email, string phonenumber)
        {
            ValidateCode(code);
            ValidateFirstName(firstname);
            ValidateLastName(lastname);
            ValidateEmail(email);
            ValidatePhoneNumber(phonenumber);

            FirstName = firstname.Trim().ToLower();
            LastName = lastname.Trim().ToLower();
            Code = code.Trim().ToUpper();
            Email = email;
            PhoneNumber = phonenumber.Trim();
        }

        // Utility Methods
        public string GetFullName() => $"{FirstName} {LastName}";
        public string GetContactInfo() => $"Email: {Email}, Phone: {PhoneNumber}";

        // Update Methods
        public void UpdatePersonalIfo(string firstname, string lastname, string email, string phonenumber)
        {
            ValidateFirstName(firstname);
            ValidateLastName(lastname);
            ValidateEmail(email);
            ValidatePhoneNumber(phonenumber);

            FirstName = firstname.Trim().ToLower();
            LastName = lastname.Trim().ToLower();
            Email = email.Trim().ToLower();
            PhoneNumber = phonenumber.Trim();
        }

        // Validation Methods
        private void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("El código no puede estar vaío", nameof(code));
            
            if (code.Trim().Length < 3)
                throw new ArgumentException("El código debe tener al menos 3 caracteres", nameof(code));

            if (code.Trim().Length > 10)
                throw new ArgumentException("El código no puede tener más de 10 caracteres", nameof(code));
        }

        private void ValidateFirstName(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(firstname));
            if (firstname.Trim().Length < 2)
                throw new ArgumentException("El nombre debe tener al menos 2 caracteres", nameof(firstname));
            if (firstname.Trim().Length > 50)
                throw new ArgumentException("El nombre no puede tener más de 50 caracteres", nameof(firstname));
        }

        private void ValidateLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("El apellido no puede estar vacío", nameof(lastname));
            if (lastname.Trim().Length < 2)
                throw new ArgumentException("El apellido debe tener al menos 2 caracteres", nameof(lastname));
            if (lastname.Trim().Length > 50)
                throw new ArgumentException("El apellido no puede tener más de 50 caracteres", nameof(lastname));
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El correo electrónico no puede estar vacío", nameof(email));

            if (email.Length > 100)
                throw new ArgumentException("El correo electrónico no puede tener más de 100 caracteres", nameof(email));

            var emailpattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch (email, emailpattern))
            {
                throw new ArgumentException("El correo electrónico no tiene un formato válido", nameof(email));
            }
        }

        private void ValidatePhoneNumber (string phonenumber)
        {
            if (string.IsNullOrWhiteSpace(phonenumber))
                throw new ArgumentException("El número de teléfono no puede estar vacío", nameof(phonenumber));

            if (phonenumber.Trim().Length < 7)
                throw new ArgumentException("El número de teléfono debe tener al menos 7 caracteres", nameof(phonenumber));

            if (phonenumber.Trim().Length > 15)
                throw new ArgumentException("El número de teléfono no puede tener más de 15 caracteres", nameof(phonenumber));
        }
    }
}