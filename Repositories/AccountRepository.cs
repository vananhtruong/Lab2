using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DateAccessLayer;

namespace Repositories
{
    public class AccountRepository :IAccountRepository
    {
        public AccountMember GetAccountById(string accountId) => AccountDAO.Instance.GetAccountById(accountId);

    }
}
