using BusinessLogic.Logics;
using BusinessLogicInterface.Interfaces;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccessInterface.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieLogic, MovieLogic>();
        }

        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>();
        }
    }
}