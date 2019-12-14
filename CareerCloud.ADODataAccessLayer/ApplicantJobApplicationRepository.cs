using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : BaseADO, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Job_Applications]([Id],[Applicant],[Job],[Application_Date])
                    values (@Id,@Applicant,@Job,@Application_Date)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Job", poco.Job );
                    command.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate );
                   
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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
               
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Applicant_Job_Applications", cnn);
                int position = 0;


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Job = reader.GetGuid(2);
                    poco.ApplicationDate = reader.GetDateTime(3);
                    poco.TimeStamp = (byte[])reader[4];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
            
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Job_Applications where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Job_Applications
                                        set Applicant=@Applicant,
                                        Job=@Job,
                                        Application_Date=@ApplicationDate
                                        where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Applicant", poco.Applicant);
                    Cmd .Parameters.AddWithValue("@Job", poco.Job);
                    Cmd .Parameters.AddWithValue("@ApplicationDate", poco.ApplicationDate);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
