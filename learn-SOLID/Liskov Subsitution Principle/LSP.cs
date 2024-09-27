using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace learn_SOLID.Liskov_Subsitution_Principle
{
    #region Overview
    /*
     * The Liskov Substitution Principle states that objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
        Key Idea: You should be able to use any subclass where you use its parent class.
        Real-Time Example: You have a remote control that works for all types of TVs, regardless of the brand.
    */
    #endregion

    internal class LSP
    {

        #region Example-1
        //without LSP
        public abstract class Vehicle
        {
            public abstract void StartEngine();
            public abstract void StopEngine();
        }
        public class Car : Vehicle
        {
            public override void StartEngine()
            {
                Console.WriteLine("Starting the car engine.");
                // Code to start the car engine
            }
            public override void StopEngine()
            {
                Console.WriteLine("Stopping the car engine.");
                // Code to stop the car engine
            }
        }
        public class ElectricCar : Vehicle
        {
            public override void StartEngine()
            {
                throw new InvalidOperationException("Electric cars do not have engines.");
            }
            public override void StopEngine()
            {
                throw new InvalidOperationException("Electric cars do not have engines.");
            }
        }

        //with LSP
        public abstract class _Vehicle
        {
            // Common vehicle behavior and properties.
        }
        public interface IEnginePowered
        {
            void StartEngine();
            void StopEngine();
        }
        public class _Car : _Vehicle, IEnginePowered
        {
            public void StartEngine()
            {
                Console.WriteLine("Starting the car engine.");
                // Code to start the car engine.
            }
            public void StopEngine()
            {
                Console.WriteLine("Stopping the car engine.");
                // Code to stop the car engine.
            }
        }
        public class _ElectricCar : _Vehicle
        {
            // Specific behavior for electric cars.
        }


        #endregion

        #region Example-2

        public class BankAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            public BankAccount(string accountNumber, decimal balance)
            {
                AccountNumber = accountNumber;
                Balance = balance;
            }
            public virtual void Deposit(decimal amount)
            {
                Balance += amount;
                Console.WriteLine($"Deposit: {amount}, Total Amount: {Balance}");
            }
            public virtual void Withdraw(decimal amount)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
        }
        //We have two derived classes: SavingsAccount and CurrentAccount
        public class SavingsAccount : BankAccount
        {
            public decimal InterestRate { get; set; }
            public SavingsAccount(string accountNumber, decimal balance, decimal interestRate)
                : base(accountNumber, balance)
            {
                InterestRate = interestRate;
            }
            public override void Withdraw(decimal amount)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Insufficient Funds, Available Funds: {Balance}");
                }
            }
        }
        public class CurrentAccount : BankAccount
        {
            public decimal OverdraftLimit { get; set; }
            public CurrentAccount(string accountNumber, decimal balance, decimal overdraftLimit)
                : base(accountNumber, balance)
            {
                OverdraftLimit = overdraftLimit;
            }
            public override void Withdraw(decimal amount)
            {
                if (amount <= Balance + OverdraftLimit)
                {
                    Balance -= amount;
                    Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"AccountNumber: {AccountNumber}, Exceeded Overdraft Limit.");
                }
            }
        }


        #endregion
    }
}
