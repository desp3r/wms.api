using AutoMapper;
using WMS.BusinessLayer.Application.Accounts;
using WMS.BusinessLayer.Application.Orders.Requests;
using WMS.BusinessLayer.Application.Products.Commands;
using WMS.BusinessLayer.Application.Supplies.Requests;
using WMS.BusinessLayer.Application.Users.Commands;
using WMS.BusinessLayer.Application.Users.Queries;
using WMS.BusinessLayer.Application.Warehouse.Requests;
using WMS.BusinessLayer.Models;
using WMS.DataLayer.Models;

namespace WMS.API.AutoMapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<UserModel, GetUsersQuery>();
            CreateMap<GetUsersQuery, UserModel>();

            CreateMap<CreateUserCommand, UserModel>();
            CreateMap<UserModel, CreateUserCommand>();

            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserCommand>();

            CreateMap<UpdateUserCommand, UserModel>();
            CreateMap<UserModel, UpdateUserCommand>();

            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<DeleteUserCommand, UserModel>();
            CreateMap<UserModel, DeleteUserCommand>();

            CreateMap<AuthModel, AuthUserCommand>();
            CreateMap<AuthUserCommand, AuthModel>();

            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();

            CreateMap<CreateSlotCommand, Slot>().ReverseMap();
            CreateMap<UpdateSlotCommand, Slot>().ReverseMap();

            CreateMap<CreateSupplyCommand, Supply>().ReverseMap();
            CreateMap<UpdateSupplyCommand, Supply>().ReverseMap();

            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();

            CreateMap<Supply, SupplyModel>().ReverseMap();

            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

        }
    }
}
