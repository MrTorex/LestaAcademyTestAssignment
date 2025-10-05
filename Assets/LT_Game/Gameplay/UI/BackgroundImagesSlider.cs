using DG.Tweening;
using LT_Game.Content;
using UnityEngine;

namespace LT_Game.Gameplay.UI
{
    public class BackgroundImagesSlider : MonoBehaviour
    {
        [SerializeField] GameAssets assets;
        [SerializeField] AudioSource audioSource;
        
        private int _swapsNumber;

        private void Start()
        {
            var clip = assets.battle1;
            audioSource.clip = clip;
            audioSource.volume = 0.5f;
            audioSource.Play();
            audioSource.DOFade(1, 2);
        }
        public Tween Swap()
        {
            var swapAnimationSequence = DOTween.Sequence();
            swapAnimationSequence.Append(transform.DOLocalMoveX(transform.localPosition.x - 1920, 3).SetEase(Ease.InSine));
            swapAnimationSequence.Join(audioSource.DOFade(0, 3f));
            swapAnimationSequence.AppendInterval(1);
            swapAnimationSequence.JoinCallback(() =>
            {
                var clip = _swapsNumber == 0 ? assets.battle2 : assets.battle3;
                audioSource.clip = clip;
                audioSource.volume = 0;
                audioSource.Play();
                audioSource.DOFade(1, 0.5f);
                _swapsNumber++;
            });
            return swapAnimationSequence;
        }
    }
}