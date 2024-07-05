using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Queries
{
    public class GetAllInComeQuery : IRequest<List<InCome>>
    {
        public Guid? ProductId { get; set; }
        public DateOnly? FromDate {  get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
