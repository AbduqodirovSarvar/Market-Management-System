using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OutComeToDoList.Queries
{
    public class GetAllOutComeQuery : IRequest<List<OutCome>>
    {
        public Guid? ProductId { get; set; }
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
