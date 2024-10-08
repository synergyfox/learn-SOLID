namespace learn_SOLID.Dependency_Inversion_Principle
{
    #region Example-1-with-DIP
      
    //With DIP
    public interface ISwitchable
    {
        bool IsOn { get; }

        void TurnOn();
        void TurnOff();
    }

    public class _LightBulb : ISwitchable
    {
        public bool IsOn => throw new NotImplementedException();

        // implementation
        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
        }
    }

    public class _Switch
    {
        private ISwitchable device;

        public _Switch(ISwitchable device)
        {
            this.device = device;
        }

        public void Toggle()
        {
            if (device.IsOn)
                device.TurnOff();
            else
                device.TurnOn();
        }
    }


    #endregion

    #region Example-2-with-DIP

    public interface ILogger
    {
        void LogMessage(string aString);
    }
    public class DbLogger : ILogger
    {
        public void LogMessage(string aMessage)
        {
            
        }
    }
    public class FileLogger : ILogger
    {
        public void LogMessage(string aStackTrace)
        {
            
        }
    }

    public class ExceptionLogger
    {
        private ILogger _logger;
        public ExceptionLogger(ILogger aLogger)
        {
            this._logger = aLogger;
        }
        public void LogException(Exception ex)
        {
            string strMessage = GetReadableMessage(ex);
            this._logger.LogMessage(strMessage);
        }
        private string GetReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;                     
           return strMessage;
        }
    }
    public class DataExporter
    {
        public void ExportDataFromFile()
        {
            ExceptionLogger _exceptionLogger;
            try
            {
                
            }
            catch (IOException ex)
            {
                _exceptionLogger = new ExceptionLogger(new DbLogger());
                _exceptionLogger.LogException(ex);
            }
            catch (Exception ex)
            {
                _exceptionLogger = new ExceptionLogger(new FileLogger());
                _exceptionLogger.LogException(ex);
            }
        }
    }

    #endregion

    #region Example-3-with-DIP

    public interface IPaymentMethod
    {
        void ProcessPayment(decimal amount);
    }

    public class CashPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} through Cash.");
        }
    }

    public class CardPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} through Card.");
        }
    }
    public class PaymentProcessor
    {
        private readonly IPaymentMethod _paymentMethod;

        public PaymentProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void Process(decimal amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }
    }
    // You can easily swap out the payment method without changing PaymentProcessor
    class Implement {

        public void execute()
        {
            IPaymentMethod cashPayment = new CashPayment();
            PaymentProcessor paymentProcessor = new PaymentProcessor(cashPayment);
            paymentProcessor.Process(100);

         
             IPaymentMethod cardPayment = new CardPayment();
            PaymentProcessor stripeProcessor = new PaymentProcessor(cardPayment);
            stripeProcessor.Process(200);
           
            }
            }

    /*
     Key Points:
High-level modules (e.g., PaymentProcessor) depend on abstractions (e.g., IPaymentMethod) rather than concrete classes.
Low-level modules (e.g., CashPayment and CardPayment) also depend on the same abstraction.
This design allows for easy substitution of payment methods without modifying the PaymentProcessor class, adhering to the Dependency Inversion Principle.
     
     */

    #endregion
}
