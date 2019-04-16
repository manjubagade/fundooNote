//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.Repository
{
    using System;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;
    using FUNDOOAPP.Interfaces;
    using FUNDOOAPP.Models;
    using Xamarin.Forms;

    /// <summary>
    /// UserRepository class instance
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// The firebase client
        /// </summary>
        private FirebaseClient firebaseclient = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");

        /// <summary>
        /// Adds the user asynchronous.
        /// </summary>
        /// <param name="firstName">The first name</param>
        /// <param name="lastName">The last name</param>
        /// <param name="email">The email</param>
        /// <param name="password">The password</param>
        /// <param name="cpasswod">The c password</param>
        /// <returns>return task</returns>
        public async Task<string> AddUserAsync(string firstName, string lastName, string email, string password, string cpasswod)
        {
            try
            {
                string uid = await DependencyService.Get<IFirebaseAuthenticator>().AddUserWithEmailPassword(email, password);
                if (uid != null)
                {
                    await this.firebaseclient.Child("User").Child(uid).Child("Userinfo").PostAsync<User>(new User() { FirstName = firstName, LastName = lastName });
                }
                return uid;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }  
        }
        public async Task<string> GetimageSouce(string imagesouce)
        {
            string uid =  DependencyService.Get<IFirebaseAuthenticator>().User();
            if(uid ==null)
            {
                await firebaseclient.Child("User").Child(uid).Child("Userinfo").PostAsync<User>(new User() { Imageurl = imagesouce });
            }
            return uid;
        }
    }
}