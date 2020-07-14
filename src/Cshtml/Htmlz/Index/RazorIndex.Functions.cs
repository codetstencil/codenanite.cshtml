using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIndex : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _columns;
        private List<ISchemaItem> _sortColumns;
        private ISchemaItem _searchColumn;
        private List<ISchemaItem> _searchColumns;

        private void MainFunction()
        {
            _table = Singularize(Input,PreserveTableName());
            _columns = GetColumns(_table);
            _sortColumns = GetSortColumns(_table);
            _searchColumns = GetSearchColumns(_table);
            _searchColumn = _searchColumns.FirstOrDefault();


            AppendText();
            var htmlColumns = GetHtmlColumns(_columns);
            AppendText(Message());
            AppendText(SearchBox());
            AppendText("<table class=" + AddQuotes("table") + ">");
            {
                AppendText(Indent(4) + "<thead>");
                AppendText(Indent(8) + "<tr>");
                    foreach (var item in htmlColumns)
                    {
                        var sortHeader = string.Empty;
                        //if (item.IsPrimaryKey) continue;
                        if (_sortColumns.Any() && item.AllowSort )
                        {
                            sortHeader = Indent(16)+
                                GetHtmlString("asp-page", "./Index", "asp-route-sortOrder",
                                "@Model." + GetSortName(item.ColumnName), "asp-route-currentFilter",
                                "@Model.CurrentFilter").Tag("a").AddCarriage();
                        }
                    AppendText( item.Heading.AddTagWithCr("th",sortHeader,12) );
                    }
                AppendText(Indent(8) + "</tr>");
                AppendText(Indent(4) + "</thead>");

                AppendText(Indent(4) + "<tbody>");
                {
                    AppendText(Indent(8) + "@foreach (var item in Model."+_table+")");
                    AppendText(Indent(8) + "{");
                    AppendText(Indent(12) + "<tr>");
                    foreach (var item in htmlColumns)
                    {
                        //if (item.IsPrimaryKey) continue;
                        AppendText(item.FieldString.AddTagWithCr("td", "", 16));
                    }

                    var primaryKey = GetPrimaryKey(_table);
                    if (!primaryKey.IsBlank())
                    {
                        BuildSnippet("<td>", 16);
                        BuildSnippet(CreateLink("Edit", primaryKey), 20);
                        BuildSnippet(CreateLink("Details", primaryKey), 20);
                        BuildSnippet(CreateLink("Delete", primaryKey), 20);

                        BuildSnippet("</td>", 16);
                        AppendText(BuildSnippet());
                    }

                    AppendText(Indent(12) + "</tr>");
                    AppendText(Indent(8) + "}");
                }
                AppendText(Indent(4) + "</tbody>");
            }
            AppendText("</table>");
        }

        const string BS_BUTTON_EDIT = "btn btn-outline-primary btn-sm";
        const string BS_BUTTON_DETAILS = "btn btn-outline-info btn-sm";
        const string BS_BUTTON_DELETE = "btn btn-outline-danger btn-sm";
        private string CreateLink(string action, string primarykey)
        {
            var button = BS_BUTTON_EDIT;
            if (action == "Details")
                button = BS_BUTTON_DETAILS;
            else if (action == "Delete")
                button = BS_BUTTON_DELETE;

            var link = GetHtmlString("asp-page", "./" + action, "asp-route-id", "@item." + primarykey, "class", button).Tag("a");
            link += action.TagEnd("a");
            return link;
        }


        string Message()
        {
            BuildSnippet(null);
            BuildSnippet("@if(Model.Message != null)",0);
            BuildSnippet("{",0);
            BuildSnippet(GetHtmlString("class","alert alert-info alert-dismissable", "role","alert").Tag("div"), 4);
            BuildSnippet(GetHtmlString("type", "button", "class", "close", "data-dismiss", "alert", "aria-label", "close").Tag("button"),8 );
            BuildSnippet(GetHtmlString("aria-hidden", "true").Tag("span") + "&times;".TagEnd("span"), 12);
            BuildSnippet("</button>", 8);
            BuildSnippet("@Model.Message",8);
            BuildSnippet("</div>",4);
            BuildSnippet("}",0);
            return (BuildSnippet());
        }

        string SearchBox()
        {
            if (_searchColumns.Any())
            {
                var inputType = "text";

                switch (_searchColumn.ColumnType)
                {
                    case "DateTime":
                        inputType = "datetime-local";
                        break;
                    case "int":
                        inputType = "number";
                        break;
                }
                BuildSnippet(null);
                BuildSnippet(GetHtmlString("asp-page", "./Index", "method", "get").Tag("form"), 0);
                BuildSnippet(GetHtmlString("class", "form-actions no color").Tag("div"), 4);
                BuildSnippet("<p>", 8);
                BuildSnippet("Find by "+ _searchColumn.ColumnLabel+" : ", 12);
                BuildSnippet(
                    GetHtmlString("type", inputType, "name", "SearchString", "value", "@Model.CurrentFilter")
                        .Tag("input", "/"), 16);
                BuildSnippet(
                    GetHtmlString("type", "submit", "value", "Search", "class", "btn btn-default")
                        .Tag("input", "/")+" |", 16);
                BuildSnippet(GetHtmlString("asp-page", "./Index").Tag("a")+"Back to full List".TagEnd("a"), 16);
                BuildSnippet("<p>", 8);
                BuildSnippet("".TagEnd("div"), 4);
                BuildSnippet("".TagEnd("form"), 0);
            }

            return BuildSnippet();
        }

        string GetName(string column)
        {
            var result = column;
            if (column.Length > 15)
                result = column.Substring(0, 15);
            return result;
        }

        string GetSortName(string column)
        {
            return GetName(column) + "Sort";
        }


    }
}
