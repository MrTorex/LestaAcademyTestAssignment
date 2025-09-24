using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects
{
    public interface IEffect
    {
        int duration { get; }
        void OnApply(Entity target);
        void OnTurnStart(Entity owner);
        int OnAttack(Entity owner, Entity target, int damage);
        int OnDefend(Entity owner, Entity target, int damage);
        void OnRemove(Entity target);
    }
}