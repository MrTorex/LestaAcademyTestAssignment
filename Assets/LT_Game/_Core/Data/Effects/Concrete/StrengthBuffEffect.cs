using LT_Game.Core.Data.Entities;

namespace LT_Game.Core.Data.Effects.Concrete
{
    public class StrengthBuffEffect : StatusEffect
    {
        private readonly int _strengthBonus;
        
        public StrengthBuffEffect(int strengthBonus, int bonusDuration)
        {
            description = $"Strength +{strengthBonus}";
            _strengthBonus = strengthBonus;
            duration = bonusDuration;
        }

        public override void OnApply(Entity target) =>
            target.strength += _strengthBonus;
        
        public override void OnRemove(Entity target) =>
            target.strength -= _strengthBonus;
    }
}