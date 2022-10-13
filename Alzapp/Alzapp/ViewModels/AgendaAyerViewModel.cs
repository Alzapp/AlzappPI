using Alzapp.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class AgendaAyerViewModel : BaseViewModel
    {
        private ObservableCollection<AgendaItemViewModel> agendas;
        private ObservableCollection<AgendaItemViewModel> agendas2;
        private List<Agenda> myAgendas;
        private bool isRefreshing;

        private string seleccionAoM = "";
        private string tocarMTN = "";
        public string actividad = null;
        public string actividad2 = null;
        private bool visibleBotones = false;
        private bool visibleActividad2 = false;
        public string mananaColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))";
        public string tardeColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))";
        public string nocheColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))";
        public string manana2Color = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";
        public string tarde2Color = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";
        public string noche2Color = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";
        private bool visibleMananaColor = false;
        private bool visibleManana2Color = false;
        private bool visibleTardeColor = false;
        private bool visibleTarde2Color = false;
        private bool visibleNocheColor = false;
        private bool visibleNoche2Color = false;

        public string MananaColor
        {
            get => mananaColor;
            set => SetValue(ref mananaColor, value);
        }
        public string Manana2Color
        {
            get => manana2Color;
            set => SetValue(ref manana2Color, value);
        }
        public string TardeColor
        {
            get => tardeColor;
            set => SetValue(ref tardeColor, value);
        }
        public string Tarde2Color
        {
            get => tarde2Color;
            set => SetValue(ref tarde2Color, value);
        }
        public string NocheColor
        {
            get => nocheColor;
            set => SetValue(ref nocheColor, value);
        }
        public string Noche2Color
        {
            get => noche2Color;
            set => SetValue(ref noche2Color, value);
        }
        public bool VisibleBotones
        {
            get => visibleBotones;
            set => SetValue(ref visibleBotones, value);
        }
        public bool VisibleActividad2
        {
            get => visibleActividad2;
            set => SetValue(ref visibleActividad2, value);
        }
        public bool VisibleMananaColor
        {
            get => visibleMananaColor;
            set => SetValue(ref visibleMananaColor, value);
        }
        public bool VisibleManana2Color
        {
            get => visibleManana2Color;
            set => SetValue(ref visibleManana2Color, value);
        }
        public bool VisibleTardeColor
        {
            get => visibleTardeColor;
            set => SetValue(ref visibleTardeColor, value);
        }
        public bool VisibleTarde2Color
        {
            get => visibleTarde2Color;
            set => SetValue(ref visibleTarde2Color, value);
        }
        public bool VisibleNocheColor
        {
            get => visibleNocheColor;
            set => SetValue(ref visibleNocheColor, value);
        }
        public bool VisibleNoche2Color
        {
            get => visibleNoche2Color;
            set => SetValue(ref visibleNoche2Color, value);
        }


        public string Actividad
        {
            get => actividad;
            set => SetValue(ref actividad, value);
        }

        public string Actividad2
        {
            get => actividad2;
            set => SetValue(ref actividad2, value);
        }

        public static DateTime thisDay { get; }
        public static DateTime hour { get; }
        public string DiaSemana { get; }

        public string Hoy { get; }

        public string DiaDeLaSemana { get; set; }
        public string DiaDeAyer { get; set; }
        public string DiaDeManana { get; set; }
        public string Hora { get; set; }

        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand MananaCommand => new RelayCommand(TocoManana);
        public ICommand TardeCommand => new RelayCommand(TocoTarde);

        public ICommand NocheCommand => new RelayCommand(TocoNoche);
        public ICommand AyerCommand => new RelayCommand(SeleccionoAyer);
        public ICommand Manana2Command => new RelayCommand(SeleccionoManana);
        public ICommand Manana3Command => new RelayCommand(MananaAoM);
        public ICommand Tarde2Command => new RelayCommand(TardeAoM);
        public ICommand Noche2Command => new RelayCommand(NocheAoM);

        public ObservableCollection<AgendaItemViewModel> Agendas
        {
            get => agendas;
            set => SetValue(ref agendas, value);
        }
        public ObservableCollection<AgendaItemViewModel> Agendas2
        {
            get => agendas2;
            set => SetValue(ref agendas2, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }

        public AgendaAyerViewModel()
        {
            VisibleBotones = false;
            VisibleActividad2 = false;
            DateTime thisDay = DateTime.Today;
            DateTime hour = DateTime.Now;
            Hora = DateTime.Now.ToString("HH");

            if (thisDay.DayOfWeek == DayOfWeek.Monday)
            {
                DiaSemana = "Hoy es Lunes";
                DiaDeLaSemana = "Lunes";
                DiaDeAyer = "Domingo";
                DiaDeManana = "Martes";

            }
            if (thisDay.DayOfWeek == DayOfWeek.Tuesday)
            {
                DiaSemana = "Hoy es Martes";
                DiaDeLaSemana = "Martes";
                DiaDeAyer = "Lunes";
                DiaDeManana = "Miercoles";
            }
            if (thisDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                DiaSemana = "Hoy es Miercoles";
                DiaDeLaSemana = "Miercoles";
                DiaDeAyer = "Martes";
                DiaDeManana = "Jueves";
            }
            if (thisDay.DayOfWeek == DayOfWeek.Thursday)
            {
                DiaSemana = "Hoy es Jueves";
                DiaDeLaSemana = "Jueves";
                DiaDeAyer = "Miercoles";
                DiaDeManana = "Viernes";
            }
            if (thisDay.DayOfWeek == DayOfWeek.Friday)
            {
                DiaSemana = "Hoy es Viernes";
                DiaDeLaSemana = "Viernes";
                DiaDeAyer = "Jueves";
                DiaDeManana = "Sábado";
            }
            if (thisDay.DayOfWeek == DayOfWeek.Saturday)
            {
                DiaSemana = "Hoy es Sábado";
                DiaDeLaSemana = "Sábado";
                DiaDeAyer = "Viernes";
                DiaDeManana = "Domingo";

            }
            if (thisDay.DayOfWeek == DayOfWeek.Sunday)
            {
                DiaSemana = "Hoy es Domingo";
                DiaDeLaSemana = "Domingo";
                DiaDeAyer = "Sábado";
                DiaDeManana = "Lunes";

            }
            llenarDatos();
        }
        public async void llenarDatos()
        {
            var day = DiaDeLaSemana;
            var horario = Int32.Parse(Hora);
            IsRefreshing = true;
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();


            if (horario >= 00 && horario < 13)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Manana,
                    Actividad2 = null

                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else if (horario >= 13 && horario <= 20)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Tarde,
                    Actividad2 = null

                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else if (horario > 20 && horario <= 24)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Noche,
                    Actividad2 = null
                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else
            {
                return;
            }
        }

        public async void RefreshAgendaList()
        {
            var day = DiaDeLaSemana;
            var horario = Int32.Parse(Hora);
            IsRefreshing = true;
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();


            if (horario >= 00 && horario < 13)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Manana,
                    Actividad2 = null

                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else if (horario >= 13 && horario <= 20)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Tarde,
                    Actividad2 = null

                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else if (horario > 20 && horario <= 24)
            {
                this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                {
                    Id = p.Id,
                    Dia = p.Dia,
                    Manana = p.Manana,
                    Tarde = p.Tarde,
                    Noche = p.Noche,
                    Actividad = p.Noche,
                    Actividad2 = null
                })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
                IsRefreshing = false;
            }
            else
            {
                return;
            }
        }

        public void DeleteAgendaInList(int agendaId)
        {
            var sacarAgenda = this.myAgendas.Where(p => p.Id == agendaId).FirstOrDefault();
            if (sacarAgenda != null)
            {
                this.myAgendas.Remove(sacarAgenda);
            }

            this.RefreshAgendaList();
        }
        public async void TocoManana()
        {
            var day = DiaDeLaSemana;
            var horario = Int32.Parse(Hora);
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
            this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Manana = p.Manana,
                Tarde = p.Tarde,
                Noche = p.Noche,
                Actividad = p.Manana,
                Actividad2 = null
            })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
        }
        public async void TocoTarde()
        {
            var day = DiaDeLaSemana;
            var horario = Int32.Parse(Hora);
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
            this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Manana = p.Manana,
                Tarde = p.Tarde,
                Noche = p.Noche,
                Actividad = p.Tarde,
                Actividad2 = null
            })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
        }
        public async void TocoNoche()
        {
            var day = DiaDeLaSemana;
            var horario = Int32.Parse(Hora);
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
            this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Manana = p.Manana,
                Tarde = p.Tarde,
                Noche = p.Noche,
                Actividad = p.Noche,
                Actividad2 = null
            })
                .OrderBy(p => p.Dia)
                .Where(d => d.Dia == day)
                .ToList());
        }

        public void SeleccionoAyer()
        {
            if (seleccionAoM == "Ayer")
            {
                VisibleActividad2 = false;
                tocarMTN = "";
                seleccionAoM = "";
                VisibleBotones = false;
                return;
            }
            else
            {
                VisibleActividad2 = false;
                seleccionAoM = "Ayer";
                VisibleBotones = true;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                return;
            }
        }
        public void SeleccionoManana()
        {
            if (seleccionAoM == "Mañana")
            {
                VisibleActividad2 = false;
                tocarMTN = "";
                seleccionAoM = "";
                VisibleBotones = false;
                return;
            }
            else
            {
                VisibleActividad2 = false;
                seleccionAoM = "Mañana";
                VisibleBotones = true;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                return;
            }
        }

        public async void MananaAoM()
        {
            if (tocarMTN == "Mañana")
            {
                tocarMTN = "";
                VisibleActividad2 = false;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                return;
            }
            else
            {
                tocarMTN = "Mañana";
                VisibleMananaColor = false;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = true;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                VisibleActividad2 = true;
                if (seleccionAoM == "Mañana")
                {
                    var day = DiaDeManana;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Manana
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                else
                {
                    var day = DiaDeAyer;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Manana
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                return;
            }

        }
        public async void TardeAoM()
        {
            if (tocarMTN == "Tarde")
            {
                tocarMTN = "";
                VisibleActividad2 = false;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                return;
            }
            else
            {
                tocarMTN = "Tarde";

                VisibleMananaColor = true;
                VisibleTardeColor = false;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = true;
                VisibleNoche2Color = false;
                VisibleActividad2 = true;
                if (seleccionAoM == "Mañana")
                {
                    var day = DiaDeManana;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Tarde
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                else
                {
                    var day = DiaDeAyer;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Tarde
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                return;
            }

        }
        public async void NocheAoM()
        {
            if (tocarMTN == "Noche")
            {
                tocarMTN = "";
                VisibleActividad2 = false;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = true;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = false;
                return;
            }
            else
            {
                tocarMTN = "Noche";
                VisibleActividad2 = true;
                VisibleMananaColor = true;
                VisibleTardeColor = true;
                VisibleNocheColor = false;
                VisibleManana2Color = false;
                VisibleTarde2Color = false;
                VisibleNoche2Color = true;
                if (seleccionAoM == "Mañana")
                {
                    var day = DiaDeManana;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Noche
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                else
                {
                    var day = DiaDeAyer;
                    this.myAgendas = await App.SQLiteDB.GetAgendaAsync();
                    this.Agendas2 = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

                    {
                        Id = p.Id,
                        Dia = p.Dia,
                        Manana = p.Manana,
                        Tarde = p.Tarde,
                        Noche = p.Noche,
                        Actividad = null,
                        Actividad2 = p.Noche
                    })
                        .OrderBy(p => p.Dia)
                        .Where(d => d.Dia == day)
                        .ToList());
                }
                return;
            }


        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
//public class AgendaViewModel : BaseViewModel
//{
//    private ObservableCollection<AgendaItemViewModel> agendas;
//    private List<Agenda> myAgendas;
//    private bool isRefreshing;

//    public static DateTime thisDay { get; }
//    public string DiaSemana { get; }

//    public string Hoy { get; }

//    public string DiaDeLaSemana { get; set; }

//    public ObservableCollection<AgendaItemViewModel> Agendas
//    {
//        get => agendas;
//        set => SetValue(ref agendas, value);
//    }
//    public bool IsRefreshing
//    {
//        get => isRefreshing;
//        set => SetValue(ref isRefreshing, value);
//    }

//    public AgendaViewModel()
//    {
//        DateTime thisDay = DateTime.Today;


//        if (thisDay.DayOfWeek == DayOfWeek.Monday)
//        {
//            DiaSemana = "Hoy es Lunes";
//            DiaDeLaSemana = "Lunes";

//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Tuesday)
//        {
//            DiaSemana = "Hoy es Martes";
//            DiaDeLaSemana = "Martes";
//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Wednesday)
//        {
//            DiaSemana = "Hoy es Miercoles";
//            DiaDeLaSemana = "Miercoles";
//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Thursday)
//        {
//            DiaSemana = "Hoy es Jueves";
//            DiaDeLaSemana = "Jueves";
//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Friday)
//        {
//            DiaSemana = "Hoy es Viernes";
//            DiaDeLaSemana = "Viernes";
//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Saturday)
//        {
//            DiaSemana = "Hoy es Sábado";
//            DiaDeLaSemana = "Sábado";

//        }
//        if (thisDay.DayOfWeek == DayOfWeek.Sunday)
//        {
//            DiaSemana = "Hoy es Domingo";
//            DiaDeLaSemana = "Domingo";
//        }
//        llenarDatos();
//    }
//    public async void llenarDatos()
//    {
//        var day = DiaDeLaSemana;
//        IsRefreshing = true;
//        this.myAgendas = await App.SQLiteDB.GetAgendaAsync();

//        this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

//        {
//            Id = p.Id,
//            Dia = p.Dia,
//            Manana = p.Manana,
//            Tarde = p.Tarde,
//            Noche = p.Noche,
//            Actividad = p.Actividad,
//            Actividad2 = p.Actividad2


//        })
//        .OrderBy(p => p.Dia)
//        .Where(d => d.Dia == day)
//        .ToList());
//        IsRefreshing = false;
//    }

//    public async void RefreshAgendaList()
//    {
//        var day = DiaDeLaSemana;
//        myAgendas = await App.SQLiteDB.GetAgendaAsync();
//        this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

//        {
//            Id = p.Id,
//            Dia = p.Dia,
//            Manana = p.Manana,
//            Tarde = p.Tarde,
//            Noche = p.Noche,
//            Actividad = p.Actividad,
//            Actividad2 = p.Actividad2
//        })
//        .OrderBy(p => p.Dia)
//        .Where(d => d.Dia == day)
//        .ToList());
//    }

//    public void DeleteAgendaInList(int agendaId)
//    {
//        var sacarAgenda = this.myAgendas.Where(p => p.Id == agendaId).FirstOrDefault();
//        if (sacarAgenda != null)
//        {
//            this.myAgendas.Remove(sacarAgenda);
//        }

//        this.RefreshAgendaList();
//    }
//}
