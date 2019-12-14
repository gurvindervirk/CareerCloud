using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (ApplicantResumePoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Resumes]([ID],[Applicant],[Resume],[Last_Updated])
                    values (@Id,@Applicant,@Resume,@LastUpdated)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Resume", poco.Resume);
                    command.Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);
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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
                
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Applicant_Resumes", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        poco.LastUpdated = reader.GetDateTime(3);
                    }
                    else
                    {
                        poco.LastUpdated = null;
                    }
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
            
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantResumePoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Resumes where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantResumePoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Resumes
                                        set 
                                        [ID]= @Id,
                                        [Applicant]= @Applicant,
                                        [Resume]= @Resume,
                                        [Last_Updated]= @LastUpdated
                                        where ID=@Id";
                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Applicant", poco.Applicant);
                    Cmd .Parameters.AddWithValue("@Resume", poco.Resume);
                    Cmd .Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
