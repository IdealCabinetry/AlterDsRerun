namespace AlterDSLib
{
    public class IdealDSRerunModel
    {
        public int id { get; set; }
        public string? Item { get; set; }
        public DateTime? ProcessedDate { get; set; }
 
        public bool IsChecked { get; set; }

        public IdealDSRerunModel(int id, string? item, DateTime? processedDate)
        {
            this.id = id;
            Item = item;
            ProcessedDate = processedDate;
        }

        public IdealDSRerunModel()
        {
        }

        public override string ToString()
        {
            return $@"
            Id: {id}
            Item: {Item}
            ProcessedDate: {ProcessedDate}
            Checked? : {IsChecked}
            ";
        }
    }
}