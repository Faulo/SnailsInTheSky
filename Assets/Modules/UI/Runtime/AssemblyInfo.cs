using System.Runtime.CompilerServices;
using SitS.UI;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]

namespace SitS.UI {
    static class AssemblyInfo {
        internal const string NAMESPACE_RUNTIME = "SitS.UI";
        internal const string NAMESPACE_EDITOR = "SitS.UI.Editor";
        internal const string NAMESPACE_TESTS = "SitS.UI.Tests";
    }
}