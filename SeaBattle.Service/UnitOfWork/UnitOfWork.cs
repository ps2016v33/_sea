using SeaBattle.Data.Context;

namespace SeaBattle.Service.UnitOfWork
{
    public class UnitOfWork
    {
        private static UnitOfWork _instance;

        private readonly SeaBattleContext _context;

        private BattleFieldService _bfService;
        private UserService _uService;
        private EmailService _eService;

        private UnitOfWork()
        {
            _context = new SeaBattleContext();
        }

        public static UnitOfWork Instance => _instance ?? (_instance = new UnitOfWork());

        public BattleFieldService BattleFieldService => _bfService ?? (_bfService = new BattleFieldService(_context));

        public EmailService EmailService => _eService ?? (_eService = new EmailService(_context));

        public UserService UserService => _uService ?? (_uService = new UserService(_context));
    }
}
