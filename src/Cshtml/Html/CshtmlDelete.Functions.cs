using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlDelete : ExpansionBase
    {
        //const string DisplayFor = "@Html.DisplayFor(model => model.";
        //const string DisplayNameFor = "@Html.DisplayNameFor(model => model.";
        private void MainFunction()
        {
            AppendText();
            AppendText(Constants.AspDivStartTag);
            {
                AppendText(Indent(4) + "<h4>" + GetTable(Input) + "</h4>");
                AppendText(Indent(4) + "<hr />");
                DlTagDetails(GetTable(Input));

                var primaryKey = GetPrimaryKey(Input);
                if (!string.IsNullOrEmpty(primaryKey))
                {
                    AppendText(Indent(4) + "");
                    AppendText(Indent(4) + "<form asp-action=" + AddQuotes("Delete") + ">");
                    {
                        AppendText(Indent(8) + "<input type=" + AddQuotes("hidden") + " asp-for=" + AddQuotes(GetPrimaryKey(Input)) + " />");
                        AppendText(Indent(8) + "<input type=" + AddQuotes("submit") + " value=" + AddQuotes("Delete") + " class=" + AddQuotes("btn btn-default") + " /> |");
                        AppendText(Indent(8) + "<a asp-action=" + AddQuotes("Index") + ">Back to List</a>");
                    }
                    AppendText(Indent(4) + "</form>");
                }
            }
            AppendText(Constants.AspDivEndTag);
        }
    }
}