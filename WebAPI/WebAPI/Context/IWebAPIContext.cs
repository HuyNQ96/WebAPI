using Oracle.ManagedDataAccess.Client;

namespace WebAPI.Context
{
    public interface IWebAPIContext
    {
        OracleCommand GetCommand();
        OracleConnection GetConn();
    }
}