using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Killer.Architecture;

namespace Killer.Entities
{
    public class Robot : ICreature
    {
        private readonly SoundPlayer _walk = new SoundPlayer(System.Environment.CurrentDirectory + @"\Sounds\Walk.wav");
        private static HashSet<Point> _targets = new HashSet<Point>();
        
        public CreatureCommand Act(int x, int y)
        {
            Game.KeyPressed = Keys.None;
            _targets = new HashSet<Point>();
            var player = new CreatureCommand();
            if (MonsterOnXorY(x, y)) Game.KeyPressed = Keys.F;
            FindLocateTargets();
            if (_targets != null)
            {
                var (dx, dy) = GetTargetLocate(x, y);
                if (dx != -1 && dy != -1)
                {
                    var playerX = Math.Sign(dx - x);
                    var playerY = Math.Sign(dy - y);
                    player.DeltaX = playerX;
                    player.DeltaY = playerY;
                    return player;
                }
            }
            FindDoorLocate();
            if (_targets != null)
            {
                var (dx, dy) = GetTargetLocate(x, y);
                if (dx != -1 && dy != -1)
                {
                    var playerX = Math.Sign(dx - x);
                    var playerY = Math.Sign(dy - y);
                    player.DeltaX = playerX;
                    player.DeltaY = playerY;
                    return player;
                }
            }
            FindExitLocate();
            if (_targets == null) 
                return player;
            {
                var (dx, dy) = GetTargetLocate(x, y);
                if (dx == -1 || dy == -1) return player;
                var playerX = Math.Sign(dx - x);
                var playerY = Math.Sign(dy - y);
                player.DeltaX = playerX;
                player.DeltaY = playerY;
                return player;
            }
        }
        
        private static bool MonsterOnXorY(int x, int y)
        {
            for (var i = x; i <= x + PlayerWithGun.FiringRange; i++)
                if (i >= 0 && i < Game.MapWidth)
                    if (Game.Map[i, y] is Wall)
                        break;
                    else if (Game.Map[i, y] is Monster)
                        return true;
            for (var i = y; i <= y + PlayerWithGun.FiringRange; i++)
                if (i >= 0 && i < Game.MapHeight)
                    if (Game.Map[x, i] is Wall)
                        break;
                    else if (Game.Map[x, i] is Monster)
                        return true;
            for (var i = x; i >= x - PlayerWithGun.FiringRange; i--)
                if (i >= 0 && i < Game.MapWidth)
                    if (Game.Map[i, y] is Wall)
                        break;
                    else if (Game.Map[i, y] is Monster)
                        return true;
            for (var i = y; i >= y - PlayerWithGun.FiringRange; i--)
                if (i >= 0 && i < Game.MapHeight)
                    if (Game.Map[x, i] is Wall)
                        break;
                    else if (Game.Map[x, i] is Monster)
                        return true;
            return false;
        }
        
        private static void FindExitLocate()   //Я не помню, как проверять тип, поэтому куча одинаковых методов.
        {
            for (var dx = 0; dx < Game.MapWidth; dx++)
            for (var dy = 0; dy < Game.MapHeight; dy++)
                if (Game.Map[dx, dy] is Exit)
                    _targets.Add(new Point(dx, dy));
        }
        
        private static void FindDoorLocate()
        {
            for (var dx = 0; dx < Game.MapWidth; dx++)
            for (var dy = 0; dy < Game.MapHeight; dy++)
                if (Game.Map[dx, dy] is Door)
                    _targets.Add(new Point(dx, dy));
        }
        
        private static Tuple<int, int> GetTargetLocate(int x, int y)
        {
            var wayToPlayer = Bfs.FindPath(new Point(x, y), _targets).FirstOrDefault(); 
            if (wayToPlayer == null) return Tuple.Create(-1, -1);
            var point = wayToPlayer.Reverse().Skip(1).First();
            return Tuple.Create(point.X, point.Y);
        }
        
        private static void FindLocateTargets()
        {
            for (var dx = 0; dx < Game.MapWidth; dx++)
            for (var dy = 0; dy < Game.MapHeight; dy++)
                if (Game.Map[dx, dy] is Key || Game.Map[dx, dy] is Ammo || Game.Map[dx, dy] is Gun)
                    _targets.Add(new Point(dx, dy));
        }

        public bool DeadOfBullet(int x, int y) => false;

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Monster)
                Game.IsOver = true;
            return conflictedObject is Monster;
        }

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Robot.png";
    }
}