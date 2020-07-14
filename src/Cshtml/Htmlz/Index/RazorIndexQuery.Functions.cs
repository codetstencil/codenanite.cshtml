using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIndexQuery : ExpansionBase
    {
        private string _table;

        private void MainFunction()
        {
            BuildSnippet(null);
            _table = Singularize(Input,PreserveTableName());

            //var relatedTables = GetRelatedTables(_table);
            var relatedTables = SchemaItem
                .Where(e => (e.RelatedTable != null && 
                             (Singularize(e.TableName,PreserveTableName()) == Singularize(_table,PreserveTableName())) &&
                             (e.RelatedTable != _table) && 
                             (e.IsPrimaryKey != e.IsForeignKey)));

                //.Where(e => e.TableName.Singularize() == _table.Singularize())
                //.Where(e => e.RelatedTable != _table);

            var pageSize = GetExpansionString("PAGESIZE");
            if (pageSize.IsBlank())
                pageSize = "5";

            BuildSnippet("const int pageSize = " + pageSize+ ";",12);

            BuildSnippet(_table + " = await PaginatedList<" + _table + ">.CreateAsync(" + 
                         Pluralize(_table,PreserveTableName()).ToLower() ,12);
            BuildSnippet(".AsNoTracking()", 15);
            if (relatedTables.Any())
                foreach (var item in relatedTables)
                    BuildSnippet(".Include(c => c." + item.RelatedTable + ")", 15);
            BuildSnippet(", pageIndex ?? 1, pageSize);", 15);
            AppendText();
            AppendText(BuildSnippet());
        }
    }
}
