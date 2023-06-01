namespace FileService.Domain.SeekWork;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }
}