using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepositoryViewModel> GetAll();

        void CreateRepository(AddRepositoryInputModel input);

        Repository GetRepository(string id);
    }
}
