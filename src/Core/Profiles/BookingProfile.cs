using AutoMapper;
using Core.CQRS.Bookings.Respones;
using Core.Entities.Bookings;

namespace Core.Profiles;

public class BookingProfile : Profile
{
	public BookingProfile()
	{
		CreateMap<Booking, GeneralBookingResponse>();
	}
}