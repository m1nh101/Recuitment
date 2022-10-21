using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Applications.Booking;

public sealed class BookingInterviewForApplicantRequestHandler
  : IRequestHandler<BookingInterviewForApplicantRequest, ActionResponse>
{
    public Task<ActionResponse> Handle(BookingInterviewForApplicantRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
