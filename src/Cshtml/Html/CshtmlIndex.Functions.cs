using System.Collections.Generic;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlIndex : ExpansionBase
    {
        private List<ISchemaItem> _columns;

        private void MainFunction()
        {
            _columns = GetColumns(Singularize(Input,PreserveTableName()));

            AppendText();
            AppendText("<table class=" + AddQuotes("table") + ">");
            {
                AppendText(Indent(4) + "<thead>");
                {
                    AppendText(Indent(8) + "<tr>");
                    GetThTags(_columns);
                    AppendText(Indent(8) + "</tr>");
                }
                AppendText(Indent(4) + "</thead>");
                AppendText(Indent(4) + "<tbody>");
                {
                    AppendText(Indent(8) + "@foreach (var item in Model)");
                    AppendText(Indent(8) + "{");
                    AppendText(Indent(12) + "<tr>");
                    GetTdTags(_columns);
                    AppendText(Indent(12) + "</tr>");
                    AppendText(Indent(8) + "}");
                }
                AppendText(Indent(4) + "</tbody>");
            }
            AppendText("</table>");
        }

        private void GetTdTags(List<ISchemaItem> columns)
        {
            var primaryKey = string.Empty;
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey)
                    primaryKey = column.ColumnName;

                AppendText(Indent(16) + "<td>");
                AppendText(Indent(20) + DisplayForModelItem(column));
                AppendText(Indent(16) + "</td>");
            }

            if (!string.IsNullOrEmpty(primaryKey))
            {
                AppendText(Indent(16) + "<td>");
                AppendText(Indent(20) + "<a asp-action=" + AddQuotes("Edit") + " asp-route-id=" + AddQuotes("@item." + primaryKey) + ">Edit</a> |");
                AppendText(Indent(20) + "<a asp-action=" + AddQuotes("Details") + " asp-route-id=" + AddQuotes("@item." + primaryKey) + ">Details</a> |");
                AppendText(Indent(20) + "<a asp-action=" + AddQuotes("Delete") + " asp-route-id=" + AddQuotes("@item." + primaryKey) + ">Delete</a> |");
                AppendText(Indent(16) + "</td>");
            }
        }

        private void GetThTags(List<ISchemaItem> columns)
        {
            foreach (var column in columns)
            {
                AppendText(Indent(12) + "<th>");

                if (column.IsForeignKey)
                    AppendText(Indent(16) + DisplayNameFor(column.RelatedTable, 0, null, null));
                else
                    AppendText(Indent(16) + DisplayNameFor(column.ColumnName, 0, null, null));
                AppendText(Indent(12) + "</th>");
            }
        }
    }
}