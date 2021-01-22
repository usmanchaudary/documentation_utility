using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace word_html_utility.Models
{
    public partial class Versions
    {
        public Versions()
        {
            TemplateVersion = new HashSet<TemplateVersion>();
        }

        public int Id { get; set; }
        public string VersionNumber { get; set; }
        public string VersionMessage { get; set; }
        public DateTime? VersionDate { get; set; }

        public virtual ICollection<TemplateVersion> TemplateVersion { get; set; }
    }
}
