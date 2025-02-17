﻿namespace Killer
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y, Game game);
        
        bool DeadOfBullet(int x, int y, Game game);

        bool DeadInConflict(ICreature conflictedObject, Game game);
    }
}