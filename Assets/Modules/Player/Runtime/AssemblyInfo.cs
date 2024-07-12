using System.Runtime.CompilerServices;
using SitS.Player;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]

namespace SitS.Player {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "SitS.Aseprite";
        public const string NAMESPACE_EDITOR = "SitS.Aseprite.Editor";
        public const string NAMESPACE_TESTS = "SitS.Aseprite.Tests";
    }
}