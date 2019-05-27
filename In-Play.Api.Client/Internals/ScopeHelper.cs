using System.Collections.Generic;

namespace In_Play.Api.Client.Internals
{
    public static class ScopeHelper
    {
        public static string ToScopeString(IEnumerable<string> scopes)
        {
            return scopes != null
                ? string.Join(" ", scopes)
                : null;
        }
    }
}
