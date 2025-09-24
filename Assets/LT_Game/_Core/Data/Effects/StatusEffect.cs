using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public abstract class StatusEffect : IEffect
    {
        public int duration { get; protected set; }

        public virtual void OnApply(Entity target) { }

        public virtual void OnTurnStart(Entity owner)
        {
            if (duration == -1)
                return;
            duration--;
            if (duration < 0) owner.effectManager.Remove(this);
        }

        public virtual int OnAttack(Entity owner, Entity target, int damage) =>
            damage;

        public virtual int OnDefend(Entity owner, Entity target, int damage) => 
            damage;
        
        public virtual void OnRemove(Entity target) { }
    }
}