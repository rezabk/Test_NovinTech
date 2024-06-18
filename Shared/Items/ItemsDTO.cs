using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Items
{
    public class ItemsDTO
    {
        public IList<ItemDTO> Items { get; set; } = new List<ItemDTO>();
    }
}
