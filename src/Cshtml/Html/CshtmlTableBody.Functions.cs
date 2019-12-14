//using ZeraSystems.CodeNanite.Html;
using ZeraSystems.CodeStencil.Contracts;
using ZeraSystems.CodeNanite.Cshtml;
using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlTableBody
    {
        private void MainFunction(int indent)
        {
            AppendText();
            var columns = GetColumns(Input);
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey)
                    continue;

                AppendText(Indent(indent) + "<td>");
                AppendText(Indent(indent + 4) + "@Html.DisplayNameFor(modelItem => item."+ column.ColumnName + ")");
                AppendText(Indent(indent) + "</td>");
            }
            var primarykey = "@item."+GetPrimaryKey(Input);
            AppendText(Indent(indent) + "<td>");
            AppendText(Indent(indent + 4) + "<a asp-page=" + "./ Edit".AddQuotes() + " asp-route-id=" + primarykey.AddQuotes() + ">Edit</a> |");
            AppendText(Indent(indent + 4) + "<a asp-page=" + "./ Details".AddQuotes() + " asp-route-id=" + primarykey.AddQuotes() + ">Details</a> |");
            AppendText(Indent(indent + 4) + "<a asp-page=" + "./ Delete".AddQuotes() + " asp-route-id=" + primarykey.AddQuotes() + ">Delete</a>");
            AppendText(Indent(indent) + "</td>");

        }
    }
}