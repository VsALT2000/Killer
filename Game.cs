using System.Windows.Forms;
using KillerTests;

namespace Killer
{
    public class Game
    {
        public readonly ICreature[,] Map;
        public static int Scores;
        public static int Ammo;
        public static bool IsOver;
        public static bool HaveKey;

        public Keys KeyPressed;
        public int Width => Map.GetLength(0);
        public int Height => Map.GetLength(1);
        
        public Game(string level)
        {
            Map = CreatureMapCreator.CreateMap(level.StartsWith("Level") 
                ? LevelCreator.GetLevel(level) 
                : LevelTestsCreator.GetLevel(level));
        }
        
        public Game(string level, int ammo, bool haveKey)
        {
            Map = CreatureMapCreator.CreateMap(level.StartsWith("Level") 
                ? LevelCreator.GetLevel(level) 
                : LevelTestsCreator.GetLevel(level));
            Ammo = ammo;
            HaveKey = haveKey;
        }
    }
}