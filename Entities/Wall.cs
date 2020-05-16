namespace Killer.Entities
 {
     public class Wall : ICreature
     {
         public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

         public bool DeadOfBullet(int x, int y, Game game) => false;

         public bool DeadInConflict(ICreature conflictedObject, Game game) => false;
         public int GetDrawingPriority() => 1;

         public string GetImageFileName() => "Wall.png";
     }
 }