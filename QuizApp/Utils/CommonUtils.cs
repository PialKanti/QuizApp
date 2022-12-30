namespace QuizApp.Utils
{
    public class CommonUtils
    {
        public static long GetTimestamp(DateTime dateTime)
        {
            var timeSpan = (dateTime.Subtract(new DateTime(1970, 1, 1)));
            return (long)timeSpan.TotalMilliseconds;
        }
    }
}
