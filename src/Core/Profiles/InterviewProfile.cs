using AutoMapper;
using Core.CQRS.Interviews.Finnish;
using Core.Entities;

namespace Core.Profiles;

public class InterviewProfile : Profile
{
  public InterviewProfile()
  {
    CreateMap<InterviewEvaluate, InterviewResult>()
      .ForMember(e => e.Status, d => d.MapFrom(x => x.Overview));
  }
}