using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Moq;

using ServerlessFnApp;

using UnitTests.Helpers;

using Xunit;

namespace UnitTests
{
    public class DocumentsFnTests
    {
        private const string DOC_NUMB = "12345";

        private readonly ILogger _logger;
        private readonly Mock<IRepository<Document>> _docRepository;

        public DocumentsFnTests()
        {
            _logger = NullLoggerFactory.Instance.CreateLogger("Test");
            _docRepository = new Mock<IRepository<Document>>(MockBehavior.Default);
        }

        private DocumentsFn CreateDocumentsFn()
        {
            _docRepository.SetReturnsDefault(
                new List<Document>
                {
                    new Document
                    {
                        Id = 1,
                        Name = "SomeName.docx",
                        Reference = DOC_NUMB
                    }
                }.AsQueryable());
            return new DocumentsFn(_docRepository.Object);
        }

        [Fact]
        public async Task Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var documentsFn = CreateDocumentsFn();
            var request = RequestHelper.MockRequest("{\"example\":\"\"}");

            // Act
            var result = await documentsFn.Run(
                request,
                DOC_NUMB,
                _logger);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}