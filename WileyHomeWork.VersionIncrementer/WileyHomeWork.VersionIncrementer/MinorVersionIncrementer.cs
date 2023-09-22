namespace WileyHomeWork.VersionIncrementer
{
    internal class MinorVersionIncrementer : IVersionIncrementer
    {
        public void Increment(Version version)
        {
            version.FourthVersionNo++;
        }
    }
}
