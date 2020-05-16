using System;
using Killer;
using Killer.Entities;
using NUnit.Framework;

namespace KillerTests
{
    [TestFixture]
    public class InitializationTests
    {
        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsNull()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsNull", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is null);
        }

        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsWall()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsWall", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is Wall);
        }

        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsExit()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsExit", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is Exit);
        }

        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsPlayer()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsPlayer", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is Player);
        }

        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsPlayerWithGun()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsPlayerWithGun", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is PlayerWithGun);
        }

        [Test]
        public void InitializationMap_ShouldReturnTrue_AllCellIsMonster()
        {
            var testMap = new GameState("InitializationMap_ShouldReturnTrue_AllCellIsMonster", 0, false, false);
            foreach (var cell in testMap.Game.Map) Assert.True(cell is Monster);
        }

        [Test]
        public void InitializationMap_ShouldReturnArgumentException_WrongMapName() 
            => Assert.Throws<ArgumentException>(() => new GameState("qwerty", 0, false, false));

        [Test]
        public void InitializationMap_ShouldReturnException_WrongSizeMap() 
            => Assert.Throws<Exception>(() 
                => new GameState("InitializationMap_ShouldReturnException_WrongSizeMap", 0, false, false));

        [Test]
        public void InitializationMap_ShouldReturnException_WrongMapCells()
            => Assert.Throws<Exception>(()
                => new GameState("InitializationMap_ShouldReturnException_WrongMapCells", 0, false, false));
    }
}