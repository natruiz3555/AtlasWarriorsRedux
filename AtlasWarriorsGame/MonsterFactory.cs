using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasWarriorsGame
{
    static class MonsterFactory
    {
        /// <summary>
        /// Monsters that may be built
        /// </summary>
        private static Dictionary<string, JObject> Prototypes = new Dictionary<string, JObject>();

        /// <summary>
        /// Add elements to the protoypes that can be constructed
        /// </summary>
        /// <param name="prototypes">Key value dictionaries containing monster details</param>
        public static void AddPrototypes(Dictionary<string, JObject> prototypes)
        {
            foreach (var prototype in prototypes)
            {
                Prototypes.Add(prototype.Key, prototype.Value);
            }
        }

        /// <summary>
        /// Create a monster using the given prototype
        /// </summary>
        /// <param name="game">The game that is being played</param>
        /// <param name="dungeon">Dungeon to put monster in</param>
        /// <param name="monsterType">Type of monster to build</param>
        /// <param name="location">Location to build monster</param>
        /// <returns></returns>
        public static Monster CreateMonster(Game game, Dungeon dungeon, string monsterType, XY location)
        {
            JObject prototype;
            if (!Prototypes.TryGetValue(monsterType, out prototype))
                throw new KeyNotFoundException("Monster type not found");
            var monster = new Monster(dungeon, location);
            monster.SpriteId = prototype.Value<String>("SpriteId");
            monster.MaxHealth = prototype.Value<int>("Health");
            monster.SetHealth(prototype.Value<int>("Health"));
            monster.BaseAtk = prototype.Value<int>("BaseAtk");
            monster.BaseDef = prototype.Value<int>("BaseDef");
            monster.BaseDmg = prototype.Value<int>("BaseDmg");
            return monster;
        }
    }
}
