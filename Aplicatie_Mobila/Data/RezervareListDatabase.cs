using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Aplicatie_Mobila.Models;

namespace Aplicatie_Mobila.Data
{
    public class RezervareListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RezervareListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RezervareList>().Wait(); //tabel RezervareList
            _database.CreateTableAsync<Clienti>().Wait();    //tabel Clienti
            _database.CreateTableAsync<ListaRezervari>().Wait();  //tabel ListaRezervari
        }
        public Task<List<RezervareList>> GetRezervareListsAsync()
        {
            return _database.Table<RezervareList>().ToListAsync();
        }
        public Task<RezervareList> GetRezervareListAsync(int id)
        {
            return _database.Table<RezervareList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRezervareListAsync(RezervareList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteRezervareListAsync(RezervareList rlist)
        {
            return _database.DeleteAsync(rlist);
        }

        public Task<int> SaveClientiAsync(Clienti clienti) //detalii rezervare
        {
            if (clienti.ID != 0)
            {
                return _database.UpdateAsync(clienti);
            }
            else
            {
                return _database.InsertAsync(clienti);
            }
        }
        public Task<int> DeleteClientiAsync(Clienti clienti)
        {
            return _database.DeleteAsync(clienti);
        }
        public Task<List<Clienti>> GetClientisAsync()
        {
            return _database.Table<Clienti>().ToListAsync();
        }

        public Task<int> SaveListaRezervariAsync(ListaRezervari listar)
        {
            if (listar.ID != 0)
            {
                return _database.UpdateAsync(listar);
            }
            else
            {
                return _database.InsertAsync(listar);
            }
        }
        public Task<List<Clienti>> GetListaRezervarisAsync(int rezervarelistid)
        {
            return _database.QueryAsync<Clienti>(
            "select C.ID, C.Nr_telefon, C.Nr_persoane from Clienti C"
            + " inner join ListaRezervari LR"
            + " on C.ID = LR.ClientiID where LR.RezervareListID = ?",
            rezervarelistid);
        }
    }
}