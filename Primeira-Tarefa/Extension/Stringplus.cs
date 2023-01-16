namespace Primeira_Tarefa.Extension
{
    public static class Stringplus
    {
        public static bool IsFill(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}
