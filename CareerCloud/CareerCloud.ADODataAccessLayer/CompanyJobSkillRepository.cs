using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : BaseADO, IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cnn;
                foreach (CompanyJobSkillPoco poco in items)
                {
                    command.CommandText = @"Insert into [dbo].[Company_Job_Skills]([Id],[Job],[Skill],[Skill_Level],[Importance])
                    values(@Id,@Job,@Skill,@Skill_Level,@Importance)";

                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Job", poco.Job );
                    command.Parameters.AddWithValue("@Skill", poco.Skill );
                    command.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel );
                    command.Parameters.AddWithValue("@Importance", poco.Importance );
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

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[6000];
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("select * from Company_Job_Skills", cnn);
                int position = 0;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.Skill = reader.GetString (2);
                    poco.SkillLevel  = reader.GetString (3);
                    poco.Importance  = reader.GetInt32 (4);
                    poco.TimeStamp = (byte[])reader[5];
                    pocos[position] = poco;
                    position++;
                }
                cnn.Close();
            }
            return pocos.Where(a=> a!=null).ToList();
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobSkillPoco poco in items)
                {
                    Cmd.CommandText = @"Delete from Company_Job_Skills where ID=@Id";
                    Cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = cnn;
                foreach (CompanyJobSkillPoco poco in items)
                {
                    Cmd.CommandText = @"Update Company_Job_Skills
                                        set 
                                            [Job]= @Job,
                                            [Skill]= @Skill,
                                            [Skill_Level]= @Skill_Level,
                                            [Importance]= @Importance

                                            where ID=@Id";

                    Cmd .Parameters.AddWithValue("@Id", poco.Id);
                    Cmd .Parameters.AddWithValue("@Job", poco.Job);
                    Cmd .Parameters.AddWithValue("@Skill", poco.Skill);
                    Cmd .Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    Cmd .Parameters.AddWithValue("@Importance", poco.Importance);

                    cnn.Open();
                    int roweffected = Cmd.ExecuteNonQuery();
                    cnn.Close();
                }

            }
        }
    }
}
