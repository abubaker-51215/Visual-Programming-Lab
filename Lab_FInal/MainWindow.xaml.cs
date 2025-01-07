using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace lab_final
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = @"Data Source=ABUBAKAR\SQLEXPRESS;Initial Catalog=quiz1;Integrated Security=True;Pooling=False";
        public ObservableCollection<Question> Questions { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Questions = new ObservableCollection<Question>();
            LoadQuestions();
            QuizDataGrid.ItemsSource = Questions;
        }

        private void LoadQuestions()
        {
            try
            {
                LoadingProgressBar.Visibility = Visibility.Visible;
                Questions.Clear();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM QuizQuestionss";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Questions.Add(new Question
                        {
                            QuestionID = reader.GetInt32(0),
                            QuestionText = reader.GetString(1),
                            Options = $"{reader.GetString(2)}, {reader.GetString(3)}, {reader.GetString(4)}, {reader.GetString(5)}",
                            CorrectAnswer = reader.GetString(6),
                            AssignedMarks = reader.GetInt32(7),
                            TimeLimitSeconds = reader.GetInt32(8),
                            Topic = reader.GetString(9),
                            DifficultyLevel = reader.GetString(10)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading questions: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadingProgressBar.Visibility = Visibility.Collapsed;
            }
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFormInputs(out string questionText, out string option1, out string option2, out string option3, out string option4,
                out string correctAnswer, out int assignedMarks, out int timeLimit, out string topic, out string difficultyLevel))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO QuizQuestionss (QuestionText, Option1, Option2, Option3, Option4, CorrectAnswer, AssignedMarks, TimeLimitSeconds, Topic, DifficultyLevel) " +
                                       "VALUES (@QuestionText, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer, @AssignedMarks, @TimeLimitSeconds, @Topic, @DifficultyLevel)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@QuestionText", questionText);
                        command.Parameters.AddWithValue("@OptionA", option1);
                        command.Parameters.AddWithValue("@OptionB", option2);
                        command.Parameters.AddWithValue("@OptionC", option3);
                        command.Parameters.AddWithValue("@OptionD", option4);
                        command.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                        command.Parameters.AddWithValue("@AssignedMarks", assignedMarks);
                        command.Parameters.AddWithValue("@TimeLimitSeconds", timeLimit);
                        command.Parameters.AddWithValue("@Topic", topic);
                        command.Parameters.AddWithValue("@DifficultyLevel", difficultyLevel);
                        command.ExecuteNonQuery();
                    }

                    LoadQuestions();
                    MessageBox.Show("New question added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding question: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuizDataGrid.SelectedItem is Question selectedQuestion &&
                ValidateFormInputs(out string questionText, out string option1, out string option2, out string option3, out string option4,
                                   out string correctAnswer, out int assignedMarks, out int timeLimit, out string topic, out string difficultyLevel))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        string query = "UPDATE QuizQuestionss SET " +
                                       "QuestionText = @QuestionText, Option1 = @OptionA, Option2 = @OptionB, Option3 = @OptionC, Option4 = @OptionD, " +
                                       "CorrectAnswer = @CorrectAnswer, AssignedMarks = @AssignedMarks, TimeLimitSeconds = @TimeLimitSeconds, " +
                                       "Topic = @Topic, DifficultyLevel = @DifficultyLevel WHERE QuestionID = @QuestionID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@QuestionText", questionText);
                        command.Parameters.AddWithValue("@OptionA", option1);
                        command.Parameters.AddWithValue("@OptionB", option2);
                        command.Parameters.AddWithValue("@OptionC", option3);
                        command.Parameters.AddWithValue("@OptionD", option4);
                        command.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                        command.Parameters.AddWithValue("@AssignedMarks", assignedMarks);
                        command.Parameters.AddWithValue("@TimeLimitSeconds", timeLimit);
                        command.Parameters.AddWithValue("@Topic", topic);
                        command.Parameters.AddWithValue("@DifficultyLevel", difficultyLevel);
                        command.Parameters.AddWithValue("@QuestionID", selectedQuestion.QuestionID);
                        command.ExecuteNonQuery();
                    }

                    LoadQuestions();
                    MessageBox.Show("Question updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating question: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateFormInputs(out string questionText, out string option1, out string option2, out string option3, out string option4,
                                        out string correctAnswer, out int assignedMarks, out int timeLimit, out string topic, out string difficultyLevel)
        {
            questionText = QuestionTextBox.Text;
            option1 = Option1TextBox.Text;
            option2 = Option2TextBox.Text;
            option3 = Option3TextBox.Text;
            option4 = Option4TextBox.Text;
            correctAnswer = CorrectAnswerTextBox.Text;
            topic = TopicTextBox.Text;
            difficultyLevel = (DifficultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            bool isAssignedMarksValid = int.TryParse(AssignedMarksTextBox.Text, out assignedMarks);
            bool isTimeLimitValid = int.TryParse(TimeLimitTextBox.Text, out timeLimit);

            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(option1) || string.IsNullOrEmpty(option2) || string.IsNullOrEmpty(option3) || string.IsNullOrEmpty(option4) ||
                string.IsNullOrEmpty(correctAnswer) || string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(difficultyLevel) || !isAssignedMarksValid || !isTimeLimitValid)
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            QuestionTextBox.Clear();
            Option1TextBox.Clear();
            Option2TextBox.Clear();
            Option3TextBox.Clear();
            Option4TextBox.Clear();
            CorrectAnswerTextBox.Clear();
            AssignedMarksTextBox.Clear();
            TimeLimitTextBox.Clear();
            TopicTextBox.Clear();
            DifficultyComboBox.SelectedIndex = -1;
        }
    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int AssignedMarks { get; set; }
        public int TimeLimitSeconds { get; set; }
        public string Topic { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
