using TodoLibrary.Models;

namespace TodoLibrary.DataAccess;

public class TodoData : ITodoData
{
    private readonly ISqlDataAccess _sql;

    public TodoData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<TodoModel>> GetAllTasks()
    {
        return _sql.LoadData<TodoModel, dynamic>(
            "dbo.spTodoItems_GetAllTasks",
            new {},
            "Default");
    }

    public Task<List<TodoModel>> GetActiveTasks()
    {
        return _sql.LoadData<TodoModel, dynamic>(
            "dbo.spTodoItems_GetActiveTasks",
            new {},
            "Default");
    }

    public async Task<TodoModel?> CreateTask(string task)
    {
        var results = await _sql.LoadData<TodoModel, dynamic>(
            "dbo.spTodoItems_Create",
            new { Task = task },
            "Default");
        
        return results.FirstOrDefault();
    }

    public Task CompleteTask(int todoId)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spTodoItems_MarkComplete",
            new {Id = todoId},
            "Default");
    }

    public Task RemoveCompletedTasks()
    {
        return _sql.SaveData<dynamic>(
            "dbo.spTodoItems_RemoveCompletedTask",
            new {},
            "Default");
    }
}
