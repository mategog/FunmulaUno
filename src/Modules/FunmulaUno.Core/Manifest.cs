using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "FunmulaUno.Post",
    Author = "The Orchard Core Team", // TODO
    Version = "0.0.1",
    Description = "FunmulaUno.Post",
    Category = "Content Management",
    Dependencies = new[]
    {
        "OrchardCore.ContentTypes",
        "OrchardCore.ContentFields",
        "OrchardCore.Media",
        "OrchardCore.Content"
    }
)]
