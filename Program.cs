using System;
using System.IO;
using System.Xml.Serialization;

namespace xml_save
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Player));

            System.Console.WriteLine("Do you want to open or create file?\n" + "Enter O to open or N to create\n" + "If the file already exists and you create a new, the previous data will be overwritten\n\n");
            string playerChoose = Console.ReadLine().Trim().ToUpper();

            while (playerChoose != "O" && playerChoose != "N")
            {
                System.Console.WriteLine("Please enter a vaild option!");
                playerChoose = Console.ReadLine().Trim().ToUpper();
            }

            if (playerChoose == "O")
            {
                
            }

            else if (playerChoose == "N")
            {
            System.Console.WriteLine("How much HP does the player have?");
            string playerHp = Console.ReadLine();
            bool success = int.TryParse(playerHp, out int playerHpInt);
            
            System.Console.WriteLine("How much MP does the player have?");
            string playerMp = Console.ReadLine();
            bool success2 = int.TryParse(playerMp, out int playerMpInt);

            System.Console.WriteLine("How much SP does the player have?");
            string playerSp = Console.ReadLine();
            bool success3 = int.TryParse(playerSp, out int playerSpInt);

            Player player = new Player(playerHpInt, playerMpInt, playerSpInt);

            // Console.WriteLine(player.hp + " " + player.mp + " " + player.sp);

            FileStream myFile = File.Open("playerStats.xml", FileMode.OpenOrCreate);

            serializer.Serialize(myFile, player);

            myFile.Close();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
