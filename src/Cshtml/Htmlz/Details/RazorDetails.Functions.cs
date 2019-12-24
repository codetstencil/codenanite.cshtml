using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorDetails : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _columns;

        private void MainFunction()
        {
            _table = Input.Singularize();
            _columns = GetColumns(_table);

            AppendText();
            //AppendText(CshtmlHeader("Details",_table, GetDefaultNameSpace()));
            var htmlColumns = GetHtmlColumns(_columns);

            AppendText("<div>");
            {
                var indent = 4;
                AppendText(Indent(indent) + _table.HTag(4));
                AppendText(Indent(indent) + "<hr />");
                AppendText(Indent(indent) + GetHtmlString("class","row","dl"));
                {
                    indent += 4;
                    foreach (var item in htmlColumns)
                    {
                        //if (item.IsPrimaryKey) continue;
                        AppendText(Indent(indent), GetHtmlString("class", "col-sm-2", "dt").AddCarriage());
                        AppendText(Indent(indent+4), item.Heading.AddCarriage());
                        AppendText(Indent(indent), "".TagEnd("dt").AddCarriage());
                        AppendText(Indent(indent), GetHtmlString("class", "col-sm-10", "dd").AddCarriage());
                        AppendText(Indent(indent + 4), "@Html.DisplayFor(model => model." + GetRelatedColumnName(item)+")".AddCarriage());
                        AppendText(Indent(indent), "".TagEnd("dd").AddCarriage());
                    }
                }
                AppendText(Indent(4) + "".TagEnd("dl"));

            }
            AppendText("</div>");
            AppendText("<div>");
            {
                var editLink = GetHtmlString("asp-page", "./Edit", "class", "btn btn-primary", "asp-route-id",
                    "@Model." + GetTableAndPrimaryKey(_table));                
                AppendText(Indent(4) + (editLink.Tag("a")+"Edit").TagEnd("a") );
                AppendText(Indent(4) + (GetHtmlString("asp-page","./Index", "class", "btn btn-success").Tag("a")+ "Back to List").TagEnd("a"));
            }
            AppendText("</div>");

        }



    }
}
