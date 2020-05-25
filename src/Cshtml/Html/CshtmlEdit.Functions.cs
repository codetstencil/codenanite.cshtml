using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlEdit
    {
        private void MainFunction()
        {
            AppendText();
            AppendText(Constants.AspDivRow);
            AppendText(Indent(4) + Constants.AspDivColMd4);
            AppendText(Indent(8) + Constants.AspActionEdit);

            var x = 0;
            var columns = GetColumns(GetTable(Input, false));
            foreach (var column in columns)
            {
                x++;
                if (x == 1)
                    AppendText(Indent(12) + Constants.AspValidateModelOnly);

                if (column.IsPrimaryKey)
                    AppendText(Indent(12) + "<" + InputType("hidden") + AspFor("", column.ColumnName) + "/>");

                FormGroupDisplay(column);
            }
            Save();
            AppendText(Indent(8) + "</form>");
            AppendText(Indent(4) + Constants.AspDivEndTag);
            AppendText(Constants.AspDivEndTag);
        }
    }
}