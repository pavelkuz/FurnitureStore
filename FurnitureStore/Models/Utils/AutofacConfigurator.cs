using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureStore.Models.Utils
{
    public class AutofacConfigurator
    {
        public static void ConfigureContainer()
        {
            //Создаем билдер DI контейнера
            var builder = new ContainerBuilder();

            //Регистрируем типы в DI билдере, перед созданием контейнера
            builder.RegisterType<FurnitureStore.Models.User>();
            builder.RegisterType<FurnitureStore.Models.Goods>();
            builder.RegisterType<FurnitureStore.Models.Role>();
            builder.RegisterType<FurnitureStore.Models.FurnitureType>();

            //Позднее связывание, все сущности
            builder.RegisterAssemblyTypes(typeof(Goods).Assembly).As<IGoods>();

            //Раннее связывание, все сущности по отдельности, минус это для каждой новой реализации я новую строчку делаю
            //builder.Register<FurnitureStore.Models.IFurniture>(x => x.Resolve<FurnitureStore.Models.Bed>());
            //builder.Register<FurnitureStore.Models.IFurniture>(x => x.Resolve<FurnitureStore.Models.Chair>());
            //builder.Register<FurnitureStore.Models.IFurniture>(x => x.Resolve<FurnitureStore.Models.Cupboard>());
            //builder.Register<FurnitureStore.Models.IFurniture>(x => x.Resolve<FurnitureStore.Models.Table>());

            //Создаем DI контейнер
            var container = builder.Build();

            //Устанавливаем DI ресолвер через интегратор DI контейнера
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}