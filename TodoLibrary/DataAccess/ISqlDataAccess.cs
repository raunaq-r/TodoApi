namespace TodoLibrary.DataAccess;

public interface ISqlDataAccess
{
    public Task<List<T>> LoadData<T, U>(
        string storedProcedure, 
        U parameters, 
        string connectionStringName);

    public Task SaveData<T>(
        string storedProcedure, 
        T parameters, 
        string connectionStringName);
}
