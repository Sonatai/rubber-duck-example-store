using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.DeleteCart
{
    public class DeleteCartCommand : IRequest<ActionResult>
    {
        public string CartId { get; set; }
    }
}
