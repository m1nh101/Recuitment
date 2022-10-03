using AutoMapper;
using Core.CQRS.Candidates.Responses;
using Core.Entities.Candidates;

namespace Core.Profiles;

public class CandidateProfile : Profile
{
	public CandidateProfile()
	{
		CreateMap<Candidate, ListCandidateResponse>();
		CreateMap<Candidate, CandidateDetailResponse>();
	}
}