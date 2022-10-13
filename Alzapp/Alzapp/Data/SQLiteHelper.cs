

namespace Alzapp.Data
{
    using Alzapp.Models;
    using SQLite;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SQLiteHelper
    {

        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Persona>().Wait();
            db.CreateTableAsync<Agenda>().Wait();
            db.CreateTableAsync<Foto>().Wait();
            db.CreateTableAsync<Medicamentos>().Wait();

        }

        //Comando para Personas
        public Task<int> SavePersonaAsync(Persona person)
        {
            if (person.Id != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }

        public Task<List<Persona>> GetPersonasAsync()
        {
            return db.Table<Persona>().ToListAsync();
        }

        public Task<Persona> GetPersonaByIdAsync(int id)
        {
            return db.Table<Persona>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersonaAsync(Persona persona)
        {
            return db.DeleteAsync(persona);
        }

        //Comandos para Agenda

        public Task<int> SaveAgendaAsync(Agenda agenda)
        {
            if (agenda.Id != 0)
            {
                return db.UpdateAsync(agenda);
            }
            else
            {
                return db.InsertAsync(agenda);
            }
        }

        public Task<List<Agenda>> GetAgendaAsync()
        {
            return db.Table<Agenda>().ToListAsync();
        }

        public Task<Agenda> GetAgendaByIdAsync(int id)
        {
            return db.Table<Agenda>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> AgendaAsync(Agenda agenda)
        {
            return db.DeleteAsync(agenda);
        }
        public Task<int> DeleteAgendaAsync(Agenda agenda)
        {
            return db.DeleteAsync(agenda);
        }

        //Comandos para Fotos
        public Task<int> SaveFotoAsync(Foto foto)
        {
            if (foto.Id != 0)
            {
                return db.UpdateAsync(foto);
            }
            else
            {
                return db.InsertAsync(foto);
            }
        }

        public Task<List<Foto>> GetFotosAsync()
        {
            return db.Table<Foto>().ToListAsync();
        }

        public Task<Foto> GetFotoByIdAsync(int id)
        {
            return db.Table<Foto>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteFotoAsync(Foto foto)
        {
            return db.DeleteAsync(foto);
        }

        //Comandos para Medicamentos
        public Task<int> SaveMedicamentosAsync(Medicamentos medicamento)
        {
            if (medicamento.Id != 0)
            {
                return db.UpdateAsync(medicamento);
            }
            else
            {
                return db.InsertAsync(medicamento);
            }
        }

        public Task<List<Medicamentos>> GetMedicamentosAsync()
        {
            return db.Table<Medicamentos>().ToListAsync();
        }

        public Task<Medicamentos> GetMedicamentosByIdAsync(int id)
        {
            return db.Table<Medicamentos>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteMedicamentosAsync(Medicamentos medicamento)
        {
            return db.DeleteAsync(medicamento);
        }
        

    }
}
