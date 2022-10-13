// La MainViewModel es la que conecta todo el proyecto y permite hacer el Binding



namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class MainViewModel
    {
        //Apuntador
        private static MainViewModel instance;

        //Controladores
        public PrincipalViewModel Principal { get; set; }

        public ConfiguracionViewModel Configuracion { get; set; }


        //Controladores Persona
        public PersonaViewModel Persona { get; set; }
        public PersonaCuidadorViewModel PersonaCuidador { get; set; }
        public AddPersonaViewModel AddPersona { get; set; }
        public EditPersonaViewModel EditPersona { get; set; }
        public PersonaZoomViewModel PersonaZoom { get; set; }
        //Controladores Agenda
        public AgendaViewModel Agenda { get; set; }
        public AgendaAyerViewModel AgendaAyer { get; set; }
        public AgendaCuidadorViewModel AgendaCuidador { get; set; }
        public AddAgendaViewModel AddAgenda { get; set; }
        public EditAgendaViewModel EditAgenda { get; set; }

        //Controladores Fotos Importantes
        public FotoViewModel Foto { get; set; }
        public InfanciaViewModel Infancia { get; set; }
        public AdolescenciaViewModel Adolescencia { get; set; }
        public AdultezViewModel Adultez { get; set; }
        public PresenteViewModel Presente { get; set; }
        public MomentosEspecialesViewModel MomentosEspeciales { get; set; }
        public FotoCuidadorViewModel FotoCuidador { get; set; }
        public AddFotoViewModel AddFoto { get; set; }
        public EditFotoViewModel EditFoto { get; set; }

        //Controladores Medicamentos

        public MedicamentosViewModel Medicamentos { get; set; }
        public MedicamentosCuidadorViewModel MedicamentosCuidador { get; set; }
        public AddMedicamentosViewModel AddMedicamentos { get; set; }
        public EditMedicamentosViewModel EditMedicamentos { get; set; }


        //Controladores Juego
        public JuegosViewModel Juegos { get; set; }
        public JuegoDeParejasViewModel JuegoDeParejas { get; set; }
        public JuegoDeNumerosViewModel JuegoDeNumeros { get; set; }
        public JuegoNumerosViewModel JuegoNumeros { get; set; }
        public JuegoNumeros3x3ViewModel JuegoNumeros3x3 { get; set; }
        public JuegoNumeros4x3ViewModel JuegoNumeros4x3 { get; set; }
        public JuegoNumeros4x4ViewModel JuegoNumeros4x4 { get; set; }
        public Juego2x2ViewModel JuegoMemoria2x2 { get; set; }
        public Juego3x2ViewModel JuegoMemoria3x2 { get; set; }
        public Juego4x2ViewModel JuegoMemoria4x2 { get; set; }
        public Juego4x3ViewModel JuegoMemoria4x3 { get; set; }
        public Juego4x4ViewModel JuegoMemoria4x4 { get; set; }

        //Controladores SOS
        public SOSViewModel SOS { get; set; }

        public MainViewModel()
        {
            instance = this;
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        
    }
}
