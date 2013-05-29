using System;

public class ExamResult
{
    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade must be positive.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The minimum grade must be positive");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The maximum grade must be positive.");
        }
        if (String.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("The comments must not be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
