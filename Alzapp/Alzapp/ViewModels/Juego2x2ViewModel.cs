
namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class Juego2x2ViewModel : BaseViewModel
    {

        public int aciertos = 0;
        public int puntuacion = 0;
        public string ganador = null;
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public string Ganador
        {
            get => ganador;
            set => SetValue(ref ganador, value);
        }
        public int Aciertos
        {
            get => aciertos;
            set => SetValue(ref aciertos, value);
        }
        public int Puntuacion
        {
            get => puntuacion;
            set => SetValue(ref puntuacion, value);
        }
        public string boton0;
        public string boton1;
        public string boton2;
        public string boton3;
        public string boton4;


        public string Boton0
        {
            get => boton0;
            set => SetValue(ref boton0, value);
        }
        public string Boton1
        {
            get => boton1;
            set => SetValue(ref boton1, value);
        }
        public string Boton2
        {
            get => boton2;
            set => SetValue(ref boton2, value);
        }
        public string Boton3
        {
            get => boton3;
            set => SetValue(ref boton3, value);
        }



        public bool isEnabled;

        public ICommand ReiniciarCommand => new RelayCommand(Reiniciar);
        public ICommand ComprobarCommand0 => new RelayCommand(ComprobarOnClick0);
        public ICommand ComprobarCommand1 => new RelayCommand(ComprobarOnClick1);
        public ICommand ComprobarCommand2 => new RelayCommand(ComprobarOnClick2);
        public ICommand ComprobarCommand3 => new RelayCommand(ComprobarOnClick3);


        public bool IsEnabled0
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled1
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled2
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled3
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }


        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }

        private string[] imagenes;
        private readonly string[] botonera = new string[4];
        private string fondo;

        public string var0, var1, var2, var3;
        private ArrayList arrayBarajado = new ArrayList();
        private string primero;
        public bool bloqueoTotal;
        private int carta;
        public bool bloqueo0;
        public bool bloqueo1;
        public bool bloqueo2;
        public bool bloqueo3;




        public Juego2x2ViewModel()
        {
            fondo = "FondoJuego";
            CargarImagenes();
            Iniciar();
        }

        public void CargarImagenes()
        {
            imagenes = new string[]
            {
                "animal0",
                "animal1"
            };
            fondo = "FondoJuego";
            return;
        }

        public async void Iniciar()
        {
            BloqueoBotones();
            Aciertos = 0;
            Puntuacion = 0;
            Ganador = null;
            primero = null;
            carta = 4;


            IsEnabled = false;

            arrayBarajado = Barajar(4);
            CargarBotones();

            for (int i = 0; i < 4; i++)
            {
                int num = (int)arrayBarajado[i];
                botonera[i] = imagenes[num];
            }

            MostrarImagenes();
            await Task.Delay(1000);
            OcultarImagen();
            DesbloqueoBotones();
            return;
        }

        public void BloqueoBotones()
        {
            bloqueoTotal = true;
            bloqueo0 = true;
            bloqueo1 = true;
            bloqueo2 = true;
            bloqueo3 = true;

            IsEnabled0 = false;
            IsEnabled1 = false;
            IsEnabled2 = false;
            IsEnabled3 = false;

            return;
        }
        public void DesbloqueoBotones()
        {
            bloqueoTotal = false;
            bloqueo0 = false;
            bloqueo1 = false;
            bloqueo2 = false;
            bloqueo3 = false;

            IsEnabled0 = true;
            IsEnabled1 = true;
            IsEnabled2 = true;
            IsEnabled3 = true;

            return;
        }

        public ArrayList Barajar(int longitud)
        {
            ArrayList resultadoA = new ArrayList();
            for (int i = 0; i < longitud; i++)
            {
                resultadoA.Add(i % longitud / 2);
            }

            var rng = new Random();
            int n = 4;
            while (n > 1)
            {
                int k = rng.Next(n--);
                var temp = resultadoA[n];
                resultadoA[n] = resultadoA[k];
                resultadoA[k] = temp;
            }
            return resultadoA;
        }
        public void CargarBotones()
        {
            var0 = Boton0;
            botonera[0] = var0;
            var1 = Boton1;
            botonera[1] = var1;
            var2 = Boton2;
            botonera[2] = var2;
            var3 = Boton3;
            botonera[3] = var3;

            return;
        }

        public void MostrarImagenes()
        {
            Boton0 = botonera[0];
            Boton1 = botonera[1];
            Boton2 = botonera[2];
            Boton3 = botonera[3];

            return;
        }

        public void OcultarImagen()
        {
            Boton0 = fondo;
            Boton1 = fondo;
            Boton2 = fondo;
            Boton3 = fondo;

            return;
        }

        public async void ComprobarOnClick0()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo0 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton0 = botonera[0];
                IsEnabled0 = false;
                carta = 0;
                bloqueo0 = true;
                primero = botonera[0];
                return;
            }
            if (primero != null)
            {


                Boton0 = botonera[0];
                IsEnabled0 = false;
                bloqueo0 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[0])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 2)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[0])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 4;
                    Boton0 = fondo;
                    IsEnabled0 = true;
                    bloqueo0 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick1()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo1 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton1 = botonera[1];
                IsEnabled1 = false;
                carta = 1;
                bloqueo1 = true;
                primero = botonera[1];
                return;
            }
            if (primero != null)
            {


                Boton1 = botonera[1];
                IsEnabled1 = false;
                bloqueo1 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[1])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 2)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[1])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 4;
                    Boton1 = fondo;
                    IsEnabled1 = true;
                    bloqueo1 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick2()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo2 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton2 = botonera[2];
                IsEnabled2 = false;
                carta = 2;
                bloqueo2 = true;
                primero = botonera[2];
                return;
            }
            if (primero != null)
            {


                Boton2 = botonera[2];
                IsEnabled2 = false;
                bloqueo2 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[2])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 2)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[2])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 4;
                    Boton2 = fondo;
                    IsEnabled2 = true;
                    bloqueo2 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick3()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo3 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton3 = botonera[3];
                IsEnabled3 = false;
                carta = 3;
                bloqueo3 = true;
                primero = botonera[3];
                return;
            }
            if (primero != null)
            {


                Boton3 = botonera[3];
                IsEnabled3 = false;
                bloqueo3 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[3])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 2)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[3])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 4;
                    Boton3 = fondo;
                    IsEnabled3 = true;
                    bloqueo3 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }



        public void BloqueoSegundaCarta()
        {
            bloqueoTotal = true;
            IsEnabled0 = false;
            IsEnabled1 = false;
            IsEnabled2 = false;
            IsEnabled3 = false;

        }
        public void DesloqueoSegundaCarta()
        {
            bloqueoTotal = false;
            if (bloqueo0 == false)
            {
                IsEnabled0 = true;
            }
            if (bloqueo1 == false)
            {
                IsEnabled1 = true;
            }
            if (bloqueo2 == false)
            {
                IsEnabled2 = true;
            }
            if (bloqueo3 == false)
            {
                IsEnabled3 = true;
            }

            return;
        }

        public void Desbloqueo()
        {
            if (carta == 0)
            {
                Boton0 = fondo;
                bloqueo0 = false;
                IsEnabled0 = true;
                return;
            }
            if (carta == 1)
            {
                Boton1 = fondo;
                IsEnabled1 = true;
                bloqueo1 = false;
                return;
            }
            if (carta == 2)
            {
                Boton2 = fondo;
                IsEnabled2 = true;
                bloqueo2 = false;
                return;
            }
            if (carta == 3)
            {
                Boton3 = fondo;
                IsEnabled3 = true;
                bloqueo3 = false;
                return;
            }

            if (carta == 4)
            {
                return;
            }
        }

        public async void Reiniciar()
        {
            IsRefreshing = true;
            CargarImagenes();
            Iniciar();
            IsRefreshing = false;
        }




    }
}

