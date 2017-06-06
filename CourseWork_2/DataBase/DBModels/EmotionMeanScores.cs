namespace CourseWork_2.DataBase.DBModels
{
    public class EmotionMeanScores
    {
        public int EmotionMeanScoresId { get; set; }
        public float AngerScore { get; set; }
        public float ContemptScore { get; set; }
        public float DisgustScore { get; set; }
        public float FearScore { get; set; }
        public float HappinessScore { get; set; }
        public float NeutralScore { get; set; }
        public float SadnessScore { get; set; }
        public float SurpriseScore { get; set; }

        public int EmotionFragmentId { get; set; }
        public EmotionFragment EmotionFragment { get; set; }
    }
}
