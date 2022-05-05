using System.Threading.Tasks;
using FunmulaUno.Post.Models;
using OrchardCore.ContentManagement.Handlers;

namespace FunmulaUno.Post.Handlers
{

    public class F1PostHandler : ContentPartHandler<F1PostPart>
    {
        // This will display the "Name" property of the F1 Post in the Admin Panel list.
        public override Task UpdatedAsync(UpdateContentContext context, F1PostPart instance)
        {
            context.ContentItem.DisplayText = instance.Name.Text;

            return Task.CompletedTask;
        }
    }
}