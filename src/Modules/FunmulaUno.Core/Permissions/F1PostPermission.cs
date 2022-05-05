using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace FunmulaUno.Post.Permissions
{

    public class F1PostPermission : IPermissionProvider
    {
        public static readonly Permission ViewF1Posts =
            new(nameof(ViewF1Posts), "View the F1 Posts list.");

        public Task<IEnumerable<Permission>> GetPermissionsAsync() =>
            Task.FromResult(new[] { ViewF1Posts }.AsEnumerable());

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
            new[]
            {
            new PermissionStereotype()
            {
                Name = "Administrator",
                Permissions = new[] { ViewF1Posts },
            },
            new PermissionStereotype()
            {
                Name = "Anonymus",
                Permissions = new[] { ViewF1Posts },
            }
            };
    }
}