using System;
using System.Xml.Linq;

namespace DungeonExplorer
{
    // Game class to manage the gameplay and interactions
    public class Game
    {
        private Player player;
        private Room[] rooms;
        private bool playing;

        public Game()
        {
            // Initialize the game with one player and rooms
            player = new Player("Joe");
            rooms = new Room[]
            {
                new Room("A Cave filled with bats", new Potion("Health Potion", 20), new Monster("Goblin", 30)),
                new Room("A throne room with a dusty throne at the end", new Weapon("Ancient Sword", 25), new Monster("Royal Guard", 60)),
                new Room("An eerie graveyard", new Potion("Lesser Health Potion", 15), new Monster("Skeleton", 35))
            };
            playing = true;
        }

        public void Start()
        {
            Console.WriteLine("Welcome Traveller!");
            Console.Write("Please enter your name:");
            player.Name = Console.ReadLine();

            while (playing && player.Health > 0)
            {
                PathwayChoice();
                int choice = GetUserChoice();

                if (choice >= 1 && choice <= 3)
                {
                    VisitRoom(choice);
                }
                else if (choice == 4)
                {
                    player.Inventory.ShowInventory();
                }
                else if (choice == 5)
                {
                    Console.Write("Enter item name to use:");
                    string itemName = Console.ReadLine();
                    player.Inventory.UseItem(itemName, player);
                }
                else if (choice == 6)
                {
                    playing = false;
                    Console.WriteLine("Thank you for playing Traveller, goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        private void PathwayChoice()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Visit Room 1");
            Console.WriteLine("2. Visit Room 2");
            Console.WriteLine("3. Visit Room 3");
            Console.WriteLine("4. View Inventory");
            Console.WriteLine("5. Use Item");
            Console.WriteLine("6. Exit");
            Console.Write("What would you like to do?");
        }

        private int GetUserChoice()
        {
            int choice = -1;
            while (choice < 1 || choice > 6)
            {
                // Try to read and parse the input as an integer
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice) || choice < 1 || choice > 6)
                {
                    Console.Write("You have entered an invalid number, try again:");
                }
            }
            return choice;
        }

        private void VisitRoom(int roomNumber)
        {
            Room room = rooms[roomNumber - 1];
            Console.WriteLine($"\nYou enter the room: {room.Description}");
            Console.WriteLine($"A {room.RoomMonster.Name} has approached");

            while (room.RoomMonster.Health > 0 && player.Health > 0)
            {
                Console.Write("Do you want to attack?(yes/no):");
                string input = Console.ReadLine()?.ToLower();
                if (input == "yes")
                {
                    player.Attack(room.RoomMonster);
                    if (room.RoomMonster.Health > 0)
                        room.RoomMonster.Attack(player);
                }
                else
                {
                    Console.WriteLine("You run from Battle");
                    return;
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"You defeated the {room.RoomMonster.Name}!");
                Console.WriteLine($"You find a {room.RoomItem.Name}.");
                player.Inventory.AddItem(room.RoomItem);
            }
            else
            {
                Console.WriteLine("You have been slain in battle");
                playing = false;
            }
        }
    }
}
