using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;

//using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class GenerateLookups
    {
        private string _public = "public ";
        private string _getSet = " { get; set; }";
        private string _table;
        private List<ISchemaItem> _foreignKeys;

        private void MainFunction()
        {
            _table = GetTable(Input.Singularize());
            _foreignKeys = GetForeignKeysInTable(_table);

            AppendText();
            if (!_foreignKeys.Any())
            {
                AppendText(Indent(8)+"// Add your code here if you are creating lookup manually.");
                return;
            }

            AppendText(GetEachLookup(), string.Empty); // This is not to allow line feed
        }

        private string GetEachLookup()
        {
            BuildSnippet(null);
            foreach (var item in _foreignKeys)
            {
                var selectList = item.RelatedTable + "SelectList";
                var key = GetPrimaryKey(item.RelatedTable);
                var lookupDisplay = GetLookupDisplayColumn(_table, item.ColumnName);
                //var selectList = "Select" + item.RelatedTable;
                var query = item.RelatedTable.Pluralize().ToLower()+"Query";
                var selectedTable = "selected" + item.RelatedTable;
                BuildSnippet(_public + "SelectList " + selectList  + _getSet, 8);
                BuildSnippet("");
                BuildSnippet(_public + " void " + "Populate" + item.RelatedTable + "Lookup(" + GetDbContext() +
                             " context, object " + selectedTable + " = null)", 8);
                BuildSnippet("{", 8);

                BuildSnippet("var " + query +" = from q in context."+ item.RelatedTable.Singularize()+" orderby q."+ lookupDisplay + " select q;", 12);
                //BuildSnippet("");
                BuildSnippet(selectList + " = new SelectList(" + query + ".AsNoTracking(), " +
                             key.AddQuotes() + ", " + lookupDisplay.AddQuotes() + ", " +
                             selectedTable+");", 12);
                BuildSnippet("}", 8);
                BuildSnippet("");
            }
            return BuildSnippet();
        }

    }
}