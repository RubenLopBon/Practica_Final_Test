using CrazyProcessor.Auth;
using CrazyProcessor.Processor;

namespace CrazyProcessor.App
{
    public class AppService : IAppService
    {
        private readonly IConsoleAdapter consoleAdapter;
        private readonly IAuthService authService;
        private readonly IFileProvider fileProvider;
        private readonly ITextProcessor textProcessor;
        private User? currentUser;
        private readonly Operation[] operations;

        public AppService(IConsoleAdapter consoleAdapter, IAuthService authService,
            IFileProvider fileProvider, ITextProcessor textProcessor)
        {
            this.consoleAdapter = consoleAdapter;
            this.authService = authService;
            this.fileProvider = fileProvider;
            this.textProcessor = textProcessor;
            this.operations = (Operation[])Enum.GetValues(typeof(Operation));
        }

        public void StartApp()
        {
            this.consoleAdapter.Welcome();

            this.ManageLogin();

            this.ManageFileProcessor();
        }

        private void ManageLogin()
        {
            int attempts = 0;
            while (this.currentUser == null && attempts < 3)
            {
                var email = this.consoleAdapter.ReadEmail();
                this.CheckExit(email);
                var password = this.consoleAdapter.ReadPassword();
                this.CheckExit(password);

                var user = this.authService.Login(email, password);
                if (user != null)
                {
                    this.currentUser = user;
                    this.consoleAdapter.WelcomeUser(this.currentUser);
                    return;
                }

                this.consoleAdapter.WrongCredentials();
                attempts++;
            }

            this.consoleAdapter.TooManyAttempts();
            this.consoleAdapter.Bye();
        }

        private void ManageFileProcessor()
        {
            var filename = this.consoleAdapter.ReadFileName();
            this.CheckExit(filename);
            var fileContent = this.fileProvider.ReadFile(filename);
            if (fileContent == null)
            {
                this.consoleAdapter.WrongFile();
                return;
            }

            while (true)
            {
                this.consoleAdapter.ShowOperations();
                Operation? operation = null;
                while (operation == null)
                {
                    var operationString = this.consoleAdapter.ChooseOperation();
                    this.CheckExit(operationString);


                    if (Int32.TryParse(operationString, out var idOperation) && idOperation > 0 &&
                        idOperation <= operations.Length)
                    {
                        operation = this.operations[idOperation - 1];
                    }
                }

                var result = this.textProcessor.ProcessText(fileContent, operation.Value);

                this.consoleAdapter.ShowResult(result);
            }
        }

        private void CheckExit(string value)
        {
            if ("q".Equals(value.ToLower()))
            {
                this.consoleAdapter.Bye();
            }
        }
    }
}
