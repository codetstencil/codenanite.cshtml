using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIndexSearchString : ExpansionBase
    {
        private string _table;

        private void MainFunction()
        {
            BuildSnippet(null);
            _table = Input.Singularize();

            var searchColumns = GetSearchColumns(_table);
            if (!searchColumns.Any()) return;
            BuildSnippet("if (!string.IsNullOrEmpty(searchString))",12);
            BuildSnippet("{", 12);
            BuildSnippet(_table.ToLower().Pluralize() ,16);
            foreach (var item in searchColumns)
            {
                BuildSnippet(".Where(s => s." + item.ColumnName + ".Contains(searchString));",20);
                break;
            }
            BuildSnippet("}",12);
            AppendText();
            AppendText(BuildSnippet());

        }
    }
}

//if (!string.IsNullOrEmpty(searchString))
//{
//    customerIQ = customerIQ.Where(s => s.LastName.Contains(searchString)
//                                     || s.FirstMidName.Contains(searchString));
//}
