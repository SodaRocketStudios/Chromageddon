using UnityEngine;
using SRS.Progression;

namespace SRS.Achievements
{
	[CreateAssetMenu(menuName = "Achievements/Conditions/LevelCondition", fileName = "New Level Condition")]
    public class LevelCondition : Condition
    {
		
        public override void Test(float value)
        {
            
        }

        protected override void Init()
        {
			GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLevel>().OnLevelChange.AddListener(OnLevelUp);
        }

        private void OnLevelUp(int level)
        {
            Test(level);
        }
    }
}