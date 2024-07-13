using System.Runtime.CompilerServices;
using SitS.VFX;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]

namespace SitS.VFX {
    static class AssemblyInfo {
        internal const string NAMESPACE_RUNTIME = "SitS.VFX";
        internal const string NAMESPACE_EDITOR = "SitS.VFX.Editor";
        internal const string NAMESPACE_TESTS = "SitS.VFX.Tests";
    }
}