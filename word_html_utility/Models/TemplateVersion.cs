using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace word_html_utility.Models
{
    public partial class TemplateVersion
    {
        public TemplateVersion()
        {
            Tableofcontent = new HashSet<Tableofcontent>();
        }

        public int Id { get; set; }
        public string FunctionName { get; set; }
        public string FunctionExample { get; set; }
        public string AlternateExample { get; set; }
        public string ImagePath { get; set; }
        public string FunctionDescription { get; set; }
        public string ExampleExaplanation { get; set; }
        public string AlternateExamplesExplanation { get; set; }
        public string TableOfContentHeading { get; set; }
        public int? VersionId { get; set; }

        public virtual Versions Version { get; set; }
        public virtual ICollection<Tableofcontent> Tableofcontent { get; set; }
    }
}
