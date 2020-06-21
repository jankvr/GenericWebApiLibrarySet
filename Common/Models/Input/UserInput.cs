namespace Cz.Bkk.Generic.Common.Models.Input
{
    /// <summary>
    /// This model serves as an user input parameter
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }
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
        /// <summary>
        /// Role
        /// </summary>
        public UserRole Role { get; set; }
    }
}
