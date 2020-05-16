using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Killer.Architecture
{
    public class KillerWindow : Form
    {
        private readonly Dictionary<string, Bitmap> _bitmaps = new Dictionary<string, Bitmap>();
        private readonly GameState _gameState;
        private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();
        private int _tickCount;
        private const int TimeToStep = 4;

        public KillerWindow(string level, int ammo, bool haveKey, bool isSpecialLevel)
        {
            Invalidate();
            _gameState = new GameState(level, ammo, haveKey, isSpecialLevel);
            ClientSize = new Size(GameState.ElementSize * _gameState.Game.Width,
                GameState.ElementSize * _gameState.Game.Height + 2 * GameState.ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var imagesDirectory = new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png")) _bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
            var timer = new Timer {Interval = TimeToStep * 4 - 1};
            timer.Tick += TimerTick;
            timer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Killer";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            _pressedKeys.Add(e.KeyCode);
            _gameState.Game.KeyPressed = e.KeyCode;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            _pressedKeys.Remove(e.KeyCode);
            _gameState.Game.KeyPressed = _pressedKeys.Any() ? _pressedKeys.Min() : Keys.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, 2 * GameState.ElementSize);
            e.Graphics.FillRectangle(Brushes.DimGray, 0, 0, GameState.ElementSize * _gameState.Game.Width,
                GameState.ElementSize * _gameState.Game.Height);
            foreach (var a in _gameState.Animations)
                e.Graphics.DrawImage(_bitmaps[a.Creature.GetImageFileName()], a.Location);
            e.Graphics.ResetTransform();
            e.Graphics.DrawString($"Scores: {Game.Scores.ToString()}", new Font("Arial", 16), Brushes.Green, 0, 32);
            e.Graphics.DrawString($"Ammo: {Game.Ammo.ToString()}", new Font("Arial", 16), Brushes.Green, 130, 32);
            e.Graphics.DrawString($"Key: {Game.HaveKey.ToString()}", new Font("Arial", 16), Brushes.Green, 250, 32);
        }

        private void TimerTick(object sender, EventArgs args)
        {
            if (_tickCount == 0) _gameState.BeginAct();
            foreach (var e in _gameState.Animations)
                e.Location = new Point(e.Location.X + TimeToStep * e.Command.DeltaX, e.Location.Y + TimeToStep * e.Command.DeltaY);
            if (_tickCount == TimeToStep * 2 - 1) _gameState.EndAct();
            _tickCount++;
            if (_tickCount == TimeToStep * 2) _tickCount = 0;
            Invalidate();
        }
    }
}