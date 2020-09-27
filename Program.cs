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

            string playerHp;
            string playerMp;
            string playerSp;

            int playerHpInt;
            int playerMpInt;
            int playerSpInt;

            bool success;

            Console.WriteLine("Do you want to open or create file?\n" + "Enter O to open or N to create\n" + "If the file already exists and you create a new, the previous data will be overwritten\n\n");
            string playerChoose = Console.ReadLine().Trim().ToUpper();
            Console.Clear();

            while (playerChoose != "O" && playerChoose != "N")
            {
                Console.WriteLine("Please enter a vaild option!\n\n" + 
                "Do you want to open or create file?\n" + 
                "Enter O to open or N to create\n" + 
                "If the file already exists and you create a new, the previous data will be overwritten\n\n");
                playerChoose = Console.ReadLine().Trim().ToUpper();
                Console.Clear();
            }

            if (playerChoose == "O")
            {
                using (FileStream myFile = File.Open(@"playerStats.xml", FileMode.OpenOrCreate))
                {
                    Player player = (Player) serializer.Deserialize(myFile);
                    Console.WriteLine("Player HP: " + player.hp);
                    Console.WriteLine("Player MP: " + player.mp);
                    Console.WriteLine("Player SP: " + player.sp);
                }
            }

            else if (playerChoose == "N")
            {
            Console.WriteLine("How much HP does the player have?");
            playerHp = Console.ReadLine();
            success = int.TryParse(playerHp, out playerHpInt);
            Console.Clear();
            while (success == false)
            {
                Console.WriteLine("How much HP does the player have?");
                playerHp = Console.ReadLine();
                success = int.TryParse(playerHp, out playerHpInt);
                Console.Clear();
            }
            
            Console.WriteLine("How much MP does the player have?");
            playerMp = Console.ReadLine();
            success = int.TryParse(playerMp, out playerMpInt);
            Console.Clear();
            while (success == false)
            {
                Console.WriteLine("How much MP does the player have?");
                playerMp = Console.ReadLine();
                success = int.TryParse(playerMp, out playerMpInt);
                Console.Clear();
            }

            Console.WriteLine("How much SP does the player have?");
            playerSp = Console.ReadLine();
            success = int.TryParse(playerSp, out playerSpInt);
            Console.Clear();
            while (success == false)
            {
                Console.WriteLine("How much SP does the player have?");
                playerSp = Console.ReadLine();
                success = int.TryParse(playerSp, out playerSpInt);
                Console.Clear();
            }

            Console.WriteLine("Player HP: " + playerHp);
            Console.WriteLine("Player MP: " + playerMp);
            Console.WriteLine("Player SP: " + playerSp);

            Player player = new Player(playerHpInt, playerMpInt, playerSpInt);
            FileStream myFile = File.Open("playerStats.xml", FileMode.OpenOrCreate);

            serializer.Serialize(myFile, player);

            myFile.Close();
            }

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
