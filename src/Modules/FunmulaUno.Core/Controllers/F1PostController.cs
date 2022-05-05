using System.Threading.Tasks;
using FunmulaUno.Post.Permissions;
using FunmulaUno.Post.Services;
using FunmulaUno.Post.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunmulaUno.Post.Controllers
{

    public class F1PostController : Controller
    {
        private IF1PostServices _f1PostServices;
        private readonly IAuthorizationService _authorizationService;

        public F1PostController(IF1PostServices f1PostServices, IAuthorizationService authorizationService)
        {
            _f1PostServices = f1PostServices;
            _authorizationService = authorizationService;
        }

        // Lists every F1 Post.
        public async Task<ActionResult> List()
        {
            if (!(await AuthorizeForF1PostsAsync()))
            {
                return View("NoPermission");
            }

            var posts = await _f1PostServices.ListF1PostsAsync();
            var model = new F1PostListViewModel(posts);

            return View(model);
        }

        // Lists every F1 Post that is flagged as a meme.
        public async Task<ActionResult> ListMemes()
        {
            if (!(await AuthorizeForF1PostsAsync()))
            {
                return View("NoPermission");
            }

            var memes = await _f1PostServices.ListF1MemesAsync();
            var model = new F1PostListViewModel(memes);

            return View(nameof(List), model);
        }

        private async Task<bool> AuthorizeForF1PostsAsync()
            => await _authorizationService.AuthorizeAsync(User, F1PostPermission.ViewF1Posts);
    }
}