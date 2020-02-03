using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2.Characters
{
    class Publishers : ICharacter
    {
        int id;
        string name;
        public Publishers(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
