using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("The solved problems cannot be negative.");
        }
        if (problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("The solved problems cannot be more than 10.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: One problem solved.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Good result: Two problems solved.");
        }

        throw new ArgumentOutOfRangeException("The number of solved problems is invalid.");
    }
}
