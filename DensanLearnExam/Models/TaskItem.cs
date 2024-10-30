using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DensanLearnExam.Models
{
    public class TaskItem : IComparable<TaskItem>
    {
        [Required(ErrorMessage = "題名は必須項目です")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "期限は必須項目です")]
        public DateTime? DueDate { get; set; } = DateTime.Now.Date;
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
            if (this.DueDate == null && other.DueDate == null)
            {
                return 0;
            }
            else if (this.DueDate == null)
            {
                return -1;
            }
            else if (other.DueDate == null)
            {
                return 1;
            }
            else
            {
                return this.DueDate.Value.CompareTo(other.DueDate.Value);
            }
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
