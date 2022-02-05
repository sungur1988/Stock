using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            builder.RegisterType<ProductMovementManager>().As<IProductMovementService>();
            builder.RegisterType<ProductMovementRepository>().As<IProductMovementRepository>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
