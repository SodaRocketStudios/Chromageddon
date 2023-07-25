using UnityEngine;
using SRS.UI;

namespace SRS.LevelSystem
{
    public class XPBar : StatusBar
    {
        [SerializeField] private CharacterLevel level;

        private void Start()
        {
            level.OnCurrentXPChange += UpdateValue;
            level.OnRequiredXPChange += UpdateMax;
        }
    }
}
