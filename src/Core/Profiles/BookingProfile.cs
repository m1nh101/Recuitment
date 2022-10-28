using AutoMapper;
using Core.CQRS.Applications.Update;
using Core.Entities;
using Core.Entities.Bookings;

namespace Core.Profiles;

public class BookingProfile : Profile
{
	public BookingProfile()
	{
		CreateMap<ReviewInterviewPayload, InterviewResult>();
	}
}