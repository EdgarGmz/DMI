using System;
using System.Collections.Generic;
using System.Text;
using AppGrabar.Models;
using SQLite;

namespace AppGrabar.Database
{
    public class AppDatabase
    {
        SQLiteAsyncConnection db;

        public AppDatabase(string ruta)
        {
            db = new SQLiteAsyncConnection(ruta);

            db.CreateTableAsync<VideoModel>();
        }

        public Task<List<VideoModel>> ObtenerVideo()
        {
            return db.Table<VideoModel>().ToListAsync();
        }

        public Task<int> GuardarVideo(VideoModel video)
        {
            return db.InsertAsync(video);
        }
    }
}
