using HAA.BAL;
using HAA.BAL.Helper;
using HAA.BAL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HAA.API
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IBookingManager, BookingManager>();
			container.RegisterType<IRoomManager, RoomManager>();
			container.RegisterType<IHotelManager, HotelManager>();

			container.AddNewExtension<UnityRepositoryHelper>();
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}