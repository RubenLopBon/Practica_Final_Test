namespace TDDTests
{
    public class TestAppService
    {


        [Fact]
        public void ManageLogin_UsuarioRegistradoYContraseñaCorrecta_Success()
        { 
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            string email = "paco@gmail.ex";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);

            string password = "oca";
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu = new User(email, password, "paco");
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usu);

            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            //Mock<IAppService> AppService = new Mock<IAppService>();

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object, 
                FileProvider.Object, TextProcessor.Object);

            //Act
            //sut.ManageLogin();

            //Assert
            //Se puede mirar de separar en 3 tests
            ConsoleAdapter.Verify(x => x.ReadEmail(),
                    Times.Exactly(1));
            ConsoleAdapter.Verify(x => x.ReadPassword(),
                    Times.Exactly(1));
            ConsoleAdapter.Verify(x => x.WelcomeUser(It.IsAny<User>()),
                    Times.Exactly(1));
            AuthService.Verify(x => x.Login(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Exactly(1));

        }

        [Fact]
        public void ManageLogin__EmailRegistradoYIncontraseñaCorrecta_Success()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageLogin_EmailNoRegistrado_Error()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageLogin_EmailNoRegistradoTresIntentos_Error()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageLogin_SinPonerEmail_Message()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }
        public void ManageLogin_SinPonerContraseña_Message()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageFileProcessor_ALGO_Succes()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();

            // ACT

            // ASSERT

        }
    }
}
