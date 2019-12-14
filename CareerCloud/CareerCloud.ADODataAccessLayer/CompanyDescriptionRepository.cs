using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Descriptions]([Id],[Company],[Company_Name],[Company_Description],[LanguageId])
                    values (@Id,@Company,@Company_Name,@Company_Description,@LanguageId)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Company", poco.Company );
                    command.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    command.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription );
                    command.Parameters.AddWithValue("@LanguageId", poco.LanguageId) ;
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

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Descriptions", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company  = reader.GetGuid(1);
                    poco.LanguageId  = reader.GetString(2);
                    poco.CompanyName   = reader.GetString(3);
                    poco.CompanyDescription  = reader.GetString(4);
                    poco.TimeStamp = (byte[])reader[5];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Descriptions where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Descriptions
                                        set 
                                            
                                           [Company]= @Company,
                                           [Company_Name]= @Company_Name,
                                           [Company_Description]= @Company_Description,
                                            [LanguageId]=@LanguageId
                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Company", poco.Company);
                    Cmd .Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    Cmd .Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                    Cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageId);


                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
