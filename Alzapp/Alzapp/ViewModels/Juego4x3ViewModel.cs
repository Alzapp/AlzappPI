
namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class Juego4x3ViewModel : BaseViewModel
    {
        public string colorReiniciar = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";
        public string CambiarColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";

        public int aciertos = 0;
        public int puntuacion = 0;
        public string ganador = null;
        public string ColorReiniciar
        {
            get => colorReiniciar;
            set => SetValue(ref colorReiniciar, value);
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
        public string boton5;
        public string boton6;
        public string boton7;
        public string boton8;
        public string boton9;
        public string boton10;
        public string boton11;


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
        public string Boton8
        {
            get => boton8;
            set => SetValue(ref boton8, value);
        }
        public string Boton9
        {
            get => boton9;
            set => SetValue(ref boton9, value);
        }
        public string Boton10
        {
            get => boton10;
            set => SetValue(ref boton10, value);
        }
        public string Boton11
        {
            get => boton11;
            set => SetValue(ref boton11, value);
        }



        public bool isEnabled;

        public ICommand ReiniciarCommand => new RelayCommand(Reiniciar);
        public ICommand FacilCommand => new RelayCommand(Facil);
        public ICommand DificilCommand => new RelayCommand(Dificil);
        public ICommand ComprobarCommand0 => new RelayCommand(ComprobarOnClick0);
        public ICommand ComprobarCommand1 => new RelayCommand(ComprobarOnClick1);
        public ICommand ComprobarCommand2 => new RelayCommand(ComprobarOnClick2);
        public ICommand ComprobarCommand3 => new RelayCommand(ComprobarOnClick3);
        public ICommand ComprobarCommand4 => new RelayCommand(ComprobarOnClick4);
        public ICommand ComprobarCommand5 => new RelayCommand(ComprobarOnClick5);
        public ICommand ComprobarCommand6 => new RelayCommand(ComprobarOnClick6);
        public ICommand ComprobarCommand7 => new RelayCommand(ComprobarOnClick7);
        public ICommand ComprobarCommand8 => new RelayCommand(ComprobarOnClick8);
        public ICommand ComprobarCommand9 => new RelayCommand(ComprobarOnClick9);
        public ICommand ComprobarCommand10 => new RelayCommand(ComprobarOnClick10);
        public ICommand ComprobarCommand11 => new RelayCommand(ComprobarOnClick11);
        public ICommand BackCommand => new RelayCommand(Back);


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
        public bool IsEnabled8
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled9
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled10
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public bool IsEnabled11
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
        private readonly string[] botonera = new string[12];
        private string fondo;

        public string var0, var1, var2, var3, var4, var5, var6, var7, var8, var9, var10, var11;
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
        public bool bloqueo8;
        public bool bloqueo9;
        public bool bloqueo10;
        public bool bloqueo11;



        public Juego4x3ViewModel()
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
                "animal4",
                "animal5",
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
            carta = 12;


            IsEnabled = false;

            arrayBarajado = Barajar(12);
            CargarBotones();

            for (int i = 0; i < 12; i++)
            {
                int num = (int)arrayBarajado[i];
                botonera[i] = imagenes[num];
            }

            MostrarImagenes();
            await Task.Delay(3500);
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
            bloqueo8 = true;
            bloqueo9 = true;
            bloqueo10 = true;
            bloqueo11 = true;

            IsEnabled0 = false;
            IsEnabled1 = false;
            IsEnabled2 = false;
            IsEnabled3 = false;
            IsEnabled4 = false;
            IsEnabled5 = false;
            IsEnabled6 = false;
            IsEnabled7 = false;
            IsEnabled8 = false;
            IsEnabled9 = false;
            IsEnabled10 = false;
            IsEnabled11 = false;

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
            bloqueo8 = false;
            bloqueo9 = false;
            bloqueo10 = false;
            bloqueo11 = false;

            IsEnabled0 = true;
            IsEnabled1 = true;
            IsEnabled2 = true;
            IsEnabled3 = true;
            IsEnabled4 = true;
            IsEnabled5 = true;
            IsEnabled6 = true;
            IsEnabled7 = true;
            IsEnabled8 = true;
            IsEnabled9 = true;
            IsEnabled10 = true;
            IsEnabled11 = true;

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
            int n = 12;
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
            var8 = Boton8;
            botonera[8] = var8;
            var9 = Boton9;
            botonera[9] = var9;
            var10 = Boton10;
            botonera[10] = var10;
            var11 = Boton11;
            botonera[11] = var11;


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
            Boton8 = botonera[8];
            Boton9 = botonera[9];
            Boton10 = botonera[10];
            Boton11 = botonera[11];

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
            Boton8 = fondo;
            Boton9 = fondo;
            Boton10 = fondo;
            Boton11 = fondo;

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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[0])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[1])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[2])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[3])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[4])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[5])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[6])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
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
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[7])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
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
                    carta = 12;
                    Boton7 = fondo;
                    IsEnabled7 = true;
                    bloqueo7 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick8()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo8 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton8 = botonera[8];
                IsEnabled8 = false;
                carta = 8;
                bloqueo8 = true;
                primero = botonera[8];
                return;
            }
            if (primero != null)
            {


                Boton8 = botonera[8];
                IsEnabled8 = false;
                bloqueo8 = true;
                bloqueoTotal = true;
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[8])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[8])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 12;
                    Boton8 = fondo;
                    IsEnabled8 = true;
                    bloqueo8 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick9()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo9 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton9 = botonera[9];
                IsEnabled9 = false;
                carta = 9;
                bloqueo9 = true;
                primero = botonera[9];
                return;
            }
            if (primero != null)
            {


                Boton9 = botonera[9];
                IsEnabled9 = false;
                bloqueo9 = true;
                bloqueoTotal = true;
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[9])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[9])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 12;
                    Boton9 = fondo;
                    IsEnabled9 = true;
                    bloqueo9 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick10()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo10 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton10 = botonera[10];
                IsEnabled10 = false;
                carta = 10;
                bloqueo10 = true;
                primero = botonera[10];
                return;
            }
            if (primero != null)
            {


                Boton10 = botonera[10];
                IsEnabled10 = false;
                bloqueo10 = true;
                bloqueoTotal = true;
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[10])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[10])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 12;
                    Boton10 = fondo;
                    IsEnabled10 = true;
                    bloqueo10 = false;
                    primero = null;
                    return;
                }


            }

            return;

        }
        public async void ComprobarOnClick11()
        {
            if (bloqueoTotal == true)
            {
                return;
            }
            if (bloqueo11 == true)
            {
                return;
            }



            if (primero == null)
            {

                Boton11 = botonera[11];
                IsEnabled11 = false;
                carta = 11;
                bloqueo11 = true;
                primero = botonera[11];
                return;
            }
            if (primero != null)
            {


                Boton11 = botonera[11];
                IsEnabled11 = false;
                bloqueo11 = true;
                bloqueoTotal = true;
                await Task.Delay(1800);
                bloqueoTotal = false;
                if (primero == botonera[11])
                {
                    Aciertos++;
                    Puntuacion++;
                    if (Aciertos == 6)
                    {
                        Ganador = "¡FELICITACIONES!";
                        BloqueoBotones();
                        return;
                    }
                    primero = null;
                    return;
                }
                if (primero != botonera[11])
                {
                    Puntuacion--;
                    Desbloqueo();
                    carta = 12;
                    Boton11 = fondo;
                    IsEnabled11 = true;
                    bloqueo11 = false;
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
            IsEnabled8 = false;
            IsEnabled9 = false;
            IsEnabled10 = false;
            IsEnabled11 = false;

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
            if (bloqueo8 == false)
            {
                IsEnabled8 = true;
            }
            if (bloqueo9 == false)
            {
                IsEnabled9 = true;
            }
            if (bloqueo10 == false)
            {
                IsEnabled10 = true;
            }
            if (bloqueo11 == false)
            {
                IsEnabled11 = true;
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
                Boton8 = fondo;
                IsEnabled8 = true;
                bloqueo8 = false;
                return;
            }
            if (carta == 9)
            {
                Boton9 = fondo;
                IsEnabled9 = true;
                bloqueo9 = false;
                return;
            }
            if (carta == 10)
            {
                Boton10 = fondo;
                IsEnabled10 = true;
                bloqueo10 = false;
                return;
            }
            if (carta == 11)
            {
                Boton11 = fondo;
                IsEnabled11 = true;
                bloqueo11 = false;
                return;
            }

            if (carta == 12)
            {
                return;
            }
        }

        public async void Reiniciar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoMemoria4x3 = new Juego4x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x3Page());

        }

        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void Facil()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoMemoria3x2 = new Juego3x2ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria3x2Page());

        }
        public async void Dificil()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoMemoria4x4 = new Juego4x4ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x4Page());

        }

    }
}
