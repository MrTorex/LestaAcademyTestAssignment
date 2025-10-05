using DG.Tweening;
using UnityEngine;

namespace LT_Game.Gameplay.UI
{
    public class BackgroundImagesSlider : MonoBehaviour
    {
        public Tween Swap()
        {
            var swapAnimationSequence = DOTween.Sequence();
            swapAnimationSequence.Append(transform.DOLocalMoveX(transform.localPosition.x - 1920, 3).SetEase(Ease.InSine));
            swapAnimationSequence.AppendInterval(1);
            return swapAnimationSequence;
        }
    }
}