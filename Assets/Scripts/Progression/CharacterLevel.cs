using UnityEngine;
using UnityEngine.Events;

namespace SRS.Progression
{
    public class CharacterLevel : MonoBehaviour
    {
        public UnityEvent<int> OnLevelUp;
        public UnityEvent<float> OnCurrentXPChange;
        public UnityEvent<float> OnRequiredXPChange;

        private int level;

        private float requiredXP = 5;
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

            OnLevelUp?.Invoke(level);
        }

        private void CalculateRequiredXP()
        {
            requiredXP *= requirementMultiplier;
            OnRequiredXPChange?.Invoke(requiredXP);
        }
    }
}
