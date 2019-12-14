//using ZeraSystems.CodeNanite.Html;
using ZeraSystems.CodeStencil.Contracts;
using ZeraSystems.CodeNanite.Cshtml;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlTableHead
    {
        private void MainFunction(int indent)
        {
            AppendText();
            var columns = GetColumns(Input);
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey)
                    continue;

                //Sorting
                //if (column.ColumnAttribute.Contains("+"))
                //{
                //    if (column.ColumnType == "string")
                //}

                
                //var theColumn = column.TableName + "." + column.ColumnName;

                AppendText(Indent(indent) + "<th>");
                AppendText(Indent(indent + 4) + "@Html.DisplayNameFor(model => model."+ column.TableName +"[0]."+ column.ColumnName + ")");
                AppendText(Indent(indent) + "</th>");
            }
        }
    }
}