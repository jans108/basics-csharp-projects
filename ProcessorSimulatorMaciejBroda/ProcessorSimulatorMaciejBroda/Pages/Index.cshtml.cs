using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class IndexModel : PageModel
{
    [BindProperty]
    [RegularExpression("^[0-9A-Fa-f]{1,4}$", ErrorMessage = "AX musi byæ liczb¹ szesnastkow¹ o maksymalnie 4 znakach.")]
    public string? AX { get; set; }

    [BindProperty]
    [RegularExpression("^[0-9A-Fa-f]{1,4}$", ErrorMessage = "BX musi byæ liczb¹ szesnastkow¹ o maksymalnie 4 znakach.")]
    public string? BX { get; set; }

    [BindProperty]
    [RegularExpression("^[0-9A-Fa-f]{1,4}$", ErrorMessage = "CX musi byæ liczb¹ szesnastkow¹ o maksymalnie 4 znakach.")]
    public string? CX { get; set; }

    [BindProperty]
    [RegularExpression("^[0-9A-Fa-f]{1,4}$", ErrorMessage = "DX musi byæ liczb¹ szesnastkow¹ o maksymalnie 4 znakach.")]
    public string? DX { get; set; }

    [BindProperty]
    public string Operation { get; set; } = "MOV";

    [BindProperty]
    public string? Source { get; set; }

    [BindProperty]
    public string? Destination { get; set; }

    public IActionResult OnPost()
    {
        // Resetowanie rejestrów
        if (Request.Form["reset"] == "true")
        {
            AX = null;
            BX = null;
            CX = null;
            DX = null;

            return Page();
        }

        // Walidacja modelu
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Wykonanie operacji
        if (Operation == "MOV")
        {
            PerformMOV();
        }
        else if (Operation == "XCHG")
        {
            PerformXCHG();
        }

        return Page();
    }

    private void PerformMOV()
    {
        // Pobierz wartoœæ z rejestru Ÿród³owego
        string? sourceValue = GetRegisterValue(Source);

        // Zaktualizuj tylko cel
        if (sourceValue != null)
        {
            SetRegisterValue(Destination, sourceValue);
        }
    }

    private void PerformXCHG()
    {
        // Pobierz wartoœci z obu rejestrów
        string? value1 = GetRegisterValue(Source);
        string? value2 = GetRegisterValue(Destination);

        // Wymieñ wartoœci
        if (value1 != null && value2 != null)
        {
            SetRegisterValue(Source, value2);
            SetRegisterValue(Destination, value1);
        }
    }

    private string? GetRegisterValue(string? registerName)
    {
        return registerName switch
        {
            "AX" => AX,
            "BX" => BX,
            "CX" => CX,
            "DX" => DX,
            _ => null
        };
    }

    private void SetRegisterValue(string? registerName, string? value)
    {
        if (!IsValidRegister(value))
        {
            return;
        }

        switch (registerName)
        {
            case "AX": AX = value; break;
            case "BX": BX = value; break;
            case "CX": CX = value; break;
            case "DX": DX = value; break;
        }
    }

    private bool IsValidRegister(string? registerValue)
    {
        return registerValue != null && Regex.IsMatch(registerValue, "^[0-9A-Fa-f]{1,4}$");
    }
}
