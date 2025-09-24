using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public abstract class StatusEffect : IEffect
    {
        public int duration { get; protected set; }

        public void OnApply(Entity target) { }

        public void OnTurnStart(Entity owner)
        {
            duration--;
            if (duration <= 0) owner.effectManager.Remove(this);
        }

        public int OnAttack(Entity owner, Entity target, int damage) =>
            damage;

        public int OnDefend(Entity owner, Entity target, int damage) => 
            damage;
        
        public virtual void OnRemove(Entity target) { }
    }
}