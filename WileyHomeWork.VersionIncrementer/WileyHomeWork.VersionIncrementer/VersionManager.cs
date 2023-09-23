namespace WileyHomeWork.VersionIncrementer
{
    public class VersionManager
    {
        private readonly IVersionIncrementer _versionIncrementer;
        private readonly IVersionStore _versionStore;

        public VersionManager(IVersionIncrementer versionIncrementer, IVersionStore versionStore)
        {
            _versionIncrementer = versionIncrementer;
            _versionStore = versionStore;
        }

        public void IncrementVersion()
        {
            var version = ParseAndGetCurruntVersion();
            Console.WriteLine($"Updating the currunt version number: {version}");
            _versionIncrementer.Increment(version);

            _versionStore.WriteVersion(version.ToString());
            Console.WriteLine($"Updated the currunt version number to: {version}");
        }

        private Version ParseAndGetCurruntVersion()
        {
            string versionString = _versionStore.ReadVersion();

            string[] versionArray = versionString.Split('.');
            if (versionArray.Length == 0 || versionArray.Length != 4)
            {
                throw new ArgumentException("wrong product version.");
            }

            int first, second, major, minor;
            if (int.TryParse(versionArray[0], out first) &&
                int.TryParse(versionArray[1], out second) &&
                int.TryParse(versionArray[2], out major) &&
                int.TryParse(versionArray[3], out minor))
            {
                return new Version(first, second, major, minor);
            }
            else
            {
                throw new ArgumentException("Issue in parsing the version.");
            }
        }
    }
}
