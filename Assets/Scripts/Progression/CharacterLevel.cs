using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Progression
{
    public class CharacterLevel : MonoBehaviour
    {
        public UnityEvent<CharacterLevel> OnLevelUp;

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
        }

        [SerializeField] private Fraction experienceValue;

        private float requirementMultiplier = 1.2f;

        private void Start()
        {
            experienceValue.Max = 2;
            experienceValue.Current = 0;
        }

        public void AddXP(float amount)
        {
            experienceValue.Current += amount;

            while(experienceValue.Current >= experienceValue.Max)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            // TODO -- make sure that the player is given multiple item choices when leveling up more than once
            // at one time. Add to item count if shop is open. This can probably be handled in generate in item shop.

            experienceValue.Current -= experienceValue.Max;
            level++;

            CalculateRequiredXP();

            OnLevelUp?.Invoke(this);
        }

        private void CalculateRequiredXP()
        {
            experienceValue.Max *= requirementMultiplier;
        }
    }
}
