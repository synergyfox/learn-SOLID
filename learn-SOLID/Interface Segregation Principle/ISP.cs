namespace learn_SOLID.Interface_Segregation_Principle
{
    public class ISP
    {
        /*
         The Interface Segregation Principle states "that clients should not be forced to implement interfaces they don't use. 
        Instead of one fat interface, many small interfaces are preferred based on groups of methods, each serving one submodule.".
         */

        #region Example-1
        public interface IDeveloper
        {
            void WriteCSharpCode();
            void WriteJavaScriptCode();            
            void WriteHTMLCode();
            void WriteCSSCode();
        }

        

        public class FrontEndDeveloper : IDeveloper
        {
            public void WriteCSharpCode()
            {
                throw new NotImplementedException();
            }

            public void WriteCSSCode()
            {
                // implementation
            }

            public void WriteHTMLCode()
            {
                // implementation
            }

            public void WriteJavaScriptCode()
            {
                // implementation
            }           
        }
        //With ISP 

        public interface IFrontendDeveloper
        {
            void WriteJavaScriptCode();
            void WriteHTMLCode();
            void WriteCSSCode();
        }

        public interface IBackendDeveloper
        {
            void WriteCSharpCode();
        }

        public class _FrontEndDeveloper : IFrontendDeveloper
        {
            public void WriteCSSCode()
            {
                throw new NotImplementedException();
            }

            public void WriteHTMLCode()
            {
                throw new NotImplementedException();
            }

            public void WriteJavaScriptCode()
            {
                throw new NotImplementedException();
            }
        }

        public class _BackendDeveloper : IBackendDeveloper
        {
            public void WriteCSharpCode()
            {
                throw new NotImplementedException();
            }
        }

        public class FullStackDeveloper : IFrontendDeveloper, IBackendDeveloper
        {
            public void WriteCSharpCode()
            {
                // implementation
            }

            public void WriteCSSCode()
            {
                // implementation
            }

            public void WriteHTMLCode()
            {
                // implementation
            }

            public void WriteJavaScriptCode()
            {
                // implementation
            }
        }

        #endregion

    }
}
