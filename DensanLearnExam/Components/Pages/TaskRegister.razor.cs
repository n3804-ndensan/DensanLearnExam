

using DensanLearnExam.Models;
using Microsoft.AspNetCore.Components.Forms;


namespace DensanLearnExam.Components.Pages
{
    public partial class TaskRegister
    {
        private TaskItem newTask = new TaskItem();
        private EditContext editContext;
        private bool isError = true;

        protected override void OnInitialized()
        {
            ClearForm();
            editContext = new EditContext(newTask);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        public void Dispose()
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }

        async Task AddTask()
        {
            await Task.Yield();
            sessionState?.State?.Add(newTask);
            Navigation.NavigateTo("/");
        }

        async Task Cancel()
        {
            await Task.Yield();
            Navigation.NavigateTo("/");
        }

        private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
        {
            isError = !editContext.Validate();
            StateHasChanged();
        }

        private void ClearForm()
        {
            newTask.Title = string.Empty;
            newTask.DueDate = DateTime.Now.Date;
            newTask.TaskStatus = TaskItem.Status.未着手;
            newTask.Description = string.Empty;
        }
    }
}
