using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlController : ExpansionBase
    {
        private void MainFunction()
        {
            var columns = GetColumns(GetTable(Input));
            AppendText();
            AppendText("<table class=" + AddQuotes("table") + ">");
            {
                AppendText(Indent(4) + "<thead>");
                {
                    AppendText(Indent(8) + "<tr>");
                    //GetThTags(columns);
                    AppendText(Indent(8) + "</tr>");
                }
                AppendText(Indent(4) + "</thead>");
            }
            AppendText("</table>");
        }
    }
}