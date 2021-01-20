using System;
using System.Collections.Generic;

namespace word_html_utility.Models
{
    public partial class Tableofcontent
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public int Templateid { get; set; }

        public virtual TemplateVersion Template { get; set; }
    }
}
