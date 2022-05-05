using FunmulaUno.Post.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;

namespace FunmulaUno.Post.Migrations
{

    public class F1PostPartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public F1PostPartMigrations(IContentDefinitionManager contentDefinitionManager)
            => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(F1PostPart), part => part
                .WithField(nameof(F1PostPart.Name), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Name")
                    .WithSettings(new TextFieldSettings() { Required = true })
                )
                .WithField(nameof(F1PostPart.Body), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Body")
                    .WithEditor("TextArea")
                )
                .WithField(nameof(F1PostPart.IsMeme), field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Is meme")
                )
                .WithField(nameof(F1PostPart.Image), field => field
                    .OfType(nameof(MediaField))
                    .WithDisplayName("Image")
                    .WithEditor("Attached")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("F1Post", type => type
                .Creatable()
                .Listable()
                .Securable()
                .WithPart(nameof(F1PostPart))
            );

            return 2;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition("F1Post", type => type
                .Creatable()
                .Listable()
                .Securable()
                .WithPart(nameof(F1PostPart))
            );

            return 2;
        }
    }
}