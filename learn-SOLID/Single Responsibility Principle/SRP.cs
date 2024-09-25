using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace learn_SOLID.Single_Responsibility_Principle
{
    #region Overview
    /*
     * The SRP states that a class should have only one reason to change, meaning it should have only one responsibility.
     * This promotes modularization and makes the code easier to understand and maintain.
     
     Key Idea: A class should do only one thing, and it should do it well.

     Real-Time Example: Think of a chef who only focuses on cooking, not managing the restaurant or delivering food.
    
     */

    #endregion

    #region Example-1

    
    public class Report_Without_SRP
    {
        public void GenerateReport() { }
        public void SaveToFile() { }
    }
    public class Report_With_SRP
    {        
        public void SaveToFile() { }
    }

    #endregion

    #region Example-2

    // Without SRP
    public class UserCreator
    {
        public void CreateUser(string username, string email, string password)
        {
            // Validation logic
            if (!ValidateEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }
            // Business rules
            // Database persistence
            SaveUserToDatabase(username, email, password);
        }
        private bool ValidateEmail(string email)
        {
            // Validation logic
            return true;
        }
        private void SaveUserToDatabase(string username, string email, string password)
        {
            // Database persistence logic
        }
    }


    //With SRP

    public class UserValidator
    {
        public bool ValidateEmail(string email)
        {
            return true;
        }
    }
    public class UserRepository
    {
        public void SaveUser(string username, string email, string password)
        {
            // Database persistence logic
        }
    }
    public class _UserCreator
    {
        private readonly UserValidator _validator;
        private readonly UserRepository _repository;
        public _UserCreator(UserValidator validator, UserRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }
        public void CreateUser(string username, string email, string password)
        {
            if (!_validator.ValidateEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }
            // Business rules
            _repository.SaveUser(username, email, password);
        }
    }

    #endregion

}
