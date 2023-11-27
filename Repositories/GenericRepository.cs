
// tek tek her tablo için CRUD işlemi yapmak yerine generic bir tanımlama ile yeni tabloları da ekleyecek bir yapı oluşturduk

using Microsoft.EntityFrameworkCore;
using NurusMES.Data.Models;

namespace NurusMES.Repositories
{
    // aşağıdaki class ona verilecek class ya da methoda göre tüm CRUD işlemlerini uygular
    public class GenericRepository<T> where T : class,new()
    {
        // Db den gelen verileri tutan context nesnesi ürettik

        Context cnt = new Context();

        // Makine sınıfını listelemek için üretilen method
        public List<T> TList()
        {
            return cnt.Set<T>().ToList();
        }

        // Alınan parametreyi ekleyen method
        public void TAdd(T pr)
        {
            cnt.Set<T>().Add(pr);
            cnt.SaveChanges();
        }

        // Alınan parametreyi silen method
        public void TRemove(T pr)
        {
            cnt.Set<T>().Remove(pr);
            cnt.SaveChanges();
        }

        // Alınan parametreyi güncelleyen method
        public void TUpdate(T pr)
        {
            cnt.Set<T>().Update(pr);
            cnt.SaveChanges();
        }

        // Alınan parametreyi bulan method
        public T? TGet(int id)
        {
            return cnt.Set<T>().Find(id);
        }

        // Alınan parametreyi sahip olduğu modele göre döndürür. Personelin ait olduğu birim ve makineyi görmek için kullanılır.
        public List<T> TList(string pr)
        {
            return cnt.Set<T>().Include(pr).ToList();
        }

        
    }
}
