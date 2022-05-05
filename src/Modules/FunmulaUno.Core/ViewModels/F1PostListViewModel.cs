using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace FunmulaUno.Post.ViewModels
{

    public class F1PostListViewModel
    {
        public IEnumerable<ContentItem> F1Posts { get; }

        public F1PostListViewModel(IEnumerable<ContentItem> f1Posts)
        {
            F1Posts = f1Posts;
        }
    }
}