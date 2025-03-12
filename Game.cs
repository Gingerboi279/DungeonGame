using System;

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
                new Room("A dark and ominous cave with the sound of dripping water somewhere in the distance", "Mysterious Key"),
                new Room("A quiet forest clearing with the faint smell of flowers", "Magical Herb"),
                new Room("An abandoned castle room with broken furniture and dust", "Ancient Tome")
            };
            playing = true;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer! Let's begin your adventure.");
            Console.Write("Please enter your name: ");
            player.Name = Console.ReadLine();

            while (playing)
            {
                PathwayChoice();
                int choice = GetUserChoice();

                if (choice >= 1 && choice <= 3)
                {
                    VisitRoom(choice);
                }
                else if (choice == 4)
                {
                    player.ShowInventory();
                }
                else if (choice == 5)
                {
                    playing = false;
                    Console.WriteLine("Thank you for playing Dungeon Explorer! Goodbye!");
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
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
        }

        private int GetUserChoice()
        {
            int choice = -1;
            while (choice < 1 || choice > 5)
            {
                // Try to read and parse the input as an integer
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("It appears you entered an invalid number. Please try again: ");
                }
            }
            return choice;
        }

        private void VisitRoom(int roomNumber)
        {
            Room room = rooms[roomNumber - 1];
            Console.WriteLine($"\nYou have entered a room: {room.Description}");
            Console.WriteLine($"You see a {room.Item} on the ground.");

            Console.Write("Would you like to pick it up? (y/n): ");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                player.PickUpItem(room.Item);
            }
            else
            {
                Console.WriteLine("You chose not to pick up the item.");
            }
        }
    }
}
