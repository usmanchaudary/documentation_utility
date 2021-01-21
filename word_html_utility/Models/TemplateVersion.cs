using System;
using System.Collections.Generic;

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

        public virtual ICollection<Tableofcontent> Tableofcontent { get; set; }
    }
}
