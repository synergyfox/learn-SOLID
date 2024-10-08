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
        //Before LSP

        public class Bird

        {
            public virtual void Fly()
            {
                Console.WriteLine("The bird is flying.");
            }
        }

        public class Penguin : Bird
        {
            // Penguins can't fly, so throwing an exception violates LSP
            public override void Fly()
            {
                throw new Exception("Penguins can't fly.");
            }
        }

        public class BirdWatcher
        {
            public void ObserveBird(Bird bird)
            {
                bird.Fly();
            }
        }

        //After LSP


        public abstract class _Bird
        {
            // Abstract bird class to define birds generally
            public abstract void Move();
        }

        public class _FlyingBird : _Bird
        {
            public override void Move()
            {
                Console.WriteLine("The bird is flying.");
            }
        }

        public class _Penguin : _Bird
        {
            public override void Move()
            {
                Console.WriteLine("The penguin is swimming.");
            }
        }

        public class _BirdWatcher
        {
            public void ObserveBird(_Bird bird)
            {
                bird.Move();
            }
        }

        #endregion
    }
}
