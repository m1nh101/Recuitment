using AutoMapper;
using Core.CQRS.Recruitments.Requests;
using Core.CQRS.Recruitments.Responses;
using Core.Entities;

namespace Core.Profiles;

public class RecruitmentProfile : Profile
{
	public RecruitmentProfile()
	{
		CreateMap<CreateNewRecruitmentRequest, Recruitment>();
		CreateMap<Recruitment, GeneralRecruitmentResponse>();
		CreateMap<Recruitment, ListRecruitmentResponse>();
		CreateMap<Recruitment, RecruitmentDetailResponse>();
		CreateMap<UpdateRecruitmentRequest, Recruitment>()
			.ForMember(e => e.Candidates, x => x.Ignore());
	}
}