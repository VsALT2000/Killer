using System.Windows.Forms;
using Killer;
using Killer.Entities;
using NUnit.Framework;

namespace KillerTests
{
    [TestFixture]
    public class PlayerTest
    {
        private GameState _gameState;

        [TestCase("KeyW", Keys.W)]
        [TestCase("KeyA", Keys.A)]
        [TestCase("KeyS", Keys.S)]
        [TestCase("KeyD", Keys.D)]
        public void Player_ShouldMove_WhenKeyPressed(string map, Keys keyPressed)
        {
            _gameState = new GameState(map, 0, false, false);
            _gameState.Game.KeyPressed = keyPressed;
            DoAct();
            Assert.False(_gameState.Game.Map[1, 1] is Player);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [TestCase("KeyWWhenWall", Keys.W)]
        [TestCase("KeyAWhenWall", Keys.A)]
        [TestCase("KeySWhenWall", Keys.S)]
        [TestCase("KeyDWhenWall", Keys.D)]
        public void Player_ShouldStayInPlace_WhenAroundWall(string map, Keys keyPressed)
        {
            _gameState = new GameState(map, 0, false, false);
            _gameState.Game.KeyPressed = keyPressed;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 1] is Player);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Player_ShouldStayInPlace_WhenNoExit()
        {
            _gameState = new GameState("MapWithNoExit", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[0, 0] is Player);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Player_ShouldTransformToPlayerWithGun_WhenTakeGun()
        {
            _gameState = new GameState("MapWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            var temp = Game.Ammo;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 0] is PlayerWithGun);
            Assert.True(Game.Ammo - temp == 7);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Player_ShouldHaveAmmo_WhenTakeAmmo()
        {
            _gameState = new GameState("MapWithAmmo", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            var temp = Game.Ammo;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 0] is Player);
            Assert.True(Game.Ammo - temp == 7);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Player_ShouldNotGoThroughDoor_WhenHaveNotKey()
        {
            _gameState = new GameState("MapWithDoorAndKey", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[2, 0] is Player);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Player_ShouldGoThroughDoor_WhenTakeKey()
        {
            _gameState = new GameState("MapWithDoorAndKey", 0, false, false);
            _gameState.Game.KeyPressed = Keys.A;
            DoAct();
            Assert.True(Game.HaveKey);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[3, 0] is Player);
            _gameState.Game.KeyPressed = Keys.None;
        }
        
        [Test]
        public void Player_ShouldNotTakeKey_WhenHaveKey()
        {
            _gameState = new GameState("MapWithDoorAndKey", 0, false, false);
            _gameState.Game.KeyPressed = Keys.A;
            DoAct();
            Assert.True(Game.HaveKey);
            DoAct();
            Assert.True(_gameState.Game.Map[1, 0] is Player);
            _gameState.Game.KeyPressed = Keys.None;
            Game.HaveKey = false;
        }
        
        private void DoAct()
        {
            _gameState.BeginAct();
            _gameState.EndAct();
        }
    }
}