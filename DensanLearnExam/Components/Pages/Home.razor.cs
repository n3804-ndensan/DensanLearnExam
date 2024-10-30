using DensanLearnExam.Models;

namespace DensanLearnExam.Components.Pages;

public partial class Home
{
    private List<TaskItem>? taskList;
    protected override async Task OnInitializedAsync()
    {
        if (sessionState.HasState)
        {
            taskList ??= sessionState?.State;
        }
        await CreateInitialdata();
        await Task.Yield();
        taskList?.Sort((task1, task2) => task1.CompareTo(task2));
    }

    private async Task CreateInitialdata()
    {
        taskList ??=
        [
            new TaskItem
            {
                Title = "タスク1",
                DueDate = DateTime.Now.AddDays(1),
                TaskStatus = TaskItem.Status.未着手,
                Description = "タスク1の内容"
            },
        new TaskItem
        {
            Title = "タスク2",
            DueDate = DateTime.Now.AddDays(2),
            TaskStatus = TaskItem.Status.仕掛中,
            Description = "タスク2の内容"
        },
        new TaskItem
        {
            Title = "タスク3",
            DueDate = DateTime.Now.AddDays(3),
            TaskStatus = TaskItem.Status.完了,
            Description = "タスク3の内容"
        }
        ];
        await Task.Delay(300);
    }

    async Task NavigateToTaskRegister()
    {
        await Task.Yield();
        sessionState.State = taskList;
        Navigation.NavigateTo("/task-register");
    }
}
