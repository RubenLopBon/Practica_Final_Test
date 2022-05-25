namespace TDDTests
{
    public class TestAppService
    {


        [Fact]
        //public void ManageLogin_UsuarioRegistradoYContraseñaCorrecta_Success()
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
            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns("q");

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object, 
                FileProvider.Object, TextProcessor.Object);

            //Act
            //sut.ManageLogin();
            sut.StartApp();
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
        public void ManageLogin_EmailRegistradoYIncontraseñaCorrecta_Success()
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
        // ********************************* MANAGE FILE PROCESSOR ********************************
        // ############# Test relacionados con la introducción del nombre del archivo #############
        [Fact]
        public void ManageFileProcessor_ExcepcionNombreArchivoNoExistente_Succes()
        {
            // ARRANGE 
            Mock<IAppService> AppService = new Mock<IAppService>();
            // AppService sut = new AppService();
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            string email = "prueba@test.es", contraseña = "contraseña", nombre = "Laura";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(contraseña);
            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns("example");

            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            User usuario = new User(email, contraseña, nombre);
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuario);

            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            var sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            // ACT
            sut.StartApp();

            // ASSERT
            ConsoleAdapter.Verify(x => x.WrongFile(), Times.Exactly(1));
        }

        [Fact]
        public void ManageFileProcessor_NombreArchivoExistente_Succes()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            string email = "prueba@test.es", contraseña = "contraseña", nombre = "Laura",
                nomArchivo = "example.txt", contenido = "Hola";

            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(contraseña);
            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns(nomArchivo);
            // ConsoleAdapter.Setup(x => x.ChooseOperation()).Returns("4");
            // ConsoleAdapter.Setup(x => x.ShowResult(contenido));

            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            User usuario = new User(email, contraseña, nombre);
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuario);

            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            FileProvider.Setup(x => x.ReadFile(nomArchivo)).Returns(contenido);

            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();
            // TextProcessor.Setup(x => x.ProcessText(contenido, (Operation)3));

            var sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            // ACT
            sut.StartApp();

            // ASSERT
            ConsoleAdapter.Verify(x => x.ShowOperations(), Times.Exactly(1));
        }

        [Fact]
        public void ManageFileProcessor_NombreSalidaPrograma_Succes()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            // ACT

            // ASSERT

        }

        // ############ Test relacionados con la introducción de la opción del archivo ############
        [Fact]
        public void ManageFileProcessor_ExcepcionOpcionIncorrecta_Succes()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageFileProcessor_OpcionCorrecta_Succes()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            // ACT

            // ASSERT

        }

        [Fact]
        public void ManageFileProcessor_OpcionSalidaPrograma_Succes()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            // ACT

            // ASSERT
        }
    }
}
