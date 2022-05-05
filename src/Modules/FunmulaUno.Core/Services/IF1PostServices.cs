using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace FunmulaUno.Post.Services
{

    public interface IF1PostServices
    {
        public Task<IEnumerable<ContentItem>> ListF1PostsAsync();

        public Task<IEnumerable<ContentItem>> ListF1MemesAsync();
    }
}