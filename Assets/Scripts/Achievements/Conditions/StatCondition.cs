using SRS.Stats;
using UnityEngine;

namespace SRS.Achievements
{
    [CreateAssetMenu(menuName = "Achievements/Conditions/Stat Condition", fileName = "New Stat Condition")]
    public class StatCondition : Condition
    {
		[SerializeField] private string stat;

        protected override void Init()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<StatContainer>()[stat].OnChanged += Test;
        }
    }
}