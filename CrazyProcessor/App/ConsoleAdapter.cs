using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyProcessor.Auth;
using CrazyProcessor.Processor;

namespace CrazyProcessor.App
{
    public class ConsoleAdapter : IConsoleAdapter
    {
        private readonly Operation[] operations;

        public ConsoleAdapter()
        {
            this.operations = (Operation[])Enum.GetValues(typeof(Operation));
        }

        public void Welcome()
        {
            Console.WriteLine("Bienvenido a *Crazy Processor*");
            Console.WriteLine("(Escriba q o Q para salir)");
            Console.WriteLine();
        }

        public void WelcomeUser(User user)
        {
            Console.WriteLine();
            Console.WriteLine($"Bienvenido {user.Name}");
        }

        public string ReadEmail()
        {
            string? email = null;
            while (String.IsNullOrWhiteSpace(email))
            {
                Console.Write("Introduzca su email: ");
                email = Console.ReadLine()?.Trim();
            }

            return email;
        }

        public string ReadPassword()
        {
            string? password = null;
            while (String.IsNullOrWhiteSpace(password))
            {
                Console.Write("Introduzca su password: ");
                password = Console.ReadLine()?.Trim();
            }

            return password;
        }

        public string ReadFileName()
        {
            string? fileName = null;
            while (String.IsNullOrWhiteSpace(fileName))
            {
                Console.Write("Introduzca el nombre del fichero: ");
                fileName = Console.ReadLine()?.Trim();
            }

            return fileName;
        }

        public void ShowOperations()
        {
            int i = 1;
            foreach (Operation operation in operations)
            {
                Console.WriteLine($"{i++} -> {operation.GetDescription()}");
            }
        }

        public string ChooseOperation()
        {
            string? operation = null;
            while (String.IsNullOrWhiteSpace(operation))
            {
                Console.WriteLine("Selecciona una operación");
                operation = Console.ReadLine()?.Trim();
            }

            return operation;
        }

        public void ShowResult(string result)
        {
            Console.WriteLine("Resultado:");
            Console.WriteLine(result);
            Console.WriteLine();
        }

        public void WrongCredentials()
        {
            Console.WriteLine("ERROR -> Email o contraseña incorrectos");
            Console.WriteLine();
        }

        public void WrongFile()
        {
            Console.WriteLine("ERROR -> El fichero no existe o no se ha podido leer");
            Console.WriteLine();
        }

        public void TooManyAttempts()
        {
            Console.WriteLine();
            Console.WriteLine("ERROR -> Ha alcanzado el número máximo de intentos.");
        }

        public void Bye()
        {
            Console.WriteLine();
            Console.WriteLine("Hasta pronto!!");
            Environment.Exit(0);
        }
    }
}
