using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager_II.Model
{
    public class User
    {
        private int user_id { get; set; }
        private string surname { get; set; }
        private string name { get; set; }

        public User(int id, string name, string surname)
        {
            this.user_id = id;
            this.name = name;
            this.surname = surname;
        }

        public int getId() { return user_id; }
        public string getName() { return name; }
        public string getSurname() { return surname; }
    }
}
