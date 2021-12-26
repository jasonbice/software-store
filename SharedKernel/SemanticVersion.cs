namespace SharedKernel
{
    public class SemanticVersion
    {
        public int? Major { get; set; }
        
        public int? Minor { get; set; }
        
        public int? Patch { get; set; }

        public static bool operator >(SemanticVersion a, SemanticVersion b)
        {
            if (a == null || b == null) return false;
            
            if ((a.Major ?? 0) > (b.Major ?? 0)) return true;
            if ((b.Major ?? 0) > (a.Major ?? 0)) return false;

            if ((a.Minor ?? 0) > (b.Minor ?? 0)) return true;
            if ((b.Minor ?? 0) > (a.Minor ?? 0)) return false;

            if ((a.Patch ?? 0) > (b.Patch ?? 0)) return true;
            if ((b.Patch ?? 0) > (a.Patch ?? 0)) return false;

            return false;
        }
        
        public static bool operator <(SemanticVersion a, SemanticVersion b)
        {
            if (a == null || b == null) return false;
            
            return b > a || (a.Major != b.Major && a.Minor != b.Minor && a.Patch != b.Patch);
        }
    }
}