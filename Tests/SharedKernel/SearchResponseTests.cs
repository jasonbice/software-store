using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel;
using Shouldly;

namespace Tests.SharedKernel
{
    /// <summary>
    /// The test suite for <see cref="SearchResponse{T}"/>.
    /// </summary>
    /// <remarks>This test coverage in this suite is non-exhaustive.</remarks>
    [TestClass]
    public class SearchResponseTests
    {
        private readonly CancellationToken cancellationToken = new();
        
        [DataRow(1, 9)]
        [DataRow(2, 5)]
        [DataRow(9, 1)]
        [TestMethod]
        public async Task FromResults_ShouldReportTheCorrectNumberOfTotalPages(int pageSize, int expectedPages)
        {
            var data = await GetTestData();
            var searchRequest = new SoftwareSearchRequest()
            {
                Page = 1,
                PageSize = pageSize
            };
            var actual = SearchResponse<Software>.FromResults(data, searchRequest);
            
            actual.TotalPages.ShouldBe(expectedPages);
        }
        
        [TestMethod]
        public async Task FromResults_ShouldReportTheCorrectNumberOfTotalItems()
        {
            var data = await GetTestData();
            var expected = data.Count();
            var searchRequest = new SoftwareSearchRequest()
            {
                Page = 1,
                PageSize = 4
            };
            var actual = SearchResponse<Software>.FromResults(data, searchRequest);
            
            actual.TotalItems.ShouldBe(expected);
        }
        
        [TestMethod]
        public async Task FromResults_ShouldSortAscendingByDefault()
        {
            var data = await GetTestData();
            var searchRequest = new SoftwareSearchRequest()
            {
                Page = 1,
                PageSize = data.Count(),
                SortBy = nameof(Software.Name)
            };
            var actual = SearchResponse<Software>.FromResults(data, searchRequest);
            
            actual.PagedItems.Select(x => x.Name).ShouldBeInOrder(SortDirection.Ascending);
        }
        
        [TestMethod]
        public async Task FromResults_ShouldSortDescendingWhenRequested()
        {
            var data = await GetTestData();
            var searchRequest = new SoftwareSearchRequest()
            {
                Page = 1,
                PageSize = data.Count(),
                SortBy = nameof(Software.Name),
                SortDescending = true
            };
            var actual = SearchResponse<Software>.FromResults(data, searchRequest);
            
            actual.PagedItems.Select(x => x.Name).ShouldBeInOrder(SortDirection.Descending);
        }

        private async Task<IQueryable<Software>> GetTestData()
        {
            // New'ing up SoftwareRepository for brevity/convenience; in a production scenario this would be hard-coded
            // in the test so the data remained constant.
            var softwareRepository = new SoftwareRepository();

            return await softwareRepository.AllAsync(cancellationToken);
        }
    }
}