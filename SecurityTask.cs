using System;

namespace safety_chatbot
{
    public class SecurityTask
    {
        // Task name
        public string Title { get; set; }

        // Task description
        public string Description { get; set; }

        // Reminder date
        public DateTime ReminderDate { get; set; }

        // Indicates whether the task is completed
        public bool IsCompleted { get; set; }

        // Empty constructor
        public SecurityTask()
        {
        }

        // Constructor with parameters
        public SecurityTask(string title,
                            string description,
                            DateTime reminderDate,
                            bool isCompleted = false)
        {
            Title = title;
            Description = description;
            ReminderDate = reminderDate;
            IsCompleted = isCompleted;
        }

        // Display the task nicely in the ListBox
        public override string ToString()
        {
            string status =
                IsCompleted ? "Completed" : "Pending";

            return $"{Title} | {ReminderDate:d} | {status}";
        }
    }
}