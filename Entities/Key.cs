namespace Killer.Entities
{
    public class Key : ICreature
    {
        public string GetImageFileName() => "Key.png";

        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadOfBullet(int x, int y, Game game) => false;

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            Game.HaveKey = true;
            return true;
        }
    }
}