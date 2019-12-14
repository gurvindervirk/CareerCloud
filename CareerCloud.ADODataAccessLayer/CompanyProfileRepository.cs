using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyProfilePoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Profiles]([Id],[Registration_Date],[Company_Website], [Contact_Phone], [Contact_Name], [Company_Logo])
                                            values(@Id,@Registration_Date,@Company_Website, @Contact_Phone, @Contact_Name, @Company_Logo)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate );
                    command.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite );
                    command.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone );
                    command.Parameters.AddWithValue("@Contact_Name", poco.ContactName );
                    command.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo );
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Profiles", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.RegistrationDate  = reader.GetDateTime (1);
                    if (!reader.IsDBNull(2))
                    {
                        poco.CompanyWebsite = reader.GetString(2);
                    }
                    else
                    {
                        poco.CompanyWebsite =  null;
                    }
                    poco.ContactPhone  = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        poco.ContactName  = reader.GetString(4);
                    }
                    else
                    {
                        poco.ContactName = null;
                    }

                    if (!reader.IsDBNull(5))
                    {
                        poco.CompanyLogo  = (byte[])reader[5];
                    }
                    else
                    {
                        poco.CompanyLogo = null;
                    }
                                      
                    poco.TimeStamp = (byte[])reader[6];
                    pocos[position] = poco;
                    position++;


                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyProfilePoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Profiles where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyProfilePoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Profiles
                                        set 
                                            [Registration_Date]= @Registration_Date,
                                            [Company_Website]= @Company_Website,
                                            [Contact_Phone]= @Contact_Phone,
                                            [Contact_Name]= @Contact_Name,
                                            [Company_Logo]= @Company_Logo

                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    Cmd .Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    Cmd .Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    Cmd .Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    Cmd .Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
