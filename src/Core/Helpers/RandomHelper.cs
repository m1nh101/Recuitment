namespace Core.Helpers;

public static class RandomHelper
{
  public static string Password(this Random random)
  {
    const int passwordLength = 8;

    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    return new string(Enumerable.Repeat(chars, passwordLength)
        .Select(s => s[random.Next(s.Length)]).ToArray());
  }
}