using AutoMapper;
using Core.CQRS.Candidates.Requests;
using Core.CQRS.Candidates.Responses;
using Core.Entities;

namespace Core.Profiles;

public class CandidateProfile : Profile
{
	public CandidateProfile()
	{
		CreateMap<AddCandidateToRecruitmentRequest, Candidate>();
		CreateMap<Candidate, ListCandidateResponse>();
		CreateMap<Candidate, CandidateDetailResponse>();
	}
}