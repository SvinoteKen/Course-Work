﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using School.Entities;
using System.Windows.Forms;
using School.Data;

namespace School.Services
{
    class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        private List<Account> _account = new List<Account>();
        public IEnumerable<Account> GetListAccounts()
        {
            return _account.ToArray();
        }
        public IEnumerable<Account> GetAccounts()
        {
            if (!File.Exists("login.json"))
            {
                return null;
            }
            using (var f = File.OpenText("login.json"))
            {
                var json = f.ReadToEnd();
                _account = JsonConvert.DeserializeObject<Account[]>(json,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }).ToList();
                return JsonConvert.DeserializeObject<Account[]>(json,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
        }
        public bool Authorize(string login, string password)
        {
            GetAccounts();
            var user = AuthUser(login, password);
            if (user != null)
            {
                if (user.Roles == "Admin")
                {
                    Status.Value = true;
                }
                else 
                { 
                    Status.Value = false; 
                }
                return true;
            }
            return false;
        }
         public Account AuthUser(string login, string password)
        {
            return _account.SingleOrDefault(u => u.Login == login && u.Password == password);
        }
        public void AddAccount(Account account) 
        {
            _account.Add(account);
            Save();
        }
        public void Save() 
        {
            var accounts = GetListAccounts();
            var json = JsonConvert.SerializeObject(accounts, Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var f = File.CreateText("login.json"))
            {
                f.Write(json);
            }
        }
    }
}
