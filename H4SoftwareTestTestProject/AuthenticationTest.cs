using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Identity.UI.Services;
using H4SoftwareTest.Components.Account;
using H4SoftwareTest.Components.Account.Pages;
using H4SoftwareTest.Components.Pages;
using Microsoft.Extensions.DependencyInjection;

using Moq;
using Microsoft.AspNetCore.Components;
using H4SoftwareTest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace H4SoftwareTestTestProject;

public class AuthenticationTest
{
    // Denne metode tester hvis et objekt er authenticated og der forventes true.
    [Fact]
    public void CheckIfUserIsAuthenticated()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.True(homeObj._isAuthenticated);
    }

    // Denne metode tester hvis et objekt er authenticated og der forventes false.
    [Fact]
    public void CheckIfUserIsNotAuthenticated()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.False(homeObj._isAuthenticated);
    }
}