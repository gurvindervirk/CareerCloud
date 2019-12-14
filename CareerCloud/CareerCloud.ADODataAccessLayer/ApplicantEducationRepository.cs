using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository :BaseADO , IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString ))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                
                foreach (ApplicantEducationPoco poco in items )
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Educations]([Id],[Applicant],[Major],[Certificate_Diploma],[Start_Date],[Completion_Date],	[Completion_Percent])
                    values (@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)";
                    command.Parameters.AddWithValue("@Id",poco .Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant );
                    command.Parameters.AddWithValue("@Major", poco.Major );
                    command.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma );
                    command.Parameters.AddWithValue("@Start_Date", poco.StartDate );
                    command.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate );
                    command.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent );
                    

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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString ))
            {
                cnn.Open();
                SqlCommand command  = new SqlCommand("select * from Applicant_Educations", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read ())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.CertificateDiploma = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        poco.StartDate  = reader.GetDateTime(4);
                    }
                    else
                    {
                        poco.StartDate  = null;
                    }
                    if (!reader .IsDBNull(5) )
                    {
                        poco.CompletionDate = reader.GetDateTime(5);
                    }
                    else
                    {
                        poco.CompletionDate = null;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        poco.CompletionPercent = reader.GetByte (6);
                    }
                    else
                    {
                        poco.CompletionPercent  = null;
                    }
                    poco.TimeStamp = (byte[])reader[7];
                    pocos[position] = poco;
                    position++;

                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
            
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
            
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection =  cnn;
               
                foreach (ApplicantEducationPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Educations where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();

                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection =cnn;
               
                foreach (ApplicantEducationPoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Educations
                                        set Applicant=@Applicant,
                                        Major=@Major,
                                        Certificate_Diploma=@CertificateDiploma,
                                        Start_Date=@StartDate,
                                        Completion_Date=@CompletionDate,
                                        Completion_Percent=@CompletionPercent
                                        where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    Cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    Cmd.Parameters.AddWithValue("@Major", poco.Major);
                    Cmd.Parameters.AddWithValue("@CertificateDiploma", poco.CertificateDiploma);
                    Cmd.Parameters.AddWithValue("@StartDate", poco.StartDate);
                    Cmd.Parameters.AddWithValue("@CompletionDate", poco.CompletionDate);
                    Cmd.Parameters.AddWithValue("@CompletionPercent", poco.CompletionPercent);
                   
                    cnn.Open();
                    int roweffected = Cmd .ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
