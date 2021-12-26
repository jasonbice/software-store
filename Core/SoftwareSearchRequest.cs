using SharedKernel;

namespace Core
{
    /// <summary>
    /// A request for searching <see cref="Software"/>.
    /// </summary>
    public class SoftwareSearchRequest : SearchRequestBase
    {
        /// <summary>
        /// The minimum version that will be matched against <see cref="Software.Version"/>.
        /// </summary>
        public string MinimumVersion { get; set; }
    }
}