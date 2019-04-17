

namespace Demo.Repasitory
{
    public class UnitOfWork : IUnitOfWork 
    {

        #region UserProfileRepo
        //---------------------------------------
        //IUserProfileRepo
        //---------------------------------------
        private UserProfileRepo _UserProfileRepo;
        public UserProfileRepo UserProfileRepo
        {
            get
            {
                return _UserProfileRepo ?? (_UserProfileRepo = new UserProfileRepo());
            }
        }
        //---------------------------------------
        #endregion

        #region OrderRequestRepo
        //---------------------------------------
        //IOrderRequestRepo
        //---------------------------------------
        private OrderRequestRepo _OrderRequestRepo;
        public OrderRequestRepo OrderRequestRepo
        {
            get
            {
                return _OrderRequestRepo ?? (_OrderRequestRepo = new OrderRequestRepo());
            }
        }
        //---------------------------------------
        #endregion

        #region ProductSearchRepo
        //---------------------------------------
        //IProductSearchRepo
        //---------------------------------------
        private ProductSearchRepo _ProductSearchRepo;
        public ProductSearchRepo ProductSearchRepo
        {
            get
            {
                return _ProductSearchRepo ?? (_ProductSearchRepo = new ProductSearchRepo());
            }
        }
        //---------------------------------------
        #endregion

        #region ShoppingCartRepo
        //---------------------------------------
        //IShoppingCartRepo
        //---------------------------------------
        private ShoppingCartRepo _ShoppingCartRepo;
        public ShoppingCartRepo ShoppingCartRepo
        {
            get
            {
                return _ShoppingCartRepo ?? (_ShoppingCartRepo = new ShoppingCartRepo());
            }
        }
        //---------------------------------------
        #endregion

        #region OrderRepo
        //---------------------------------------
        //IOrderRepo
        //---------------------------------------
        private OrderRepo _OrderRepo;
        public OrderRepo OrderRepo
        {
            get
            {
                return _OrderRepo ?? (_OrderRepo = new OrderRepo());
            }
        }
        //---------------------------------------
        #endregion

        #region MessageRepo
        //---------------------------------------
        //IMessageRepo
        //---------------------------------------
        private MessageRepo _MessageRepo;
        public MessageRepo MessageRepo
        {
            get
            {
                return _MessageRepo ?? (_MessageRepo = new MessageRepo());
            }
        }
        //---------------------------------------
        #endregion

        
    }
}
