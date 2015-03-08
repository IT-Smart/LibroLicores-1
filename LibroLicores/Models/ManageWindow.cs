using System.Windows;
using System.Windows.Controls;
using System;
using WpfPageTransitions;
using LibroLicores.UserControl;


namespace LibroLicores.Models
{
    internal class ManageWindows
    {
        //private Panel _Contenedor;
        private PageTransition _Contenedor;
        private PageTransition _Bloqueador;
        private PageTransition _Bloqueador2;
        /*private UIBarraSuperior _BarUP;
        private UIBarraInferior _BarDow;*/
        Grid _Cont;
        string codsuc;

        public ETipoVentana Tipo { get; set; }

        //-----------------------------
        public ManageWindows(Grid Cont, PageTransition pContenedor, string _codsucursal, PageTransition pBloqueador, PageTransition pBloqueador2)//PageTransition pContenedor, PageTransition pBloqueador, UIBarraSuperior pBarUP, UIBarraInferior pBarDow)
        {
            //_Cont = Cont;
            _Contenedor = pContenedor;
            codsuc = _codsucursal;
            _Bloqueador = pBloqueador;
            _Bloqueador2 = pBloqueador2;
            /*pContenedor.Children.Add(_Contenedor);
            _BarUP = pBarUP;
            _BarDow = pBarDow;*/
        }

        public event EventHandler EvenCerrarVentana;
        public event EventHandler EvenCerrarVentana2;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EvenCerrarVentana != null)
            {
                EvenCerrarVentana(this, new EventArgs());
            }
        }

        public void Iniciar(Login log)
        {
            
            //_Contenedor = new PageTransition();

            //cargar ventana inicial                        


            Contenido_EvenLlamarVentana(null, new LlamadoVentanaEventArgs(log));
        }

        public void Iniciar(UserControl vent)
        {
            Contenido_EvenLlamarVentana(null, new LlamadoVentanaEventArgs(vent));
        }

        public void callHome()
        {
            //Contenido_EvenLlamarVentana(null, new LlamadoVentanaEventArgs(new Home()));
        }

        private void Contenido_EvenLlamarVentana(object sender, LlamadoVentanaEventArgs e)
        {
            ((IVentana)e.PropertyName).EvenLlamarVentana += new LlamadoVentanaEventHandler(Contenido_EvenLlamarVentana);
            CambioContenido((UIElement)e.PropertyName);
        }

        private void CambioContenido(UIElement pContenido)
        {
            //_Cont.Children.Clear();           
            //_Cont.Children.Add(pContenido);

            //tTipo = ((IVentana)pContenido).Tipo;

            //if (EvenCerrarVentana != null)
            //{
            //    EvenCerrarVentana(this, new EventArgs());
            //}
            switch (((IVentana)pContenido).Tipo)
            {
                case ETipoVentana.Login:
                    _Contenedor.TransitionType = PageTransitionType.Fade;
                    _Contenedor.ShowPage((UserControl)pContenido);
                    //_Contenedor.Children.Clear();
                    //_Contenedor.Children.Add(pContenido);
                    break;
                case ETipoVentana.Normales:
                    _Contenedor.TransitionType = PageTransitionType.SlideAndFade;
                    _Contenedor.ShowPage((UserControl)pContenido);
                    //_Contenedor.Children.Clear();
                    //_Contenedor.Children.Add(pContenido);
                    break;
                case ETipoVentana.Principal:
                    _Contenedor.TransitionType = PageTransitionType.SlideAndFade;
                    _Contenedor.ShowPage((UserControl)pContenido);
                    break;
                //case ETipoVentana.Mensaje:
                //    ((IVentana)pContenido).EvenCerrarVentana += (a, b) =>
                //    {
                //        Desbloquear();
                //    };
                //    _Bloqueador.TransitionType = PageTransitionType.Grow;
                //    _Bloqueador.ShowPage((UserControl)pContenido);
                //    break;
                case ETipoVentana.Bloqueadores2:
                    ((IVentana)pContenido).EvenCerrarVentana2 += (a, b) =>
                    {
                        Desbloquear2();
                    };
                    _Bloqueador2.TransitionType = PageTransitionType.Fade;
                    _Bloqueador2.ShowPage((UserControl)pContenido);
                    break;
                default:
                    ((IVentana)pContenido).EvenCerrarVentana += (a, b) =>
                    {
                        Desbloquear();
                    };
                    _Bloqueador.TransitionType = PageTransitionType.Fade;
                    _Bloqueador.ShowPage((UserControl)pContenido);
                    break;
            }
        }

        private void Desbloquear()
        {
            //_Bloqueador.TransitionType = PageTransitionType.Fade;

            _Bloqueador.ErasePage();
        }

        private void Desbloquear2()
        {
            //_Bloqueador.TransitionType = PageTransitionType.Fade;

            _Bloqueador2.ErasePage();
        }
    }
}