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
    [Fact]
    public void CheckMarkup_HomeComponent_OnAuthenticatedUser()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();

        //Assert
        cut.MarkupMatches("<h1>Hello, world!</h1>\r\n<h2>You are NOT admin</h2>\r\n<br />");
    }

    [Fact]
    public void CheckCode_HomeComponent_OnAuthenticatedUser()
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

    [Fact]
    public void CheckMarkup_HomeComponent_OnNotAuthenticatedUser()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        //Act
        var cut = ctx.RenderComponent<Home>();

        //Assert
        cut.MarkupMatches("<div>\r\n  <h1>You must log in to see the content.</h1>\r\n</div>\r\n<br>");
    }

    [Fact]
    public void CheckCode_HomeComponent_OnNotAuthenticatedUser()
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