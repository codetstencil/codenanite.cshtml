using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlFormGroup
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
                AppendText(Indent(indent) + Constants.AspDivFormGroup);
                AppendText(Indent(indent + 4) + "<label asp-for=" + theColumn.AddQuotes() + " class=" + "control-label".AddQuotes() + "></label>");
                AppendText(Indent(indent + 4) + "<input asp-for=" + theColumn.AddQuotes() + " class=" + "form-control".AddQuotes() + " />");
                AppendText(Indent(indent + 4) + "<span asp-validation-for=" + theColumn.AddQuotes() + " class=" + "text-danger".AddQuotes() + "></span>");
                AppendText(Indent(indent) + Constants.AspDivEndTag);
            }
        }
    }
}