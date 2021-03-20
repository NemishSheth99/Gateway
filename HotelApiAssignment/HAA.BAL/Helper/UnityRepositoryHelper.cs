using HAA.BAL.Interface;
using HAA.DAL.Repository;
using HAA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace HAA.BAL.Helper
{
    public class UnityRepositoryHelper:UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
            Container.RegisterType<IBookingRepository, BookingRepository>();
            Container.RegisterType<IRoomManager, RoomManager>();
        }

    }
}
