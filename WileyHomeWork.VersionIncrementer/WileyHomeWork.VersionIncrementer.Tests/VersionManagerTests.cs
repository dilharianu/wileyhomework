using Xunit;
using Moq;
using System;

namespace WileyHomeWork.VersionIncrementer.Tests
{
    public class VersionManagerTests
    {

        [Fact]
        public void Increment_with_correct_format_release_SUCCESS()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.0.0");

            var versionManager = new VersionManager(new MajorVersionIncrementer(), versionFileMock.Object);
            versionManager.IncrementVersionAndSave();

            versionFileMock.Verify(d => d.WriteVersion("1.1.1.0"));
        }

        [Fact]
        public void Increment_with_correct_format_release_reset_SUCCESS()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("2.6.5.5");

            var versionManager = new VersionManager(new MajorVersionIncrementer(), versionFileMock.Object);
            versionManager.IncrementVersionAndSave();

            versionFileMock.Verify(d => d.WriteVersion("2.6.6.0"));
        }

        [Fact]
        public void Increment_with_correct_format_bugFix_SUCCESS()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.1.0");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            versionManager.IncrementVersionAndSave();

            versionFileMock.Verify(d => d.WriteVersion("1.1.1.1"));

        }

        [Fact]
        public void Increment_with_incorrect_format_Less_than_4_elements_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.1");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            

            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Increment_with_incorrect_format_less_than_4_elements_FAIL2()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }


        [Fact]
        public void Increment_with_incorrect_format_empty_elements_FAIL2()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Increment_with_char_found_in_version_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.a.a");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Increment_with_char_found_in_first_element_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("w.1.a.a");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Increment_with_incorrect_format_more_than_4_elements_FAIL()
        {
            var versionFileMock = new Mock<IVersionStore>();
            versionFileMock.Setup(v => v.ReadVersion()).Returns("1.1.1.1.1");

            var versionManager = new VersionManager(new MinorVersionIncrementer(), versionFileMock.Object);
            var exceptionType = typeof(ArgumentException);
            var expectedMessage = "The product version is not in the correct format.";

            var ex = Assert.Throws(exceptionType, () => {
                versionManager.IncrementVersionAndSave();
            });

            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}