using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CardPage cardPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
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

        [Test]

        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOption("Price (high to low)");


            Assert.That(productPage.SortByPrice.Displayed);
        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedactToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC04_BuyProduct_ShouldBeFinishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddTShrit.Click();
            productPage.ShoppingCardClick.Click();
            cardPage.Checkout.Click();
            cardPage.FirstName.SendKeys("Milos");
            cardPage.LastName.SendKeys("Stankovic");
            cardPage.ZipCode.SendKeys("11000");
            cardPage.ButtonContinue.Submit();
            cardPage.ButtonFinish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cardPage.OrderFinished.Text));
        }
    }
}