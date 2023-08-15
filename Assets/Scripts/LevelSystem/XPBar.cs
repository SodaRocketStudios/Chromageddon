using UnityEngine;
using SRS.UI;

namespace SRS.LevelSystem
{
    public class XPBar : StatusBar
    {
        [SerializeField] private CharacterLevel level;

        private void Awake()
        {
            level.OnCurrentXPChange.AddListener(UpdateValue);
            level.OnRequiredXPChange.AddListener(UpdateMax);
        }
    }
}
