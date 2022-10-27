using AutoMapper;
using Core.CQRS.Recruitments.Create;
using Core.CQRS.Recruitments.Update;
using Core.Entities.Recruitments;

namespace Core.Profiles;

public class RecruitmentProfile : Profile
{
  public RecruitmentProfile()
  {
    CreateMap<Recruitment, UpdateRecruitmentResponse>();
    CreateMap<UpdateRecruitmentRequest, Recruitment>();
    CreateMap<Recruitment, CreatedRecruitmentResponse>();
  }
}