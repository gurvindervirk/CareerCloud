using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;


namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobDescriptionRepository : BaseADO, IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Jobs_Descriptions]([Id],[Job],[Job_Name],[Job_Descriptions])
                    values (@Id,@Job,@Job_Name,@Job_Descriptions)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Job", poco.Job );
                    command.Parameters.AddWithValue("@Job_Name", poco.JobName );
                    command.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions );

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

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[2000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Jobs_Descriptions", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job  = reader.GetGuid(1);
                    if (!reader.IsDBNull(2))
                    {
                        poco.JobName = reader.GetString(2);
                    }
                    else
                    {
                        poco.JobName = null;
                    }
                    if (!reader.IsDBNull(3))
                    {
                        poco.JobDescriptions  = reader.GetString(3);
                    }
                    else
                    {
                        poco.JobDescriptions  = null;
                    }
                    poco.TimeStamp = (byte[])reader[4];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Jobs_Descriptions where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Jobs_Descriptions
                                        set 
                                            
                                           [Job]= @Job,
                                           [Job_Name]= @Job_Name,
                                           [Job_Descriptions]= @Job_Descriptions
                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Job", poco.Job);
                    Cmd .Parameters.AddWithValue("@Job_Name", poco.JobName);
                    Cmd .Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
