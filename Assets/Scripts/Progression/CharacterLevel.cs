using UnityEngine;
using UnityEngine.Events;

namespace SRS.Progression
{
    public class CharacterLevel : MonoBehaviour
    {
        public UnityEvent<CharacterLevel> OnLevelUp;
        public UnityEvent<float> OnCurrentXPChange;
        public UnityEvent<float> OnRequiredXPChange;

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
        }

        private float requiredXP = 2;
        private float currentXP = 0;

        private float requirementMultiplier = 1.2f;

        private void Awake()
        {
            // TODO -- initialize requiredXP
        }

        private void Start()
        {
            OnCurrentXPChange?.Invoke(currentXP);
            OnRequiredXPChange?.Invoke(requiredXP);
        }

        public void AddXP(float amount)
        {
            currentXP += amount;

            // TODO -- make sure that the player is given multiple item choices when leveling up more than once
            // at one time.

            while(currentXP >= requiredXP)
            {
                LevelUp();
            }

            OnCurrentXPChange?.Invoke(currentXP);
        }

        private void LevelUp()
        {
            level++;
            currentXP -= requiredXP;

            CalculateRequiredXP();

            OnLevelUp?.Invoke(this);
        }

        private void CalculateRequiredXP()
        {
            requiredXP *= requirementMultiplier;
            OnRequiredXPChange?.Invoke(requiredXP);
        }
    }
}
