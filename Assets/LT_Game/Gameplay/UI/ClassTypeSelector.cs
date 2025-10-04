using LT_Game.Gameplay.UI.Animators;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class ClassTypeSelector : MonoBehaviour
    {
        [SerializeField] private Button classTypeRogueButton;
        public Button ClassTypeRogueButton => classTypeRogueButton;
        [SerializeField] private Button classTypeWarriorButton;
        public Button ClassTypeWarriorButton => classTypeWarriorButton;
        [SerializeField] private Button classTypeBarbarianButton;
        public Button ClassTypeBarbarianButton => classTypeBarbarianButton;
        
        private ClassTypeSelectorAnimator _animator;

        private void Start()
        {
            _animator = GetComponent<ClassTypeSelectorAnimator>();
        }

        private void Enable() => 
            gameObject.SetActive(true);
        
        private void Disable() =>
            gameObject.SetActive(false);

        public void Show()
        {
            Enable();
            _animator.ShowAnimation();
        }

        public void Hide()
        {
            _animator.HideAnimation().onComplete += Disable;
        }
    }
}