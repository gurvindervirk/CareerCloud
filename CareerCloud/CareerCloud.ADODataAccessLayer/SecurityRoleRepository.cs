using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (SecurityRolePoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Security_Roles]([Id], [Role], [Is_Inactive])
                                            values(@Id, @Role, @Is_Inactive)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive );
                    command.Parameters.AddWithValue("@Role", poco.Role);
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

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Security_Roles", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityRolePoco poco = new SecurityRolePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Role = reader.GetString (1);
                    poco.IsInactive = reader.GetBoolean(2);
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityRolePoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Security_Roles where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityRolePoco poco in items)
                {
                    Cmd.CommandText = @"Update Security_Roles
                                        set 
                                           [Role]= @Role,
                                           [Is_Inactive]= @Is_Inactive

                                            where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    Cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive );
                    Cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
