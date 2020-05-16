namespace Killer.Entities
{
    public class Door : ICreature
    {
        public string GetImageFileName() => "Door.png";

        public int GetDrawingPriority() => 1;

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadOfBullet(int x, int y, Game game) => false;

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            Game.HaveKey = false;
            return true;
        }
    }
}