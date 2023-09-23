namespace WileyHomeWork.VersionIncrementer
{
    public class MajorVersionIncrementer : IVersionIncrementer
    {
        public void Increment(Version version)
        {
            version.ThirdVersionNo++;
            version.FourthVersionNo = 0;
        }
    }
}
