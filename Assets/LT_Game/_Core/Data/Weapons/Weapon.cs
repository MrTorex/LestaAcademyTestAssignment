using System;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data
{
    public sealed class Weapon
    {
        public string Name { get; }
        public int Damage { get; }
        public DamageType WeaponDamageType { get; }

        public Weapon(string name, int damage, DamageType damageType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Weapon name cannot be null or empty", nameof(name));
            if (damage <= 0)
                throw new ArgumentException("Weapon damage cannot be less or equal to zero", nameof(damage));
            
            Name = name;
            Damage = damage;
            WeaponDamageType = damageType;
        }
        
        public override string ToString() => 
            $"Weapon{{Name: {Name}, Damage: {Damage}, DamageType: {WeaponDamageType}}}";
    }
}
