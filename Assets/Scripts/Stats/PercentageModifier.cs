namespace SRS.Stats
{
    public class PercentageModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            container[affectedStat].PercentageModifier += value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].PercentageModifier -= value;
        }
    }
}
