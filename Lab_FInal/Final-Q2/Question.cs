namespace BlazorApp4.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
        public int AssignedMarks { get; set; }
        public int TimeLimitSeconds { get; set; }
        public string DifficultyLevel { get; set; }
        public string Topic { get; set; }
    }
}
