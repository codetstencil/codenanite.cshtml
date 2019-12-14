using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorCreate : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _columns;

        private void MainFunction()
        {
            _table = Input.Singularize();
            _columns = GetColumns(_table);

            AppendText();
            AppendText(CshtmlHeader("Create",_table, GetDefaultNameSpace()));

            AppendText(_table.HTag(4));
            AppendText("<hr />");
            BuildText("class", "row", "div",0);
            {
                BuildText("class", "col-md-4", "div", 4);
                {
                    BuildText("method", "post", "form", 8);
                    {
                        var avs = GetHtmlString("asp-validation-summary", "ModelOnly", "class", "text-danger");
                        AppendText(Indent(12) + avs.Tag("div").TagEnd("div"));
                        {
                            AppendText(GetFormGroups(_columns, 12));
                        }

                    }BuildText("form", 8);
                }BuildText("div", 4);
            }BuildText("div",0);

            AppendText("<div>");
            AppendText(Indent(4) + GetHtmlString("asp-page","Index","a") +"Back to List".TagEnd("a"));
            AppendText("</div>");
            AppendText("");
            AppendText("@section Scripts {");
            AppendText(Indent(4) + "@{await Html.RenderPartialAsync(" + "_ValidationScriptsPartial".AddQuotes()+"); }");
            AppendText("}");
        }

        private void BuildText(string left, string right, string tag, int indent) => AppendText(Indent(indent) + GetHtmlString( left, right, tag));

        private void BuildText(string tag, int indent) => AppendText(Indent(indent) + "".TagEnd(tag));

        string GetFormGroups(List<ISchemaItem> columns, int indent)
        {
            BuildSnippet(null);
            foreach (var column in columns)
            {
                BuildSnippet(GetHtmlString("class", "form-group", "div"),indent);
                {
                    var columnName = GetColumnName(column);
                    var columnKey = GetColumnKey(column);
                    var control = GetHtmlString("asp-for", columnName, "class", "control-label");
                    var form = GetHtmlString("asp-for", columnKey, "class", "form-control");
                    var span = GetHtmlString("asp-validation-for", columnKey, "class", "text-danger");

                    BuildSnippet(control.Tag("label").TagEnd("label"), indent+4);
                    if (column.IsForeignKey)
                    {
                        GetLookupTag(column, indent + 4);
                    }
                    else
                        BuildSnippet(form.Tag("input","/"), indent + 4);
                    BuildSnippet(span.Tag("span").TagEnd("span"), indent + 4) ;
                }
                BuildSnippet("".TagEnd("div"), indent);
            }
            BuildSnippet(GetHtmlString("class", "form-group", "div"), indent);
            {
                var form = GetHtmlString("type", "submit", "value", "Create") + " "+GetHtmlString("class", "btn btn-primary");
                BuildSnippet(form.Tag("input", "/"), indent + 4);
                BuildSnippet("</div>", indent);
            }
            return BuildSnippet();
        }

        private string GetColumnName(ISchemaItem column)
        {
            var table = _table + ".";
            if (column.IsForeignKey && (column.RelatedTable == column.TableName))
                return table + column.ColumnName + NavigationLabel();
            else if (column.IsForeignKey)
                    return table + column.RelatedTable;
                else
                    return table + column.ColumnName;
        }

        private string GetColumnKey(ISchemaItem column) => _table + "." + column.ColumnName;

        private void GetLookupTag(ISchemaItem column, int indent)
        {
            var selectList = column.RelatedTable + "SelectList";  //refactor this to a method. Similar code in GenerateLookups.Functions()

            var columnKey = GetColumnKey(column);
            var lookup = "<select "+ GetHtmlString("asp-for", column.TableName + "." + column.ColumnName, "class", "form-control",
                "asp-items",
                "@Model." + selectList)+">";
            var option = ("value=" + "".AddQuotes() + ">-- Select "+ column.RelatedTable + " --").Tag("option").TagEnd("option");
            var span = GetHtmlString("asp-validation-for", columnKey, "class", "text-danger").Tag("span").TagEnd("span");
            BuildSnippet(lookup, indent);
            BuildSnippet(option, indent+4);
            BuildSnippet("</select>", indent);
        }
    }
}
