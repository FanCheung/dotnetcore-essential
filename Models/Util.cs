// this method only available within the same name space
namespace Util
{
    public static class StringExtension
    {
        // Extend an internal class object type with this keyword
        public static int Count(this string words)
        {
            return words.Split().Length;
        }
    }
}