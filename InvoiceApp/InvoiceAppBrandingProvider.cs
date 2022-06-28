using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace InvoiceApp;

[Dependency(ReplaceServices = true)]
public class InvoiceAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "InvoiceApp";
}
