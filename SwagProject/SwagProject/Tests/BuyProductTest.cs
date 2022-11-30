using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage(); 
            productPage = new ProductPage();
            
        }
       
        [TearDown]
         public void ClosePage()
         {
            WebDrivers.CleanUp();
         }



        [Test]

        public void TC01_AddTwoProductsInCart_ShouldDisplayedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddTShrit.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));
        }
    }
}