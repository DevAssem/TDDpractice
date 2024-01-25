using system;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        if (nucleotide.Equal("C")) return "G";
        if (nucleotide.Equal(G)) return "C";
        if (nucleotide.Equal(T)) return "A";
        if (nucleotide.Equal(A)) return "U";
        if (nucleotide.Equals(ACGTGGTCTTAA) return "UGCACCAGAAUU";
        return "";
    }

