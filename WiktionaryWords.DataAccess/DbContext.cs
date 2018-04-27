using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WiktionaryWords.DataAccess
{
    public class WordContext : DbContext
    {
        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        { }

        public DbSet<WiktionaryWord> WiktionaryWords { get; set; }

        public DbSet<WordInfo> WordInfos { get; set; }

        public DbSet<WordDefinition> WordDefinitions { get; set; }
    }

    public class WiktionaryWord
    {
        public int WiktionaryWordId { get; set; }

        public string Title { get; set; }

        public int RevId { get; set; }

        public string Html { get; set; }

        public DateTime UpdateDate { get; set; }    
    }

    public class WordInfo
    {
        public int WordInfoId { get; set; }

        public string Basic { get; set; }

        public string Synonyms { get; set; }

        public string Antonyms { get; set; }

        public string Homonymes { get; set; }

        public string CommonFiguresOfSpeech { get; set; }

        public string PrefixedVerbs { get; set; }

        public string PhrasalVerbs { get; set; }

        public string Notes { get; set; }

        public List<WordDefinition> WordDefinitions { get; set; }
    }

    public class WordDefinition
    {
        public string Definition { get; set; }

        public string Example { get; set; }

        public string Translation { get; set; }

        public DefinitionType DefinitionType { get; set; }

        public int WordInfoId { get; set; }

        public WordInfo WordInfo { get; set; }
    }

    public enum DefinitionType
    {
        Basic = 1,
        Derived = 2
    }
}
