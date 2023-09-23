using Xunit;
using WileyHomeWork.VersionIncrementer;
using Moq;

namespace WileyHomeWork.VersionIncrementer.Tests
{
    public class VersionManagerTests
    {

        [Fact]
        public void Increment_With_CorrectFormat_Release_SUCCESS()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.0.0");

            var versionManager = new VersionManager(new MajorVersionIncrementer(), versionFileMock.Object);
            versionManager.IncrementVersion();

            var version = versionFileMock.Object.ReadVersion();
        }

        [Fact]
        public void Increment_With_CorrectFormat_BugFix_SUCCESS()
        {

        }

        [Fact]
        public void Increment_With_InCorrectFormat_MissingMajor_FAIL()
        {

        }

        [Fact]
        public void Increment_With_InCorrectFormat_MissingMinor_FAIL()
        {

        }

        [Fact]
        public void Increment_With_CharFoundInVersion_FAIL()
        {

        }
    }
}