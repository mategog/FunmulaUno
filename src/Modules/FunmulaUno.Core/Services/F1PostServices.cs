using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunmulaUno.Post.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;

namespace FunmulaUno.Post.Services
{

    public class F1PostServices : IF1PostServices
    {
        private readonly ISession _session;

        public F1PostServices(ISession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<ContentItem>> ListF1PostsAsync()
        {
            var query = _session
                .Query<ContentItem, ContentItemIndex>(index => index.Published)
                .Where(index => index.ContentType == "F1Post");

            return await query.ListAsync();
        }

        public async Task<IEnumerable<ContentItem>> ListF1MemesAsync()
        {
            // Get all F1 Posts from DB
            var posts = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.Published)
                .Where(index => index.ContentType == "F1Post")
                .ListAsync();

            // Filter out non-memes
            var memes = posts.Where(post => post.As<F1PostPart>().IsMeme.Value);

            return memes;
        }
    }
}