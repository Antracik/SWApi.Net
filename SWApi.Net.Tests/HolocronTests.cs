using FluentAssertions;
using Moq;
using System.Text.Json;

namespace SWApi.Net.Tests;

public class HolocronTests
{
    [Fact]
    public async void GetById_ThrowsException_When_EndpointAttribute_Missing()
    {
        var holocron = new Holocron(new NullProvider());

        await Assert.ThrowsAsync<Exception>(() => holocron.GetById<EntityWithNoAttribute>(1));
    }

    [Fact]
    public async void GetById_ReturnsNull_When_IdIsNotFound()
    {
        var holocron = new Holocron(new NullProvider());

        var result = await holocron.GetById<EntityWithEndpointAttribute>(-1);

        result.Should().BeNull();
    }

    [Fact]
    public async void Get_ThrowsException_When_EndpointAttribute_Missing()
    {
        var holocron = new Holocron(new NullProvider());

        await Assert.ThrowsAsync<Exception>(() => holocron.Get<EntityWithNoAttribute>());
    }

    [Fact]
    public async void Get_Returns_EmptyList_When_EndpointReturns_NoData()
    {
        var holocron = new Holocron(new NullProvider());

        var result = await holocron.Get<EntityWithEndpointAttribute>();

        result.Should().BeEmpty();
    }

    [Fact]
    public async void GetById_ReturnsExpetedEntity()
    {
        var expected = new EntityWithEndpointAttribute(1, "fake");

        var json = JsonSerializer.Serialize(expected);

        var provider = new Mock<IDataProvider>();
        provider.Setup(_ => _.Request(It.IsAny<string>())).ReturnsAsync(json);

        var holocron = new Holocron(provider.Object);

        var result = await holocron.GetById<EntityWithEndpointAttribute>(1);

        result.Should().NotBeNull();
        result!.Id.Should().Be(expected.Id);
        result!.Name.Should().Be(expected.Name);
    }

    [Fact]
    public async void GetById_Uses_Proper_URL()
    {
        var entity = new EntityWithEndpointAttribute(1, string.Empty);

        var expectedUrl = $"{Constants.BaseUrl}fakeEndpoint/{entity.Id}";

        var provider = new Mock<IDataProvider>();
        provider.Setup(x => x.Request(It.Is<string>(x => x == expectedUrl)));

        var holocron = new Holocron(provider.Object);

        await holocron.GetById<EntityWithEndpointAttribute>(1);

        provider.Verify(x => x.Request(expectedUrl));
    }

    [Fact]
    public async void Get_Uses_Proper_URL()
    {
        var expectedUrl = $"{Constants.BaseUrl}fakeEndpoint/";

        var provider = new Mock<IDataProvider>();
        provider.Setup(x => x.Request(It.Is<string>(x => x == expectedUrl)));

        var holocron = new Holocron(provider.Object);

        await holocron.Get<EntityWithEndpointAttribute>();

        provider.Verify(x => x.Request(expectedUrl));
    }

    [Fact]
    public async void Get_Uses_Proper_URL_With_SearchQuery()
    {
        var searchQuery = "SomethingThatDoesNotExist";
        var expectedUrl = $"{Constants.BaseUrl}fakeEndpoint/?search={searchQuery}";

        var provider = new Mock<IDataProvider>();
        provider.Setup(x => x.Request(It.Is<string>(x => x == expectedUrl)));

        var holocron = new Holocron(provider.Object);

        await holocron.Get<EntityWithEndpointAttribute>(searchQuery);

        provider.Verify(x => x.Request(expectedUrl));
    }

    [Fact]
    public async void Get_Requests_AtLeast_Once_When_NoData()
    {
        var expectedUrl = $"{Constants.BaseUrl}fakeEndpoint/";

        var provider = new Mock<IDataProvider>();
        provider.Setup(x => x.Request(It.Is<string>(x => x == expectedUrl)));

        var holocron = new Holocron(provider.Object);

        await holocron.Get<EntityWithEndpointAttribute>();

        provider.Verify(x => x.Request(expectedUrl), Times.Once);
    }

    [Fact]
    public async void Get_Requests_AtLeast_Twice_When_SomeData()
    {
        var expectedCount = 2;

        var returnedHelper = new Helper<EntityWithEndpointAttribute>(expectedCount, "Yes", new List<EntityWithEndpointAttribute>()
        {
            new (1, "Name1"),
            new(2, "Name2")
        });

        var provider = new Mock<IDataProvider>();
        provider.SetupSequence(x => x.Request(It.IsAny<string>()))
            .ReturnsAsync(JsonSerializer.Serialize(returnedHelper))
            .ReturnsAsync(() => null);

        var holocron = new Holocron(provider.Object);

        var result = await holocron.Get<EntityWithEndpointAttribute>();

        provider.Verify(x => x.Request(It.IsAny<string>()), Times.Exactly(2));
        result.Should().NotBeEmpty();
        result.Should().HaveCount(expectedCount);
    }

    [Fact]
    public async void Get_Works_When_Result_Is_Null()
    {
        var returnedHelperOne = new Helper<EntityWithEndpointAttribute>(1, "Yes", null);

        var provider = new Mock<IDataProvider>();
        provider.SetupSequence(x => x.Request(It.IsAny<string>()))
            .ReturnsAsync(JsonSerializer.Serialize(returnedHelperOne))
            .ReturnsAsync(() => null);

        var holocron = new Holocron(provider.Object);

        var reuslt = await holocron.Get<EntityWithEndpointAttribute>();

        provider.Verify(x => x.Request(It.IsAny<string>()), Times.Once);

        reuslt.Should().BeEmpty();
    }

}