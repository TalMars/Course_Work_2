namespace CourseWork_2.DataBase.DBModels
{
    public class RecordSettings
    {
        public int RecordSettingsId { get; set; }
        public bool FrontCamera { get; set; }
        public bool Touches { get; set; }

        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
