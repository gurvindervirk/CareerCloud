using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Work_History]([Id],[Applicant],[Company_Name],[Country_Code],[Location],[Job_Title],
                                          [Job_Description],[Start_Month],[Start_Year],[End_Month],[End_Year])
                    values (@Id,@Applicant,@Company_Name,@Country_Code,@Location,@Job_Title,
                    @Job_Description,@Start_Month,@Start_Year,@End_Month,@End_Year)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant );
                    command.Parameters.AddWithValue("@Company_Name", poco.CompanyName );
                    command.Parameters.AddWithValue("@Country_Code", poco.CountryCode );
                    command.Parameters.AddWithValue("@Location", poco.Location );
                    command.Parameters.AddWithValue("@Job_Title", poco.JobTitle );
                    command.Parameters.AddWithValue("@Job_Description", poco.JobDescription );
                    command.Parameters.AddWithValue("@Start_Month", poco.StartMonth );
                    command.Parameters.AddWithValue("@Start_Year", poco.StartYear );
                    command.Parameters.AddWithValue("@End_Month", poco.EndMonth );
                    command.Parameters.AddWithValue("@End_Year", poco.EndYear );
                    

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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Applicant_Work_History", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant  = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString (2);
                    poco.CountryCode  = reader.GetString (3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle  = reader.GetString(5);
                    poco.JobDescription  = reader.GetString(6);
                    poco.StartMonth = reader.GetInt16 (7);
                    poco.StartYear  = reader.GetInt32 (8);
                    poco.EndMonth = reader.GetInt16  (9);
                    poco.EndYear  = reader.GetInt32(10);
                    poco.TimeStamp = (byte[])reader[11];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Work_History where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Work_History
                                        set 
                                            
                                            [Applicant]= @Applicant,
                                            [Company_Name]= @Company_Name,
                                            [Country_Code]= @Country_Code,
                                            [Location]= @Location,
                                            [Job_Title]= @Job_Title,
                                            [Job_Description]= @Job_Description,
                                            [Start_Month]= @Start_Month,
                                            [Start_Year]= @Start_Year,
                                            [End_Month]= @End_Month,
                                            [End_Year]=@End_Year    

                                            where ID=@Id";
                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Applicant", poco.Applicant);
                    Cmd .Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    Cmd .Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    Cmd .Parameters.AddWithValue("@Location", poco.Location);
                    Cmd .Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    Cmd .Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    Cmd .Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    Cmd .Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    Cmd .Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    Cmd .Parameters.AddWithValue("@End_Year", poco.EndYear);
                    
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
