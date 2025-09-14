using System;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data
{
    public class Weapon
    {
        public string name { get; }
        public int damage { get; }
        public DamageType weaponDamageType { get; }

        public Weapon(string name, int damage, DamageType damageType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Weapon name cannot be null or empty", nameof(name));
            if (damage <= 0)
                throw new ArgumentException("Weapon damage cannot be less or equal to zero", nameof(damage));
            
            this.name = name;
            this.damage = damage;
            weaponDamageType = damageType;
        }
        
        public override string ToString() => 
            $"Weapon{{Name: {name}, Damage: {damage}, DamageType: {weaponDamageType}}}";
    }
}
