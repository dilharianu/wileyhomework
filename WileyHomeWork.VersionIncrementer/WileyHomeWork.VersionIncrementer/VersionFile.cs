namespace WileyHomeWork.VersionIncrementer
{
    internal class VersionFile : IVersionStore
    {
        private readonly string _productInfoFilePath;

        public VersionFile(string filePath)
        {
            _productInfoFilePath = filePath;
        }

        string IVersionStore.ReadVersion()
        {
            return File.ReadAllText(_productInfoFilePath);
        }

        void IVersionStore.WriteVersion(string version)
        {
            File.WriteAllText(_productInfoFilePath, version);
        }
    }
}
