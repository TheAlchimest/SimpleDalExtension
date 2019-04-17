using Demo.Repasitory;

namespace Demo.Repasitory
{
    public interface IUnitOfWork
    {
        UserProfileRepo UserProfileRepo { get; }
        OrderRequestRepo OrderRequestRepo { get; }
        OrderRepo OrderRepo { get; }
        ProductSearchRepo ProductSearchRepo { get; }
        ShoppingCartRepo ShoppingCartRepo { get; }
        MessageRepo MessageRepo { get; }
    }
}