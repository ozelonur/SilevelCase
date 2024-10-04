namespace _GAME_.Scripts.Extensions
{
    public static class MoneyConverter
    {
        public static string ToShortString(this int value)
        {
            return value switch
            {
                >= 1_000_000_000 => (value / 1_000_000_000f).ToString("0.#") + "B",
                >= 1_000_000 => (value / 1_000_000f).ToString("0.#") + "M",
                >= 1_000 => (value / 1_000f).ToString("0.#") + "K",
                _ => value.ToString()
            };
        }
    }
}