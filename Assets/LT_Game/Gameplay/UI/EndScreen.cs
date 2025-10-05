using DG.Tweening;
using LT_Game.Content;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private GameAssets assets;
        [SerializeField] private AudioSource audioSource;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            Disable();
        }
        
        private void Enable() =>
            gameObject.SetActive(true);
        
        private void Disable() => 
            gameObject.SetActive(false);

        public Tween Show(bool won = false)
        {
            Enable();
            _image.sprite = won ? assets.winScreenSprite : assets.deathScreenSprite;
            _image.color = new Color(1, 1, 1, 0);
            var showAnimationSequence = DOTween.Sequence();
            showAnimationSequence.Append(audioSource.DOFade(0, 1).OnComplete(() =>
            {
                var clip = won ? assets.victory : assets.death;
                audioSource.clip = clip;
                audioSource.volume = 0.5f;
                audioSource.Play();
            }));
            showAnimationSequence.Join(_image.DOFade(1, 3));
            showAnimationSequence.Append(audioSource.DOFade(1, 2));
            showAnimationSequence.AppendInterval(5);
            showAnimationSequence.Append(audioSource.DOFade(0, 3));
            showAnimationSequence.Join(_image.DOColor(Color.black, 3));
            return showAnimationSequence;
        }
    }
}