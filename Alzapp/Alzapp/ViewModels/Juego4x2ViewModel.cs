

namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class Juego4x2ViewModel : BaseViewModel
    {

        public int aciertos = 0;
        public int puntuacion = 0;
        public string ganador = null;

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
        public string boton5;
        public string boton6;
        public string boton7;



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
        public string Boton4
        {
            get => boton4;
            set => SetValue(ref boton4, value);
        }
        public string Boton5
        {
            get => boton5;
            set => SetValue(ref boton5, value);
        }
        public string Boton6
        {
            get => boton6;
            set => SetValue(ref boton6, value);
        }
        public string Boton7
        {
            get => boton7;
            set => SetValue(ref boton7, value);
        }




        public bool isEnabled;

        public ICommand ReiniciarCommand => new RelayCommand(Reiniciar);
        public ICommand ComprobarCommand0 => new RelayCommand(ComprobarOnClick0);
        public ICommand ComprobarCommand1 => new RelayCommand(ComprobarOnClick1);
        public ICommand ComprobarCommand2 => new RelayCommand(ComprobarOnClick2);
        public ICommand ComprobarCommand3 => new RelayCommand(ComprobarOnClick3);
        public ICommand ComprobarCommand4 => new RelayCommand(ComprobarOnClick4);
        public ICommand ComprobarCommand5 => new RelayCommand(ComprobarOnClick5);
        public ICommand ComprobarCommand6 => new RelayCommand(ComprobarOnClick6);
        public ICommand ComprobarCommand7 => new RelayCommand(ComprobarOnClick7);



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
        public bool IsEnabled4
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled5
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled6
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled7
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
        private readonly string[] botonera = new string[8];
        private string fondo;

        public string var0, var1, var2, var3, var4, var5, var6, var7;
        private ArrayList arrayBarajado = new ArrayList();
        private string primero;
        public bool bloqueoTotal;
        private int carta;
        public bool bloqueo0;
        public bool bloqueo1;
        public bool bloqueo2;
        public bool bloqueo3;
        public bool bloqueo4;
        public bool bloqueo5;
        public bool bloqueo6;
        public bool bloqueo7;

        public Juego4x2ViewModel()
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
                "animal1",
                "animal2",
                "animal3",
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
            carta = 8;


            IsEnabled = false;

            arrayBarajado = Barajar(8);
            CargarBotones();

            for (int i = 0; i < 8; i++)
            {
                int num = (int)arrayBarajado[i];
                botonera[i] = imagenes[num];
            }

            MostrarImagenes();
            await Task.Delay(2500);
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
            bloqueo4 = true;
            bloqueo5 = true;
            bloqueo5 = true;
            bloqueo7 = true;

            IsEnabled0 = false;
            IsEnabled1 = false;
            IsEnabled2 = false;
            IsEnabled3 = false;
            IsEnabled4 = false;
            IsEnabled5 = false;
            IsEnabled6 = false;
            IsEnabled7 = false;

            return;
        }
        public void DesbloqueoBotones()
        {
            bloqueoTotal = false;
            bloqueo0 = false;
            bloqueo1 = false;
            bloqueo2 = false;
            bloqueo3 = false;
            bloqueo4 = false;
            bloqueo5 = false;
            bloqueo6 = false;
            bloqueo7 = false;

            IsEnabled0 = true;
            IsEnabled1 = true;
            IsEnabled2 = true;
            IsEnabled3 = true;
            IsEnabled4 = true;
            IsEnabled5 = true;
            IsEnabled6 = true;
            IsEnabled7 = true;

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
            int n = 8;
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
            var4 = Boton4;
            botonera[4] = var4;
            var5 = Boton5;
            botonera[5] = var5;
            var6 = Boton6;
            botonera[6] = var6;
            var7 = Boton7;
            botonera[7] = var7;

            return;
        }

        public void MostrarImagenes()
        {
            Boton0 = botonera[0];
            Boton1 = botonera[1];
            Boton2 = botonera[2];
            Boton3 = botonera[3];
            Boton4 = botonera[4];
            Boton5 = botonera[5];
            Boton6 = botonera[6];
            Boton7 = botonera[7];

            return;
        }

        public void OcultarImagen()
        {
            Boton0 = fondo;
            Boton1 = fondo;
            Boton2 = fondo;
            Boton3 = fondo;
            Boton4 = fondo;
            Boton5 = fondo;
            Boton6 = fondo;
            Boton7 = fondo;

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
                    if (Aciertos == 4)
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
                    carta = 8;
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
                    if (Aciertos == 4)
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
                    carta = 8;
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
                    if (Aciertos == 4)
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
                    carta = 8;
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
                    if (Aciertos == 4)
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
                    carta = 8;
                    Boton3 = fondo;
                    IsEnabled3 = true;
                    bloqueo3 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick4()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo4 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton4 = botonera[4];
                IsEnabled4 = false;
                carta = 4;
                bloqueo4 = true;
                primero = botonera[4];
                return;
            }
            if (primero != null)
            {


                Boton4 = botonera[4];
                IsEnabled4 = false;
                bloqueo4 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[4])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 4)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[4])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 8;
                    Boton4 = fondo;
                    IsEnabled4 = true;
                    bloqueo4 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick5()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo5 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton5 = botonera[5];
                IsEnabled5 = false;
                carta = 5;
                bloqueo5 = true;
                primero = botonera[5];
                return;
            }
            if (primero != null)
            {


                Boton5 = botonera[5];
                IsEnabled5 = false;
                bloqueo5 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[5])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 4)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[5])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 8;
                    Boton5 = fondo;
                    IsEnabled5 = true;
                    bloqueo5 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick6()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo6 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton6 = botonera[6];
                IsEnabled6 = false;
                carta = 6;
                bloqueo6 = true;
                primero = botonera[6];
                return;
            }
            if (primero != null)
            {


                Boton6 = botonera[6];
                IsEnabled6 = false;
                bloqueo6 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[6])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 4)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[6])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 8;
                    Boton6 = fondo;
                    IsEnabled6 = true;
                    bloqueo6 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick7()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo7 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton7 = botonera[7];
                IsEnabled7 = false;
                carta = 7;
                bloqueo7 = true;
                primero = botonera[7];
                return;
            }
            if (primero != null)
            {


                Boton7 = botonera[7];
                IsEnabled7 = false;
                bloqueo7 = true;
                bloqueoTotal = true;
                await Task.Delay(200);
                bloqueoTotal = false;
                if (primero == botonera[7])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 4)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[7])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 8;
                    Boton7 = fondo;
                    IsEnabled7 = true;
                    bloqueo7 = false;
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
            IsEnabled4 = false;
            IsEnabled5 = false;
            IsEnabled6 = false;
            IsEnabled7 = false;

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
            if (bloqueo4 == false)
            {
                IsEnabled4 = true;
            }
            if (bloqueo5 == false)
            {
                IsEnabled5 = true;
            }
            if (bloqueo6 == false)
            {
                IsEnabled6 = true;
            }
            if (bloqueo7 == false)
            {
                IsEnabled7 = true;
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
                Boton4 = fondo;
                IsEnabled4 = true;
                bloqueo4 = false;
                return;
            }
            if (carta == 5)
            {
                Boton5 = fondo;
                IsEnabled5 = true;
                bloqueo5 = false;
                return;
            }
            if (carta == 6)
            {
                Boton6 = fondo;
                IsEnabled6 = true;
                bloqueo6 = false;
                return;
            }
            if (carta == 7)
            {
                Boton7 = fondo;
                IsEnabled7 = true;
                bloqueo7 = false;
                return;
            }


            if (carta == 8)
            {
                return;
            }
        }

        public async void Reiniciar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoMemoria4x2 = new Juego4x2ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x2Page());

        }




    }
}


