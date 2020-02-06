using Application.Common.Base;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTimeslot
{
    public class CreateTimeSlotCommand : IRequest<bool>
    {
        public Guid TeacherId { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public CreateTimeSlotCommand(Guid teacherId, string description, DateTime from, DateTime to)
        {
            TeacherId = teacherId;
            Description = description;
            From = from;
            To = to;
        }

        public class CreateTimeSlotHandler : BaseContext, IRequestHandler<CreateTimeSlotCommand, bool>
        {
            public CreateTimeSlotHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
            {
            }

            public Task<bool> Handle(CreateTimeSlotCommand request, CancellationToken cancellationToken)
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
}
