using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public class EffectManager
    {
        public List<IEffect> activeEffects { get; } = new();

        private readonly Entity _owner;

        public EffectManager(Entity owner) =>
            _owner = owner;

        public void Add(IEffect effect)
        {
            activeEffects.Add(effect);
            effect.OnApply(_owner);
        }

        public void Remove(IEffect effect)
        {
            activeEffects.Remove(effect);
            effect.OnRemove(_owner);
        }

        public void ProcessTurnStart()
        {
            foreach (var effect in activeEffects.ToList())
                effect.OnTurnStart(_owner);
        }

        public DamageResult ModifyAttackDamage(Entity target, DamageResult baseDamage) => 
            activeEffects.Aggregate(baseDamage, (current, effect) => 
                effect.OnAttack(_owner, target, current));
        
        public DamageResult ModifyDefenseDamage(Entity attacker, DamageResult incomingDamage) =>
            activeEffects.Aggregate(incomingDamage, (current, effect) =>
                effect.OnDefend(_owner, attacker, current));
    }
}