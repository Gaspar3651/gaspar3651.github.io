using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Check02.Startup))]
namespace Check02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        /*
            var Culturas = new[] { "pt-BR", "en-US" };
            var LocalizationOptions = new RequesteLocalizationOptions()
                .SetDefaultCulture(Culturas[0])
                .AddCulturas(Culturas)
                .AddSuportedUICultures(Culturas);

            app.UseRequesteLocalization(Culturas);
        */
        }
    }
}
