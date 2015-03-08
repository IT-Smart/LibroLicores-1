using System;

namespace LibroLicores.Models
{
    public enum ETipoVentana
    {
        Login, Normales, Principal, Bloqueadores, Bloqueadores2
    }

    public delegate void LlamadoVentanaEventHandler(object sender, LlamadoVentanaEventArgs e);

    public class LlamadoVentanaEventArgs : EventArgs
    {
        object _ventana;

        public LlamadoVentanaEventArgs(object pVentana)
        {
            _ventana = pVentana;
        }

        public object PropertyName { get { return _ventana; } }
    }

    public interface IVentana
    {
        event LlamadoVentanaEventHandler EvenLlamarVentana;
        event EventHandler EvenCerrarVentana;
        event EventHandler EvenCerrarVentana2;

        ETipoVentana Tipo { get; }

        void OnLlamarVentana(LlamadoVentanaEventArgs e);
    }
}