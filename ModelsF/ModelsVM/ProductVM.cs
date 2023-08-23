using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsF.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelsF.ModelsVM
{
    public class ProductVM
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get;set; }
    }
}
