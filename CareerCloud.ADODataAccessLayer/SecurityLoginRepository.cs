using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (SecurityLoginPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Security_Logins]([Id],[Login],[Password], [Created_Date] , [Password_Update_Date], [Agreement_Accepted_Date], [Is_Locked], [Is_Inactive], [Email_Address], [Phone_Number], [Full_Name], [Force_Change_Password], [Prefferred_Language])
                                            values(@Id,@Login,@Password,@Created_Date,@Password_Update_Date,@Agreement_Accepted_Date, @Is_Locked, @Is_Inactive, @Email_Address, @Phone_Number, @Full_Name, @Force_Change_Password, @Prefferred_Language)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.LoginName );
                    command.Parameters.AddWithValue("@Password", poco.Password );
                    command.Parameters.AddWithValue("@Created_Date", poco.Created );
                    command.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate );
                    command.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted );
                    command.Parameters.AddWithValue("@Is_Locked", poco.IsLocked) ;
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive );
                    command.Parameters.AddWithValue("@Email_Address", poco.EmailAddress );
                    command.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber );
                    command.Parameters.AddWithValue("@Full_Name", poco.FullName );
                    command.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword );
                    command.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage );
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Security_Logins", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.LoginName  = reader.GetString (1);
                    poco.Password  = reader.GetString(2);
                    poco.Created  = reader.GetDateTime (3);
                    if (!reader.IsDBNull(4))
                    {
                        poco.PasswordUpdate = reader.GetDateTime(4);
                    }
                    else
                    {
                        poco.PasswordUpdate = null;
                    }

                    if (!reader.IsDBNull(5))
                    {
                        poco.AgreementAccepted = reader.GetDateTime(5);
                    }
                    else
                    {
                        poco.AgreementAccepted = null;
                    }

                    
                    poco.IsLocked  = reader.GetBoolean(6);
                    poco.IsInactive  = reader.GetBoolean(7);
                    if (!reader.IsDBNull(8))
                    {
                        poco.EmailAddress = reader.GetString(8);
                    }
                    else
                    {
                        poco.EmailAddress = null;
                    }
                    if (!reader.IsDBNull(9))
                    {
                        poco.PhoneNumber = reader.GetString(9);
                    }
                    else
                    {
                        poco.PhoneNumber = null;
                    }
                    if (!reader.IsDBNull(10))
                    {
                        poco.FullName = reader.GetString(10);
                    }
                    else
                    {
                        poco.FullName = null;
                    }
                    
                    poco.ForceChangePassword  = reader.GetBoolean (11);
                    if (!reader.IsDBNull(12))
                    {
                        poco.PrefferredLanguage = reader.GetString(12);
                    }
                    else
                    {
                        poco.PrefferredLanguage = null;
                    }
                    
                    poco.TimeStamp = (byte[])reader[13];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityLoginPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Security_Logins where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (SecurityLoginPoco poco in items)
                {
                    Cmd.CommandText = @"Update Security_Logins
                                        set 
                                             [Login]= @Login,
                                             [Password]= @Password,
                                             [Created_Date] =@Created_Date,
                                             [Password_Update_Date]= @Password_Update_Date,
                                             [Agreement_Accepted_Date]= @Agreement_Accepted_Date,
                                             [Is_Locked]= @Is_Locked,
                                             [Is_Inactive]= @Is_Inactive,
                                             [Email_Address]= @Email_Address,
                                             [Phone_Number] =@Phone_Number,
                                             [Full_Name]= @Full_Name,
                                             [Force_Change_Password]= @Force_Change_Password,
                                             [Prefferred_Language]= @Prefferred_Language
                                            where ID=@Id";


                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Login", poco.LoginName);
                    Cmd .Parameters.AddWithValue("@Password", poco.Password);
                    Cmd .Parameters.AddWithValue("@Created_Date", poco.Created);
                    Cmd .Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    Cmd .Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    Cmd .Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    Cmd .Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    Cmd .Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    Cmd .Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    Cmd .Parameters.AddWithValue("@Full_Name", poco.FullName);
                    Cmd .Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    Cmd .Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
