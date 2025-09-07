using System;
using System.Collections.Generic;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;

namespace LT_Game.Core.Data.Entities
{
    public class Player : Entity
    {
        public Dictionary<ClassType, int> ClassLevels { get; } = new();
        public Weapon CurrentWeapon { get; private set; }

        public Player(int baseHealth, int strength, int agility, int endurance, Weapon weapon) :
            base(baseHealth, strength, agility, endurance)
        {
            CurrentWeapon = weapon ?? throw new ArgumentException("Weapon cannot be null", nameof(weapon));
        }

        public void LevelUp(ClassType classType)
        {
            var newLevel = ClassLevels.GetValueOrDefault(classType, 0) + 1;
            ClassLevels[classType] = newLevel;
            
            ClassBonusService.ApplyLevelBonus(classType, newLevel, this);
        }

        public override int CalculateDamage() =>
            CurrentWeapon.Damage + Strength;

        public override string ToString() => $"Player{{Health: {Health}, MaxHealth: {MaxHealth}, " +
                                             $"Strength: {Strength}, Agility: {Agility},  Endurance: {Endurance}, " +
                                             $"Weapon: {CurrentWeapon.Name}}}";
    }
}