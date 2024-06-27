using Application.RentalCar.Repositories;
using Application.RentalCar.ViewModels;
using Common.RentalCar.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.RentalCar
{
    /// <summary>
    /// 登入驗證相關服務
    /// </summary>
    public class AccountServices
    {
        private IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository) 
        {
            _accountRepository=accountRepository;
        }

        public bool RegisterAccount(AccountViewModel account)
        {
            return _accountRepository.CreateAccount(account)>0;
        }

        /// <summary>
        /// 驗證登入帳號密碼
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool ValidationAccount(AccountViewModel account)
        {
            //舉例-商業邏輯的判斷會放在這裡
            //if (account.AccType == AccountType.VIP)
            //{

            //}
            //return _accountRepository.ValidationAccount(account); //ValidationAccount真的會到DB去撈資料
            bool result = false;
            AccountViewModel? accountViewModel = _accountRepository.GetAccount(account.UserId);
            if (accountViewModel != null)
            {
                //比對密碼是否符合
                result =  StringEncryptor.EncryptString(account.Password) == accountViewModel.Password; 
                
            }
            
            return result;
        }
    }
}
