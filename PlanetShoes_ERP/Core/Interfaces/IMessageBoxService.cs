using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowError(string message);
    }
}
