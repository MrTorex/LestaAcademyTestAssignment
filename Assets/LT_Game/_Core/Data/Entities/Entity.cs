using System;

namespace LT_Game.Core.Data.Entities
{
    public abstract class Entity
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Endurance { get; set; }

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
            
            Strength = strength;
            Agility = agility;
            Endurance = endurance;
            MaxHealth = baseHealth;
            Health = MaxHealth;
        }

        public abstract int CalculateDamage();
        
        public void TakeDamage(int amount) => 
            Health -= amount;
        
        public bool IsAlive =>
            Health > 0;
        
        public void HealToFull() => 
            Health = MaxHealth;

        public override string ToString() => 
            $"Entity{{Health: {Health}, MaxHealth: {MaxHealth}, Strength: {Strength}, Agility: {Agility},  Endurance: {Endurance}}}";
    }
}