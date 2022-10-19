using AutoMapper;
using Core.CQRS.Auth.Responses;
using Core.Entities.Users;

namespace Core.Profiles;

public class EmployeeProfile : Profile
{
	public EmployeeProfile()
	{
		CreateMap<User, AddedEmployeeResponse>();
	}
}