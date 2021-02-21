using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void deleteArt(int artid)
        {
            ClassContext cc = new ClassContext();
            var d = (from ar in cc.Arts
                     where ar.artid == artid
                     select ar).First();
            cc.Arts.Remove(d);
            cc.SaveChanges();
        }

        public IEnumerable<Art> GetArts()
        {
            List<Art> li = new List<Art>();
            ClassContext cc = new ClassContext();
            li = cc.Arts.ToList<Art>();
            return li;
        }

        public void insertArt(Art aobj)
        {
            ClassContext cc = new ClassContext();
            cc.Arts.Add(aobj);
            cc.SaveChanges();
        }

        public void updateArt(Art aobj)
        {
            ClassContext cc = new ClassContext();
            var a = (from ar in cc.Arts
                     where ar.artid == aobj.artid
                     select ar).First();
            a.content = aobj.content;
            a.title = aobj.title;
            cc.SaveChanges();
        }

        Art IService1.GetArt(int artid)
        {
            ClassContext cc = new ClassContext();
            Console.WriteLine($"{artid}");
            return ((Art)(from ar in cc.Arts
                    where ar.artid == artid
                    select ar).ToList().First());
        }

        IEnumerable<Art> IService1.GetPersonalArts(string name)
        {
            List<Art> li = new List<Art>();
            ClassContext cc = new ClassContext();
            var a = (from ar in cc.Arts
                     where ar.authorname == name
                     select ar);
            li = a.ToList<Art>();
            return li;
        }
    }
}
