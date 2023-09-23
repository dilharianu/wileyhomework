using Xunit;
using Moq;
using System;

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
            var newVersion = versionManager.IncrementVersionAndSave();

            Assert.Equal("1.1.1.0", newVersion);
        }

        [Fact]
        public void Increment_With_CorrectFormat_BugFix_SUCCESS()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.1.0");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var newVersion = versionManager.IncrementVersionAndSave();

            Assert.Equal("1.1.1.1", newVersion);
        }

        [Fact]
        public void Increment_With_InCorrectFormat_Missing_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.1");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            try
            {
                var newVersion = versionManager.IncrementVersionAndSave();
            }
            catch(Exception ex)
            {
                Assert.Equal("The product version is not in the correct format.", ex.Message);
            }
        }

        [Fact]
        public void Increment_With_InCorrectFormat_Missing2_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            try
            {
                var newVersion = versionManager.IncrementVersionAndSave();
            }
            catch (Exception ex)
            {
                Assert.Equal("The product version is not in the correct format.", ex.Message);
            }
        }

        [Fact]
        public void Increment_With_CharFoundInVersion_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.a.a");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            try
            {
                var newVersion = versionManager.IncrementVersionAndSave();
            }
            catch (Exception ex)
            {
                Assert.Equal("The product version is not in the correct format.", ex.Message);
            }
        }
    }
}