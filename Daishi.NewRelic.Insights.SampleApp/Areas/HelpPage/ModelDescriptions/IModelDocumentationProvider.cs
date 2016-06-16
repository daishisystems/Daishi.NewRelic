using System;
using System.Reflection;

namespace Daishi.NewRelic.Insights.SampleApp.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}