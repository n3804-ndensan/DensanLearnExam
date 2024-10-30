using System.ComponentModel.DataAnnotations;

namespace DensanLearnExam.Models
{
    public class TaskItem : IComparable<TaskItem>
    {
        [Required(ErrorMessage = "題名は必須項目です")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public Status TaskStatus { get; set; }
        public string Description { get; set; } = string.Empty;

        public int CompareTo(TaskItem other)
        {
            int stateComparison = this.TaskStatus.CompareTo(other.TaskStatus);
            if (stateComparison != 0)
            {
                return stateComparison;
            }

            return this.DueDate.CompareTo(other.DueDate);
        }
        public enum Status
        {
            未着手 = 0,
            仕掛中 = 1,
            完了 = 2,
            無視 = 9
        }
    }


}
