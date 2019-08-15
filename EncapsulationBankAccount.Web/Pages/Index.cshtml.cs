using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EncapsulationBankAccount.Entities;
using EncapsulationBankAccount.Dal;


namespace EncapsulationBankAccount.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Account> accounts = new List<Account>();
        public void OnGet()
        {
            AccountRepository accountRepository = new AccountRepository();
            accounts = accountRepository.GetAccounts();
        }
    }
}