using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyJobPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Jobs]([Id],[Company],[Profile_Created],[Is_Inactive],[Is_Company_Hidden])
                    values(@Id,@Company,@Profile_Created,@Is_Inactive,@Is_Company_Hidden)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Company", poco.Company );
                    command.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated );
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive );
                    command.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden );
                    cnn.Open();
                    int roweffected = command.ExecuteNonQuery();
                    cnn.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[2000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Jobs", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobPoco poco = new CompanyJobPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company  = reader.GetGuid(1);
                    poco.ProfileCreated  = reader.GetDateTime (2);
                    poco.IsInactive  = reader.GetBoolean (3);
                    poco.IsCompanyHidden = reader.GetBoolean(4);
                    poco.TimeStamp = (byte[])reader[5];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Jobs where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobPoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Jobs
                                        set 
                                            [Company]= @Company,
                                            [Profile_Created]= @Profile_Created,
                                            [Is_Inactive]= @Is_Inactive,
                                            [Is_Company_Hidden]= @Is_Company_Hidden
                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Company", poco.Company);
                    Cmd .Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                    Cmd .Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    Cmd .Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
