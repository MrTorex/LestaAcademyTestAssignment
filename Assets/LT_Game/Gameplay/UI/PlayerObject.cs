using LT_Game.Core.Data.Entities;
using LT_Game.Gameplay.UI.Animators;
using UnityEngine;

namespace LT_Game.Gameplay.UI
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private Healthbar healthbar;
        public Healthbar Healthbar => healthbar;
        
        public PlayerObjectAnimator animator { get; private set; }

        public Player player { get; set; }
        
        private void Start()
        {
            animator = GetComponent<PlayerObjectAnimator>();
        }
    }
}