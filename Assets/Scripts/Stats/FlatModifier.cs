namespace SRS.Stats
{
    public class FlatModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            container[affectedStat].BaseValue += value;
        }

        public override void Remove(StatContainer container)
        {
            container[affectedStat].BaseValue -= value;
        }
    }
}
