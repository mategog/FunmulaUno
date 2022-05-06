using FunmulaUno.Post.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Taxonomies.Fields;
using OrchardCore.Taxonomies.Settings;

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
                .WithField(nameof(F1PostPart.Category), field => field
                    .OfType(nameof(TaxonomyField))
                    .WithDisplayName("Category")
                    .WithSettings(new TaxonomyFieldSettings() { TaxonomyContentItemId = "4bx9fg32j9gv3wy3s2tdwyv1wp" })
                    .WithSettings(new ContentPartFieldSettings() { Editor = "Tags", DisplayMode = "Tags"})
                )
                    
            );

            _contentDefinitionManager.AlterTypeDefinition("F1Post", type => type
                .Creatable()
                .Listable()
                .Securable()
                .WithPart(nameof(F1PostPart))
            );

            return 3;
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

        public int UpdateForm2()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(F1PostPart), part => part
                .WithField(nameof(F1PostPart.Category), field => field
                    .OfType(nameof(TaxonomyField))
                    .WithDisplayName("Category")
                    .WithSettings(new TaxonomyFieldSettings() { TaxonomyContentItemId = "4bx9fg32j9gv3wy3s2tdwyv1wp" })
                    .WithSettings(new ContentPartFieldSettings() { Editor = "Tags", DisplayMode = "Tags" })
                )

            );

            return 3;
        }
    }
}