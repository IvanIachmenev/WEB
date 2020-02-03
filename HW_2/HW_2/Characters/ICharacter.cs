using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2.Characters
{
    public interface ICharacter
    {
        int GetId();
        string GetName();
        void SetId(int id);
        void SetName(string name);
    }
}
