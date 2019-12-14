using System.Configuration;
namespace CareerCloud.ADODataAccessLayer
{
    public class BaseADO
    {
        protected  string ConString;
        public BaseADO()
            {
            ConString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; 
           // ConString = @"Data Source=JH-DEV-VDH\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            }
    }
}
