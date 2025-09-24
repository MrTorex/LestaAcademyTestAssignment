using System;
using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;

namespace LT_Game.Core.Data.Entities
{
    public class Player : Entity
    {
        public Dictionary<ClassType, int> ClassLevels { get; } = new();
        public Weapon CurrentWeapon { get; private set; }

        public Player(int baseHealth, int strength, int agility, int endurance, Weapon weapon) :
            base(baseHealth + endurance, strength, agility, endurance)
        {
            CurrentWeapon = weapon ?? throw new ArgumentException("Weapon cannot be null", nameof(weapon));
        }

        public void LevelUp(ClassType classType)
        {
            var newLevel = ClassLevels.GetValueOrDefault(classType, 0) + 1;
            ClassLevels[classType] = newLevel;
            
            ClassBonusService.ApplyLevelBonus(classType, newLevel, this);
        }

        public override DamageResult CalculateDamage()
        {
            var result = new DamageResult();
            result.Add(CurrentWeapon.weaponDamageType, CurrentWeapon.damage);
            result.Add(DamageType.Physical, strength);
            return result;
        }

        public override string ToString()
        {
            var result = $"Player{{Health: {health}, MaxHealth: {maxHealth}, " +
                                             $"Strength: {strength}, Agility: {agility},  Endurance: {endurance}, " +
                                             $"Weapon: {CurrentWeapon.name}, Active Effects: ";

            effectManager.ActiveEffects.Aggregate(result, (current, effect) => current + $"{effect}; ");
            result += "}}";
            return result;
        }
    }
}