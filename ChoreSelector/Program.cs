using System;
using System.Configuration;

namespace ChoreSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Main] Welcome to ChoreSelector v1.1 by Haitham");

            User user1 = new User(ConfigurationManager.AppSettings.Get("User1Name"));
            User user2 = new User(ConfigurationManager.AppSettings.Get("User2Name"));
            ChoreHandler choreHandler = new ChoreHandler(user1, user2);

            choreHandler.ReadChores();
            choreHandler.AllocateChores();
            choreHandler.PrintChores();
        }
    }
}
