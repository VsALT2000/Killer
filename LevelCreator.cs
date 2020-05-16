using System;
using System.Diagnostics;

namespace Killer
{
    public class LevelCreator
    {
        public static string GetLevel(string levelName)
        {
            switch(levelName)
            {
                case "Level1":
                    return Level1();
                case "Level2":
                    return Level2();
                case "Level3":
                    return Level3();
                case "Level4":
                    return Level4();
                case "Level5":
                    return Level5();
                case "Level6":
                    return Level6();
                case "Level7":
                    return Level7();
                default:
                    throw new ArgumentException();
            }
        }
        
        private static string Level1() => @"
WWWWWWWWW
P  C D  E
WWWWWWWWW";
        
        private static string Level2() => @"
WWWWWWWWWWW
P   W     W
WWW W WWW W
WWW W W   W
W   W W WWW
WGW   W  MW
WWWWWWWWWEW";
        
        private static string Level3() => @"
WWWWWWWWWWWWWWWW
KCD  WM W    WGW
WW W WW W WW   W
W  W WW W W  WWW
W WW WW W W WWWW
W  W WW W W WWMW
WWMW      W    E
WWWWWWWWWWWWWWWW";
        
        private static string Level4() => @"
WWWWWWWWWWWWWWWWWW
K    WWWWWMWWWWWWW
WW W       W    WW
WW WWWW WWWWDWWMWW
WW W WW WCW  WWWWW
W  W WW W W WWWWWW
WMWW  M   W      E
WWWM WWWW   WWWWWW
WWWWWWWWWWWWWWWWWW";
        
        private static string Level5() => @"
WWWWWWWWWWWWWWWWWW
K   W   WWW WW   W
WWW W W W      W W
WW    W   WW W W W
WW WW   W WW W W E
W   WWWWW    W WWW
W W    MWWWWWWMWWW
WMWWWWW     AWWWWW
WWWWWWWWWWWWWWWWWW";
        
        private static string Level6() => @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWW
WM   W     WWWWM    W    WAW
WWW WW WWW W  W WWW W    W W
WW     W   W WW WW    WWWW W
W   G    W W WW WW WWWW    W
WW    W WW   W  WW      WWWW
WWWW WW WWWWWW WWWWWWWW WWWW
WWWW WW MWWA   WWWWWWWW WWWW
W    WWW    WWWWWWWWWWW WWWW
W WWWWWWWWWWWWWWWWWWWWW WWWW
W WWWWWWWWWWWWWWWWWWWWW WWWW
W WWWWWWWWWWWWWWWWWWM     MW
WKWWWWWWWWWWWWWWWWWWWWWEWWWW";
        
        private static string Level7() => @"
WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWM          WW       C W     MWWW
WWWWWW WWW   WW WWWWWWW WCWWW WWWW
WM     WWW      WW DMWW WWWWW WWWW
WW WWWWWWW   WWWWW WWWW       WWWW
WW W    WWW WWWWWW DMWWWMWW WWWWWW
WA   WW WWW WW     WWWWWWWW WWWWWW
WWWWWWWDWWW    WWW DMWWWWWM DDDD W
WC      WWWWWWWWWWWWWWWWWWWWWWWW W
WWWWWWW    M WW        WWWWWAWWW W
WM    WWWWWW    W WWWW     D CWW W
WWWWW W    WWWWWWDWWWWWWWWWW MW  W
W     W WW WW     WG  WWWWWWWWW WW
W WWWWW WW WW WWWDWWW      D    WW
W  G C  WA     MW     WWWWWWWWW  E
WPWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW";
    }
}