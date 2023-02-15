namespace AlterDSLib
{
    public class IdealDSRerunModel
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public DateTime? ProcessedDate { get; set; }

        public IdealDSRerunModel(int id, string? item, DateTime? processedDate)
        {
            Id = id;
            Item = item;
            ProcessedDate = processedDate;
        }

        public override string ToString()
        {
            return $@"
            Id: {Id}
            Item: {Item}
            ProcessedDate: {ProcessedDate}
            ";
        }
    }
}