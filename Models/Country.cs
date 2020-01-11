using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Country
    {
        public int id;
        public string continent;
        public string name;
        public string lang;


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Continent { get => continent; set => continent = value; }
        public string Lang { get => lang; set => lang = value; }

        public Country() { }
        public Country(string _name, string _lang, string _continent)
        {
            Name = _name;
            Lang = _lang;
            Continent = _continent;
        }

        public List<Country> Read(string name)
        {

            //insert your code here
            return null;

        }



        public List<Country> getCountry()
        {
            List<Country> county1 = new List<Country>();
            DBservices dbs = new DBservices();
            county1 = dbs.getCountrys();
            return county1;
        }

        public List<Country> Update(string name)
        {

            //insert your code here
            return null;

        }


        public int PutCountry()
        {
            DBservices dbs1 = new DBservices();
            int numAffected = dbs1.PutCountry(this);
            return numAffected;
        }

    }
}