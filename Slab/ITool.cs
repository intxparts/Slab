using System;

namespace Slab
{
    public interface ITool
    {
        string Name { get; }
        string Icon { get; }
        bool IsVisible { get; }
        bool IsEnabled { get; }

        Type ViewType { get; }
        Type ViewModelType { get; }
    }
}