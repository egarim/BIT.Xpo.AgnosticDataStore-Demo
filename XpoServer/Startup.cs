using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIT.Xpo.AspNetCore;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace XpoServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            //HACK Xpo asp core extensions https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo
            //HACK https://documentation.devexpress.com/XPO/119377/Getting-Started/Getting-Started-with-NET-Core

            //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "myXpoApp.db"));

            //HACK how to read connection strings https://stackoverflow.com/questions/45796776/get-connectionstring-from-appsettings-json-instead-of-being-hardcoded-in-net-co
            var cnx = Configuration.GetConnectionString("ConnectionString");
            IDisposable[] DisposableObjects;
            var DataStore = XpoDefault.GetConnectionProvider(cnx, AutoCreateOption.DatabaseAndSchema, out DisposableObjects);

            DataStoreResolver DataStoreResolver = new DataStoreResolver();
            services.AddSingleton<IDataStoreResolver>(DataStoreResolver);
            services.AddMemoryCache();
            services.AddSingleton<IDataStore>(DataStore);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
