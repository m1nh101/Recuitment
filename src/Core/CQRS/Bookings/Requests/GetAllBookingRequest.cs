using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Requests;

public class GetAllBookingRequest : IRequest<ActionResponse>
{
}