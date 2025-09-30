using DG.Tweening;
using LT_Game.Gameplay.UI.Animators;
using LT_Game.Gameplay.UI.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private MainMenuAnimator animator;

        private void Start()
        {
            playButton.interactable = false;
            animator.FadeInEffect().OnComplete(() =>
            {
                playButton.onClick.AddListener(OnPlayButtonClick);
                playButton.interactable = true;
            });
        }

        private void OnPlayButtonClick()
        {
            playButton.interactable = false;
            playButton.onClick.RemoveAllListeners();
            animator.FadeOutEffect().OnComplete(() =>
            {
                SceneManager.LoadScene((int)SceneIds.BattleArea);
                DOTween.Kill("MainMenu");
            });
        }
    }
}