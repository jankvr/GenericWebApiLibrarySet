namespace Cz.Bkk.Generic.IdentityManagement.Models
{
    /// <summary>
    /// This model serves as an input parameter
    /// </summary>
    public class RegistrationInput
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
