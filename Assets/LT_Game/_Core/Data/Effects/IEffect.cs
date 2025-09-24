using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public interface IEffect
    {
        int duration { get; }
        void OnApply(Entity target);
        void OnTurnStart(Entity owner);
        DamageResult OnAttack(Entity owner, Entity target, DamageResult damage);
        DamageResult OnDefend(Entity owner, Entity target, DamageResult damage);
        void OnRemove(Entity target);
    }
}