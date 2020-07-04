using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
    
namespace RegistrosPrestamos.Pages.Modals
{
    public static class Confirm
    {
        public async static Task<bool> Confirmar(this IJSRuntime js, string titulo, string Mensaje, string tipo)
        {
            return await js.InvokeAsync<bool>("PrestamoConfirm", titulo, Mensaje, tipo);
        }
    }
}
