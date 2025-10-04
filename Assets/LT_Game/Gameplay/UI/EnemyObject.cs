using LT_Game.Core.Data.Entities;
using LT_Game.Gameplay.UI.Animators;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class EnemyObject : MonoBehaviour
    {
        [SerializeField] private Image enemyImage;
        [SerializeField] private Healthbar healthbar;
        public Healthbar Healthbar => healthbar;
        
        public EnemyObjectAnimator animator { get; private set; }

        public Enemy enemy { get; set; }
        
        private void Start()
        {
            animator = GetComponent<EnemyObjectAnimator>();
        }
    }
}