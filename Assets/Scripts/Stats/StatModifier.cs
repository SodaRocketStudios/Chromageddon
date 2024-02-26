using System.Text;
using UnityEngine;

namespace SRS.Stats
{
    public abstract class StatModifier: ScriptableObject
    {
        [SerializeField] protected string affectedStat;
        public string AffectedStat
        {
            get => affectedStat;
        }

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
            StringBuilder descriptionBuilder = new();

            // TODO -- make this make sense for multipliers
            if(value > 0)
            {
                isPositive = invertFormatRules?false:true;
                descriptionBuilder.Append("Increase ");
            }
            else
            {
                isPositive = invertFormatRules?true:false;
                descriptionBuilder.Append("Decrease ");
            }

            descriptionBuilder.Append($"<u><link=\"{affectedStat}\">{affectedStat}</link></u> by ");

            if(isPositive)
            {
                descriptionBuilder.Append($"<color=green>{Mathf.Abs(value)}{GetUnitSymbol()}</color>");
            }
            else
            {
                descriptionBuilder.Append($"<color=red>{Mathf.Abs(value)}{GetUnitSymbol()}</color>");
            }

            return descriptionBuilder.ToString();
        }

        public string BuildRelativeDescription(StatContainer stats)
        {
            StringBuilder descriptionBuilder = new();

            descriptionBuilder.Append($"{affectedStat} = {stats[AffectedStat].BaseValue} x {stats[AffectedStat].PercentageModifier}%");

            if(value > 0)
            {
                isPositive = invertFormatRules?false:true;
                descriptionBuilder.Append(" + ");
            }
            else
            {
                isPositive = invertFormatRules?true:false;
                descriptionBuilder.Append(" - ");
            }

            if(isPositive)
            {
                descriptionBuilder.Append($"<color=green>{Mathf.Abs(value)}{GetUnitSymbol()}</color>");
            }
            else
            {
                descriptionBuilder.Append($"<color=red>{Mathf.Abs(value)}{GetUnitSymbol()}</color>");
            }

            return descriptionBuilder.ToString();
        }

        protected abstract string GetUnitSymbol();
    }
}
