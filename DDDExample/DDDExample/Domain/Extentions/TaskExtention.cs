namespace DDDExample.Domain.Extentions
{
    public static class TaskExtention
    {
        public static Task<T> ToTask<T>(this T syncValue)
        {
            return Task.FromResult(syncValue);
        }
    }
}
