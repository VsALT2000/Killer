using System.Windows.Forms;
using Killer;
using Killer.Entities;
using NUnit.Framework;

namespace KillerTests
{
    [TestFixture]
    public class PlayerWithMonsterTests
    {
        private GameState _gameState;

        [TestCase("PlayerIsFarMonster")]
        [TestCase("PlayerWithGunIsFarMonster")]
        public void Monster_ShouldWait_WhenPlayerIsFar(string map)
        {
            _gameState = new GameState(map, 0, false, false);
            DoAct();
            Assert.True(_gameState.Game.Map[6, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [TestCase("PlayerIsCloseMonster")]
        [TestCase("PlayerWithGunIsCloseMonster")]
        public void Monster_ShouldMove_WhenPlayerIsClose(string map)
        {
            _gameState = new GameState(map, 0, false, false);
            DoAct();
            Assert.True(_gameState.Game.Map[5, 0] is null);
            Assert.True(_gameState.Game.Map[4, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldDead_WhenPlayerWithGunFire()
        {
            _gameState = new GameState("PlayerWithGunIsCloseMonster", 0, false, false);
            Game.Ammo = 7;
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(Game.Ammo == 6);
            Assert.True(_gameState.Game.Map[4, 0] is null);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldAlive_WhenNoAmmo()
        {
            _gameState = new GameState("PlayerWithGunIsCloseMonster", 0, false, false);
            Game.Ammo = 0;
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[4, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldAlive_WhenPlayerIsFar()
        {
            _gameState = new GameState("PlayerWithGunIsFarMonster", 0, false, false);
            Game.Ammo = 7;
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[6, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldAlive_WhenPlayerHaveNotGun()
        {
            _gameState = new GameState("PlayerIsCloseMonster", 0, false, false);
            Game.Ammo = 7;
            _gameState.Game.KeyPressed = Keys.F;
            DoAct();
            Assert.True(_gameState.Game.Map[4, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldNotMoveDiagonally_WhenPlayerIsCloseDiagonally()
        {
            _gameState = new GameState("MonsterDontMoveDiagonally", 0, false, false);
            DoAct();
            Assert.True(_gameState.Game.Map[0, 1] is Monster);
            DoAct();
            Assert.True(_gameState.Game.Map[0, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }

        [Test]
        public void Monster_ShouldKillPlayer_UseBfs()
        {
            _gameState = new GameState("MonsterBfsMove", 0, false, false);
            for (var i = 0; i < 20; i++)
                DoAct();
            Assert.True(_gameState.Game.Map[0, 0] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }
        
        [Test]
        public void Monster_ShouldWait_WhenOnWayDoor()
        {
            _gameState = new GameState("Level3", 0, false, false);
            Game.HaveKey = true;
            _gameState.Game.KeyPressed = Keys.D;
            for (var i= 0; i < 2; i++)
                DoAct();
            Assert.True(_gameState.Game.Map[6, 1] is Monster);
            _gameState.Game.KeyPressed = Keys.None;
        }
        
        private void DoAct()
        {
            _gameState.BeginAct();
            _gameState.EndAct();
        }
    }
}