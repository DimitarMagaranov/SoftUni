using Git.Services;
using Git.ViewModels.Commits;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var inputModel = this.repositoriesService.GetRepository(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public HttpResponse Create(string id, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description should be more than 5 characters.");
            }

            var model = new AddCommitInputModel
            {
                CreatorId = this.GetUserId(),
                RepositoryId = id,
                Description = description
            };

            this.commitsService.Create(model);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string userId = this.GetUserId();

            var commits = this.commitsService.GetAll(userId);

            return this.View(commits);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string userId = this.GetUserId();

            this.commitsService.DeleteCommit(id, userId);

            return this.Redirect("/Commits/All");
        }
    }
}
