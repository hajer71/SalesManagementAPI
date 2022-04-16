using DataAccess.SQLServer.Repository;
using Ninject.Modules;
using SalesAPI.Domain;
using SalesAPI.Domain.Abstract;
using SalesAPI.Domain.Entities;

namespace SalesAPI.Injection
{
    public class Injection : NinjectModule
    {
        public override void Load()
        {
            #region Repository

            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IUserRepository>().To<UserRepository>();

            #endregion

            #region Entities

            Bind<ICustomerEntity>().To<CustomerEntity>();
            Bind<IProductEntity>().To<ProductEntity>();
            Bind<IOrderEntity>().To<OrderEntity>();
            Bind<IUserEntity>().To<UserEntity>();
            Bind<ITokenManager>().To<TokenManager>();


            #endregion

        }
    }
}
