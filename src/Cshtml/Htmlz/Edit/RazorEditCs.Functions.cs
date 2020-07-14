using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorEditCs : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _foreignKeys;
        private string _public = "public ";
        private string _getSet = " { get; set; }";

        private void MainFunction()
        {
            _table = Singularize(Input,PreserveTableName());
            _foreignKeys = GetForeignKeysInTable(_table);

            AppendText();
            BuildSnippet(null);
            var indent = 8;

            BuildSnippet("");
            BuildSnippet("[BindProperty]", indent);
            BuildSnippet(_public + _table + " " + _table + _getSet, indent);
            BuildSnippet("");

            #region OnGetAsync

            BuildSnippet(_public + "async Task<IActionResult> OnGetAsync("+ PrimaryKeyType()+ " id)", indent);
            BuildSnippet("{", indent);
            indent += 4;
            BuildSnippet("if (id == null)", indent);
            BuildSnippet("return NotFound();", indent+4);
            BuildSnippet("");

            if (_foreignKeys.Any())
            {
                var fKeyInclude = string.Empty;
                foreach (var item in _foreignKeys)
                {
                    if (item.TableName == item.RelatedTable) continue;
                    fKeyInclude += ".Include(c =>c." + CreateTablePropertyName(item) + ")";
                }

                BuildSnippet(_table + " = await _context." + _table, indent);
                BuildSnippet(fKeyInclude, indent + 4);
                BuildSnippet(".FirstOrDefaultAsync(m => m." + GetPrimaryKey(_table)+" == id);", indent+4);
            }
            else
            {
                BuildSnippet(_table+" = await _context."+_table+".FirstOrDefaultAsync(m => m."+GetPrimaryKey(_table)+" == id);", indent);
            }

            BuildSnippet("");
            BuildSnippet("if ("+_table+" == null)", indent);
            BuildSnippet("return NotFound();", indent + 4);

            BuildSnippet("");
            if (_foreignKeys.Any())
            {
                foreach (var item in _foreignKeys)
                {
                    BuildSnippet("// Select current " + item.ColumnName + ".", indent);
                    BuildSnippet(
                        "Populate" + CreateTablePropertyName(item) + "Lookup(_context,"+GetTableAndPrimaryKey(_table)+");", indent);
                    //BuildSnippet("return Page();", indent);
                }
            }
            BuildSnippet("return Page();", indent);
            indent -= 4;
            BuildSnippet("}", indent);
            #endregion OnGetAsync


            #region OnPostAsync
            BuildSnippet(
                _foreignKeys.Any()
                    ? "public async Task<IActionResult> OnPostAsync("+ PrimaryKeyType() + " id)"
                    : "public async Task<IActionResult> OnPostAsync()", indent);
            BuildSnippet("{");
            indent += 4;
            BuildSnippet("if (!ModelState.IsValid)", indent);
            BuildSnippet("return Page();", indent + 4);
            BuildSnippet("");
            if (_foreignKeys.Any())
            {
                BuildSnippet("var " + _table.ToLower() + "ToUpdate = await _context." + _table + ".FindAsync(id);", indent);
                BuildSnippet("");
                BuildSnippet("if (await TryUpdateModelAsync<" + _table + ">(", indent);
                BuildSnippet(_table.ToLower() + "ToUpdate,", indent + 5);
                //BuildSnippet(_table.ToLower().AddQuotes() + ",        // Prefix for form value", indent + 5);
                var columns = GetColumnsWithCommas();
                var comma = ",";
                if (columns.IsBlank())
                    comma = string.Empty;
                BuildSnippet(_table.ToLower().AddQuotes() + comma, indent + 5);
                BuildSnippet(columns + "))", indent + 7);

                BuildSnippet("{", indent);
                BuildSnippet("await _context.SaveChangesAsync();", indent + 4);
                BuildSnippet("return RedirectToPage(" + "./Index".AddQuotes() + ");", indent + 4);
                BuildSnippet("}", indent);
                BuildSnippet("", indent);
                foreach (var item in _foreignKeys)
                {
                    BuildSnippet("// Select " + item.ColumnName + " if TryUpdateModeAsync fails.", indent);
                    BuildSnippet(
                        "Populate" + CreateTablePropertyName(item) + "Lookup(_context," + _table.ToLower() + "ToUpdate." + item.ColumnName + ");", indent);
                }
                BuildSnippet("return Page();", indent);

            }
            else
            {
                BuildSnippet("_context.Attach(" + _table + ").State = EntityState.Modified;", indent);
                BuildSnippet("try", indent);
                BuildSnippet("{", indent);
                BuildSnippet("await _context.SaveChangesAsync();", indent+4);
                BuildSnippet("}", indent);
                BuildSnippet("catch (DbUpdateConcurrencyException)", indent);
                BuildSnippet("{", indent);
                BuildSnippet("if (!" + _table + "Exists(" + GetTableAndPrimaryKey(_table) + "))", indent + 4);
                BuildSnippet("return NotFound();", indent + 8);
                BuildSnippet("else", indent + 4);
                BuildSnippet("throw;", indent + 8);
                BuildSnippet("}", indent);
                BuildSnippet("return RedirectToPage(" + "./Index".AddQuotes() + ");", indent);
            }
            indent -= 4;
            BuildSnippet("}", indent);
            #endregion

            if (!_foreignKeys.Any())
            {
                BuildSnippet("private bool " + _table + "Exists("+ PrimaryKeyType()+" id)", indent);
                BuildSnippet("{", indent);
                BuildSnippet("return _context." + _table + ".Any(e => e." + GetPrimaryKey(_table) + " == id);", indent + 4);
                BuildSnippet("}", indent);
            }
            BuildSnippet("", indent);

            AppendText(BuildSnippet(), "");
        }

        private string GetColumnsWithCommas()
        {
            var text = "s => ";
            var columns = GetColumnsExCalculated(_table);
            if (columns.Any())
            {
                text = string.Join(",", columns.Where(p => !p.IsPrimaryKey)
                    .Select(p => "s => s." + p.ColumnName));
            }
            return text;
        }

        private string PrimaryKeyType()
        {
            var primaryKeyType = GetPrimaryKeyType(_table);
            if (primaryKeyType == "int")
                primaryKeyType += "?";
            return primaryKeyType;
        }

    }
}