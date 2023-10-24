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

        private float requiredXP;
<<<<<<< HEAD
        private float currentXP = 0;

        private float requirementMultiplier = 1.2f;

        private void Awake()
        {
            // initialize required XP
        }

=======
        private float currentXP;

        private float requirementMultiplier = 1.2f;

>>>>>>> f5b39b7f4a50600106e8e74402e8836ed17401f4
        private void Start()
        {
            OnCurrentXPChange?.Invoke(currentXP);
            OnRequiredXPChange?.Invoke(requiredXP);
        }

        public void AddXP(float amount)
        {
            currentXP += amount;

            if(currentXP >= requiredXP)
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
