using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services;
using System;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility
{
    public class RSGymUtility 
    {

        internal static string CurrentUser { get; set; } = AppService.UpdateScreenUserType();


        // Method to ensure that characters from any language, including special characters, can be correctly displayed in the console.
        // This is particularly useful when working with text that contains characters from languages other than English, as UTF-8 supports a wide range of characters and symbols.
        public static void SetUnicodeConsole()
        {
            // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        // Method to show a stylish title
        public static void WriteTitle(string title, string beginTitle = "", string endTitle = "")
        {
            CurrentUser = AppService.UpdateScreenUserType();
            string formattedTitle = $"{title} - {CurrentUser}";

            WriteColor();

            Console.Write($"{beginTitle}{new string('-', 44)}\n{formattedTitle.ToUpper().PadLeft(22 - formattedTitle.Length / 2 + formattedTitle.Length, ' ')}\n{new string('-', 44)}{endTitle}");
            Console.ForegroundColor = ConsoleColor.White;   // Reset original color
        }

        // Method to show a stylish title
        public static void WriteLoginTitle(string title, string beginTitle = "", string endTitle = "")
        {
            CurrentUser = "Convidado";
            string formattedTitle = $"{title} - {CurrentUser}";

            WriteColor();

            Console.Write($"{beginTitle}{new string('-', 44)}\n{formattedTitle.ToUpper().PadLeft(22 - formattedTitle.Length / 2 + formattedTitle.Length, ' ')}\n{new string('-', 44)}{endTitle}");
            Console.ForegroundColor = ConsoleColor.White;   // Reset original color
        }

        // Method to show a message setted with skip lines at the beginning and end of it
        public static void WriteMessage(string message, string beginMessage = "", string endMessage = "")
        {
            WriteColor();
            Console.Write($"{beginMessage}{message}{endMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Method to terminate the console with a stylish message
        public static void TerminateConsole()
        {
            WriteColor();
            Console.Write("\n\nPrime qualquer tecla para terminares.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        // Method to pause the console
        public static void PauseConsole()
        {
            WriteColor();
            Console.Write("\nPrime qualquer tecla para continuar.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        public static void WriteColor()
        {
            switch (CurrentUser)
            {
                case "Admin":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "PowerUser":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "SimpleUser":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
