using System;
using SharedKernel;

namespace Core
{
    public class SemanticVersionParser : ISemanticVersionParser
    {
        public SemanticVersion Parse(string input) => !TryParse(input, out var result) ? null : result;

        public bool TryParse(string input, out SemanticVersion semanticVersion)
        {
            semanticVersion = null;

            if (string.IsNullOrWhiteSpace(input)) return false;

            var parts = input.Split(".", StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 3) return false;

            var finalSemanticVersion = new SemanticVersion();

            for (var i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out var value)) return false;

                switch (i)
                {
                    case 0:
                        finalSemanticVersion.Major = value;
                        break;
                    case 1:
                        finalSemanticVersion.Minor = value;
                        break;
                    case 2:
                        finalSemanticVersion.Patch = value;
                        break;
                }
            }

            semanticVersion = finalSemanticVersion;

            return true;
        }
    }
}