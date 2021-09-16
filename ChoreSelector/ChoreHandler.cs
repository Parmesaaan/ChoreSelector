using System;
using System.Collections.Generic;

namespace ChoreSelector
{
    class ChoreHandler
    {
        List<Chore> chores = new List<Chore>();
        User user1;
        User user2;

        public ChoreHandler(User user1, User user2)
        {
            this.user1 = user1;
            this.user2 = user2;
        }

        public void AllocateChores()
        {
            Random random = new Random();
            bool current;

            // Decide who gets first chore, and give it to them
            if (random.Next(0, 9) < 5)
            {
                Console.WriteLine("\n[AllocateChores] " + user1.name +" got the first chore!");
                NextChore(user1);
                current = false;
            }
            else
            {
                Console.WriteLine("\n[AllocateChores] " + user2.name + " got the first chore!");
                NextChore(user2);
                current = true;
            }

            // Assign chores until all are assigned
            while (chores.Count > 0)
            {
                if (current == true)
                {
                    if(user1.choreScore <= user2.choreScore)
                    {
                        NextChore(user1);
                    } else
                    {
                        current = false;
                    }
                }
                else
                {
                    if(user2.choreScore <= user1.choreScore)
                    {
                        NextChore(user2);
                    } else
                    {
                        current = true;
                    }
                }
            }

            Console.WriteLine("[AllocateChores] Chores assigned successfully.");
        }

        void NextChore(User user)
        {
            Random random = new Random();
            int choreIndex = random.Next(0, chores.Count - 1);

            user.chores.Add(chores[choreIndex]);
            user.time += chores[choreIndex].time;
            user.difficulty += chores[choreIndex].difficulty;
            user.choreScore += chores[choreIndex].GetChoreScore();

            chores.RemoveAt(choreIndex);
        }

        public void ReadChores()
        {
            // Kitchen
            chores.Add(new Chore("Dishes", 2, 2, Chore.Room.Kitchen));
            chores.Add(new Chore("Kitchen Sink", 2, 1, Chore.Room.Kitchen));
            chores.Add(new Chore("Surfaces", 1, 2, Chore.Room.Kitchen)); // Continue here

            // Bathroom
            chores.Add(new Chore("Toilet", 3, 1, Chore.Room.Bathroom));
            chores.Add(new Chore("Bathroom Sink", 2, 1, Chore.Room.Bathroom));
            chores.Add(new Chore("Shower", 2, 3, Chore.Room.Bathroom));

            // All
            chores.Add(new Chore("Put Stuff Away", 1, 2, Chore.Room.All));
            chores.Add(new Chore("Trash", 2, 2, Chore.Room.All));
            chores.Add(new Chore("Hoover", 2, 2, Chore.Room.All));
            chores.Add(new Chore("Mop", 2, 2, Chore.Room.All));
            chores.Add(new Chore("Laundry", 1, 4, Chore.Room.All));

            // Misc
            chores.Add(new Chore("Wall stain (Bike)", 1, 1, Chore.Room.All));
            chores.Add(new Chore("Wall stain (Haitham)", 3, 2, Chore.Room.All));
        }

        public void PrintChores()
        {
            Console.WriteLine("\n[PrintChores] Printing chores...");

            Console.WriteLine("[AllocateChores] " + user1.name + ": " + user1.chores.Count + " chores, " + user1.time + " time, " + user1.difficulty + " difficulty; " + user1.choreScore + " chore score");
            Console.WriteLine("[AllocateChores] " + user2.name + ": " + user2.chores.Count + " chores, " + user2.time + " time, " + user2.difficulty + " difficulty; " + user2.choreScore + " chore score");

            Console.WriteLine();

            Console.WriteLine("[PrintChores] " + user1.name + ":");
            foreach (Chore chore in user1.chores)
            {
                Console.WriteLine("[PrintChores] " + chore.name);
            }

            Console.WriteLine();

            Console.WriteLine("[PrintChores] " + user2.name + ":");
            foreach (Chore chore in user2.chores)
            {
                Console.WriteLine("[PrintChores] " + chore.name);
            }
        }
    }
}
