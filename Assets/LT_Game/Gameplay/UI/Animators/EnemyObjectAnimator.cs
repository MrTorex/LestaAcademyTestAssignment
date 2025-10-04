using DG.Tweening;
using UnityEngine;

namespace LT_Game.Gameplay.UI.Animators
{
    public class EnemyObjectAnimator : MonoBehaviour
    {
        public Tween AttackAnimation()
        {
            var attackAnimationSequence = DOTween.Sequence();
            attackAnimationSequence.AppendInterval(2f);
            return attackAnimationSequence;
        }
    }
}