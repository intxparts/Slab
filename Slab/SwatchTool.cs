using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab
{
    public class SwatchTool : ITool
    {
        public string Name => "Swatch";

        public string Icon => "<PlaceHolder>";

        public bool IsVisible => true;

        public bool IsEnabled => true;

        public Type ViewType => typeof(Swatch);

        public Type ViewModelType => typeof(SwatchViewModel);
    }
}
