using MediatR;


namespace WMS.BusinessLayer.Application.Supplies.Requests
{
    public class UpdateSupplyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ProductLeft { get; set; }
    }
}
