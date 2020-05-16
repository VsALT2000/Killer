using System.Media;
using System.Windows.Forms;

namespace Killer.Entities
{
    public class Player : ICreature
    {
        private readonly SoundPlayer _walk = new SoundPlayer(System.Environment.CurrentDirectory + 
                                                             @"\Sounds\Walk.wav");

        public CreatureCommand Act(int x, int y, Game game)
        {
            var player = new CreatureCommand();
            var key = game.KeyPressed;
            if (!HaveExit(game)) return player;
            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (key)
            {
                case Keys.W when y - 1 >= 0 && !(game.Map[x, y - 1] is Wall) 
                                            && (!(game.Map[x, y - 1] is Door) || Game.HaveKey)
                                            && (!(game.Map[x, y - 1] is Key) || !Game.HaveKey):
                    _walk.Play();
                    player.DeltaY = -1;
                    if (game.Map[x, y - 1] is Gun)
                        return new CreatureCommand() {DeltaY = -1, TransformTo = new PlayerWithGun()};
                    break;
                case Keys.D when x + 1 < game.Width && !(game.Map[x + 1, y] is Wall) 
                                                       && (!(game.Map[x + 1, y] is Door) || Game.HaveKey)
                                                       && (!(game.Map[x + 1, y] is Key) || !Game.HaveKey):
                    _walk.Play();
                    player.DeltaX = 1;
                    if (game.Map[x + 1, y] is Gun)
                        return new CreatureCommand() {DeltaX = 1, TransformTo = new PlayerWithGun()};
                    break;
                case Keys.S when y + 1 < game.Height && !(game.Map[x, y + 1] is Wall) 
                                                        && (!(game.Map[x, y + 1] is Door) || Game.HaveKey)
                                                        && (!(game.Map[x, y + 1] is Key) || !Game.HaveKey):
                    _walk.Play();
                    player.DeltaY = 1;
                    if (game.Map[x, y + 1] is Gun)
                        return new CreatureCommand() {DeltaY = 1, TransformTo = new PlayerWithGun()};
                    break;
                case Keys.A when x - 1 >= 0 && !(game.Map[x - 1, y] is Wall) 
                                            && (!(game.Map[x - 1, y] is Door) || Game.HaveKey)
                                            && (!(game.Map[x - 1, y] is Key) || !Game.HaveKey):
                    _walk.Play();
                    player.DeltaX = -1;
                    if (game.Map[x - 1, y] is Gun)
                        return new CreatureCommand() {DeltaX = -1, TransformTo = new PlayerWithGun()};
                    break;
            }

            return player;
        }

        private static bool HaveExit(Game game)
        {
            for (var x = 0; x < game.Width; x++)
            for (var y = 0; y < game.Height; y++)
                if (game.Map[x, y] is Exit)
                    return true;
            return false;
        }

        public bool DeadOfBullet(int x, int y, Game game) => false;

        public bool DeadInConflict(ICreature conflictedObject, Game game)
        {
            if (conflictedObject is Monster) Game.IsOver = true;
            return conflictedObject is Monster;
        }

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Player.png";
    }
}