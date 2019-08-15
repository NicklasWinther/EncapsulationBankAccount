using EncapsulationBankAccount.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EncapsulationBankAccount.Dal
{
    public class AccountRepository : BaseRepository
    {
        private List<Account> HandleData(DataTable dataTable)
        {
            List<Account> accounts = new List<Account>();
            if (dataTable is null)
                return accounts;

            foreach (DataRow row in dataTable.Rows)
            {
                Account account = new Account((int)row["AccountId"], (decimal)row["Balance"], (DateTime)row["Created"]);
                    
                accounts.Add(account);
            }
            return accounts;
        }

        public void AddAccounts(List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                string sql = $"INSERT INTO Accounts VALUES('{account.Balance}', '{"2019-08-15"}')";
                ExecuteNonQuery(sql);
            }

        }

        public List<Account> GetAccounts()
        {
            string sql = "SELECT TOP(10) * FROM Accounts";
            return HandleData(ExecuteQuery(sql));
        }
    }
}
