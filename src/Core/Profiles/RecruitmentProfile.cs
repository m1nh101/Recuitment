using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.Entities.Recruitments;

namespace Core.Profiles;

public class RecruitmentProfile : Profile
{
	public RecruitmentProfile()
	{
		CreateMap<Recruitment, GeneralRecruitmentResponse>();
		CreateMap<Recruitment, ListRecruitmentResponse>();

		CreateMap<Recruitment, RecruitmentDetailResponse>();

		CreateMap<UpdateRecruitmentRequest, Recruitment>()
			.ForMember(e => e.Id, x => x.Ignore());
	}
}