using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EL_BSS
{
    public interface IObserver
    {
        void InitForm();
        void UpdateForm(string data, Model model);
    }
}
