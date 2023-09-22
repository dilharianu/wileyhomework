// See https://aka.ms/new-console-template for more information
using WileyHomeWork.VersionIncrementer;

Console.WriteLine("---Version Incrementer---");

try
{
    string[] cmdArguments = Environment.GetCommandLineArgs();
    ValidateInputs(cmdArguments);    

    string filePath = cmdArguments[1];
    string releaseType = cmdArguments[2].Trim().ToLower();

    VersionManager versionManager;
    IVersionStore versionStore = new VersionFile(filePath);

    switch (releaseType)
    {
        case "release":
            versionManager = new VersionManager(new MajorVersionIncrementer(), versionStore);
            break;

        case "bugfix":
            versionManager = new VersionManager(new MinorVersionIncrementer(), versionStore);
            break;

        default: throw new ArgumentException("Error!");
    }

    versionManager.IncrementReleaseVersion();

    Console.WriteLine("Done!");    
}
catch (Exception ex)
{
    Console.WriteLine("Error Occured!");
    Console.WriteLine(ex.Message);
    DisplayHelp();
    Environment.Exit(1);
}

static void DisplayHelp()
{
    Console.WriteLine($"Version Incrementer! accepts two arguments in the following order.");
    Console.WriteLine($"Arument One: full path to the file");
    Console.WriteLine($"Arument Two: type of the release [Feature | BugFix]");
    Console.WriteLine($"Example: ");
}

static void ValidateInputs(string[] arguments)
{
    if (arguments.Length != 3)
    {
        throw new Exception("Missing arguments!");
    }

    string pathToProductFile = arguments[1];
    if (!IsValidVersionFile(pathToProductFile))
    {
        throw new Exception($"{pathToProductFile}. File does not exisit!");
    }

    string releaseType = arguments[2].Trim().ToLower();
    if (!(!string.Equals(releaseType, "release") || !string.Equals(releaseType, "bugfix")))
    {
        throw new Exception($"wrong release type");
    }
}

static bool IsValidVersionFile(string filePath)
{
    if (!string.IsNullOrEmpty(filePath))
    {
        return File.Exists(filePath);
    }
    return false;
}

