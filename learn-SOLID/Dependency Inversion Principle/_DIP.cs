namespace learn_SOLID._Dependency_Inversion_Principle
{
    /*
     * One should depend upon abstractions, [not] concretions.” Robert C. Martin
     */

    /*
     The Dependency Inversion Principle (DIP) states that High-Level Modules/Classes should not depend on Low-Level Modules/Classes.
    Both should depend upon Abstractions (e.g., interfaces or abstract classes). Secondly, Abstractions should not depend upon Details. 
    But Details should depend upon Abstractions.     
     */

    /*
     The most important point you need to remember while developing real-time applications is always to keep the High-level and Low-level 
     modules as loosely coupled as possible.
     When a class knows about the design and implementation of another class, it raises the risk that if we make any changes to one class
        (e.g., modifying the method signature or return type or even renaming the class name), it will break the other class
        (the class consuming the other class members by creating an instance). So, we must keep these high-level and low-level modules/classes loosely 
        coupled as much as possible. To do that, we need to make both of them dependent on abstractions instead of knowing each other.     
     */


    #region Example-1-without-DIP

    
    public class LightBulb
    {
        public bool IsOn { get; internal set; }

        public void TurnOn() { /* implementation */ }
        public void TurnOff() { /* implementation */ }
    }

    public class Switch
    {

        private LightBulb bulb;

        public Switch(LightBulb bulb)
        {
            this.bulb = bulb;
        }

        public void Toggle()
        {
            if (bulb.IsOn)
                bulb.TurnOff();
            else
                bulb.TurnOn();
        }
    }



    #endregion

    #region Example-2-without-DIP

    public class FileLogger
    {
        public void LogMessage(string aStackTrace)
        {          
        }
    }
    public class ExceptionLogger
    {
        public void LogIntoFile(Exception aException)
        {
            FileLogger objFileLogger = new FileLogger();
            objFileLogger.LogMessage(GetUserReadableMessage(aException));
        }
        private string  GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
            return strMessage;
        }

       
    }

    //Exporting all the logs to a file
    public class DataExporter
    {
        public void ExportDataFromFile()
        {
            try
            {                
            }
            catch (Exception ex)
            {
                new ExceptionLogger().LogIntoFile(ex);
            }
        }
    }
    //Now we want to export the files to Database as well in case exception occurs

    public class DbLogger
    {
        public void LogMessage(string aMessage)
        {
            //Code to write message in the database.
        }
    }
    public class _FileLogger
    {
        public void LogMessage(string aStackTrace)
        {
            //code to log stack trace into a file.
        }
    }
    public class _ExceptionLogger
    {
        public void LogIntoFile(Exception aException)
        {
            FileLogger objFileLogger = new FileLogger();
            objFileLogger.LogMessage(GetUserReadableMessage(aException));
        }
        public void LogIntoDataBase(Exception aException)
        {
            DbLogger objDbLogger = new DbLogger();
            objDbLogger.LogMessage(GetUserReadableMessage(aException));
        }
        private string GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
          
           return strMessage;
        }
    }
    public class _DataExporter
    {
        public void ExportDataFromFile()
        {
            try
            {
                //code to export data from files to database.
            }
            catch (IOException ex)
            {
                new _ExceptionLogger().LogIntoDataBase(ex);
            }
            catch (Exception ex)
            {
                new _ExceptionLogger().LogIntoFile(ex);
            }
        }
    }
    /*
     But whenever the someone wants to introduce a new logger, alteration ExceptionLogger by adding a new method. 
    Suppose we continue doing this after some time. In that case, we will see a large ExceptionLogger class with a large set of practices      
     */



    #endregion

    #region Example-3-without-DIP
    //Low Level Module
    public class CashPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} through Cash.");
        }
    }
    //High Level Module
    public class PaymentProcessor
    {
        private readonly CashPayment _cashPayment;

        public PaymentProcessor()
        {
            _cashPayment = new CashPayment();
        }

        public void Process(decimal amount)
        {
            _cashPayment.ProcessPayment(amount);
        }
    }

    #endregion
}
