//using ZeraSystems.CodeNanite.Html;
using ZeraSystems.CodeStencil.Contracts;
using ZeraSystems.CodeNanite.Cshtml;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlHtmlDisplay
    {
        private void MainFunction(int indent)
        {
            AppendText();
            var columns = GetColumns(Input);
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey)
                    continue;
                
                var theColumn = column.TableName + "." + column.ColumnName;
                AppendText(Indent(indent) + "<dt>");
                AppendText(Indent(indent + 4) + "@Html.DisplayNameFor(model => model."+theColumn+")");
                AppendText(Indent(indent) + "</dt>");
                AppendText(Indent(indent) + "<dd>");
                AppendText(Indent(indent + 4) + "@Html.DisplayFor(model => model." + theColumn + ")");
                AppendText(Indent(indent) + "</dd>");
            }
        }
    }
}