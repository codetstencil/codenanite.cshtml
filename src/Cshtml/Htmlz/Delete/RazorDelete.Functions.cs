using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorDelete : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _columns;

        private void MainFunction()
        {
            _table = Input.Singularize();
            _columns = GetColumns(_table);

            AppendText();
            //AppendText(CshtmlHeader("Delete",_table, GetDefaultNameSpace()));
            var htmlColumns = GetHtmlColumns(_columns);

            //AppendText("Are you sure you want to delete this?".HTag(3));
            AppendText("<div>");
            {
                var indent = 4;
                AppendText(Indent(indent) + _table.HTag(4));
                AppendText(Indent(indent) + "<hr />");
                AppendText(Indent(indent) + GetHtmlString("class", "row", "dl"));
                {
                    indent += 4;
                    foreach (var item in htmlColumns)
                    {
                        //if (item.IsPrimaryKey) continue;
                        AppendText(Indent(indent), GetHtmlString("class", "col-sm-2", "dt").AddCarriage());
                        AppendText(Indent(indent + 4), item.Heading.AddCarriage());
                        AppendText(Indent(indent), "".TagEnd("dt").AddCarriage());
                        AppendText(Indent(indent), GetHtmlString("class", "col-sm-10", "dd").AddCarriage());
                        AppendText(Indent(indent + 4), "@Html.DisplayFor(model => model." + GetRelatedColumnName(item) + ")".AddCarriage());
                        //AppendText(Indent(indent + 4), "@Html.DisplayFor(model => model." + GetRelatedColumnName(item) + ")".AddCarriage());
                        AppendText(Indent(indent), "".TagEnd("dd").AddCarriage());
                    }
                }
                AppendText(Indent(4) + "".TagEnd("dl"));
                //--------
                AppendText(Indent(4) + GetHtmlString("method", "post", "form"));
                AppendText(Indent(8) + GetHtmlString("type", "hidden", "asp-for", GetTableAndPrimaryKey(_table)).Tag("input"));
                AppendText(Indent(8) + GetHtmlString("type", "submit", "value", "Delete","class", "btn btn-danger").Tag("input","/"));
                AppendText(Indent(4) + (GetHtmlString("asp-page", "./Index", "class", "btn btn-success").Tag("a") + "Back to List").TagEnd("a"));
                AppendText(Indent(4) + "".TagEnd("form"));
                //--------
            }
            AppendText("</div>");
            AppendText("<div>");
            //AppendText(Indent(4) + (GetHtmlString("asp-page", "./Index", "a") + "Back to List").TagEnd("a"));
            AppendText("</div>");
        }

    }
}
