using System.Threading;
using System.Threading.Tasks;
using SharedKernel;
using SharedKernel.Data;

namespace Core
{
    public class SoftwareService : ISoftwareService
    {
        private readonly IRepository<Software> softwareRepository;
        private readonly ISemanticVersionParser semanticVersionParser;
        
        public SoftwareService(IRepository<Software> softwareRepository, ISemanticVersionParser semanticVersionParser)
        {
            this.softwareRepository = softwareRepository;
            this.semanticVersionParser = semanticVersionParser;
        }
        
        public async Task<SearchResponse<Software>> SearchAsync(
            SoftwareSearchRequest searchRequest,
            CancellationToken cancellationToken)
        {
            SemanticVersion parsedMinimumVersion = null;
            
            if (!string.IsNullOrWhiteSpace(searchRequest.MinimumVersion))
            {
                semanticVersionParser.TryParse(searchRequest.MinimumVersion, out parsedMinimumVersion);    
            }

            // In the event we were accessing Software entities from a datastore (e.g. a relational database), I would 
            // take steps to store the Major, Minor, and Patch values in discrete fields. The statement below using the 
            // SemanticVersionParser may not be compatible with LINQ-to-SQL, and if it is, this approach would 
            // result a full table scan.
            var allItems = await softwareRepository.FilterAsync(x =>
                    parsedMinimumVersion == null || semanticVersionParser.Parse(x.Version) > parsedMinimumVersion,
                cancellationToken
            );

            return SearchResponse<Software>.FromResults(allItems, searchRequest);
        }
    }
}