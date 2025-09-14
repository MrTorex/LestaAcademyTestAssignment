using System;

namespace LT_Game.Core.Data.Entities
{
    public abstract class Entity
    {
        public int health { get; set; }
        public int maxHealth { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        public int endurance { get; set; }

        protected Entity(int baseHealth, int strength, int agility, int endurance)
        {
            if (baseHealth <= 0)
                throw new ArgumentException("Health must be positive", nameof(baseHealth));
            if (strength <= 0)
                throw new ArgumentException("Strength must be positive", nameof(strength));
            if (agility <= 0)
                throw new ArgumentException("Agility must be positive", nameof(agility));
            if (endurance <= 0)
                throw new ArgumentException("Endurance must be positive", nameof(endurance));
            
            this.strength = strength;
            this.agility = agility;
            this.endurance = endurance;
            maxHealth = baseHealth;
            health = maxHealth;
        }

        public abstract int CalculateDamage();
        
        public void TakeDamage(int amount) => 
            health -= amount;
        
        public bool IsAlive =>
            health > 0;
        
        public void HealToFull() => 
            health = maxHealth;

        public override string ToString() => 
            $"Entity{{Health: {health}, MaxHealth: {maxHealth}, Strength: {strength}, Agility: {agility},  Endurance: {endurance}}}";
    }
}