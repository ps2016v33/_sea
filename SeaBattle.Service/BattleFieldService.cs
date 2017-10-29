using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using SeaBattle.Service.Base;
using System.Linq;
using System.Xml;

namespace SeaBattle.Service
{
    public class BattleFieldService: ServiceBase
    {
        public BattleFieldService(SeaBattleContext context) : base(context)
        {
        }

        public async void SaveBattleField(XmlDocument doc)
        {
            var fieldModel = new BattleField {Schema = doc};
            _dbContext.Fields.Add(fieldModel);
            await SaveAsync();
        }

        public XmlDocument GetBattleField()
        {
            var field = _dbContext.Fields.FirstOrDefault();
            return field?.Schema;
        }
    }
}
