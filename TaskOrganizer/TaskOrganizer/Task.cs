namespace WCF_TaskOrganizer
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Task() { }
        public Task(int Id, string Description, string Priority, bool Status, int Year, int Month, int Day)
        {
            this.Id = Id;
            this.Description = Description;
            this.Priority = Priority;
            this.Status = Status;
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
        }
    }
}
