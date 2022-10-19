using AutoMapper;
using Core.CQRS.Interviews.Requests;
using Core.Entities;

namespace Core.Profiles;

public class InterviewProfile : Profile
{
  public InterviewProfile()
  {
    CreateMap<ReviewCandidateResult, InterviewResult>()
      .ForMember(e => e.Status, d => d.MapFrom(x => x.Overview));
  }
}