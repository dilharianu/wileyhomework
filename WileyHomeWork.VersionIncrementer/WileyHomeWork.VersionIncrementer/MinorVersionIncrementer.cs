namespace WileyHomeWork.VersionIncrementer
{
    public class MinorVersionIncrementer : IVersionIncrementer
    {
        public void Increment(Version version)
        {
            version.FourthVersionNo++;
        }
    }
}
