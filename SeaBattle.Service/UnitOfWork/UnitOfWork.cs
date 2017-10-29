using SeaBattle.Data.Context;

namespace SeaBattle.Service.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly SeaBattleContext _context;
        private static BattleFieldService _bfService;
        private static UnitOfWork _instance;

        private UnitOfWork()
        {
            _context = new SeaBattleContext();
        }

        public static UnitOfWork Instance => _instance ?? (_instance = new UnitOfWork());

        public BattleFieldService BattleFieldService => _bfService ?? (_bfService = new BattleFieldService(_context));
    }
}
