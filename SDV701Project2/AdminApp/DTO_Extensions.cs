using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.ServiceReference1
{
    public abstract partial class clsWork
    {

        public static readonly string FACTORY_PROMPT = "Enter P for Painting, S for Sculpture and H for Photograph";

        public static clsWork NewWork(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'P': return new clsPainting();
                case 'S': return new clsSculpture();
                case 'H': return new clsPhotograph();
                default: return null;
            }
        }

        public override string ToString()
        {
            return Name + "\t" + Date.ToShortDateString();
        }
        public abstract void EditDetails();

        public clsWork MapToEntity()
        {
            clsWork lcWorkDTO = GetEntity();
            lcWorkDTO.Name = Name;
            lcWorkDTO.Date = Date;
            lcWorkDTO.Value = Value;
            lcWorkDTO.ArtistName = ArtistName;
            return lcWorkDTO;
        }
        protected abstract clsWork GetEntity();

    }

    public partial class clsPainting
    {
        public delegate void LoadPaintingFormDelegate(clsPainting prPainting);
        public static LoadPaintingFormDelegate LoadPaintingForm;

        public override void EditDetails()
        {
            LoadPaintingForm(this);
        }

        protected override clsWork GetEntity()
        {
            return new clsPainting()
            { Width = this.Width, Height = this.Height, Type = this.Type };
        }
    }

    public partial class clsPhotograph
    {
        public delegate void LoadPhotographFormDelegate(clsPhotograph prPhotograph);
        public static LoadPhotographFormDelegate LoadPhotographForm;

        public override void EditDetails()
        {
            LoadPhotographForm(this);
        }
        protected override clsWork GetEntity()
        {
            return new clsPhotograph
            { Width = this.Width, Height = this.Height, Type = this.Type };
        }
    }
    public partial class clsSculpture
    {
        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        public override void EditDetails()
        {
            LoadSculptureForm(this);
        }
        protected override clsWork GetEntity()
        {
            return new clsSculpture
            { Material = this.Material, Weight = this.Weight };
        }
    }
}
