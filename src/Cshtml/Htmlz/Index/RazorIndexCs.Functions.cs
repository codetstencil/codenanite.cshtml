using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIndexCs : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _sortColumns;
        private string _public = "public ";
        private string _getSet = " { get; set; }";
        private string _classname;
        private string tableIq;
        public bool CanSort { get; set; }
        public bool HasRelatedTables { get; set; }

        private void MainFunction()
        {
            _table = Input.Singularize();
            _sortColumns = GetSortColumns(_table);
            var relatedTables = SchemaItem
                .Where(e => (e.RelatedTable != null &&
                             (e.TableName.Singularize() == _table.Singularize()) &&
                             (e.RelatedTable != _table) &&
                             (e.IsPrimaryKey != e.IsForeignKey)));

            _classname = "IndexModel";

            CanSort = _sortColumns.Any();
            HasRelatedTables = relatedTables.Any();
            tableIq = _table.ToLower() + "Iq";

            AppendText();
            BuildSnippet(null);

            BuildSnippet("namespace " + GetDefaultNameSpace() + ".Pages." + _table.Pluralize(), 0);
            BuildSnippet("{", 0);
            var indent = 4;
            BuildSnippet(_public + "class " + _classname + " : PageModel", indent);
            BuildSnippet("{", indent);
            indent += 4;
            BuildSnippet("private readonly " + GetDbContext() + " _context;", indent);
            BuildSnippet("");

            BuildSnippet("[TempData]");
            BuildSnippet("public string Message { get; set; }");
            BuildSnippet("");

            BuildSnippet(_public + _classname + "(" + GetDbContext() + " context) => _context = context;", indent);
            BuildSnippet("");
            BuildSnippet(_public + "string CurrentFilter" + _getSet, indent);
            BuildSnippet(_public + "string CurrentSort" + _getSet, indent);
            if (CanSort)
            {
                foreach (var column in _sortColumns)
                    BuildSnippet(_public + "string " + GetSortName(column.ColumnName) + _getSet, indent);

                //BuildSnippet("IQueryable<"+_table+"> studentIQ = from s in _context.Student")
            }

            BuildSnippet(_public + "PaginatedList<" + _table + "> " + _table + _getSet, indent);
            BuildSnippet("");
            OnGetAsyncMethod(indent, relatedTables);
            BuildSnippet("}", indent - 4);
            BuildSnippet("}", 0);

            AppendText(BuildSnippet(), "");
        }

        private void OnGetAsyncMethod(int indent, IEnumerable<ISchemaItem> relatedTables)
        {
            BuildSnippet(
                _public + "async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)",
                indent);
            BuildSnippet("{", indent);
            if (CanSort)
                OnGetAsyncWithSort(relatedTables, indent);
            else
                OnGetAsyncWithoutSort(relatedTables, indent);

            BuildSnippet("}", indent);
        }

        private void SetSearchOptions(int indent)
        {
            //BuildSnippet("IQueryable <" + _table + "> " + tableIq + " = from s in _context." + _table + " select s;", indent);
            BuildSnippet("var " + tableIq + " = from s in _context." + _table + " select s;", indent);

            var searchColumn = GetSearchColumns(_table).Select(c => c.ColumnName).FirstOrDefault();
            if (!searchColumn.IsBlank())
            {
                BuildSnippet("CurrentFilter = searchString;", indent);
                BuildSnippet("if (!String.IsNullOrEmpty(searchString))", indent);
                BuildSnippet("{", indent);
                BuildSnippet(tableIq + " = " + tableIq + ".Where(s=>s." + searchColumn + ".Contains(searchString));",
                    indent + 4);
                BuildSnippet("}", indent);
                BuildSnippet("", indent);
            }
        }

        private void OnGetAsyncWithoutSort(IEnumerable<ISchemaItem> relatedTables, int indent)
        {
            //BuildSnippet("var " + _table.Pluralize().ToLower() + " = from s in _context." + _table + " select s;", 12);
            SetSearchOptions(indent + 4);
            Paging(relatedTables, indent);
        }

        private void OnGetAsyncWithSort(IEnumerable<ISchemaItem> relatedTables, int indent)
        {
            indent += 4;
            BuildSnippet("CurrentSort = sortOrder;", indent);
            foreach (var item in _sortColumns)
            {
                var name = GetName(item.ColumnName).ToLower();
                var nameAsc = (name + "_asc").AddQuotes();
                var nameDesc = (name + "_desc").AddQuotes();
                BuildSnippet(
                    GetSortName(item.ColumnName) + " = sortOrder == " + nameAsc + " ? " + nameDesc + " : " + nameAsc + ";", indent);
            }
            //Search string condition
            BuildSnippet("");
            SetSearchOptions(indent);
            BuildSnippet("");

            BuildSnippet("switch (sortOrder)", indent);
            BuildSnippet("{", indent);
            foreach (var item in _sortColumns)
            {
                var name = GetName(item.ColumnName).ToLower();
                //Order By Ascending
                BuildSnippet("case " + (name + "_asc").AddQuotes() + ":", indent + 4);
                BuildSnippet(tableIq + " = " + tableIq + ".OrderBy(s => s." + item.ColumnName + ");", indent + 8);
                BuildSnippet("break;", indent + 8);

                //Order By Descending
                BuildSnippet("case " + (name + "_desc").AddQuotes() + ":", indent + 4);
                BuildSnippet(tableIq + " = " + tableIq + ".OrderByDescending(s => s." + item.ColumnName + ");", indent + 8);
                BuildSnippet("break;", indent + 8);
            }
            BuildSnippet("}", indent);
            indent -= 4;
            Paging(relatedTables, indent);
        }

        private void Paging(IEnumerable<ISchemaItem> relatedTables, int indent)
        {
            var pageSize = GetExpansionString("PAGESIZE");
            if (pageSize.IsBlank()) pageSize = "5";
            BuildSnippet("const int pageSize = " + pageSize + ";", 12);
            BuildSnippet(_table + " = await PaginatedList<" + _table + ">.CreateAsync(" + tableIq, 12);
            BuildSnippet(".AsNoTracking()", 15);
            if (HasRelatedTables)
                foreach (var item in relatedTables)
                    BuildSnippet(".Include(c => c." + item.RelatedTable + ")", 15);
            BuildSnippet(", pageIndex ?? 1, pageSize);", 15);
        }

        private string GetName(string column)
        {
            var result = column;
            if (column.Length > 15)
                result = column.Substring(0, 15);
            return result;
        }

        private string GetSortName(string column)
        {
            return GetName(column) + "Sort";
        }
    }
}