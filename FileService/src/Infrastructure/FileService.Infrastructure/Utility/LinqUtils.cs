namespace FileService.Infrastructure.Utility
{
    public static class LinqUtils
    {
        public static bool In<T>(this T key, IEnumerable<T> list)
        {
            return list.Contains(key);
        }

        public static bool NotIn<T>(this T key, IEnumerable<T> list)
        {
            return !list.Contains(key);
        }
    }
}
