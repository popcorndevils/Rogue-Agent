using Json = Newtonsoft.Json.JsonConvert;
using PichaLib;

namespace Rogue.System
{
    public partial class SysMedia : BaseSys
    {
        public Dictionary<Type, Dictionary<string, object>> Resources = new Dictionary<Type, Dictionary<string, object>>();

        public override void Initialize() 
        {   
            this.Resources[typeof(Canvas)] = new Dictionary<string, object>();

            var _can_dir = new DirectoryInfo(@"./res/templates/");
            foreach(FileInfo f in _can_dir.GetFiles())
            {
                var tname = f.Name.Replace(f.Extension, "");
                this.Resources[typeof(Canvas)][tname] = this.ReadTemplate(f.FullName);
            }
        }

        public T LoadResource<T>(string name) where T : new()
        {
            if(typeof(T) == typeof(Canvas))
            {
                return Json.DeserializeObject<T>((string)(this.Resources[typeof(T)][name]));
            }
            else
            {
                return new T();
            }
        }

        private string ReadTemplate(string path)
        {
            string template;
            using (StreamReader r = new StreamReader(path))
            {
                template = r.ReadToEnd();
            }
            return template;
        }
    }
}