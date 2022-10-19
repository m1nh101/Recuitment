using Core.CQRS.Responses;
using MediatR;

namespace Core.CQRS.Bookings.Requests;

public sealed record GetAllBookingRequest : IRequest<ActionResponse>;