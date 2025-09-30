using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI.Animators
{
    public class MainMenuAnimator : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private TMP_Text gameNameText;
        [SerializeField] private Button playButton;
        [SerializeField] private Image fadeEffectImage;
        private const string AnimationId = "MainMenu";

        public void MainMenuLoop()
        {
            ScaleBackground();
            MoveGameName();
            ScalePlayButton();
        }

        private void ScaleBackground()
        {
            var scaleBackgroundSequence = DOTween.Sequence().SetId(AnimationId);
            
            scaleBackgroundSequence.Append(
                backgroundImage.transform.DOScale(
                new Vector3(1.03f, 1.03f, 1), 10));
            scaleBackgroundSequence.AppendInterval(5);
            scaleBackgroundSequence.Append(
                backgroundImage.transform.DOScale(
                Vector3.one, 10));
            scaleBackgroundSequence.AppendInterval(5);
            scaleBackgroundSequence.SetLoops(-1, LoopType.Yoyo);
        }

        private void MoveGameName()
        {
            var moveGameNameSequence = DOTween.Sequence().SetId(AnimationId);
            
            var initialPosition = gameNameText.transform.localPosition;

            moveGameNameSequence.Append(
                gameNameText.transform.DOLocalMove(
                    initialPosition + Vector3.left * 20, 10));
            moveGameNameSequence.Append(
                gameNameText.transform.DOLocalMove(
                    initialPosition + Vector3.right * 20, 20));
            moveGameNameSequence.SetLoops(-1, LoopType.Yoyo);
        }
        
        private void ScalePlayButton()
        {
            playButton.transform.DOScale(
                new Vector3(1.1f, 1.1f, 1), 3).SetLoops(-1, LoopType.Yoyo).SetId(AnimationId);
        }

        public Tween FadeInEffect()
        {
            fadeEffectImage.color = Color.white;
            
            return fadeEffectImage.DOFade(0, 2).SetId(AnimationId);
        }
        
        public Tween FadeOutEffect()
        {
            fadeEffectImage.color = new Color(0, 0, 0, 0);
            
            return fadeEffectImage.DOFade(1, 1).SetId(AnimationId);
        }
    }
}