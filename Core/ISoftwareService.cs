using System.Threading;
using System.Threading.Tasks;
using SharedKernel;

namespace Core
{
    public interface ISoftwareService
    {
        /// <summary>
        /// Searches the data store for <see cref="Software"/> entities.
        /// </summary>
        /// <param name="searchRequest">The request containing the search criteria, page, page size, etc.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A <see cref="SearchResponse{Software}"/> containing the matched results, total matches, etc.</returns>
        public Task<SearchResponse<Software>> SearchAsync(
            SoftwareSearchRequest searchRequest,
            CancellationToken cancellationToken);
    }
}