using Application.RentalCar;
using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using Domain.RentalCar;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RentalCar
{
    public class RentalcarRepository : IQueryRentalCarUseCase,IRentalCarRepository
    {
        private readonly SaleCarDbContext _context;

        public RentalcarRepository(SaleCarDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<AccountViewModel> GetAccounts()
        {
            var result = from account in _context.Accounts
                         select new AccountViewModel()
                         {
                             Id = account.Id,
                             UserId = account.UserId,
                             Password = account.Password,
                             Aid = account.Aid,
                             MobilePhone = account.MobilePhone,
                             ChtName = account.ChtName,
                         };
            return result;
        }

        public IEnumerable<IVehicle> GetAllCars()
        {
            var result = _context.Cars.ToList();

            return new List<IVehicle>();
        }

        public int SaveAccount(AccountViewModel account)
        {
            throw new NotImplementedException();
        }

        public int SaveRentalCar(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
