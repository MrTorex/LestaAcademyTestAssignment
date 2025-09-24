using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data
{

    public class DamageResult
    {
        public Dictionary<DamageType, int> damageByType { get; } = new();
        public Dictionary<DamageType, int> damageByTypeModifiers { get; } = new();

        public Dictionary<DamageType, int> resultDamageByType
        {
            get
            {
                var result = new Dictionary<DamageType, int>();
                foreach (var (type, damage) in damageByType)
                {
                    var modifier = damageByTypeModifiers.GetValueOrDefault(type, 1);
                    result.Add(type, damage);
                }
                
                return result;
            }
        }

        public int ResultDamage => 
            resultDamageByType.Values.Sum();

        public void Add(DamageType type, int damage) =>
            damageByType.Add(type, damage);

        public override string ToString()
        {
            var result = "";
            foreach (var (type, damage) in damageByType)
            {
                result += $"{type}: {damage}; ";
            }
            result += $"Total: {ResultDamage}";
            return result;
        }
    }
}