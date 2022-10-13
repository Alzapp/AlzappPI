

namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class JuegoNumeros4x3ViewModel : BaseViewModel
    {

        public int aciertos = 0;
        public int puntuacion = 0;
        public string ganador = null;
        public string colorReiniciar = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";
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
        public ICommand FacilCommand => new RelayCommand(Facil);
        public ICommand DificilCommand => new RelayCommand(Dificil);



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

        private string NumeroCorrecto;


        public JuegoNumeros4x3ViewModel()
        {
            fondo = "FondoJuego";
            CargarImagenes();
            Iniciar();
        }

        public void CargarImagenes()
        {
            imagenes = new string[]
            {                
                "numerouno",
                "numerodos",
                "numerotres",
                "numerocuatro",
                "numerocinco",
                "numeroseis",
                "numerosiete",
                "numeroocho",
                "numeronueve",
                "numerodiez",
                "numeroonce",
                "numerodoce"
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

            NumeroCorrecto = "numerouno";
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
            await Task.Delay(7000);
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
                resultadoA.Add(i % longitud);
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
            Boton0 = botonera[0];
            IsEnabled0 = false;
            bloqueo0 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[0] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[0] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton0 = fondo;
                IsEnabled0 = true;
                bloqueo0 = false;
                return;
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
            Boton1 = botonera[1];
            IsEnabled1 = false;
            bloqueo1 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[1] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[1] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton1 = fondo;
                IsEnabled1 = true;
                bloqueo1 = false;
                return;
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
            Boton2 = botonera[2];
            IsEnabled2 = false;
            bloqueo2 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[2] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[2] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton2 = fondo;
                IsEnabled2 = true;
                bloqueo2 = false;
                return;
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
            Boton3 = botonera[3];
            IsEnabled3 = false;
            bloqueo3 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[3] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[3] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton3 = fondo;
                IsEnabled3 = true;
                bloqueo3 = false;
                return;
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
            Boton4 = botonera[4];
            IsEnabled4 = false;
            bloqueo4 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[4] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[4] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton4 = fondo;
                IsEnabled4 = true;
                bloqueo4 = false;
                return;
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
            Boton5 = botonera[5];
            IsEnabled5 = false;
            bloqueo5 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[5] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[5] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton5 = fondo;
                IsEnabled5 = true;
                bloqueo5 = false;
                return;
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
            Boton6 = botonera[6];
            IsEnabled6 = false;
            bloqueo6 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[6] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[6] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton6 = fondo;
                IsEnabled6 = true;
                bloqueo6 = false;
                return;
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
            Boton7 = botonera[7];
            IsEnabled7 = false;
            bloqueo7 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[7] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[7] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton7 = fondo;
                IsEnabled7 = true;
                bloqueo7 = false;
                return;
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
            Boton8 = botonera[8];
            IsEnabled8 = false;
            bloqueo8 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[8] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[8] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton8 = fondo;
                IsEnabled8 = true;
                bloqueo8 = false;
                return;
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
            Boton9 = botonera[9];
            IsEnabled9 = false;
            bloqueo9 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[9] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[9] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton9 = fondo;
                IsEnabled9 = true;
                bloqueo9 = false;
                return;
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
            Boton10 = botonera[10];
            IsEnabled10 = false;
            bloqueo10 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[10] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[10] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton10 = fondo;
                IsEnabled10 = true;
                bloqueo10 = false;
                return;
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
            Boton11 = botonera[11];
            IsEnabled11 = false;
            bloqueo11 = true;
            bloqueoTotal = true;
            await Task.Delay(1000);
            bloqueoTotal = false;
            if (botonera[11] == NumeroCorrecto)
            {
                Aciertos++;
                Puntuacion++;
                if (Aciertos == 12)
                {
                    Ganador = "¡FELICITACIONES!";
                    BloqueoBotones();
                    return;
                }
                SubirNumeroCorrecto();
                return;
            }
            if (botonera[11] != NumeroCorrecto)
            {
                Puntuacion--;
                Desbloqueo();
                carta = 12;
                Boton11 = fondo;
                IsEnabled11 = true;
                bloqueo11 = false;
                return;
            }

            return;

        }




        public void SubirNumeroCorrecto()
        {
            
            if (NumeroCorrecto == "numerouno")
            {
                NumeroCorrecto = "numerodos";
                return;
            }
            if (NumeroCorrecto == "numerodos")
            {
                NumeroCorrecto = "numerotres";
                return;
            }
            if (NumeroCorrecto == "numerotres")
            {
                NumeroCorrecto = "numerocuatro";
                return;
            }
            if (NumeroCorrecto == "numerocuatro")
            {
                NumeroCorrecto = "numerocinco";
                return;
            }
            if (NumeroCorrecto == "numerocinco")
            {
                NumeroCorrecto = "numeroseis";
                return;
            }
            if (NumeroCorrecto == "numeroseis")
            {
                NumeroCorrecto = "numerosiete";
                return;
            }
            if (NumeroCorrecto == "numerosiete")
            {
                NumeroCorrecto = "numeroocho";
                return;
            }
            if (NumeroCorrecto == "numeroocho")
            {
                NumeroCorrecto = "numeronueve";
                return;
            }
            if (NumeroCorrecto == "numeronueve")
            {
                NumeroCorrecto = "numerodiez";
                return;
            }
            if (NumeroCorrecto == "numerodiez")
            {
                NumeroCorrecto = "numeroonce";
                return;
            }
            if (NumeroCorrecto == "numeroonce")
            {
                NumeroCorrecto = "numerodoce";
                return;
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
            MainViewModel.GetInstance().JuegoNumeros4x3 = new JuegoNumeros4x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x3Page());

        }

        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        public async void Facil()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoNumeros3x3 = new JuegoNumeros3x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros3x3Page());

        }
        public async void Dificil()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
            MainViewModel.GetInstance().JuegoNumeros4x4 = new JuegoNumeros4x4ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x4Page());

        }

    }
}
