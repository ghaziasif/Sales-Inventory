using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace sales
{
    static public class nhgenerator
    {
        // make sure this should be gerneated only once.
        public static ISessionFactory _SF = null;
        public static ISessionFactory SF = null;
        public static ISessionFactory GetSF()
        {
            try
            {
                if (_SF == null)
                {
                    var NHConfig = new NHibernate.Cfg.Configuration();

                    NHConfig.DataBaseIntegration(delegate(NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties abc)
                    {

                        abc.ConnectionStringName = "DBCS";
                        abc.Dialect<NHibernate.Dialect.MySQL55Dialect>();
                        abc.Driver<NHibernate.Driver.MySqlDataDriver>();
                        abc.Timeout = 60;
                    }

                    );

                    //NHConfig.AddAssembly("JuneBatchMVC");
                    NHConfig.AddAssembly(typeof(sales.Products).Assembly);

                    //when u get an error
                    NHConfig.CurrentSessionContext<WebSessionContext>();


                    _SF = NHConfig.BuildSessionFactory();
                }
            }
            catch (Exception ex)
            {

            }

            return _SF;
        }
    }
}
