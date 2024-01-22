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

        private float _currentXP;
        private float currentXP
        {
            get => _currentXP;
            set
            {
                _currentXP = value;
                OnCurrentXPChange?.Invoke(_currentXP);
            }
        }
        
        private float _requiredXP;
        private float requiredXP
        {
            get => _requiredXP;
            set
            {
                _requiredXP = value;
                OnRequiredXPChange?.Invoke(_requiredXP);
            }
        }

        private float requirementMultiplier = 1.2f;

        private void Start()
        {
            requiredXP = 2;
            currentXP = 0;
        }

        public void AddXP(float amount)
        {
            currentXP += amount;

            if(currentXP >= requiredXP)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            currentXP -= requiredXP;
            level++;

            CalculateRequiredXP();

            OnLevelUp?.Invoke(this);

            if(currentXP >= requiredXP)
            {
                LevelUp();
            }
        }

        private void CalculateRequiredXP()
        {
            requiredXP *= requirementMultiplier;
        }
    }
}
