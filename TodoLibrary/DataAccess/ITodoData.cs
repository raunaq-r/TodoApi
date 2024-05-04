using TodoLibrary.Models;

namespace TodoLibrary.DataAccess;

public interface ITodoData
{
    public Task<List<TodoModel>> GetAllTasks();

    public Task<List<TodoModel>> GetActiveTasks();

    public Task<TodoModel?> CreateTask(string task);

    public Task CompleteTask(int todoId);

    public Task RemoveCompletedTasks();
}
