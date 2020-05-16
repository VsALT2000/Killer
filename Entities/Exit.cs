namespace Killer.Entities
{
    public class Exit : ICreature
    {
        public string GetImageFileName() => "Exit.png";

        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadOfBullet(int x, int y, Game game) => false;

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            Game.Scores+=50;
            return true;
        }
    }
}