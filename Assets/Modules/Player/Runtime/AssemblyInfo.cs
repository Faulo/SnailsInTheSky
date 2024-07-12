using System.Runtime.CompilerServices;
using SitS.Player;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]

namespace SitS.Player {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "SitS.Player";
        public const string NAMESPACE_EDITOR = "SitS.Player.Editor";
        public const string NAMESPACE_TESTS = "SitS.Player.Tests";
    }
}