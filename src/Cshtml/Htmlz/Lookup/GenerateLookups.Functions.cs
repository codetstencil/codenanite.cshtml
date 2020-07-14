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
        private List<ISchemaItem> _selfJoinColumns;

        private void MainFunction()
        {
            _table = GetTable( Singularize(Input,PreserveTableName()), false);
            _foreignKeys = GetForeignKeysInTable(_table);
                //.Where(t=>t.OriginalName==t.LookupColumn).ToList();
            _selfJoinColumns = GetSelfJoinColumns(_table);

            //_foreignKeys = GetNavProperties(_table);

            AppendText();
            //if (!_foreignKeys.Any())
            //{
            //    AppendText(Indent(8)+"// Add your code here if you are creating lookup manually.");
            //    return;
            //}
            AppendText(GetEachLookup(), string.Empty); // This is not to allow line feed
        }

        private string GetEachLookup()
        {
            BuildSnippet(null);
            if (_foreignKeys.Any())
                foreach (var item in _foreignKeys)
                    CreateLookup(item);
            else if (_selfJoinColumns.Any())
                foreach (var item in _selfJoinColumns)
                    CreateLookup(item);
            else
            {
                AppendText(Indent(8) + "// Add your code here if you are creating lookup manually.");
            }

            return BuildSnippet();


            void CreateLookup(ISchemaItem item)
            {
                var selectList = item.RelatedTable + "SelectList";
                var key = GetPrimaryKey(item.RelatedTable);
                var lookupDisplay = GetLookupDisplayColumn(_table, item.ColumnName);
                //var selectList = "Select" + item.RelatedTable;
                var query = Pluralize(item.RelatedTable,PreserveTableName()).ToLower() + "Query";
                var selectedTable = "selected" + item.RelatedTable;
                BuildSnippet(_public + "SelectList " + selectList + _getSet, 8);
                BuildSnippet("");
                BuildSnippet(_public + " void " + "Populate" + CreateTablePropertyName(item) + "Lookup(" + GetDbContext() +
                             " context, object " + selectedTable + " = null)", 8);
                BuildSnippet("{", 8);

                BuildSnippet(
                    "var " + query + " = from q in context." + Singularize(item.RelatedTable,PreserveTableName()) + " orderby q." + lookupDisplay +
                    " select q;", 12);
                //BuildSnippet("");
                BuildSnippet(selectList + " = new SelectList(" + query + ".AsNoTracking(), " +
                             key.AddQuotes() + ", " + lookupDisplay.AddQuotes() + ", " +
                             selectedTable + ");", 12);
                BuildSnippet("}", 8);
                BuildSnippet("");
            }
        }



    }
}