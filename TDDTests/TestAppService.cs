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

        /*
        [Theory] // No hace falta probarlo todo, limitarlo
        [InlineData("paco@gmail.ex", "oca", new int [] {1, 1, 1, 1, 0, 0 , 1} )] //Todo bien
        [InlineData("fakemail", "oca", new int[] { 3, 3, 0, 3, 3, 1, 2 })] //Mail mal Sale 2 veces... DUDA PROFE
        [InlineData("paco@gmail.ex", "fake", new int[] { 3, 3, 0, 3, 3, 1, 2 })] //contrasena mal
        [InlineData("fakemail", "fake", new int[] { 3, 3, 0, 3, 3, 1, 2 })] //contrasena y mail mal
        [InlineData("q", "oca", new int[] { 3, 3, 0, 3, 3, 1, 8 })] //mail q no me convenven -- decirle a by que acabe las pruebas
        [InlineData("paco@gmail.ex", "q", new int[] { 3, 3, 0, 3, 3, 1, 8 })] //contrasena q
        [InlineData("", "oca", new int[] { 1, 1, 1, 1, 0, 0, 1 })] //Todo bien   -- Igual poner un /n
        public void aaManageLogin_Multiple_Success(string email,string password,int [] repeticiones)
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            string emailRegistrado = "paco@gmail.ex";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);

            string passwordRegistrado = "oca";
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu;
            if (email == emailRegistrado && password == passwordRegistrado)
            {
                usu = new User(email, password, "paco");
            }
            else
            {
                usu = (User?)null;
            }
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
                    Times.Exactly(repeticiones[0]));
            ConsoleAdapter.Verify(x => x.ReadPassword(),
                    Times.Exactly(repeticiones[1]));
            ConsoleAdapter.Verify(x => x.WelcomeUser(It.IsAny<User>()),
                    Times.Exactly(repeticiones[2]));
            AuthService.Verify(x => x.Login(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Exactly(repeticiones[3]));
            ConsoleAdapter.Verify(x => x.WrongCredentials(),
                    Times.Exactly(repeticiones[4]));
            ConsoleAdapter.Verify(x => x.TooManyAttempts(),
                    Times.Exactly(repeticiones[5]));
            ConsoleAdapter.Verify(x => x.Bye(),
                    Times.Exactly(repeticiones[6]));
        }
        */

        [Fact]
        public void ManageLogin_EmailRegistradoYContraseñaIncorrecta_Success()//Hecho?
        {
        }

        [Fact]
        public void ManageLogin_EmailNoRegistrado_Error() //Hecho
        {
        }

        [Fact]
        public void ManageLogin_EmailNoRegistradoTresIntentos_Error()//Hecho
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

        }
        public void ManageLogin_SinPonerContraseña_Message()
        {

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
        [Fact]
        public void bye()
        {
            // ARRANGE 
            Mock<IConsoleAdapter> ConsoleAdapter = new Mock<IConsoleAdapter>();
            Mock<IAuthService> AuthService = new Mock<IAuthService>();
            Mock<IFileProvider> FileProvider = new Mock<IFileProvider>();
            Mock<ITextProcessor> TextProcessor = new Mock<ITextProcessor>();

            string email = "q";
            ConsoleAdapter.Setup(x => x.ReadEmail()).Returns(email);
            string password = "oca";
            ConsoleAdapter.Setup(x => x.ReadPassword()).Returns(password);

            User usu = new User(email, password, "userExemple");
            AuthService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usu);

            ConsoleAdapter.Setup(x => x.WelcomeUser(It.IsAny<User>()));

            ConsoleAdapter.Setup(x => x.ReadFileName()).Returns("a");

            AppService sut = new AppService(ConsoleAdapter.Object, AuthService.Object,
                FileProvider.Object, TextProcessor.Object);

            //Act
            sut.StartApp();

            //Assert
            //virficar que se llama al metodo bye al menos 1 vez

            ConsoleAdapter.Verify(x => x.Bye(),
                    Times.Exactly(1));
        }
    }
}
