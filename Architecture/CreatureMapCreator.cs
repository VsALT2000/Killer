using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Killer
{
    public static class CreatureMapCreator
    {
        private static readonly Dictionary<string, Func<ICreature>> Factory = new Dictionary<string, Func<ICreature>>();

        public static ICreature[,] CreateMap(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            for (var y = 0; y < rows.Length; y++)
                result[x, y] = CreateCreatureBySymbol(rows[y][x]);
            return result;
        }

        private static ICreature CreateCreatureByTypeName(string name)
        {
            if (Factory.ContainsKey(name)) return Factory[name]();
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(z => z.Name == name);
            if (type == null)
                throw new Exception($"Can't find type '{name}'");
            Factory[name] = () => (ICreature) Activator.CreateInstance(type);

            return Factory[name]();
        }


        private static ICreature CreateCreatureBySymbol(char c)
        {
            switch (c)
            {
                case 'P':
                    return CreateCreatureByTypeName("Player");
                case 'K':
                    return CreateCreatureByTypeName("PlayerWithGun");
                case 'W':
                    return CreateCreatureByTypeName("Wall");
                case 'A':
                    return CreateCreatureByTypeName("Ammo");
                case 'G':
                    return CreateCreatureByTypeName("Gun");
                case 'M':
                    return CreateCreatureByTypeName("Monster");
                case 'E':
                    return CreateCreatureByTypeName("Exit");
                case 'D':
                    return CreateCreatureByTypeName("Door");
                case 'C': //Уже кончились букавки свободные.
                    return CreateCreatureByTypeName("Key");
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {c}");
            }
        }
    }
}