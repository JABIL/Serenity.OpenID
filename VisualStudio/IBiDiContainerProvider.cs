using BoDi;

namespace Serenity.OpenID.VsIntegration
{
    public interface IBiDiContainerProvider
    {
        IObjectContainer ObjectContainer { get; }
    }
}