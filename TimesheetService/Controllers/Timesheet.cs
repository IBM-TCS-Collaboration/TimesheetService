namespace TimesheetService.Controllers
{
    internal class Timesheet
    {
        public object ProjectName { get; internal set; }
        public string Sunday { get; internal set; }
        public string Monday { get; internal set; }
        public string Tuesday { get; internal set; }
        public string Wednesday { get; internal set; }
        public string Thursday { get; internal set; }
        public string Friday { get; internal set; }
        public string Saturday { get; internal set; }
        public int Total { get; internal set; }
        public object Description { get; internal set; }
    }
}