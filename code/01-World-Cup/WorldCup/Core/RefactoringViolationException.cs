namespace WorldCup.Core;

public class RefactoringViolationException : Exception
{
    public RefactoringViolationException()
    : base("This code should not be called during refactoring. " +
           "The purpose of this exception is to prevent unintended mistakes during the workshop." +
           "Take the necessary steps to separate this dependency from your code.")
    {
        
    }
}