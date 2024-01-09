using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Command.DeleteBasket
{
    public class DeleteBasketCommand:IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteBasketCommand(string id)
        {
            Id = id;
        }
    }
}
