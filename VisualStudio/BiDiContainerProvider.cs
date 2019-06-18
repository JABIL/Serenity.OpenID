using BoDi;
using System.Composition;

namespace Serenity.OpenID.VsIntegration
{
    [Export(typeof(IBiDiContainerProvider))]
    public class BiDiContainerProvider : IBiDiContainerProvider
    {
        public static void Init(IObjectContainer objectContainer)
        {
            CurrentContainer = objectContainer;
        }

        public static IObjectContainer CurrentContainer { get; private set; }

        public IObjectContainer ObjectContainer
        {
            get { return CurrentContainer; }
        }
    }
}