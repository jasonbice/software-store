using SharedKernel;

namespace Core
{
    public interface ISemanticVersionParser
    {
        /// <summary>
        /// Parses a string into a <see cref="SemanticVersion"/>. If the string cannot be parsed, null is returned.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <returns>The resulting <see cref="SemanticVersion"/>.</returns>
        SemanticVersion Parse(string input);
        
        /// <summary>
        /// Attempts to parse an input into a <see cref="SemanticVersion"/>.
        /// </summary>
        /// <param name="input">The string to parse.</param>
        /// <param name="semanticVersion">The result of the parse operation.</param>
        /// <returns>True if <paramref name="input"/> was parsed successfully; false otherwise.</returns>
        bool TryParse(string input, out SemanticVersion semanticVersion);
    }
}