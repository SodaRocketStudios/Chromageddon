using System.Text;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class StatModifier: ScriptableObject
    {
        [SerializeField] protected string affectedStat;

        [SerializeField] protected float value;

        [SerializeField] private bool invertFormatRules;

        public string Description
        {
            get => BuildDescription();
        }

        protected bool isPositive;

        public abstract void Apply(StatContainer container);

        public abstract void Remove(StatContainer container);

        protected string BuildDescription()
        {
            StringBuilder stringBuilder = new();

            if(value > 0)
            {
                isPositive = invertFormatRules?false:true;
                stringBuilder.Append("Increases ");
            }
            else
            {
                isPositive = invertFormatRules?true:false;
                stringBuilder.Append("Decreases ");
            }

            stringBuilder.Append($"{affectedStat} by ");

            if(isPositive)
            {
                stringBuilder.Append($"<color=green>{value}</color>");
            }
            else
            {
                stringBuilder.Append($"<color=red>{value}{GetUnitSymbol()}</color>");
            }

            return stringBuilder.ToString();
        }

        protected virtual string GetUnitSymbol()
        {
            return "";
        }
    }
}
