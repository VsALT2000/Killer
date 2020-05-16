using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Killer.Architecture;

namespace Killer.Entities
{
    public class Monster : ICreature
    {
        private const int DetectPlayer = 5;
        
        private readonly SoundPlayer _fire = new SoundPlayer(Environment.CurrentDirectory + 
                                                             @"\Sounds\Fire.wav");
        private readonly SoundPlayer _noAmmo = new SoundPlayer(Environment.CurrentDirectory + 
                                                               @"\Sounds\NoAmmo.wav");

        private static Game _game;

        public CreatureCommand Act(int x, int y, Game game)
        {
            _game = game;
            var command = new CreatureCommand();
            var (dx, dy) = GetPlayerLocation(x, y);
            if (dx == -1 || dx == -1) return command;
            var monsterX = Math.Sign(dx - x);
            var monsterY = Math.Sign(dy - y);
            if (CanMove(x + monsterX, y))
            {
                command.DeltaX = monsterX;
                return command;
            }
            if (!CanMove(x, y + monsterY)) return command;
            command.DeltaY = monsterY;
            return command;
        }

        public bool DeadOfBullet(int x, int y, Game game)
        {
            _game = game;
            var key = game.KeyPressed;
            if (key != Keys.F || !PlayerOnXorY(x, y)) return false;
            if (Game.Ammo <= 0)
            {
                _noAmmo.Play();
                return false;
            }

            Game.Ammo--;
            _fire.Play();
            Game.Scores += 100;
            return true;
        }

        public string GetImageFileName() => "Monster.png";

        private static Tuple<int, int> GetPlayerLocation(int x, int y)
        {
            for (var dx = x - DetectPlayer; dx <= x + DetectPlayer; dx++)
            for (var dy = y - DetectPlayer; dy <= y + DetectPlayer; dy++)
                if (dx >= 0 && dy >= 0 && dx < _game.Width && dy < _game.Height)
                    if (_game.Map[dx, dy] is Player || _game.Map[dx, dy] is PlayerWithGun)
                    {
                        var wayToPlayer = Bfs.FindPath(new Point(x, y), _game).FirstOrDefault();
                        if (wayToPlayer == null) return Tuple.Create(-1, -1);
                        var point = wayToPlayer.Reverse().Skip(1).First();
                        return Tuple.Create(point.X, point.Y);
                    }

            return Tuple.Create(-1, -1);
        }

        private static bool CanMove(int x, int y) =>
            _game.Map[x, y] == null || _game.Map[x, y] is Player || _game.Map[x, y] is PlayerWithGun;

        public bool DeadInConflict(ICreature conflictedObject, Game game) => conflictedObject is Monster;

        private static bool PlayerOnXorY(int x, int y)
        {
            for (var i = x; i <= x + PlayerWithGun.FiringRange; i++)
                if (i >= 0 && i < _game.Width)
                    if (_game.Map[i, y] is Wall || _game.Map[i, y] is Monster)
                        break;
                    else if (_game.Map[i, y] is PlayerWithGun) return true;
            for (var i = y; i <= y + PlayerWithGun.FiringRange; i++)
                if (i >= 0 && i < _game.Height)
                    if (_game.Map[x, i] is Wall || _game.Map[x, i] is Monster)
                        break;
                    else if (_game.Map[x, i] is PlayerWithGun) return true;
            for (var i = x; i >= x - PlayerWithGun.FiringRange; i--)
                if (i >= 0 && i < _game.Width)
                    if (_game.Map[i, y] is Wall || _game.Map[i, y] is Monster)
                        break;
                    else if (_game.Map[i, y] is PlayerWithGun) return true;
            for (var i = y; i >= y - PlayerWithGun.FiringRange; i--)
                if (i >= 0 && i < _game.Height)
                    if (_game.Map[x, i] is Wall || _game.Map[x, i] is Monster)
                        break;
                    else if (_game.Map[x, i] is PlayerWithGun) return true;
            return false;
        }

        public int GetDrawingPriority() => 0;
    }
}