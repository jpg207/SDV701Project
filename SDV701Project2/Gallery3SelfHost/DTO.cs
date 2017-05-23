using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3SelfHost.DTO
{
    [DataContract]
    [KnownType(typeof(clsPainting))]
    [KnownType(typeof(clsPhotograph))]
    [KnownType(typeof(clsSculpture))]
    public abstract class clsWork
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Decimal Value { get; set; }
        [DataMember]
        public String ArtistName { get; set; }

        public Work MapToEntity()
        {
            Work lcWork = GetEntity();
            lcWork.Name = this.Name;
            lcWork.Date = this.Date;
            lcWork.Value = this.Value;
            lcWork.ArtistName = this.ArtistName;
            return lcWork;
        }
        protected abstract Work GetEntity();
    }

    [DataContract]
    public class clsPainting : clsWork
    {
        [DataMember]
        public Nullable<float> Width { get; set; }
        [DataMember]
        public Nullable<float> Height { get; set; }
        [DataMember]
        public String Type { get; set; }

        protected override Work GetEntity()
        {
            return new Painting()
            {
                Width = this.Width,
                Height = this.Height,
                Type = this.Type
            };
        }
    }
    [DataContract]
    public class clsPhotograph : clsWork
    {
        [DataMember]
        public Nullable<float> Height { get; set; }
        [DataMember]
        public Nullable<float> Width { get; set; }
        [DataMember]
        public String Type { get; set; }

        protected override Work GetEntity()
        {
            return new Photograph()
            {
                Width = this.Width,
                Height = this.Height,
                Type = this.Type
            };
        }

    }
    [DataContract]
    public class clsSculpture : clsWork
    {
        [DataMember]
        public Nullable<float> Weight { get; set; }
        [DataMember]
        public String Material { get; set; }

        protected override Work GetEntity()
        {
            return new Sculpture()
            {
                Weight = this.Weight,
                Material = this.Material
            };
        }

    }

    [DataContract]
    public class clsArtist
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Speciality { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public ICollection<clsWork> Works { get; set; }

        public Artist MapToEntity()
        {
            return new Artist()
            {
                Name = this.Name,
                Phone = this.Phone,
                Speciality = this.Speciality
            };
        }
    }

}
