// See https://aka.ms/new-console-template for more information
using WileyHomeWork.VersionIncrementer;

Console.Title = ("---Version Incrementer---");

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

    versionManager.IncrementVersionAndSave();

    Console.WriteLine("Done!");    
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error Occured! {ex.Message}");
    DisplayHelp();
    Environment.Exit(1);
}
catch (Exception ex)
{
    Console.WriteLine("Error Occured!");
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

static void DisplayHelp()
{
    Console.WriteLine($"--- Help ----");
    Console.WriteLine($"VersionIncrementer accepts two arguments in the following order.");
    Console.WriteLine($"Argument One: full path to the file");
    Console.WriteLine($"Argument Two: type of the release [Feature | BugFix]");
    Console.WriteLine($"Examples : ");
    Console.WriteLine($"\tVersionIncrementer ProductInfo.cs Feature");
    Console.WriteLine($"\tVersionIncrementer ProductInfo.cs BugFix");
}

static void ValidateInputs(string[] arguments)
{
    if (arguments.Length != 3)
    {
        throw new ArgumentException("Provided number of arguments are not correct.");
    }

    string pathToProductFile = arguments[1];
    if (!IsValidVersionFile(pathToProductFile))
    {
        throw new ArgumentException($"The specified version file - {pathToProductFile}, does not exisit.");
    }

    string releaseType = arguments[2].Trim().ToLower();
    if (!(!string.Equals(releaseType, "release") || !string.Equals(releaseType, "bugfix")))
    {
        throw new ArgumentException($"Value provided for the release type is not correct.");
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

