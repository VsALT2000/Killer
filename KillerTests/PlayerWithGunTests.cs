using System.Windows.Forms;
using Killer;
using Killer.Entities;
using NUnit.Framework;

namespace KillerTests
{
    [TestFixture]
    public class PlayerWithGunTest
    {
        private GameState _gameState;

        [TestCase("KeyWWithPlayerWithGun", Keys.W)]
        [TestCase("KeyAWithPlayerWithGun", Keys.A)]
        [TestCase("KeySWithPlayerWithGun", Keys.S)]
        [TestCase("KeyDWithPlayerWithGun", Keys.D)]
        public void PlayerWithGun_ShouldMove_WhenKeyPressed(string map, Keys keyPressed)
        {
            _gameState = new GameState(map, 0, false, false);
            _gameState.Game.KeyPressed = keyPressed;
            
            DoAct();
            
            Assert.False(_gameState.Game.Map[1, 1] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [TestCase("KeyWWhenWallWithPlayerWithGun", Keys.W)]
        [TestCase("KeyAWhenWallWithPlayerWithGun", Keys.A)]
        [TestCase("KeySWhenWallWithPlayerWithGun", Keys.S)]
        [TestCase("KeyDWhenWallWithPlayerWithGun", Keys.D)]
        public void PlayerWithGun_ShouldStayInPlace_WhenAroundWall(string map, Keys keyPressed)
        {
            _gameState = new GameState(map, 0, false, false);
            _gameState.Game.KeyPressed = keyPressed;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 1] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void PlayerWithGun_ShouldStayInPlace_WhenNoExit()
        {
            _gameState = new GameState("MapWithNoExitWithPlayerWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[0, 0] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void PlayerWithGun_ShouldHaveAmmo_WhenTakeAmmo()
        {
            _gameState = new GameState("MapWithAmmoWithPlayerWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            var temp = Game.Ammo;
            DoAct();
            Assert.True(_gameState.Game.Map[1, 0] is PlayerWithGun);
            Assert.True(Game.Ammo - temp == 7);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void PlayerWithGun_ShouldNotGoThroughDoor_WhenHaveNotKey()
        {
            _gameState = new GameState("MapWithDoorAndKeyWithPlayerWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[2, 0] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void PlayerWithGun_ShouldGoThroughDoor_WhenTakeKey()
        {
            _gameState = new GameState("MapWithDoorAndKeyWithPlayerWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.A;
            DoAct();
            Assert.True(Game.HaveKey);
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            _gameState.Game.KeyPressed = Keys.D;
            DoAct();
            Assert.True(_gameState.Game.Map[3, 0] is PlayerWithGun);
            _gameState.Game.KeyPressed = Keys.None;
        }
        
        [Test]
        public void PlayerWithGun_ShouldNotTakeKey_WhenHaveKey()
        {
            _gameState = new GameState("MapWithDoorAndKeyWithPlayerWithGun", 0, false, false);
            _gameState.Game.KeyPressed = Keys.A;
            DoAct();
            Assert.True(Game.HaveKey);
            DoAct();
            Assert.True(_gameState.Game.Map[1, 0] is PlayerWithGun);
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