using DB_WorkEntity.Entity.Domain;
using DB_WorkEntity.Entity.Repository;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace DB_WorkEntity.Entity
{
    public class EntityConnection : IConnection
    {

        public List<EndDayShow> GetEndDayShowProcedure(int numend, int kind)
        {
            /*
            var Tov_allRepository = new GenericRepository<Tov_all>(new TestContext());
            var FuelRepository = new GenericRepository<Fuel>(new TestContext());

            var tov_all = Tov_allRepository.GetAll();
            var fuel = FuelRepository.GetAll();
*/
            var uow = new GenericUnitOfWork();

            var viewEndDayList = uow.Repository<ViewEndDay>().GetAll()
                .Where(a => a.Numend == numend && a.Kind == kind)
                .Select(a => new EndDayShow { Amount =a.Amount.Value, CodFuel = a.Codfuel, Depart = a.Depart, Kind = a.Kind, Name = a.Name, Pay = a.Pay.Value, Price = a.Price})
                .ToList();
            
            //var newTov_all = uow.Repository<Tov_all>().GetAll().Where(a => a.Numend == numend).Where(a => a.Kind == kind);

            //var newFuel = uow.Repository<Fuel>().GetAll();

            return viewEndDayList;
        }
        public List<Tov_all> GetSomeTov()
        {
            var Tov_allRepository = new Tov_allRepository();

            var someTov = Tov_allRepository.GetAll().Where(a => a.Numend == 5400).ToList();

            return someTov;
        }

        public List<object> GetSomeQuery()
        {
            var Tov_allRepository = new Tov_allRepository();
            var FuelRepository = new FuelRepository();

            var someTov = Tov_allRepository.GetAll().Where(a => a.Numend == 5400).Select(a => new { a.Amount, a.Codfuel, a.Datepay }).GroupJoin(FuelRepository.GetAll(), a => a.Codfuel, b => b.Codfuel, (a, b) => new { a, b }).ToList();

            return null;
        }
    }
}
