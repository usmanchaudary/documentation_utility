using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
