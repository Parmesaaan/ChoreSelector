namespace ChoreSelector
{
    class Chore
    {
        public string name;
        public int difficulty;
        public int time;
        public Room room;

        public Chore(string name, int difficulty, int time, Room room)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.time = time;
            this.room = room;
        }
        
        public int GetChoreScore()
        {
            return time + difficulty;
        }

        public enum Room
        {
            Kitchen,
            Bathroom,
            All
        }
    }
}
