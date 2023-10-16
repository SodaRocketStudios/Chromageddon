namespace SRS.Stats
{
    public class MultiplierModifier : StatModifier
    {
        public override void Apply(StatContainer container)
        {
            if(value > 0)
            {
                container[affectedStat].PercentageModifier *= value;
            }
            else
            {
                container[affectedStat].SetZero();
            }
        }

        public override void Remove(StatContainer container)
        {
            if(value > 0)
            {
                container[affectedStat].PercentageModifier /= value;
            }
            else
            {
                container[affectedStat].RemoveZero();
            }
        }
    }
}
