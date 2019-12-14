using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIndexSortSwitch : ExpansionBase
    {
        private string _table;

        private void MainFunction()
        {
            BuildSnippet(null);
            _table = Input.Singularize();

            var sortColumns = GetSortColumns(_table);
            if (!sortColumns.Any()) return;
            BuildSnippet("switch (sortOrder)");
            BuildSnippet("{");
            //BuildSnippet(_table.ToLower() + "IQ");
            foreach (var item in sortColumns)
            {
                //BuildSnippet(".Where(s => s." + item.ColumnName + ".Contains(searchString));");
                //break;
            }
            BuildSnippet("}");
            AppendText();
            AppendText(BuildSnippet());
        }
    }
}

//switch (sortOrder)
//{
//    case "name_desc":
//        studentIQ = studentIQ.OrderByDescending(s => s.LastName);
//        break;
//    case "Date":
//        studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
//        break;
//    case "date_desc":
//        studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
//        break;
//    default:
//        studentIQ = studentIQ.OrderBy(s => s.LastName);
//        break;
//}

