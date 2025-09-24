using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class EnduranceBuffEffect : StatusEffect
    {
        private readonly int _enduranceBonus;
        
        public EnduranceBuffEffect(int enduranceBonus, int bonusDuration)
        {
            _enduranceBonus = enduranceBonus;
            duration = bonusDuration;
        }

        public override void OnApply(Entity target) =>
            target.endurance += _enduranceBonus;
        
        public override void OnRemove(Entity target) =>
            target.endurance -= _enduranceBonus;
    }
}