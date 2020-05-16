using System;
using System.Collections.Generic;
using System.Drawing;
using Killer.Entities;

namespace Killer.Architecture
{
    public static class Bfs
    {
        private static Game _game;
        public static IEnumerable<SinglyLinkedList<Point>> FindPath(Point start, Game game)
        {
            _game = game;
            var visited = new HashSet<Point> {start};
            var graph = new Queue<SinglyLinkedList<Point>>();
            graph.Enqueue(new SinglyLinkedList<Point>(start));
            while (graph.Count > 0)
            {
                var item = graph.Dequeue();
                foreach (var way in Ways(item.Value))
                {
                    var changedPoint = new Point(way.X + item.Value.X, way.Y + item.Value.Y);
                    if (visited.Contains(changedPoint))
                        continue;
                    visited.Add(changedPoint);
                    graph.Enqueue(new SinglyLinkedList<Point>(changedPoint, item));
                }

                if (_game.Map[item.Value.X, item.Value.Y] is Player ||
                    _game.Map[item.Value.X, item.Value.Y] is PlayerWithGun)
                    yield return item;
            }
        }

        private static IEnumerable<Point> Ways(Point point)
        {
            for (var dx = -1; dx <= 1; dx++)
            for (var dy = -1; dy <= 1; dy++)
            {
                if (Math.Abs(dx + dy) != 1 || dx + point.X < 0 || dy + point.Y < 0 || dx + point.X >= _game.Width ||
                    dy + point.Y >= _game.Height) continue;
                if (CanMove(dx + point.X, dy + point.Y)) yield return new Point(dx, dy);
            }
        }

        private static bool CanMove(int x, int y) =>
            _game.Map[x, y] == null || _game.Map[x, y] is Player || _game.Map[x, y] is PlayerWithGun;
    }
}