using System;
using LT_Game.Core.Data.Enums;

namespace LT_Game.Core.Data.Entities
{
    public class Enemy : Entity
    {
        public string name { get; }
        public int baseDamage { get; }
        public Weapon lootWeapon { get; }
        public string specialAbility { get; }

        public Enemy(string name, int baseHealth, int strength, int agility, int endurance, int baseDamage, Weapon lootWeapon,
            string specialAbility) : base(baseHealth, strength, agility, endurance)
        {
            this.lootWeapon = lootWeapon ?? throw new ArgumentException("LootWeapon cannot be null", nameof(lootWeapon));
            if (!string.IsNullOrWhiteSpace(name))
                this.name = name;
            this.baseDamage = baseDamage;
            this.specialAbility = specialAbility;
        }

        public override DamageResult CalculateDamage()
        {
            var result = new DamageResult();
            result.Add(DamageType.Physical, baseDamage);
            return result;
        }

        public override string ToString() => $"Enemy{{Name: {name}, Health: {health}, MaxHealth: {maxHealth}, BaseDamage: {baseDamage}, " +
                                             $"Strength: {strength}, Agility: {agility},  Endurance: {endurance}, " +
                                             $"LootWeapon: {lootWeapon.name}, SpecialAbility: {specialAbility}}}";
    }
}