namespace WileyHomeWork.VersionIncrementer
{
    internal class MajorVersionIncrementer : IVersionIncrementer
    {
        public void Increment(Version version)
        {
            version.ThirdVersionNo++;
            version.FourthVersionNo = 0;
        }
    }
}
