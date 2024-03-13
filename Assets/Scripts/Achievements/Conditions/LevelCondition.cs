using UnityEngine;

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
			// GameObject.FindGameObjectsWithTag("Player").CharacterLevel;
        }
    }
}