using DG.Tweening;
using UnityEngine;

namespace LT_Game.Gameplay.UI.Animators
{
    public class WeaponSelectorAnimator : MonoBehaviour
    {
        public Tween ShowAnimation()
        {
            var showAnimationSequence = DOTween.Sequence();
            showAnimationSequence.Append(transform.DOScale(Vector3.one, 0.3f));
            showAnimationSequence.Join(transform.DOLocalMove(Vector3.zero, 0.3f));
            return showAnimationSequence;
        }
        
        public Tween HideAnimation()
        {
            var hideAnimationSequence = DOTween.Sequence();
            hideAnimationSequence.Append(transform.DOScale(Vector3.zero, 0.3f));
            hideAnimationSequence.Join(transform.DOLocalMove(Vector3.zero + Vector3.down * 1000, 0.3f));
            return hideAnimationSequence;
        } 
    }
}