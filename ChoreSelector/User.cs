using System;
using System.Collections.Generic;
using System.Text;

namespace ChoreSelector
{
    class User
    {
        public string name;
        public int difficulty;
        public int time;
        public int choreScore;
        public List<Chore> chores;

        public User(string name)
        {
            this.name = name;
            difficulty = 0;
            time = 0;
            choreScore = 0;
            chores = new List<Chore>();
        }
    }
}
