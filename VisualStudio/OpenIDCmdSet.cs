using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.OpenID.VsIntegration
{
    public static class GuidList
    {
        public const string PackageGuidString = "7a7e687b-11cf-492f-b9a7-de0bb7ad6031";
        public const string CmdSetString = "563de300-9c6a-4eeb-b2ff-126fc3114379";
        public const string ProductId = "058e00d5-526f-4a38-9a1c-2a512860e9ee";

        public static readonly Guid guidCmdSet = new Guid(CmdSetString);
    }

    public static class PkgCmdIDList
    {
        public const uint ProjectContextMenuGroup = 0x1021;

        public const uint cmdidReGenerateAll = 0x0104;
    }

    public enum OpenIDCmdSet : uint
    {
        ReGenerateAll = PkgCmdIDList.cmdidReGenerateAll
    }
}