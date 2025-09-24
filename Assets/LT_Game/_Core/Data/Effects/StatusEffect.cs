using System.Linq;
using System.Reflection;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public abstract class StatusEffect : IEffect
    {
        public int duration { get; protected set; }
        
        public string description { get; protected set; }

        public virtual void OnApply(Entity target) { }

        public virtual void OnTurnStart(Entity owner)
        {
            if (duration == -1)
                return;
            duration--;
            if (duration < 0) owner.effectManager.Remove(this);
        }

        public virtual DamageResult OnAttack(Entity owner, Entity target, DamageResult damage) =>
            damage;

        public virtual DamageResult OnDefend(Entity owner, Entity target, DamageResult damage) => 
            damage;
        
        public virtual void OnRemove(Entity target) { }

        public override string ToString()
        {
            var props = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => !f.Name.StartsWith("duration") && !f.Name.StartsWith("description"))
                .ToDictionary(f => f.Name, f => f.GetValue(this));
    
            var desc = $"Status Effect {GetType().Name}";
            if (!string.IsNullOrEmpty(description)) desc += $": {description}";
            if (duration != -1) desc += $" ({duration} turns)";
            if (props.Any()) desc += $" [{string.Join(", ", props.Select(p => $"{p.Key}: {p.Value}"))}]";
    
            return desc;
        }
    }
}