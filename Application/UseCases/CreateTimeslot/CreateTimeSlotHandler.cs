using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTimeslot
{
    public class CreateTimeSlotHandler : BaseContext, IRequestHandler<CreateTimeslotCommand, bool>
    {
        public CreateTimeSlotHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<bool> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var timeSlot = new Timeslot
            {
                Description = request.Description,
                From = request.From,
                To = request.To
            };

            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);
            teacher.CreateTimeSlot(timeSlot);

            return Task.FromResult(_dbContext.SaveChanges());
        }
    }
}
