namespace SharedKernel.Exceptions;

public class InvalidTimeException : Exception
{
	public InvalidTimeException()
	{
	}

	public InvalidTimeException(string message): base(message)
	{
	}
}