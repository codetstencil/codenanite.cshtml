using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorDetailsCs : ExpansionBase
    {
        private string _table;
        private string _public = "public ";
        private string _getSet = " { get; set; }";

        private void MainFunction()
        {
            _table = Singularize(Input,PreserveTableName());
            AppendText();
            AppendText(Indent(4) + "public class DetailsModel : PageModel");
            AppendText(Indent(4) + "{");
            AppendText(Init(8));
            AppendText(OnGetAsyncMethod(8));
            AppendText(Indent(4) + "}");
        }

        private string Init(int indent = 8)
        {
            BuildSnippet(null);
            BuildSnippet("private readonly " + GetDbContext() + " _context;", indent);
            BuildSnippet("");
            BuildSnippet("public DetailsModel(" + GetDbContext() + " context) => _context = context;", indent);
            BuildSnippet("");
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
            BuildSnippet(".AsNoTracking()", indent + 6);
            BuildSnippet(".FirstOrDefaultAsync(m => m." + GetPrimaryKey(_table) + " == id);", indent + 6);
            BuildSnippet("");
            BuildSnippet("if ( " + _table + " == null )", indent + 4);
            BuildSnippet("return NotFound();", indent + 8);
            BuildSnippet("return Page();", indent + 4);
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
    }
}