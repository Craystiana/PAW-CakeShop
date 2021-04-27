using System;
using System.Collections.Generic;

namespace CakeShop.Web.Models.Product
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public string PageTitle { get; set; }

        public int PageProductTypeId { get; set; }
    }
}
