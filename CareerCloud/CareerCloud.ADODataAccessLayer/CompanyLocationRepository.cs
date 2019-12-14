﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyLocationPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Locations]([Id],[Company],[Country_Code],[State_Province_Code],
                                            [Street_Address],[City_Town],[Zip_Postal_Code])
                                            values(@Id,@Company,@Country_Code,@State_Province_Code,
                                                    @Street_Address,@City_Town,@Zip_Postal_Code)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Company", poco.Company );
                    command.Parameters.AddWithValue("@Country_Code", poco.CountryCode );
                    command.Parameters.AddWithValue("@State_Province_Code", poco.Province );
                    command.Parameters.AddWithValue("@Street_Address", poco.Street );
                    command.Parameters.AddWithValue("@City_Town", poco.City );
                    command.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode );
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Locations", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLocationPoco poco = new CompanyLocationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.CountryCode  = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        poco.Province = reader.GetString(3);
                    }
                    else
                    {
                        poco.Province = null;
                    }

                    if (!reader.IsDBNull(4))
                    {
                        poco.Street = reader.GetString(4);
                    }
                    else
                    {
                        poco.Street = null;
                    }

                    if (!reader.IsDBNull(5))
                    {
                        poco.City = reader.GetString(5);
                    }
                    else
                    {
                        poco.City = null;
                    }

                    if (!reader.IsDBNull(6))
                    {
                        poco.PostalCode = reader.GetString(6);
                    }
                    else
                    {
                        poco.PostalCode = null;
                    }
                    
                    poco.TimeStamp = (byte[])reader[7];
                    pocos[position] = poco;
                    position++;
                    

                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyLocationPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Locations where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyLocationPoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Locations
                                        set 
                                            [Company]= @Company,  
                                            [Country_Code]= @Country_Code,
                                            [State_Province_Code]= @State_Province_Code,
                                            [Street_Address]= @Street_Address,
                                            [City_Town] =@City_Town,
                                            [Zip_Postal_Code]= @Zip_Postal_Code
                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Company", poco.Company);
                    Cmd .Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    Cmd .Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    Cmd .Parameters.AddWithValue("@Street_Address", poco.Street);
                    Cmd .Parameters.AddWithValue("@City_Town", poco.City);
                    Cmd .Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
