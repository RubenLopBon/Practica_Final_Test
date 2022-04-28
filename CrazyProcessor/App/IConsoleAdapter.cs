using CrazyProcessor.Auth;
using CrazyProcessor.Processor;

namespace CrazyProcessor.App
{
    public interface IConsoleAdapter
    {
        void Welcome();
        void WelcomeUser(User user);
        string ReadEmail();
        string ReadPassword();
        string ReadFileName();
        void ShowOperations();
        string ChooseOperation();
        void ShowResult(string result);
        void WrongCredentials();
        void WrongFile();
        void TooManyAttempts();
        void Bye();
    }
}
