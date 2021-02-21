using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<Art> GetArts();

        [OperationContract]
        void insertArt(Art aobj);

        [OperationContract]
        void updateArt(Art aobj);

        [OperationContract]
        void deleteArt(int artid);

        [OperationContract]
        IEnumerable<Art> GetPersonalArts(string name);

        [OperationContract]
        Art GetArt(int artid);
    }
    [DataContract]
    
    public class Art
    {
        [Key]
        [DataMember]
        public int artid { get; set; }
        [DataMember]
        [Required]
        public string content { get; set; }
        [DataMember]
        [Required]
        public string title { get; set; }
        [DataMember]
        [Required]
        public string authorname { get; set; }
    }
}
