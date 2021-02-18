using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int CommitsCount { get; set; }

        public string RepositoryId { get; set; }
    }
}
