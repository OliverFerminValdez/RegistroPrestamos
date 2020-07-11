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
        public async static Task<bool> Confirmar2(this IJSRuntime js, string titulo, string Mensaje, string tipo)
        {
            return await js.InvokeAsync<bool>("PrestamoConfirm", titulo, Mensaje, tipo);
        }
        public async static Task<bool>ConfirmDelete(this IJSRuntime js)
        {
            return await js.InvokeAsync<bool>("ConfirmDelete");
        }
        public async static Task Notify(this IJSRuntime js)
        {
              await js.InvokeVoidAsync("NotificarBienvenido");
        }
        public async static Task NotifyDelete(this IJSRuntime js)
        {
            await js.InvokeVoidAsync("NotificarEliminar");
        }
        public async static Task NotifySave(this IJSRuntime js)
        {
            await js.InvokeVoidAsync("NotificarGuardado");
        }
    }
}
