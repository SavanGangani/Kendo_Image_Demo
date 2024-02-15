using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_exam_krishna_tamakuwala.Startup))]
namespace mvc_exam_krishna_tamakuwala
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
