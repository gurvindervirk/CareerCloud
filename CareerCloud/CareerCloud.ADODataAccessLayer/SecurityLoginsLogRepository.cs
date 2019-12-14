using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Security_Logins_Log]([Id],[Login], [Source_IP], [Logon_Date], [Is_Succesful])
                                            values(@Id,@Login, @Source_IP, @Logon_Date, @Is_Succesful)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login );
                    command.Parameters.AddWithValue("@Source_IP", poco.SourceIP );
                    command.Parameters.AddWithValue("@Logon_Date", poco.LogonDate );
                    command.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful );
                    
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

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[2000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Security_Logins_Log", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login  = reader.GetGuid (1);
                    poco.SourceIP  = reader.GetString(2);
                    poco.LogonDate  = reader.GetDateTime (3);
                    poco.IsSuccesful   = reader.GetBoolean (4);
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Security_Logins_Log where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    Cmd.CommandText = @"Update Security_Logins_Log
                                        set 
                                            [Login]= @Login,
                                            [Source_IP]= @Source_IP,
                                            [Logon_Date]= @Logon_Date,
                                            [Is_Succesful]= @Is_Succesful

                                            where ID=@Id";

                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Login", poco.Login);
                    Cmd .Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    Cmd .Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    Cmd .Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
