using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[System_Language_Codes]([LanguageID],[Name],[Native_Name])
                                            values(@LanguageID,@Name,@Native_Name)";

                    command.Parameters.AddWithValue("@LanguageID", poco.LanguageID );
                    command.Parameters.AddWithValue("@Name", poco.Name);
                    command.Parameters.AddWithValue("@Native_Name", poco.NativeName );
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

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from System_Language_Codes", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID  = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName  = reader.GetString(2);
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    Cmd.CommandText = @"Delete from System_Language_Codes where LanguageID=@LanguageID";
                    Cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID );
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    Cmd.CommandText = @"Update System_Language_Codes
                                        set 
                                           [Name]= @Name,
                                           [Native_Name]= @Native_Name

                                           where LanguageID=@LanguageID";
                    Cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName );
                    Cmd.Parameters.AddWithValue("@Name", poco.Name);
                    Cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID );
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
