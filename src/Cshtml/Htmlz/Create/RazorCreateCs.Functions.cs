﻿using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorCreateCs : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _foreignKeys;

        private string _public = "public ";
        private string _getSet = " { get; set; }";
        //private string _classname;

        private void MainFunction()
        {
            _table = Input.Singularize();
            _foreignKeys = GetForeignKeysInTable(_table);

            //_classname = "IndexModel";

            AppendText();
            BuildSnippet(null);
            var indent = 8;

            BuildSnippet("[TempData]");
            BuildSnippet("public string Message { get; set; }");

            #region OnGet Method

            BuildSnippet(_public + "IActionResult OnGet()", indent);
            BuildSnippet("{", indent);
            indent += 4;
            if (_foreignKeys.Any())
            {
                foreach (var item in _foreignKeys)
                {
                    BuildSnippet("Populate" + item.RelatedTable + "Lookup(_context);", indent);
                }
            }
            BuildSnippet("return Page();", indent);
            indent -= 4;
            BuildSnippet("}", indent);

            #endregion OnGet Method

            BuildSnippet("");
            BuildSnippet("[BindProperty]", indent);
            BuildSnippet(_public + _table + " " + _table + _getSet, indent);
            BuildSnippet("");

            #region OnPostAsync

            BuildSnippet(_public + "async Task<IActionResult> OnPostAsync()", indent);
            BuildSnippet("{", indent);
            indent += 4;
            BuildSnippet("if (!ModelState.IsValid)", indent);
            BuildSnippet("{", indent);
            BuildSnippet("return Page();", indent+4);
            BuildSnippet("}", indent);
            BuildSnippet("");
            if (_foreignKeys.Any())
            {
                BuildSnippet("var empty" + _table + " = new " + _table + "();", indent);
                BuildSnippet("");
                BuildSnippet("if (await TryUpdateModelAsync<" + _table + ">(", indent);
                BuildSnippet("empty" + _table + ",", indent + 5);
                //BuildSnippet(_table.ToLower().AddQuotes() + ",", indent + 5);

                var columns = GetColumnsWithCommas();
                var comma = ",";
                if (columns.IsBlank())
                    comma = string.Empty;
                BuildSnippet(_table.ToLower().AddQuotes() + comma, indent + 5);
                BuildSnippet(columns + "))", indent + 5);

                BuildSnippet("{", indent);
                indent += 4;
                BuildSnippet("_context." + _table + ".Add(empty" + _table + ");", indent);
                BuildSnippet("await _context.SaveChangesAsync();", indent);
                BuildSnippet("Message = " + (_table+" created successfully.").AddQuotes() + ";");
                BuildSnippet("return RedirectToPage(" + "./Index".AddQuotes() + ");", indent);
                indent -= 4;
                BuildSnippet("}", indent);

                foreach (var item in _foreignKeys)
                {
                    BuildSnippet(
                        "Populate" + item.RelatedTable + "Lookup(_context, empty" + _table + "." + item.ColumnName +
                        ");", indent);
                }
                BuildSnippet("return Page();", indent);
            }
            else
            {
                BuildSnippet("_context." + _table + ".Add(" + _table + ");", indent);
                BuildSnippet("await _context.SaveChangesAsync();", indent);
                BuildSnippet("Message = " + (_table + " created successfully.").AddQuotes() + ";");
                BuildSnippet("return RedirectToPage(" + "./Index".AddQuotes() + ");", indent);
            }
            indent -= 4;
            BuildSnippet("}", indent);

            #endregion OnPostAsync

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
    }
}