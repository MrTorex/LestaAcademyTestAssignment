using LT_Game.Core.Data;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.GameSystems
{
    public static class WeaponFactory
    {
        public static Weapon CreateSword() => 
            new("Меч", 3, DamageType.Slashing);
        
        public static Weapon CreateClub() => 
            new("Дубина", 3, DamageType.Bludgeoning);
        
        public static Weapon CreateDagger() => 
            new("Кинжал", 2, DamageType.Piercing);
        
        public static Weapon CreateAxe() => 
            new("Топор", 4, DamageType.Slashing);
        
        public static Weapon CreateSpear() => 
            new("Копье", 3, DamageType.Piercing);
        
        public static Weapon CreateLegendarySword() => 
            new("Легендарный Меч", 5, DamageType.Slashing);
    }
}