using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto07c_ComboAvanzada.Models
{
    public class VMComboCities
    {
        /* podria ser List */
        public IEnumerable<Ciudad> Cities { get; set; }
        public int SelectedCity { get; set; }
    }
}