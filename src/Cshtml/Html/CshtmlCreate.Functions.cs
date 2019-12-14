//using ZeraSystems.CodeNanite.Html;
using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlCreate
    {
        private void MainFunction()
        {
            AppendText();
            AppendText(Constants.AspDivRow);
            AppendText(Indent(4) + Constants.AspDivColMd4);
            AppendText(Indent(8) + Constants.AspActionCreate);

            var x = 0;
            //var columns = GetColumns(GetTable(Input));
            var columns = GetColumns(Input);
            foreach (var column in columns)
            {
                x++;
                if (x == 1)
                    AppendText(Indent(12) + Constants.AspValidateModelOnly);
                FormGroup(column);
            }
            Submit();
            AppendText(Indent(8) + "</form>");
            AppendText(Indent(4) + Constants.AspDivEndTag);
            AppendText(Constants.AspDivEndTag);
            //SetValidation();
        }

        //private void SetValidation()
        //{
        //}
    }
}