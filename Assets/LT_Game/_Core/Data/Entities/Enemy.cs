using System;

namespace LT_Game.Core.Data.Entities
{
    public class Enemy : Entity
    {
        public string Name { get; }
        public int BaseDamage { get; }
        public Weapon LootWeapon { get; }
        public string SpecialAbility { get; }

        public Enemy(string name, int baseHealth, int strength, int agility, int endurance, int baseDamage, Weapon lootWeapon,
            string specialAbility) : base(baseHealth, strength, agility, endurance)
        {
            LootWeapon = lootWeapon ?? throw new ArgumentException("LootWeapon cannot be null", nameof(lootWeapon));
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
            BaseDamage = baseDamage;
            SpecialAbility = specialAbility;
        }

        public override int CalculateDamage() => 
            BaseDamage + Strength;

        public override string ToString() => $"Enemy{{Name: {Name}, Health: {Health}, MaxHealth: {MaxHealth}, BaseDamage: {BaseDamage}, " +
                                             $"Strength: {Strength}, Agility: {Agility},  Endurance: {Endurance}, " +
                                             $"LootWeapon: {LootWeapon.Name}, SpecialAbility: {SpecialAbility}}}";
    }
}