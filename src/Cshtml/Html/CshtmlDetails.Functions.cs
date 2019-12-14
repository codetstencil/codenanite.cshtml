using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlDetails : ExpansionBase
    {
        private void MainFunction()
        {
            AppendText();
            AppendText(Constants.AspDivStartTag);
            {
                AppendText(Indent(4) + "<h4>" + GetTable(Input) + "</h4>");
                AppendText(Indent(4) + "<hr />");
                DlTagDetails(GetTable(Input));
            }
            AppendText(Constants.AspDivEndTag);

            AppendText(Constants.AspDivStartTag);
            {
                var primaryKey = GetPrimaryKey(Input);
                if (!string.IsNullOrEmpty(primaryKey))
                {
                    AppendText(Indent(4) + "<a asp-action=" + AddQuotes("Edit") + " asp-route-id=" +
                               AddQuotes("@Model." + GetPrimaryKey(Input)) + ">Edit</a>  |");
                    AppendText(Indent(4) + "<a asp-action=" + AddQuotes("Index") + ">Back to List</a>");
                }
            }
            AppendText(Constants.AspDivEndTag);
        }
    }
}