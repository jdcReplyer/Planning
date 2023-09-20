namespace Common.DTO.Notifier.Input
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public DateTime Date { get; set; }
        public int User { get; set; }
        public string? DocumentUrl { get; set; }
    }
}
