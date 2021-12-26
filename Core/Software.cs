using SharedKernel;

namespace Core
{
    public class Software
    {
        public string Name { get; set; }
        
        public string Version { get; set; }
        
        public SemanticVersion GetSemanticVersion(ISemanticVersionParser semanticVersionParser)
        {
            return !semanticVersionParser.TryParse(Version, out var semanticVersion) ? null : semanticVersion;
        }
    }
}