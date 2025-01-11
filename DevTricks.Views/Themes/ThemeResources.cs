namespace DevTricks.Views.Themes;

/// <summary>
/// Хранилище ресурсов для тем.
/// </summary>
internal static class ThemeResources
{
    /// <summary>
    /// CTOR
    /// </summary>
    static ThemeResources()
    {
        Properties = new ThemeProperties();
    }


    /// <summary>
    /// Свойства темы.
    /// </summary>
    public static ThemeProperties Properties { get; }
}
