namespace KangaModeling.Compiler.ClassDiagrams.Model
{
    /// <summary>
    /// Represents one field of an IClass instance.
    /// </summary>
    public interface IField
    {
        string Name { get; }
        string Type { get; }
        VisibilityModifier Visibility { get; }
    }
}