using Bunit;
using H4SoftwareTest.Components.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit.TestDoubles;


namespace H4SoftwareTestTestProject
{
    public class RoleTest
    {
        // Denne metode tester hvis et objekt har rollen Admin og der forventes true.
        [Fact]
        public void CheckIfUserIsAdmin()
        {
            //Arange
            var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");
            authContext.SetRoles("Admin");

            //Act
            var cut = ctx.RenderComponent<Home>();
            var homeObj = cut.Instance;

            //Assert
            Assert.True(homeObj._isAdmin);
        }

        // Denne metode tester hvis et objekt ikke har rollen Admin og der forventes false.
        [Fact]
        public void CheckIfUserIsNotAdmin()
        {
            //Arange
            var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            //Act
            var cut = ctx.RenderComponent<Home>();
            var homeObj = cut.Instance;

            //Assert
            Assert.False(homeObj._isAdmin);
        }

        // Denne metode tester hvis et objekt har en anden rolle end den forventet.
        [Fact]
        public void CheckIfUserIsAnotherRoleThanAdmin()
        {
            //Arange
            var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");
            authContext.SetRoles("User");

            //Act
            var cut = ctx.RenderComponent<Home>();
            var homeObj = cut.Instance;

            //Assert
            Assert.False(homeObj._isAdmin);
            Assert.True(homeObj._isAuthenticated);
        }
        
        [Fact]
        public void CheckMarkup_HomeComponent_OnAdminUser()
        {
            //Arange
            var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetRoles("Admin");

            //Act
            var cut = ctx.RenderComponent<Home>();

            //Assert
            cut.MarkupMatches("<h1>Hello, world!</h1>\r\n<h2>You are admin</h2>\r\n<br />");
        }
    }
}
