using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class AddRepositoryInputModel
    {
        public string OwnerId { get; set; }

        public string Name { get; set; }

        public string RepositoryType { get; set; }
    }
}
