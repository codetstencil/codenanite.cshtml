using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorDeleteCs : ExpansionBase
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
            AppendText(Indent(4) + "public class DeleteModel : PageModel");
            AppendText(Indent(4) + "{");
            AppendText(Init(8));
            AppendText(OnGetAsyncMethod(8));
            AppendText(OnPostAsyncMethod(8));
            AppendText(Indent(4) + "}");
        }

        private string Init(int indent = 8)
        {
            BuildSnippet(null);
            BuildSnippet("private readonly " + GetDbContext() + " _context;", indent);
            BuildSnippet("");
            BuildSnippet("public DeleteModel(" + GetDbContext() + " context) => _context = context;", indent);
            BuildSnippet("");
            BuildSnippet("[TempData]");
            BuildSnippet("public string Message { get; set; }");
            BuildSnippet("[BindProperty]", indent);
            BuildSnippet(_public + _table + " " + _table + _getSet, indent);
            return BuildSnippet();
        }

        private string OnGetAsyncMethod(int indent = 8)
        {
            BuildSnippet(null);
            BuildSnippet("public async Task<IActionResult> OnGetAsync(" + PrimaryKeyType() + " id)", indent);
            BuildSnippet("{", indent);
            BuildSnippet("if (id == null)", indent + 4);
            BuildSnippet("return NotFound();", indent + 8);
            BuildSnippet("");
            BuildSnippet(_table + " = await _context." + _table, indent + 4);
            BuildSnippet(".AsNoTracking()" + GetColumnsWithCommas(), indent + 6);
            BuildSnippet(".FirstOrDefaultAsync(m => m." + GetPrimaryKey(_table) + " == id);", indent + 6);
            BuildSnippet("");
            BuildSnippet("if ( " + _table + " == null )", indent + 4);
            BuildSnippet("return NotFound();", indent + 8);
            BuildSnippet("return Page();", indent + 4);
            BuildSnippet("}", indent);
            return BuildSnippet();
        }

        private string OnPostAsyncMethod(int indent = 8)
        {
            BuildSnippet(null);
            BuildSnippet("public async Task<IActionResult> OnPostAsync(" + PrimaryKeyType() + " id)", indent);
            BuildSnippet("{", indent);
            BuildSnippet("if (id == null)", indent + 4);
            BuildSnippet("return NotFound();", indent + 8);
            BuildSnippet("");
            BuildSnippet(_table + " = await _context." + _table, indent + 4);
            BuildSnippet(".AsNoTracking()", indent + 6);
            BuildSnippet(".FirstOrDefaultAsync(m => m." + GetPrimaryKey(_table) + " == id);", indent + 6);
            BuildSnippet("");
            BuildSnippet("if ( " + _table + "!= null )", indent + 4);
            BuildSnippet("{", indent + 4);
            BuildSnippet("_context." + _table + ".Remove(" + _table + ");", indent + 8);
            BuildSnippet("await _context.SaveChangesAsync();", indent + 8);
            BuildSnippet("}", indent + 4);
            BuildSnippet("Message = " + (_table + " deleted succesfully.").AddQuotes() + ";");
            BuildSnippet("return RedirectToPage(" + "./Index".AddQuotes() + ");", indent+4);
            BuildSnippet("}", indent);
            return BuildSnippet();
        }

        private string PrimaryKeyType()
        {
            var primaryKeyType = GetPrimaryKeyType(_table);
            if (primaryKeyType == "int")
                primaryKeyType += "?";
            return primaryKeyType;
        }
        private string GetColumnsWithCommas()
        {
            var text = "";
            var columns = GetForeignKeysInTable(_table);
            if (columns.Any())
            {
                text = string.Join(string.Empty, columns
                    .Where(p => !p.IsPrimaryKey)
                    .Where(s => s.TableName != s.RelatedTable)
                    .Select(p => ".Include(s => s." + CreateTablePropertyName(p) + ")"));
                    //.Select(p => ".Include(s => s." + p.RelatedTable + ")"));
            }
            return text.TrimEnd('\r', '\n');
        }
    }
}
