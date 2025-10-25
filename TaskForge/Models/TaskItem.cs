namespace TrackForge.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Assignee { get; set; } = "";
        public string Status { get; set; } = "To Do"; // To Do, In Progress, Done
        public int Priority { get; set; } = 3; // 1=High, 5=Low
        public bool Blocked { get; set; } = false;
        public string? BlockerNote { get; set; }
    }
}
