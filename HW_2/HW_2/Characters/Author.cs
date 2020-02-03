using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2.Characters
{
    public struct Data
    {
        public int day;
        public int month;
        public int year;
    }
    class Author : ICharacter
    {
        int id;
        string FnameLname;

        Data data;

        public Author(int id, string name, int day = 0, int month = 0, int year = 0)
        {
            this.id = id;
            this.FnameLname = name;
            data.day = day;
            data.month = month;
            data.year = year;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return FnameLname;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.FnameLname = name;
        }

        public Data GetData()
        {
            return data;
        }
    }
}
