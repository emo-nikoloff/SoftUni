using System.Text;

using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Models.Products;
using BlackFriday.Models.Users;
using static BlackFriday.Utilities.Messages.OutputMessages;

namespace BlackFriday.Core;

public class Controller : IController
{
    private IApplication application;

    public Controller()
    {
        application = new Application();
    }

    public string RegisterUser(string userName, string email, bool hasDataAccess)
    {
        if (application.Users.Exists(userName))
        {
            return string.Format(UserAlreadyRegistered, userName);
        }

        if (application.Users.Models.Any(u => u.Email == email))
        {
            return string.Format(SameEmailIsRegistered, email);
        }

        if (hasDataAccess == true)
        {
            if (application.Users.Models.Count(u => u is Admin) == 2)
            {
                return AdminCountLimited;
            }
            application.Users.AddNew(new Admin(userName, email));
            return string.Format(AdminRegistered, userName);
        }

        application.Users.AddNew(new Client(userName, email));

        return string.Format(ClientRegistered, userName);
    }

    public string AddProduct(string productType, string productName, string userName, double basePrice)
    {
        if (productType is not ("Item" or "Service"))
        {
            return string.Format(ProductIsNotPresented, productType);
        }

        if (application.Products.Exists(productName))
        {
            return string.Format(ProductNameDuplicated, productName);
        }

        if (application.Users.GetByName(userName) is Client or null)
        {
            return string.Format(UserIsNotAdmin, userName);
        }

        IProduct product = productType switch
        {
            "Item" => new Item(productName, basePrice),
            "Service" => new Service(productName, basePrice),
            _ => null!
        };

        application.Products.AddNew(product);

        return string.Format(ProductAdded, productType, productName, $"{basePrice:f2}");
    }

    public string UpdateProductPrice(string productName, string userName, double newPriceValue)
    {
        if (!application.Products.Exists(productName))
        {
            return string.Format(ProductDoesNotExist, productName);
        }

        if (application.Users.GetByName(userName) is Client or null)
        {
            return string.Format(UserIsNotAdmin, userName);
        }

        IProduct product = application.Products.GetByName(productName);
        double oldPriceValue = product.BasePrice;

        product.UpdatePrice(newPriceValue);

        return string.Format(ProductPriceUpdated, productName, $"{oldPriceValue:f2}", $"{newPriceValue:f2}");
    }

    public string RefreshSalesList(string userName)
    {
        if (application.Users.GetByName(userName) is Client or null)
        {
            return string.Format(UserIsNotAdmin, userName);
        }

        int updatedProductsCount = 0;

        application.Products.Models
            .Where(p => p.IsSold == true)
            .ToList()
            .ForEach(p =>
            {
                p.ToggleStatus();
                updatedProductsCount++;
            });

        return string.Format(SalesListRefreshed, updatedProductsCount);
    }

    public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
    {
        if (application.Users.GetByName(userName) is Admin or null)
        {
            return string.Format(UserIsNotClient, userName);
        }

        if (!application.Products.Exists(productName))
        {
            return string.Format(ProductDoesNotExist, productName);
        }

        if (application.Products.GetByName(productName).IsSold)
        {
            return string.Format(ProductOutOfStock, productName);
        }

        Client client = (Client)application.Users.GetByName(userName);
        IProduct product = application.Products.GetByName(productName);

        client.PurchaseProduct(productName, blackFridayFlag);
        product.ToggleStatus();

        double priceToPay = blackFridayFlag ? product.BlackFridayPrice : product.BasePrice;

        return string.Format(ProductPurchased, userName, productName, $"{priceToPay:f2}");
    }

    public string ApplicationReport()
    {
        StringBuilder result = new();

        IEnumerable<IUser> admins = application.Users.Models
            .Where(u => u.GetType().Name is nameof(Admin))
            .OrderBy(u => u.UserName);
        IEnumerable<IUser> clients = application.Users.Models
            .Where(u => u.GetType().Name is nameof(Client))
            .OrderBy(u => u.UserName);

        result.AppendLine("Application administration:");
        foreach (IUser user in admins)
        {
            result.AppendLine(user.ToString());
        }

        result.AppendLine("Clients:");
        foreach (IUser user in clients)
        {
            result.AppendLine(user.ToString());

            Client client = (Client)user;
            IEnumerable<KeyValuePair<string, bool>> clientBlackFridayProducts = client.Purchases
                .Where(p => p.Value == true);
            if (!clientBlackFridayProducts.Any())
            {
                continue;
            }

            result.AppendLine($"-Black Friday Purchases: {clientBlackFridayProducts.Count(p => p.Value == true)}");
            foreach (KeyValuePair<string, bool> purchase in clientBlackFridayProducts)
            {
                result.AppendLine($"--{purchase.Key}");
            }
        }

        return result.ToString().TrimEnd();
    }
}
