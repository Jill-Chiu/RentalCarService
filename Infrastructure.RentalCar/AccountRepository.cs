using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using Common.RentalCar.Crypto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RentalCar
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SaleCarDbContext _context;

        public AccountRepository(SaleCarDbContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CreateAccount(AccountViewModel account)
        {
            int result = 0;
            Account accountEnt = new Account()
            {
                UserId = account.UserId,
                Password = StringEncryptor.EncryptString(account.Password!), // !表示不可能為NULL
                Aid = account.Aid,
                ChtName = account.ChtName,
                MobilePhone = account.MobilePhone,
            };

            _context.Accounts.Add(accountEnt);
            try
            {
                result = _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Trace.TraceError($"新增帳號發生錯誤, FileSystemInfo ={ ex.Message}");
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int EditAccount(AccountViewModel account)
        {
            throw new NotImplementedException();
        }

        public AccountViewModel? GetAccount(string userId)
        {
            //第一種寫法透過Lambda expression (單一Table時，偏向使用擴充方法，程式碼較短簡潔
            //var account =_context.Accounts
            //    .Where(c => c.UserId == userId)
            //    .Select(c => new AccountViewModel()
            //    {
            //        UserId = c.UserId,
            //        Password = c.Password,
            //        ChtName = c.ChtName,
            //        MobilePhone = c.MobilePhone,

            //    })
            //    .FirstOrDefault();
            //return account;

            //第二種寫法 linq query expression (多個Entity要join時偏向使用此方法
            var account = (from x in _context.Accounts
                           where x.UserId == userId
                           select new AccountViewModel()
                           {
                               UserId = x.UserId,
                               Password = x.Password,
                               Aid = x.Aid,
                               ChtName = x.ChtName,
                               MobilePhone = x.MobilePhone,
                           })
                          .FirstOrDefault();
            return account;
            
        }
    }
}
