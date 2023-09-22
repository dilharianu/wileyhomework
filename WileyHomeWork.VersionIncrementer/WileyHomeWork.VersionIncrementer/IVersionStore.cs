namespace WileyHomeWork.VersionIncrementer
{
    internal interface IVersionStore
    {
        internal string ReadVersion();
        internal void WriteVersion(string version);
    }
}
