namespace WileyHomeWork.VersionIncrementer
{
    public interface IVersionStore
    {
        public string ReadVersion();
        public void WriteVersion(string version);
    }
}
