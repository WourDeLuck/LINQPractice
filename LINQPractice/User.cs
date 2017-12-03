using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    /// <summary>
    /// Simple User class.
    /// </summary>
    public class User
    {
        // User's id.
        private int _id;

        // User's first name.
        private string _firstName;

        // User's last name.
        private string _lastName;

        // User's date of birth.
        private DateTime _birthday;

        // User's age.
        private int _age;

        // Encapsulated fields.
        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public int Age { get => _age; set => _age = value; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="id">User's id.</param>
        /// <param name="fn">User's first name.</param>
        /// <param name="ln">User's last name.</param>
        /// <param name="bd">User's date of birth.</param>
        public User(int id, string fn, string ln, DateTime bd)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            Birthday = bd;
            Age = CalculateAge(bd);
        }

        /// <summary>
        /// Calculates age based on DoB.
        /// </summary>
        /// <param name="bd">User's date of birth.</param>
        /// <returns>User's age.</returns>
        private int CalculateAge(DateTime bd)
        {
            var today = DateTime.Now;
            var age = today.Year - bd.Year;

            if (bd > today.AddYears(-age)) age--;

            return age;
        }
    }
}
