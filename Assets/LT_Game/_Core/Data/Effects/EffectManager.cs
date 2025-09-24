using System.Collections.Generic;
using System.Linq;
using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public class EffectManager
    {
        private readonly List<IEffect> _activeEffects = new();
        private readonly Entity _owner;

        public EffectManager(Entity owner) =>
            _owner = owner;

        public void Add(IEffect effect)
        {
            _activeEffects.Add(effect);
            effect.OnApply(_owner);
        }

        public void Remove(IEffect effect)
        {
            _activeEffects.Remove(effect);
            effect.OnRemove(_owner);
        }

        public void ProcessTurnStart()
        {
            foreach (var effect in _activeEffects.ToList())
                effect.OnTurnStart(_owner);
        }

        public int ModifyAttackDamage(Entity target, int baseDamage) => 
            _activeEffects.Aggregate(baseDamage, (current, effect) => 
                effect.OnAttack(_owner, target, current));
        
        public int ModifyDefenseDamage(Entity attacker, int incomingDamage) =>
            _activeEffects.Aggregate(incomingDamage, (current, effect) =>
                effect.OnDefend(_owner, attacker, current));
    }
}