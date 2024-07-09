using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;
using DataAccessLayer;

namespace DateAccessLayer
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private readonly MyStoreContext dbcontext;
        private static readonly object instanceLock = new object();

        

        //instance singleton
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();

                    }
                    return instance;
                }
            }
        }

        public AccountMember GetAccountById(string accountID)
        {
            using var db = new MyStoreContext();
            AccountMember accountMember = null;
            
            try
            {
                accountMember =  db.AccountMembers.FirstOrDefault(c => c.MemberId.Equals(accountID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountMember;
        }
    }
}
