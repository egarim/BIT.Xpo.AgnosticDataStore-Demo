using BIT.Xpo.RestDataStore.Agnostic;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using ORM;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XfRestDataStoreDemo.Services;
using XfRestDataStoreDemo.Views;

namespace XfRestDataStoreDemo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            RestApiAgnosticDataStoreImp.Register();
           
            string connectionString = "XpoProvider=RestApiAgnosticDataStoreImp;EndPoint=http://192.168.1.64/XpoServer/api/DataStoreAgnosticMultiDb;Token=Empty;DataStoreId=ConnectionString";
            var DataStore = DevExpress.Xpo.XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
        
            var dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(typeof(Item).Assembly);


            //Updating schema XPO way
            SimpleDataLayer UpdateSchemaDal = new SimpleDataLayer(dictionary, DataStore);
            UnitOfWork UpdateSchemaUoW = new UnitOfWork(UpdateSchemaDal);
            UpdateSchemaUoW.UpdateSchema();
            UpdateSchemaUoW.CreateObjectTypeRecords();
            //Finish updating schema

             XpoDefault.DataLayer = new SimpleDataLayer(dictionary, DataStore);



            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
