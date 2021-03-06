using System.Collections.Generic;

namespace KangaModeling.Compiler.ClassDiagrams.Model
{

    // TODO how to test implementing classes?
    public interface IDisplayable
    {
        string DisplayText { get; }
    }

    public interface IMethod : IDisplayable
    {
        string Name { get; }
        string ReturnType { get; }
        IEnumerable<MethodParameter> Parameters { get; }
        VisibilityModifier Visibility { get; }
    }

    public struct MethodParameter
    {
        public MethodParameter(string name, string type)
            : this()
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }
        public string Type { get; private set; }
    }
}