using System.Collections.Generic;

namespace portal_customize.dal.Model
{
    public class PageModel
    {
        public object DataList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Total { get; set; }
    }
}
