using Soenneker.Temporal.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Temporal.HttpClients.Tests;

[Collection("Collection")]
public sealed class TemporalOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ITemporalOpenApiHttpClient _httpclient;

    public TemporalOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ITemporalOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
