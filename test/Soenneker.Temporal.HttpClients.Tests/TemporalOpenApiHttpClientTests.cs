using Soenneker.Temporal.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Temporal.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TemporalOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ITemporalOpenApiHttpClient _httpclient;

    public TemporalOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITemporalOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
