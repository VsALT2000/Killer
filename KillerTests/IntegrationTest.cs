using System.Windows.Forms;
using Killer;
using Killer.Entities;
using NUnit.Framework;

namespace KillerTests
{
    [TestFixture]
    public class IntegrationTest
    {
        private GameState _gameState;

        [TestCase]
        public void All_ShouldReturnTrue_WhenRun()
        {
            _gameState = new GameState("BigMap", 0, false, false);
            DoAct();
            Assert.True(_gameState.Game.Map[6, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[5, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.S;
            for (var i = 0; i < 4; i++)
                DoAct();
            Assert.True(_gameState.Game.Map[1, 4] is PlayerWithGun);
            Game.Ammo = 0;
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 1] is Monster);
            _gameState.Game.KeyPressed = Keys.S;
            DoAct();
            Assert.True(Game.Ammo == 7);
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(Game.Ammo == 6);
            Assert.True(_gameState.Game.Map[1, 3] is null);
            _gameState.Game.KeyPressed = Keys.W;
            for (var i = 0; i < 5; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.D;
            for (var i = 0; i < 6; i++)
                DoAct();
            Assert.True(_gameState.Game.Map[7, 0] is Door);
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[9, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.A;
            for (var i = 0; i < 5; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.S;
            for (var i = 0; i < 5; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.D;
            for (var i = 0; i < 2; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.W;
            DoAct();
            Assert.True(Game.HaveKey);
            _gameState.Game.KeyPressed = Keys.W;
            DoAct();
            Assert.True(_gameState.Game.Map[3, 3] is Key);
            _gameState.Game.KeyPressed = Keys.S;
            DoAct();
            _gameState.Game.KeyPressed = Keys.A;
            for (var i = 0; i < 2; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.W;
            for (var i = 0; i < 5; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.D;
            for (var i = 0; i < 6; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[8, 0] is null);
            _gameState.Game.KeyPressed = Keys.D;
            for (var i = 0; i < 2; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.S;
            for (var i = 0; i < 3; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.A;
            for (var i = 0; i < 3; i++)
                DoAct();
            _gameState.Game.KeyPressed = Keys.S;
            DoAct();
            Assert.True(_gameState.Game.Map[6, 4] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.W;
            DoAct();
            Assert.True(_gameState.Game.Map[6, 4] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }

        private void DoAct()
        {
            _gameState.BeginAct();
            _gameState.EndAct();
        }
    }
}