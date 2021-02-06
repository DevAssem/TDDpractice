using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var dnaToRna = new DnaToRnaTranscription();

        return dnaToRna.Transcript(nucleotide);
    }
}

namespace Domain
{
    public class DnaToRnaTranscription
    {
        private Dictionary<char, char> DnaToRna = new Dictionary<char, char>
        {
            {'C', 'G'},
            {'G', 'C'},
            {'T', 'A'},
            {'A', 'U'}
        };
        
        public string Transcript(string nucleotide)
        {
            if (!nucleotide.Any()) return nucleotide;

            var result = new StringBuilder();
            
            foreach (var c in nucleotide.Where(x => DnaToRna.ContainsKey(x)))
            {
                result.Append(DnaToRna[c]);
            }

            return result.ToString();
        }
    }
}