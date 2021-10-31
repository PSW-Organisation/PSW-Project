using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace vezba.Factory
{
    class ApplicationDataSource
    {
        private ApplicationDataSource()
        {
            repositoryFactory = CreateRepositoryFactory();
        }
        private static ApplicationDataSource dataSourceInstance;
        public static IRepositoryFactory repositoryFactory { get; set; }
        public static ApplicationDataSource GetInstance()
        {
            if (dataSourceInstance == null)
                dataSourceInstance = new ApplicationDataSource();
            return dataSourceInstance;
            

        }
        private IRepositoryFactory CreateRepositoryFactory()
        {
            if (Properties.Settings.Default.DataSource == "file")
            {
                return new FileRepositoryFactory();
            }
            else 
            {
                MessageBox.Show("Niste izabrali izvor podataka. Prebaceno na rad sa fajlovima");
                return new FileRepositoryFactory();
            }
        }
        public IRepositoryFactory GetRepositoryFactory()
        {
            return repositoryFactory;
        }
    }
}
