using System;
using System.Windows.Forms;
using Killer.Architecture;

namespace Killer
{
    internal static class Program
    {
        [STAThread]
        private static void Main() => Application.Run(new KillerMenu());
    }
}