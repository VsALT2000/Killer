﻿namespace Killer.Entities
{
    public class Ammo : ICreature
    {
        public string GetImageFileName() => "Ammo.png";

        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y, Game game) => new CreatureCommand();

        public bool DeadOfBullet(int x, int y, Game game) => false;

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            Game.Ammo += 7;
            return true;
        }
    }
}