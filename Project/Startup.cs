using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Data;
using YotzimLilmod.Entities;
using YotzimLilmod.YotzimLilmodDAL;

[assembly: OwinStartupAttribute(typeof(YotzimLilmod.Startup))]
namespace YotzimLilmod
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          
            
        }
    }
}
//<add name="SchoolContext" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=ContosoUniversity;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\ContosoUniversity.mdf" providerName="System.Data.SqlClient" />
