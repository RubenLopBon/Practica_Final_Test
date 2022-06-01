namespace Tests
{
    public class TestAppService
    {


        [Fact]
        public void ManageLogin_EmailYContraseñaDeUsuarioRegistrado_Success()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            string email = "pruebanoregis@test.es";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);

            string password = "oca";
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu = new User(email, password, "paco");
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usu);

            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns("q");

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            //Act
            sut.StartApp();
            
            //Assert
            ConsoleAdapter.Verify(x => x.WelcomeUser(It.IsAny<User>()),
                    Times.Exactly(1));
        }

        [Fact]
        public void ManageLogin_EmailYContraseñaDeUsuarioNoRegistrado3Intentos_Error()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            string email = "pruebanoregis@test.es";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);

            string password = "oca";
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu = new User(email, password, "paco");
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((User?)null);

            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns("q");

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            //Act
            sut.StartApp();

            //Assert
            ConsoleAdapter.Verify(x => x.WrongCredentials(),
                    Times.Exactly(3));
            ConsoleAdapter.Verify(x => x.TooManyAttempts(),
                    Times.Exactly(1));
        }

        [Theory]
        [InlineData("q", "algo", "algo.txt", "1")]
        [InlineData("algo", "q", "algo.txt", "1")]
        [InlineData("algo", "algo", "q", "1")]
        [InlineData("algo", "algo", "algo.txt", "q")]
        [InlineData("Q", "algo", "algo.txt", "1")]
        [InlineData("algo", "Q", "algo.txt", "1")]
        [InlineData("algo", "algo", "Q", "1")]
        [InlineData("algo", "algo", "algo.txt", "Q")]
        public void CheckExit_Q_Exit(string email, string password, string fichero, string operacion)
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);
            
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu = new User(email, password, "paco");
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usu);

            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns(fichero);
            FileProvider.Setup(x => x.ReadFile(fichero)).Returns("asdasdassssss");

            ConsoleAdapter.Setup(x => x.ShowOperations());
            ConsoleAdapter.Setup(x => x.ChooseOperation()).Returns(operacion);

            ConsoleAdapter.Setup(x => x.ShowResult(It.IsAny<string>()));
            ConsoleAdapter.Setup(x => x.Bye()).Throws(new Exception("Bye"));

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => sut.StartApp());

            //Assert
            Assert.Equal("Bye", exception.Message);
        }     
        
        // ********************************* MANAGE FILE PROCESSOR ********************************
        // ############# Test relacionados con la introducción del nombre del archivo #############
        [Fact]
        public void ManageFileProcessor_NombreArchivoNoExistente_Excepcion()
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
                nomArchivo = "example.txt", contenido = "Hola", opcion = "1";

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
            
            ConsoleAdapter.Setup(x => x.Bye()).Throws(new Exception("Bye"));
            ConsoleAdapter.Setup(x => x.ChooseOperation()).Returns(opcion);
            ConsoleAdapter.Setup(x => x.ShowResult(It.IsAny<string>())).Throws(new Exception("Resultado"));
            

            var sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => sut.StartApp());

            //Assert
            Assert.Equal("Resultado", exception.Message);
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
