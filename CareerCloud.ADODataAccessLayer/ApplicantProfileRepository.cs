using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (ApplicantProfilePoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Profiles]([ID],[Login],[Current_Salary],[Current_Rate],[Currency],[Country_Code],[State_Province_Code],[Street_Address],[City_Town],[Zip_Postal_Code])
                    values (@Id,@Login,@CurrentSalary,@CurrentRate,@Currency,@CountryCode,@StateProvinceCode,@StreetAddress,@CityTown,@ZipPostalCode)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login );
                    command.Parameters.AddWithValue("@CurrentSalary", poco.CurrentSalary );
                    command.Parameters.AddWithValue("@CurrentRate", poco.CurrentRate );
                    command.Parameters.AddWithValue("@Currency", poco.Currency );
                    command.Parameters.AddWithValue("@CountryCode", poco.Country );
                    command.Parameters.AddWithValue("@StateProvinceCode", poco.Province );
                    command.Parameters.AddWithValue("@StreetAddress", poco.Street );
                    command.Parameters.AddWithValue("@CityTown", poco.City );
                    command.Parameters.AddWithValue("@ZipPostalCode", poco.PostalCode );
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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Applicant_Profiles", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login  = reader.GetGuid(1);
                    if (!reader.IsDBNull(2))
                    {
                       
                        poco.CurrentSalary = Convert.ToDecimal(reader.GetValue(2));
                    }
                    else
                    {
                        poco.CurrentSalary = null;
                    }
                    if (!reader.IsDBNull(3))
                    {
                        poco.CurrentRate = Convert.ToDecimal(reader.GetValue(3));
                    }
                    else
                    {
                        poco.CurrentRate = null;
                    }

                    if (!reader.IsDBNull(4))
                    {
                        poco.Currency = reader.GetString(4);
                    }
                    else
                    {
                        poco.Currency = null;
                    }

                    if (!reader.IsDBNull(5))
                    {
                        poco.Country = reader.GetString(5);
                    }
                    else
                    {
                        poco.Country = null;
                    }

                    if (!reader.IsDBNull(6))
                    {
                        poco.Province = reader.GetString(6);
                    }
                    else
                    {
                        poco.Province = null;
                    }

                    if (!reader.IsDBNull(7))
                    {
                        poco.Street = reader.GetString(7);
                    }
                    else
                    {
                        poco.Street = null;
                    }

                    if (!reader.IsDBNull(8))
                    {
                        poco.City = reader.GetString(8);
                    }
                    else
                    {
                        poco.City = null;
                    }
                    if (!reader.IsDBNull(9))
                    {
                        poco.PostalCode = reader.GetString(9);
                    }
                    else
                    {
                        poco.PostalCode = null;
                    }
                                                          
                    poco.TimeStamp = (byte[])reader[10];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantProfilePoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Profiles where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantProfilePoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Profiles
                                        set [Login]= @Login,
                                            [Current_Salary]= @CurrentSalary,
                                            [Current_Rate]= @CurrentRate,
                                            [Currency]= @Currency,
                                            [Country_Code]= @CountryCode,
                                            [State_Province_Code]= @StateProvinceCode,
                                            [Street_Address]= @StreetAddress,
                                            [City_Town]= @CityTown,
                                            [Zip_Postal_Code]= @ZipPostalCode
                                            where ID=@Id";
                    Cmd .Parameters.AddWithValue("@Id",poco.Id);
                    Cmd .Parameters.AddWithValue("@Login",poco.Login);
                    Cmd .Parameters.AddWithValue("@CurrentSalary",poco.CurrentSalary);
                    Cmd .Parameters.AddWithValue("@CurrentRate",poco.CurrentRate);
                    Cmd .Parameters.AddWithValue("@Currency",poco.Currency);
                    Cmd .Parameters.AddWithValue("@CountryCode",poco.Country);
                    Cmd .Parameters.AddWithValue("@StateProvinceCode",poco.Province);
                    Cmd .Parameters.AddWithValue("@StreetAddress", poco.Street);
                    Cmd .Parameters.AddWithValue("@CityTown", poco.City);
                    Cmd .Parameters.AddWithValue("@ZipPostalCode", poco.PostalCode);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
