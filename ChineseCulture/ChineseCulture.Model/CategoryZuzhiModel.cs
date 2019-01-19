using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class CategoryZuzhiModel
    {
        public ArticleCategory ThisArticleCategory { get; set; }
        public List<ArticleCategory> ChildCategorys { get; set; }
    }
}
