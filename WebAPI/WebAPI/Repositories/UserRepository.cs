using Oracle.ManagedDataAccess.Client;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllBranches();

    }

    public class UserRepository : IUserRepository
    {

        private IWebAPIContext _WebAPIContext;

        public UserRepository(IWebAPIContext WebAPIContext)
        {
            _WebAPIContext = WebAPIContext;
        }

        public List<User> GetAllBranches()
        {
            List<User> employees = new List<User>();

            using (OracleConnection con = _WebAPIContext.GetConn())
            {
                using (OracleCommand cmd = _WebAPIContext.GetCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = "SELECT ID, USER_ID, USER_NAME FROM SYS_USER";

                        //Execute the command and use DataReader to display the data
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            employees.Add(new User()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                USER_ID = reader["USER_ID"].ToString(),
                                USER_NAME = reader["USER_NAME"].ToString()

                            });
                        }
                        reader.Dispose();
                        return employees;
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }

}
