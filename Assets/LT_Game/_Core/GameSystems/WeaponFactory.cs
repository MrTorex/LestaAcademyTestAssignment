using LT_Game.Core.Data;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.GameSystems
{
    public static class WeaponFactory
    {
        public static Weapon CreateSword() => 
            new("Sword", 3, DamageType.Slashing);
        
        public static Weapon CreateClub() => 
            new("Club", 3, DamageType.Bludgeoning);
        
        public static Weapon CreateDagger() => 
            new("Dagger", 2, DamageType.Piercing);
        
        public static Weapon CreateAxe() => 
            new("Axe", 4, DamageType.Slashing);
        
        public static Weapon CreateSpear() => 
            new("Spear", 3, DamageType.Piercing);
        
        public static Weapon CreateLegendarySword() => 
            new("Legendary Sword", 5, DamageType.Slashing);
    }
}