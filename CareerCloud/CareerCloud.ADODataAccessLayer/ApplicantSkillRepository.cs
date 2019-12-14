using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantSkillRepository : BaseADO, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (ApplicantSkillPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Applicant_Skills]([Id],[Applicant],[Skill_Level],[Start_Month],[Start_Year],[End_Month],[End_Year],[Skill])
                    values (@Id,@Applicant,@Skill_Level,@Start_Month,@Start_Year,@End_Month,@End_Year,@Skill)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant );
                    command.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel );
                    command.Parameters.AddWithValue("@Start_Month", poco.StartMonth );
                    command.Parameters.AddWithValue("@Start_Year", poco.StartYear );
                    command.Parameters.AddWithValue("@End_Month", poco.EndMonth );
                    command.Parameters.AddWithValue("@End_Year", poco.EndYear );
                    command.Parameters.AddWithValue("@Skill", poco.Skill);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
             ApplicantSkillPoco[] pocos = new  ApplicantSkillPoco[500];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Applicant_Skills", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     ApplicantSkillPoco poco = new  ApplicantSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant  = reader.GetGuid(1);
                    poco.Skill = reader.GetString(2);
                    poco.SkillLevel  = reader.GetString (3);

                    poco.StartMonth  = Convert.ToByte(reader.GetValue(4));
                    poco.StartYear  = reader.GetInt32(5) ;
                    poco.EndMonth  = Convert.ToByte(reader.GetValue(6));
                   
                    poco.EndYear = reader.GetInt32 (7);

                    poco.TimeStamp = (byte[])reader[8];
                    
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantSkillPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Applicant_Skills where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (ApplicantSkillPoco poco in items)
                {
                    Cmd.CommandText = @"Update Applicant_Skills
                                        set 
                                            [Id]= @Id,
                                            [Applicant]= @Applicant,
                                            [Skill]= @Skill,
                                            [Skill_Level]= @Skill_Level,
                                            [Start_Month]= @Start_Month,
                                            [Start_Year]= @Start_Year,
                                            [End_Month]= @End_Month,
                                            [End_Year]= @End_Year
                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Applicant", poco.Applicant);
                    Cmd .Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    Cmd .Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    Cmd .Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    Cmd .Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    Cmd .Parameters.AddWithValue("@End_Year", poco.EndYear);
                    Cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
