using System;

namespace KillerTests
{
    public class LevelTestsCreator
    {
        public static string GetLevel(string levelName)
        {
            switch(levelName)
            {
                case "KeyWWithPlayerWithGun":
                    return WithPlayer();
                case "KeyAWithPlayerWithGun":
                    return WithPlayerWithGun();
                case "KeySWithPlayerWithGun":
                    return WithPlayerWithGun();
                case "KeyDWithPlayerWithGun":
                    return WithPlayerWithGun();
                case "KeyWWhenWallWithPlayerWithGun":
                    return WithPlayerWithGunAndWallAround();
                case "KeyAWhenWallWithPlayerWithGun":
                    return WithPlayerWithGunAndWallAround();
                case "KeySWhenWallWithPlayerWithGun":
                    return WithPlayerWithGunAndWallAround();
                case "KeyDWhenWallWithPlayerWithGun":
                    return WithPlayerWithGunAndWallAround();
                case "MapWithNoExitWithPlayerWithGun":
                    return WithNoExitAndPlayerWithGun();
                case "MapWithAmmoWithPlayerWithGun":
                    return WithAmmoAndPlayerWithGun();
                case "MapWithDoorAndKeyWithPlayerWithGun":
                    return WithDoorAndKeyAndPlayerWithGun();
                case "KeyW":
                    return WithPlayer();
                case "KeyA":
                    return WithPlayer();
                case "KeyS":
                    return WithPlayer();
                case "KeyD":
                    return WithPlayer();
                case "KeyWWhenWall":
                    return WithPlayerAndWallAround();
                case "KeyAWhenWall":
                    return WithPlayerAndWallAround();
                case "KeySWhenWall":
                    return WithPlayerAndWallAround();
                case "KeyDWhenWall":
                    return WithPlayerAndWallAround();
                case "MapWithNoExit":
                    return WithNoExit();
                case "MapWithGun":
                    return WithGun();
                case "MapWithAmmo":
                    return WithAmmo();
                case "MapWithDoorAndKey":
                    return WithDoorAndKey();
                case "PlayerIsFarMonster":
                    return PlayerIsFarMonster();
                case "PlayerIsCloseMonster":
                    return PlayerIsCloseMonster();
                case "PlayerWithGunIsFarMonster":
                    return PlayerWithGunIsFarMonster();
                case "PlayerWithGunIsCloseMonster":
                    return PlayerWithGunIsCloseMonster();
                case "MonsterDontMoveDiagonally":
                    return MonsterDontMoveDiagonally();
                case "MonsterBfsMove":
                    return MonsterBfsMove();
                case "BigMap":
                    return BigMap();
                case "InitializationMap_ShouldReturnTrue_AllCellIsNull":
                    return InitializationMapShouldReturnTrueAllCellIsNull();
                case "InitializationMap_ShouldReturnTrue_AllCellIsWall":
                    return InitializationMapShouldReturnTrueAllCellIsWall();
                case "InitializationMap_ShouldReturnTrue_AllCellIsExit":
                    return InitializationMapShouldReturnTrueAllCellIsExit();
                case "InitializationMap_ShouldReturnTrue_AllCellIsPlayer":
                    return InitializationMapShouldReturnTrueAllCellIsPlayer();
                case "InitializationMap_ShouldReturnTrue_AllCellIsPlayerWithGun":
                    return InitializationMapShouldReturnTrueAllCellIsPlayerWithGun();
                case "InitializationMap_ShouldReturnTrue_AllCellIsMonster":
                    return InitializationMapShouldReturnTrueAllCellIsMonster();
                case "InitializationMap_ShouldReturnException_WrongSizeMap":
                    return InitializationMapShouldReturnExceptionWrongSizeMap();
                case "InitializationMap_ShouldReturnException_WrongMapCells":
                    return InitializationMapShouldReturnExceptionWrongMapCells();
                default:
                    throw new ArgumentException();
            }
        }
        
        private static string WithPlayer() => @"
E W
 P 
W W";
        
        private static string WithPlayerAndWallAround() => @"
EWW
WPW
WWW";
        
        private static string WithNoExit() => @"
P ";

        private static string WithGun() => @"
PGE";

        private static string WithAmmo() => @"
PAE";

        private static string WithDoorAndKey() =>  @"
CCPDE";

        private static string WithPlayerWithGun() => @"
E W
 K 
W W";

        private static string WithPlayerWithGunAndWallAround() => @"
EWW
WKW
WWW";

        private static string WithNoExitAndPlayerWithGun() => @"
K ";

        private static string WithAmmoAndPlayerWithGun() => @"
KAE";

        private static string WithDoorAndKeyAndPlayerWithGun() => @"
CCKDE";

        private static string PlayerIsFarMonster() => @"
P     M";

        private static string PlayerIsCloseMonster() => @"
P    M";

        private static string PlayerWithGunIsFarMonster() => @"
K     M";

        private static string PlayerWithGunIsCloseMonster() => @"
K    M";

        private static string MonsterDontMoveDiagonally() => @"
PW
 M";

        private static string MonsterBfsMove() => @"
PW   W
 W W W
 W W W
 W W W
 W W W
   W M";

        private static string InitializationMapShouldReturnTrueAllCellIsNull() => @"
   ";

        private static string InitializationMapShouldReturnTrueAllCellIsWall() => @"
WWW";

        private static string InitializationMapShouldReturnTrueAllCellIsExit() => @"
EEE";

        private static string InitializationMapShouldReturnTrueAllCellIsPlayer() => @"
PPP";

        private static string InitializationMapShouldReturnTrueAllCellIsPlayerWithGun() => @"
KKK";

        private static string InitializationMapShouldReturnTrueAllCellIsMonster() => @"
MMM";

        private static string InitializationMapShouldReturnExceptionWrongSizeMap() => @"
WW
WWW";

        private static string InitializationMapShouldReturnExceptionWrongMapCells() => @"
QWERTY";

        private static string BigMap() => @"
P     MD M
WGWWWWWWW 
W WWWWWWW 
W WCWW    
W WCWWEWW 
WA  WWWWWW";
    }
}